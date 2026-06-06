using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Data;

public static class DatabaseExtensions
{
    public static IServiceCollection AddAppDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = ResolveConnectionString(configuration);

        services.AddDbContext<AppDbContext>(options =>
        {
            if (IsPostgreSql(connectionString))
            {
                options.UseNpgsql(connectionString);
            }
            else
            {
                options.UseSqlite(connectionString);
            }
        });

        return services;
    }

    public static string ResolveConnectionString(IConfiguration configuration)
    {
        var databaseUrl = configuration["DATABASE_URL"] ?? Environment.GetEnvironmentVariable("DATABASE_URL");
        if (!string.IsNullOrWhiteSpace(databaseUrl))
        {
            return ParseDatabaseUrl(databaseUrl);
        }

        return configuration.GetConnectionString("DefaultConnection")
            ?? "Data Source=apartamentos.db";
    }

    private static bool IsPostgreSql(string connectionString) =>
        connectionString.Contains("Host=", StringComparison.OrdinalIgnoreCase)
        || connectionString.Contains("Server=", StringComparison.OrdinalIgnoreCase)
        && connectionString.Contains("Username=", StringComparison.OrdinalIgnoreCase);

    private static string ParseDatabaseUrl(string databaseUrl)
    {
        if (databaseUrl.StartsWith("Host=", StringComparison.OrdinalIgnoreCase)
            || databaseUrl.StartsWith("Server=", StringComparison.OrdinalIgnoreCase))
        {
            return databaseUrl;
        }

        var uri = new Uri(databaseUrl);
        var userInfo = uri.UserInfo.Split(':', 2);
        var username = Uri.UnescapeDataString(userInfo[0]);
        var password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : string.Empty;
        var database = uri.AbsolutePath.TrimStart('/');
        var port = uri.Port > 0 ? uri.Port : 5432;

        return $"Host={uri.Host};Port={port};Database={database};Username={username};Password={password};SSL Mode=Prefer;Trust Server Certificate=true";
    }
}
