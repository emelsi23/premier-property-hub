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

        var databaseUrl = configuration["DATABASE_URL"] ?? Environment.GetEnvironmentVariable("DATABASE_URL");
        if (!string.IsNullOrWhiteSpace(databaseUrl))
        {
            return NormalizePostgresConnectionString(databaseUrl.Trim());
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

        if (databaseUrl.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase)
            || databaseUrl.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
        {
            return AppendPostgresOptions(ParsePostgresUri(databaseUrl));
        }

        return AppendPostgresOptions(databaseUrl);
    }

    private static string ParsePostgresUri(string databaseUrl)
    {
        var schemeEnd = databaseUrl.IndexOf("://", StringComparison.Ordinal);
        if (schemeEnd < 0)
        {
            throw new InvalidOperationException("DATABASE_URL is not a valid PostgreSQL URI.");
        }

        var remainder = databaseUrl[(schemeEnd + 3)..];
        var atIndex = remainder.LastIndexOf('@');
        if (atIndex < 0)
        {
            throw new InvalidOperationException("DATABASE_URL is missing credentials.");
        }

        var userInfo = remainder[..atIndex];
        var hostPart = remainder[(atIndex + 1)..];

        var colonIndex = userInfo.IndexOf(':');
        var username = Uri.UnescapeDataString(colonIndex >= 0 ? userInfo[..colonIndex] : userInfo);
        var password = Uri.UnescapeDataString(colonIndex >= 0 ? userInfo[(colonIndex + 1)..] : string.Empty);

        var slashIndex = hostPart.IndexOf('/');
        var hostPort = slashIndex >= 0 ? hostPart[..slashIndex] : hostPart;
        var database = slashIndex >= 0 ? hostPart[(slashIndex + 1)..] : string.Empty;

        var questionIndex = database.IndexOf('?');
        if (questionIndex >= 0)
        {
            database = database[..questionIndex];
        }

        var port = 5432;
        var host = hostPort;
        var portSeparator = hostPort.LastIndexOf(':');
        if (portSeparator > 0 && int.TryParse(hostPort[(portSeparator + 1)..], out var parsedPort))
        {
            host = hostPort[..portSeparator];
            port = parsedPort;
        }

        return $"Host={host};Port={port};Database={database};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true";
    }

    private static string AppendPostgresOptions(string connectionString)
    {
        if (connectionString.Contains("Gss Encryption Mode=", StringComparison.OrdinalIgnoreCase))
        {
            return connectionString;
        }

        return connectionString.TrimEnd(';') + ";Gss Encryption Mode=Disable";
    }
}
