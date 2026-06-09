namespace ApartamentosRenta.Services;

public class EmailOptions
{
    public const string SectionName = "Email";

    public bool Enabled { get; set; } = true;

    /// <summary>Smtp, Resend, or GmailRelay. Auto picks GmailRelay/Resend when configured.</summary>
    public string Provider { get; set; } = "Auto";

    public string FromEmail { get; set; } = string.Empty;

    public string FromName { get; set; } = "Premier Property Hub";

    public string NotifyEmail { get; set; } = string.Empty;

    public string SmtpHost { get; set; } = "smtp.gmail.com";

    public int SmtpPort { get; set; } = 587;

    public bool SmtpUseSsl { get; set; } = true;

    public string SmtpUsername { get; set; } = string.Empty;

    public string SmtpPassword { get; set; } = string.Empty;

    public string? ResendApiKey { get; set; }

    public string? GmailRelayUrl { get; set; }

    public string? GmailRelaySecret { get; set; }

    public string ResolvedProvider
    {
        get
        {
            if (!string.Equals(Provider, "Auto", StringComparison.OrdinalIgnoreCase))
            {
                return Provider;
            }

            if (!string.IsNullOrWhiteSpace(GmailRelayUrl) && !string.IsNullOrWhiteSpace(GmailRelaySecret))
            {
                return "GmailRelay";
            }

            if (!string.IsNullOrWhiteSpace(ResendApiKey))
            {
                return "Resend";
            }

            return "Smtp";
        }
    }

    public bool IsConfigured =>
        Enabled
        && !string.IsNullOrWhiteSpace(FromEmail)
        && !string.IsNullOrWhiteSpace(NotifyEmail)
        && ResolvedProvider switch
        {
            "GmailRelay" => !string.IsNullOrWhiteSpace(GmailRelayUrl)
                && !string.IsNullOrWhiteSpace(GmailRelaySecret),
            "Resend" => !string.IsNullOrWhiteSpace(ResendApiKey),
            _ => !string.IsNullOrWhiteSpace(SmtpHost)
                && !string.IsNullOrWhiteSpace(SmtpUsername)
                && !string.IsNullOrWhiteSpace(SmtpPassword)
        };
}
