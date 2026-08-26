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

        // Postgres table may lack IDENTITY on Id (created as plain integer PK). Assign next id explicitly.
        var nextId = await context.ReservaPaymentSettings.MaxAsync(s => (int?)s.Id) ?? 0;
        settings = new ReservaPaymentSettings
        {
            Id = nextId + 1,
            AdminUsername = key
        };
        context.ReservaPaymentSettings.Add(settings);

        try
        {
            await context.SaveChangesAsync();
            return settings;
        }
        catch (DbUpdateException)
        {
            // Concurrent create or unique race — reload.
            context.Entry(settings).State = EntityState.Detached;
            var existing = await context.ReservaPaymentSettings.FirstOrDefaultAsync(s => s.AdminUsername == key);
            if (existing is not null)
            {
                return existing;
            }

            throw;
        }
    }
}
