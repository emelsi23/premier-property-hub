using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class LeaseContractSeedHelper
{
    public static async Task EnsureForAllPropertiesAsync(AppDbContext context)
    {
        var missing = await context.Propiedades
            .Include(p => p.LeaseContract)
            .Where(p => p.LeaseContract == null)
            .ToListAsync();

        foreach (var propiedad in missing)
        {
            context.LeaseContracts.Add(LeaseContractDefaults.CreateForProperty(propiedad.Id));
        }

        if (missing.Count > 0)
        {
            await context.SaveChangesAsync();
        }
    }
}
