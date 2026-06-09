using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class ContractTemplateRenderer
{
    public static string Render(string template, Propiedad propiedad)
    {
        if (string.IsNullOrEmpty(template))
        {
            return template;
        }

        var monthly = propiedad.PrecioMensual;
        var securityDeposit = monthly;
        var lateFee = Math.Round(monthly * 0.05m, 0, MidpointRounding.AwayFromZero);
        var visitDeposit = VisitDepositSettings.GetAmount(propiedad);
        var firstMonthTotal = monthly + securityDeposit;
        var moveInTotal = firstMonthTotal + visitDeposit;
        var landlord = string.IsNullOrWhiteSpace(propiedad.ZelleDisplayName)
            ? "Premier Property Hub"
            : propiedad.ZelleDisplayName.Trim();

        var values = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["PropertyTitle"] = propiedad.Titulo,
            ["Address"] = propiedad.Direccion,
            ["City"] = propiedad.Ciudad,
            ["Bedrooms"] = propiedad.Habitaciones.ToString(),
            ["Bathrooms"] = propiedad.Banos.ToString(),
            ["SquareFeet"] = propiedad.MetrosCuadrados.ToString("N0"),
            ["MonthlyRent"] = FormatMoney(monthly),
            ["SecurityDeposit"] = FormatMoney(securityDeposit),
            ["VisitDeposit"] = FormatMoney(visitDeposit),
            ["LateFee"] = FormatMoney(lateFee),
            ["FirstMonthTotal"] = FormatMoney(firstMonthTotal),
            ["MoveInTotal"] = FormatMoney(moveInTotal),
            ["ZelleName"] = landlord,
            ["ZelleContact"] = string.IsNullOrWhiteSpace(propiedad.ZelleContact) ? "—" : propiedad.ZelleContact,
            ["LandlordName"] = landlord
        };

        var result = template;
        foreach (var (key, value) in values)
        {
            result = result.Replace($"{{{{{key}}}}}", value, StringComparison.Ordinal);
        }

        return result;
    }

    private static string FormatMoney(decimal amount) =>
        "$" + amount.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
}
