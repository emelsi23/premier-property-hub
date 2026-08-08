namespace ApartamentosRenta.Options;

public class EmailOptions
{
    public const string SectionName = "Email";

    public bool Enabled { get; set; }

    /// <summary>Resend (recommended on Render) or Smtp (local dev).</summary>
    public string Provider { get; set; } = "Resend";

    public string FromAddress { get; set; } = "Premier Property Hub <onboarding@resend.dev>";

    public string? ResendApiKey { get; set; }

    public string? SmtpHost { get; set; }

    public int SmtpPort { get; set; } = 587;

    public string? SmtpUser { get; set; }

    public string? SmtpPassword { get; set; }

    public bool UseSsl { get; set; } = true;

    public int TimeoutSeconds { get; set; } = 12;
}
