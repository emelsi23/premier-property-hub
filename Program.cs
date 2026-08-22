using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
QuestPDF.Settings.License = LicenseType.Community;

if (args.Contains("--generate-pdfs", StringComparer.OrdinalIgnoreCase))
{
    var webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
    RemaxBrandedPdfDocuments.WriteToWebRoot(webRoot);
    var docs = Path.Combine(webRoot, "documentos");
    Console.WriteLine($"PDFs generados en {docs}");
    return;
}

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

builder.Services.AddScoped<PropertyPhotoUploadService>();
builder.Services.AddScoped<AgentPhotoUploadService>();
SiteCulture.Configure(builder.Services);
builder.Services.AddAdminRazorPages();
builder.Services.AddAppDatabase(builder.Configuration);
builder.Services.AddAdminAuth(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddAppEmail(builder.Configuration);
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
app.UseRequestLocalization();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/rentals"));
app.MapGet("/rentals", () => Results.Redirect("/Apartamentos/Index"));
app.MapGet("/listings", () => Results.Redirect("/Apartamentos/Index"));
app.MapGet("/contract", () => Results.Redirect("/Admin/Index"));
app.MapGet("/casa/{slug}", (string slug) => Results.Redirect($"/property/{slug}", permanent: true));
app.MapGet("/casa/{slug}/gracias", (string slug) => Results.Redirect($"/property/{slug}/thank-you", permanent: true));
app.MapGet("/Admin/Citas/{**path}", () => Results.Redirect("/Admin/Appointments", permanent: true));

app.MapGet("/agent/{slug}", (string slug) => Results.Redirect($"/agente/{slug}", permanent: false));

app.MapGet("/api/agentes/{slug}", async (string slug, AppDbContext db, HttpContext http) =>
{
    var agente = await db.Agentes.AsNoTracking()
        .FirstOrDefaultAsync(a => a.Slug == slug && a.Activo);

    if (agente is null)
    {
        return Results.NotFound(new { error = "Agente no encontrado." });
    }

    var baseUrl = $"{http.Request.Scheme}://{http.Request.Host}";
    return Results.Json(AgenteApiResponse.From(agente, baseUrl));
});

app.MapGet("/documentos/Protocolo-Reserva-PREMAX.pdf", () =>
    Results.File(
        RemaxBrandedPdfDocuments.GenerateProtocoloReserva(),
        "application/pdf",
        "Protocolo-Reserva-PREMAX.pdf"));

app.MapGet("/documentos/Pago-Efectivo-Barcode-PREMAX.pdf", () =>
    Results.File(
        RemaxBrandedPdfDocuments.GeneratePagoEfectivoBarcode(),
        "application/pdf",
        "Pago-Efectivo-Barcode-PREMAX.pdf"));

app.MapGet("/documentos/protocolo-reserva", () =>
    Results.Redirect("/documentos/Protocolo-Reserva-PREMAX.pdf"));

app.MapGet("/documentos/pago-efectivo", () =>
    Results.Redirect("/documentos/Pago-Efectivo-Barcode-PREMAX.pdf"));

app.MapRazorPages();

await InitializeDatabaseAsync(app.Services);

RemaxBrandedPdfDocuments.WriteToWebRoot(app.Environment.WebRootPath);

app.Run();

static async Task InitializeDatabaseAsync(IServiceProvider services)
{
    const int maxAttempts = 30;

    for (var attempt = 1; attempt <= maxAttempts; attempt++)
    {
        try
        {
            await using var scope = services.CreateAsyncScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();
            await DbSeeder.SeedAsync(db);
            await PropertyCatalogSeedHelper.EnsureCatalogPropertiesAsync(db);
            await LeaseContractSeedHelper.EnsureForAllPropertiesAsync(db);
            await StampSealSeedHelper.EnsureForAllPropertiesAsync(db);
            await ContractSpanishLocalizationHelper.ApplySpanishDefaultsIfLegacyEnglishAsync(db);
            await AgentSeedHelper.EnsureSampleAgentAsync(db);
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
