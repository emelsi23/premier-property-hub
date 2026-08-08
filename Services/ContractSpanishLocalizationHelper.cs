using ApartamentosRenta.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class ContractSpanishLocalizationHelper
{
    private const string LegacyLeaseTitle = "Residential Lease Agreement";
    private const string LegacyStampTitle = "Stamps & Seals Purchase Agreement";

    public static async Task ApplySpanishDefaultsIfLegacyEnglishAsync(AppDbContext context)
    {
        var leases = await context.LeaseContracts
            .Where(c => c.Title == LegacyLeaseTitle)
            .ToListAsync();

        foreach (var contract in leases)
        {
            contract.Title = "Contrato de arrendamiento residencial";
            contract.Subtitle = "Alquiler de apartamento · Estados Unidos";
            contract.NoticeHtml = LeaseContractDefaults.NoticeHtml;
            contract.BodyHtml = LeaseContractDefaults.BodyHtml;
            contract.UpdatedAt = DateTime.UtcNow;
        }

        var stampContracts = await context.StampSealContracts
            .Where(c => c.Title == LegacyStampTitle)
            .ToListAsync();

        foreach (var contract in stampContracts)
        {
            contract.Title = "Acuerdo de compra de estampillas y sellos";
            contract.Subtitle = "Documentación oficial · Estados Unidos";
            contract.NoticeHtml = StampSealContractDefaults.NoticeHtml;
            contract.BodyHtml = StampSealContractDefaults.BodyHtml;
            contract.UpdatedAt = DateTime.UtcNow;
        }

        if (leases.Count > 0 || stampContracts.Count > 0)
        {
            await context.SaveChangesAsync();
            Console.WriteLine($"Contratos actualizados a español: {leases.Count} arrendamiento(s), {stampContracts.Count} estampillas/sellos.");
        }
    }
}
