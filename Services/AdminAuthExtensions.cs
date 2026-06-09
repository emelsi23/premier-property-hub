using Microsoft.AspNetCore.Authentication.Cookies;

namespace ApartamentosRenta.Services;

public static class AdminAuthExtensions
{
    public static IServiceCollection AddAdminAuth(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        services.Configure<AdminAuthSettings>(configuration.GetSection(AdminAuthSettings.SectionName));

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Admin/Login";
                options.AccessDeniedPath = "/Admin/Login";
                options.Cookie.Name = "PremierAdminAuth";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = isDevelopment
                    ? CookieSecurePolicy.SameAsRequest
                    : CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
            });

        services.AddAuthorization();
        return services;
    }

    public static IServiceCollection AddAdminRazorPages(this IServiceCollection services)
    {
        services.AddRazorPages(options =>
        {
            options.Conventions.AuthorizeFolder("/Admin");
            options.Conventions.AllowAnonymousToPage("/Admin/Login");
        });

        return services;
    }
}
