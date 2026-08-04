using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ApartamentosRenta.Data;

public static class DatabaseExtensions
{
    public static IServiceCollection AddAppDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = ResolveConnectionString(configuration);

        services.AddDbContext<AppDbContext>(options =>
        {
            options.ConfigureWarnings(w =>
                w.Ignore(RelationalEventId.PendingModelChangesWarning));

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
            return NormalizePostgresConnectionString(databaseUrl);
        }

        var pgHost = configuration["PGHOST"] ?? Environment.GetEnvironmentVariable("PGHOST");
        if (!string.IsNullOrWhiteSpace(pgHost))
        {
            var pgPort = configuration["PGPORT"] ?? Environment.GetEnvironmentVariable("PGPORT") ?? "5432";
            var pgUser = configuration["PGUSER"] ?? Environment.GetEnvironmentVariable("PGUSER") ?? "";
            var pgPassword = configuration["PGPASSWORD"] ?? Environment.GetEnvironmentVariable("PGPASSWORD") ?? "";
            var pgDatabase = configuration["PGDATABASE"] ?? Environment.GetEnvironmentVariable("PGDATABASE") ?? "";

            return AppendPostgresOptions(
                $"Host={pgHost};Port={pgPort};Database={pgDatabase};Username={pgUser};Password={pgPassword};SSL Mode=Require;Trust Server Certificate=true");
        }

        return configuration.GetConnectionString("DefaultConnection")
            ?? "Data Source=apartamentos.db";
    }

    private static bool IsPostgreSql(string connectionString) =>
        connectionString.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase)
        || connectionString.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase)
        || connectionString.Contains("Host=", StringComparison.OrdinalIgnoreCase)
        || (connectionString.Contains("Server=", StringComparison.OrdinalIgnoreCase)
            && connectionString.Contains("Username=", StringComparison.OrdinalIgnoreCase));

    private static string NormalizePostgresConnectionString(string databaseUrl)
    {
        if (databaseUrl.StartsWith("Host=", StringComparison.OrdinalIgnoreCase)
            || databaseUrl.StartsWith("Server=", StringComparison.OrdinalIgnoreCase))
        {
            return AppendPostgresOptions(databaseUrl);
        }

        // Npgsql parses postgres:// URIs correctly, including encoded passwords.
        // Manual Uri parsing breaks Render URLs when passwords contain @, /, etc.
        if (databaseUrl.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase)
            || databaseUrl.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
        {
            return databaseUrl;
        }

        return AppendPostgresOptions(databaseUrl);
    }

    private static string AppendPostgresOptions(string connectionString)
    {
        if (connectionString.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase)
            || connectionString.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
        {
            return connectionString;
        }

        if (connectionString.Contains("Gss Encryption Mode=", StringComparison.OrdinalIgnoreCase))
        {
            return connectionString;
        }

        return connectionString.TrimEnd(';') + ";Gss Encryption Mode=Disable";
    }
}
