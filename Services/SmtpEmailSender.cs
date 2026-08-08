using System.Net;
using System.Net.Mail;
using ApartamentosRenta.Options;
using Microsoft.Extensions.Options;

namespace ApartamentosRenta.Services;

public sealed class SmtpEmailSender(IOptions<EmailOptions> options) : IEmailSender
{
    public async Task SendAsync(string to, string subject, string htmlBody, CancellationToken cancellationToken = default)
    {
        var config = options.Value;
        if (string.IsNullOrWhiteSpace(config.SmtpHost))
        {
            throw new InvalidOperationException("Email:SmtpHost is not configured.");
        }

        using var message = new MailMessage
        {
            From = new MailAddress(ExtractEmail(config.FromAddress), ExtractName(config.FromAddress)),
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true
        };
        message.To.Add(to);

        using var client = new SmtpClient(config.SmtpHost, config.SmtpPort)
        {
            EnableSsl = config.UseSsl,
            Credentials = string.IsNullOrWhiteSpace(config.SmtpUser)
                ? null
                : new NetworkCredential(config.SmtpUser, config.SmtpPassword),
            Timeout = config.TimeoutSeconds * 1000
        };

        await client.SendMailAsync(message, cancellationToken);
    }

    private static string ExtractEmail(string from)
    {
        var start = from.IndexOf('<');
        var end = from.IndexOf('>');
        if (start >= 0 && end > start)
        {
            return from[(start + 1)..end].Trim();
        }

        return from.Trim();
    }

    private static string ExtractName(string from)
    {
        var start = from.IndexOf('<');
        if (start > 0)
        {
            return from[..start].Trim();
        }

        return "Premier Property Hub";
    }
}
