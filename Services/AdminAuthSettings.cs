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

    public string NormalizedUsername => AdminUsers.Normalize(Username);

    public string EffectiveDisplayName =>
        string.IsNullOrWhiteSpace(DisplayName) ? Username : DisplayName.Trim();
}

public static class AdminUsers
{
    public static string Normalize(string? username) =>
        (username ?? string.Empty).Trim().ToLowerInvariant();

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
                    DisplayName = string.IsNullOrWhiteSpace(u.DisplayName) ? Normalize(u.Username) : u.DisplayName.Trim()
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
                    DisplayName = Normalize(settings.Username)
                }
            ];
        }

        return [];
    }

    public static AdminUserAccount? Find(AdminAuthSettings settings, string? username)
    {
        var key = Normalize(username);
        if (string.IsNullOrEmpty(key))
        {
            return null;
        }

        return Resolve(settings).FirstOrDefault(u => u.Username == key);
    }

    public static bool TryAuthenticate(AdminAuthSettings settings, string? username, string? password, out AdminUserAccount? user)
    {
        user = Find(settings, username);
        if (user is null || string.IsNullOrEmpty(password))
        {
            return false;
        }

        return string.Equals(user.Password, password, StringComparison.Ordinal);
    }

    public static string CurrentUsername(System.Security.Claims.ClaimsPrincipal user) =>
        Normalize(user.Identity?.Name);
}
