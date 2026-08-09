namespace ApartamentosRenta.Services;

public static class WhatsAppLinkHelper
{
    public const string DefaultNumber = "19453846408";

    public static string? TryNormalizeNumber(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
        {
            return null;
        }

        var digits = new string(raw.Where(char.IsDigit).ToArray());
        if (digits.Length == 10)
        {
            return "1" + digits;
        }

        return digits.Length >= 11 ? digits : null;
    }

    public static string NormalizeNumber(string? raw) =>
        TryNormalizeNumber(raw) ?? DefaultNumber;

    /// WhatsApp del agente: número personal; ignora el default del sitio si hay teléfono propio.
    public static string? ResolveAgentContactNumber(string? whatsAppNumber, string? telefono)
    {
        var fromWhatsApp = TryNormalizeNumber(whatsAppNumber);
        var fromTelefono = TryNormalizeNumber(telefono);

        if (fromWhatsApp is not null && fromWhatsApp != DefaultNumber)
        {
            return fromWhatsApp;
        }

        if (fromTelefono is not null && fromTelefono != DefaultNumber)
        {
            return fromTelefono;
        }

        return fromWhatsApp ?? fromTelefono;
    }

    public static string? BuildAgentContactUrl(string? whatsAppNumber, string? telefono, string message)
    {
        var number = ResolveAgentContactNumber(whatsAppNumber, telefono);
        if (number is null)
        {
            return null;
        }

        return $"https://wa.me/{number}?text={Uri.EscapeDataString(message)}";
    }

    public static bool UsesSiteDefaultNumber(string? whatsAppNumber) =>
        TryNormalizeNumber(whatsAppNumber) == DefaultNumber;

    public static string BuildUrl(string? whatsAppNumber, string message)
    {
        var number = NormalizeNumber(whatsAppNumber);
        return $"https://wa.me/{number}?text={Uri.EscapeDataString(message)}";
    }

    public static string BuildAgentMessage(string propertyTitle, string propertyUrl) =>
        $"Hola, me interesa {propertyTitle}. Necesito ayuda con el depósito de visita. Propiedad: {propertyUrl}";

    public static string BuildShareMessage(string propertyTitle, string propertyUrl) =>
        $"Hola, mira este alquiler en Premier Property Hub: {propertyTitle} — {propertyUrl}";
}
