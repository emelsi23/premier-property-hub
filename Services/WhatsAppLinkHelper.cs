namespace ApartamentosRenta.Services;

public static class WhatsAppLinkHelper
{
    public const string DefaultNumber = "19453846408";

    public static string NormalizeNumber(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
        {
            return DefaultNumber;
        }

        var digits = new string(raw.Where(char.IsDigit).ToArray());
        if (digits.Length == 10)
        {
            return "1" + digits;
        }

        return digits.Length >= 11 ? digits : DefaultNumber;
    }

    public static string BuildUrl(string? whatsAppNumber, string message)
    {
        var number = NormalizeNumber(whatsAppNumber);
        return $"https://wa.me/{number}?text={Uri.EscapeDataString(message)}";
    }

    public static string BuildAgentMessage(string propertyTitle, string propertyUrl) =>
        $"Hi, I'm interested in {propertyTitle}. I need help with my visit deposit. Property: {propertyUrl}";

    public static string BuildShareMessage(string propertyTitle, string propertyUrl) =>
        $"Hi, check out this rental on Premier Property Hub: {propertyTitle} — {propertyUrl}";
}
