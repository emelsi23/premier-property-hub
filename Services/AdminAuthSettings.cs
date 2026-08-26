namespace ApartamentosRenta.Services;

public class AdminAuthSettings
{
    public const string SectionName = "AdminAuth";

    /// <summary>Legacy single-user fields (still honored if Users is empty).</summary>
    public string Username { get; set; } = "admin000";

    public string Password { get; set; } = "Admin000";

    public List<AdminUserAccount> Users { get; set; } = [];
}

public class AdminUserAccount
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    /// <summary>Public URL segment for /reserva/{slug}, e.g. maria-angelica.</summary>
    public string PublicSlug { get; set; } = string.Empty;

    public string EffectiveDisplayName =>
        string.IsNullOrWhiteSpace(DisplayName) ? Username : DisplayName.Trim();

    public string EffectivePublicSlug
    {
        get
        {
            var slug = AdminUsers.Slugify(PublicSlug);
            if (!string.IsNullOrEmpty(slug))
            {
                return slug;
            }

            slug = AdminUsers.Slugify(DisplayName);
            return string.IsNullOrEmpty(slug) ? AdminUsers.Normalize(Username) : slug;
        }
    }
}

public static class AdminUsers
{
    public static string Normalize(string? username) =>
        (username ?? string.Empty).Trim().ToLowerInvariant();

    public static string Slugify(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        var normalized = value.Trim().ToLowerInvariant();
        var chars = normalized
            .Select(ch => char.IsLetterOrDigit(ch) ? ch : '-')
            .ToArray();
        var slug = new string(chars);
        while (slug.Contains("--", StringComparison.Ordinal))
        {
            slug = slug.Replace("--", "-", StringComparison.Ordinal);
        }

        return slug.Trim('-');
    }

    public static IReadOnlyList<AdminUserAccount> Resolve(AdminAuthSettings settings)
    {
        if (settings.Users is { Count: > 0 })
        {
            return settings.Users
                .Where(u => !string.IsNullOrWhiteSpace(u.Username) && !string.IsNullOrWhiteSpace(u.Password))
                .Select(u => new AdminUserAccount
                {
                    Username = Normalize(u.Username),
                    Password = u.Password,
                    DisplayName = string.IsNullOrWhiteSpace(u.DisplayName) ? Normalize(u.Username) : u.DisplayName.Trim(),
                    PublicSlug = string.IsNullOrWhiteSpace(u.PublicSlug) ? string.Empty : Slugify(u.PublicSlug)
                })
                .GroupBy(u => u.Username)
                .Select(g => g.First())
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(settings.Username) && !string.IsNullOrWhiteSpace(settings.Password))
        {
            return
            [
                new AdminUserAccount
                {
                    Username = Normalize(settings.Username),
                    Password = settings.Password,
                    DisplayName = Normalize(settings.Username),
                    PublicSlug = Normalize(settings.Username)
                }
            ];
        }

        return [];
    }

    public static AdminUserAccount? FindByUsername(AdminAuthSettings settings, string? username)
    {
        var key = Normalize(username);
        if (string.IsNullOrEmpty(key))
        {
            return null;
        }

        return Resolve(settings).FirstOrDefault(u => u.Username == key);
    }

    /// <summary>Resolve by public URL slug or legacy login username.</summary>
    public static AdminUserAccount? FindByPublicAgent(AdminAuthSettings settings, string? agent)
    {
        var key = Slugify(agent);
        if (string.IsNullOrEmpty(key))
        {
            key = Normalize(agent);
        }

        if (string.IsNullOrEmpty(key))
        {
            return null;
        }

        return Resolve(settings).FirstOrDefault(u =>
            u.EffectivePublicSlug == key || u.Username == key);
    }

    public static bool TryAuthenticate(AdminAuthSettings settings, string? username, string? password, out AdminUserAccount? user)
    {
        user = FindByUsername(settings, username);
        if (user is null || string.IsNullOrEmpty(password))
        {
            return false;
        }

        return string.Equals(user.Password, password, StringComparison.Ordinal);
    }

    public static string CurrentUsername(System.Security.Claims.ClaimsPrincipal user) =>
        Normalize(user.Identity?.Name);

    public static string CurrentPublicSlug(System.Security.Claims.ClaimsPrincipal user, AdminAuthSettings settings)
    {
        var claim = user.FindFirst("public_slug")?.Value;
        if (!string.IsNullOrWhiteSpace(claim))
        {
            return Slugify(claim);
        }

        var account = FindByUsername(settings, CurrentUsername(user));
        return account?.EffectivePublicSlug ?? CurrentUsername(user);
    }

    public static string BuildReservaUrl(string scheme, HostString host, string publicSlug) =>
        $"{scheme}://{host}/reserva/{Slugify(publicSlug)}";
}
