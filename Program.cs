using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 6 * 1024 * 1024;
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 6 * 1024 * 1024;
});

builder.Services.AddAdminRazorPages();
builder.Services.AddAppDatabase(builder.Configuration);
builder.Services.AddAdminAuth(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "RequestVerificationToken";
    options.Cookie.SecurePolicy = builder.Environment.IsDevelopment()
        ? CookieSecurePolicy.SameAsRequest
        : CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    var forwardedHeaders = new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    };
    forwardedHeaders.KnownNetworks.Clear();
    forwardedHeaders.KnownProxies.Clear();
    app.UseForwardedHeaders(forwardedHeaders);
}

app.MapGet("/health", () => Results.Ok("healthy"));

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/Admin/Login"));
app.MapGet("/contract", () => Results.Redirect("/Admin/Index"));
app.MapGet("/casa/{slug}", (string slug) => Results.Redirect($"/property/{slug}", permanent: true));
app.MapGet("/casa/{slug}/gracias", (string slug) => Results.Redirect($"/property/{slug}/thank-you", permanent: true));
app.MapGet("/Admin/Citas/{**path}", () => Results.Redirect("/Admin/Appointments", permanent: true));

app.MapRazorPages();

await InitializeDatabaseAsync(app.Services);

app.Run();

static async Task InitializeDatabaseAsync(IServiceProvider services)
{
    const int maxAttempts = 12;

    for (var attempt = 1; attempt <= maxAttempts; attempt++)
    {
        try
        {
            await using var scope = services.CreateAsyncScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();
            await DbSeeder.SeedAsync(db);
            await LeaseContractSeedHelper.EnsureForAllPropertiesAsync(db);
            await StampSealSeedHelper.EnsureForAllPropertiesAsync(db);
            Console.WriteLine("Database initialized successfully.");
            return;
        }
        catch (Exception ex) when (attempt < maxAttempts)
        {
            var detail = ex.InnerException?.Message ?? ex.ToString();
            Console.WriteLine($"Database init attempt {attempt} failed: {ex.Message} | {detail}. Retrying in 5s...");
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }

    throw new InvalidOperationException("Could not initialize the database after multiple attempts.");
}
