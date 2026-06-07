using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class StampSealSettings
{
    public const decimal StampsAmount = 245m;
    public const decimal SealsAmount = 245m;
    public const decimal TotalAmount = StampsAmount + SealsAmount;

    public static decimal GetAmount(StampSealPurchaseOption option) => option switch
    {
        StampSealPurchaseOption.Stamps => StampsAmount,
        StampSealPurchaseOption.Seals => SealsAmount,
        StampSealPurchaseOption.Both => TotalAmount,
        _ => TotalAmount
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
