using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class StampSealSeedHelper
{
    public static async Task EnsureForAllPropertiesAsync(AppDbContext context)
    {
        var missing = await context.Propiedades
            .Include(p => p.StampSealContract)
            .Where(p => p.StampSealContract == null)
            .ToListAsync();

        foreach (var propiedad in missing)
        {
            context.StampSealContracts.Add(StampSealContractDefaults.CreateForProperty(propiedad.Id));
        }

        if (missing.Count > 0)
        {
            await context.SaveChangesAsync();
        }
    }
}
