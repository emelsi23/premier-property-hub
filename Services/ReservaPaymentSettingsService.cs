using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class ReservaPaymentSettingsService
{
    public static async Task<ReservaPaymentSettings> GetOrCreateAsync(AppDbContext context, string adminUsername)
    {
        var key = AdminUsers.Normalize(adminUsername);
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Admin username is required.", nameof(adminUsername));
        }

        var settings = await context.ReservaPaymentSettings.FirstOrDefaultAsync(s => s.AdminUsername == key);
        if (settings is not null)
        {
            return settings;
        }

        settings = new ReservaPaymentSettings { AdminUsername = key };
        context.ReservaPaymentSettings.Add(settings);
        await context.SaveChangesAsync();
        return settings;
    }
}
