using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class StampSealSettings
{
    public const decimal DefaultStampsAmount = 245m;
    public const decimal DefaultSealsAmount = 245m;

    public static decimal GetStampsAmount(Propiedad propiedad) =>
        propiedad.StampsAmount > 0 ? propiedad.StampsAmount : DefaultStampsAmount;

    public static decimal GetSealsAmount(Propiedad propiedad) =>
        propiedad.SealsAmount > 0 ? propiedad.SealsAmount : DefaultSealsAmount;

    public static decimal GetTotalAmount(Propiedad propiedad) =>
        GetStampsAmount(propiedad) + GetSealsAmount(propiedad);

    public static decimal GetAmount(Propiedad propiedad, StampSealPurchaseOption option) => option switch
    {
        StampSealPurchaseOption.Stamps => GetStampsAmount(propiedad),
        StampSealPurchaseOption.Seals => GetSealsAmount(propiedad),
        StampSealPurchaseOption.Both => GetTotalAmount(propiedad),
        _ => GetTotalAmount(propiedad)
    };

    public static string GetLabel(StampSealPurchaseOption option) => option switch
    {
        StampSealPurchaseOption.Stamps => "Stamps only",
        StampSealPurchaseOption.Seals => "Seals only",
        StampSealPurchaseOption.Both => "Stamps & seals",
        _ => "Stamps & seals"
    };

    public static bool TryParseOption(string? value, out StampSealPurchaseOption option)
    {
        option = StampSealPurchaseOption.Both;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        return Enum.TryParse(value.Trim(), ignoreCase: true, out option);
    }
}
