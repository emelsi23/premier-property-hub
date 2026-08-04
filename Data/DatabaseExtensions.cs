using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;

namespace ApartamentosRenta.Data;

public static class DatabaseExtensions
{
    public static IServiceCollection AddAppDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = ResolveConnectionString(configuration);
        Console.WriteLine($"Database target: {DescribeConnection(connectionString)}");

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
        var databaseUrl = SanitizeEnvValue(
            configuration["DATABASE_URL"] ?? Environment.GetEnvironmentVariable("DATABASE_URL"));
        if (!string.IsNullOrWhiteSpace(databaseUrl))
        {
            return NormalizePostgresConnectionString(databaseUrl);
        }

        var pgHost = SanitizeEnvValue(configuration["PGHOST"] ?? Environment.GetEnvironmentVariable("PGHOST"));
        if (!string.IsNullOrWhiteSpace(pgHost))
        {
            var pgPort = SanitizeEnvValue(configuration["PGPORT"] ?? Environment.GetEnvironmentVariable("PGPORT")) ?? "5432";
            var pgUser = SanitizeEnvValue(configuration["PGUSER"] ?? Environment.GetEnvironmentVariable("PGUSER")) ?? "";
            var pgPassword = SanitizeEnvValue(configuration["PGPASSWORD"] ?? Environment.GetEnvironmentVariable("PGPASSWORD")) ?? "";
            var pgDatabase = SanitizeEnvValue(configuration["PGDATABASE"] ?? Environment.GetEnvironmentVariable("PGDATABASE")) ?? "";

            return BuildPostgresConnectionString(pgHost, int.Parse(pgPort), pgDatabase, pgUser, pgPassword);
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
            return databaseUrl;
        }

        if (databaseUrl.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase)
            || databaseUrl.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
        {
            return ParsePostgresUri(databaseUrl);
        }

        throw new InvalidOperationException(
            "DATABASE_URL must be a postgres:// URI or Host= connection string.");
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

        return BuildPostgresConnectionString(host, port, database, username, password);
    }

    private static string BuildPostgresConnectionString(
        string host, int port, string database, string username, string password)
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = host,
            Port = port,
            Database = database,
            Username = username,
            Password = password,
            SslMode = SslMode.Require,
            GssEncryptionMode = GssEncryptionMode.Disable
        };

        return builder.ConnectionString;
    }

    private static string SanitizeEnvValue(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        value = value.Trim().Trim('"', '\'');

        if (value.StartsWith("${", StringComparison.Ordinal))
        {
            throw new InvalidOperationException(
                "DATABASE_URL looks like an unresolved template. Link the database from Render Environment settings.");
        }

        return value;
    }

    private static string DescribeConnection(string connectionString)
    {
        if (connectionString.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
        {
            return "SQLite (local)";
        }

        try
        {
            var builder = new NpgsqlConnectionStringBuilder(connectionString);
            return $"PostgreSQL host={builder.Host}; database={builder.Database}";
        }
        catch
        {
            return "PostgreSQL (invalid connection string format)";
        }
    }
}
