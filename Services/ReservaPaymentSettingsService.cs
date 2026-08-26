using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class ReservaPaymentSettingsService
{
    public static async Task<ReservaPaymentSettings> GetOrCreateAsync(AppDbContext context)
    {
        var settings = await context.ReservaPaymentSettings.FirstOrDefaultAsync(s => s.Id == 1);
        if (settings is not null)
        {
            return settings;
        }

        settings = new ReservaPaymentSettings { Id = 1 };
        context.ReservaPaymentSettings.Add(settings);
        await context.SaveChangesAsync();
        return settings;
    }
}
