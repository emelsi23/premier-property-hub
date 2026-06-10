namespace ApartamentosRenta.Services;

public static class WhatsAppLinkHelper
{
    public const string DefaultAgentPhone = "19453846408";

    public static string NormalizePhone(string? phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            return DefaultAgentPhone;
        }

        var digits = new string(phone.Where(char.IsDigit).ToArray());
        if (digits.Length == 0)
        {
            return DefaultAgentPhone;
        }

        if (digits.Length == 10)
        {
            return "1" + digits;
        }

        return digits;
    }

    public static string FormatDisplay(string? phone)
    {
        var digits = NormalizePhone(phone);
        if (digits.Length == 11 && digits.StartsWith('1'))
        {
            return $"+1 ({digits[1..4]}) {digits[4..7]}-{digits[7..11]}";
        }

        return phone?.Trim() ?? string.Empty;
    }

    public static string BuildChatUrl(string? phone, string? message = null)
    {
        var digits = NormalizePhone(phone);
        if (string.IsNullOrEmpty(digits))
        {
            return string.Empty;
        }

        var url = $"https://wa.me/{digits}";
        if (string.IsNullOrWhiteSpace(message))
        {
            return url;
        }

        return $"{url}?text={Uri.EscapeDataString(message)}";
    }

    public static bool HasConfiguredPaymentMethod(string? zelleContact) =>
        !string.IsNullOrWhiteSpace(zelleContact);
}
