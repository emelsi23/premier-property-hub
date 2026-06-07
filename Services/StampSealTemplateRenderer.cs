using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class StampSealTemplateRenderer
{
    public static string Render(string template, Propiedad propiedad)
    {
        if (string.IsNullOrEmpty(template))
        {
            return template;
        }

        var landlord = string.IsNullOrWhiteSpace(propiedad.ZelleDisplayName)
            ? "Premier Property Hub"
            : propiedad.ZelleDisplayName.Trim();

        var values = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["PropertyTitle"] = propiedad.Titulo,
            ["Address"] = propiedad.Direccion,
            ["City"] = propiedad.Ciudad,
            ["MonthlyRent"] = FormatMoney(propiedad.PrecioMensual),
            ["StampsAmount"] = FormatMoney(StampSealSettings.StampsAmount),
            ["SealsAmount"] = FormatMoney(StampSealSettings.SealsAmount),
            ["TotalAmount"] = FormatMoney(StampSealSettings.TotalAmount),
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
