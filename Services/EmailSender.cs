using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ApartamentosRenta.Services;

public class EmailSender(
    IOptions<EmailOptions> options,
    IHttpClientFactory httpClientFactory,
    ILogger<EmailSender> logger)
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
    private readonly EmailOptions _options = options.Value;

    public async Task SendAsync(EmailMessage message, string clientName, string clientEmail)
    {
        if (!_options.IsConfigured)
        {
            logger.LogWarning("Email skipped: Email section is disabled or incomplete.");
            return;
        }

        var provider = _options.ResolvedProvider;
        try
        {
            switch (provider)
            {
                case "GmailRelay":
                    await SendViaGmailRelayAsync(message);
                    break;
                case "Resend":
                    await SendViaResendAsync(message);
                    break;
                default:
                    await SendViaSmtpAsync(message);
                    break;
            }

            logger.LogInformation(
                "Email sent via {Provider} to {Recipient} for {ClientName} ({ClientEmail}).",
                provider,
                _options.NotifyEmail,
                clientName,
                clientEmail);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Failed to send email via {Provider} for {ClientName} ({ClientEmail}).",
                provider,
                clientName,
                clientEmail);

            if (provider != "Smtp"
                && _options is { SmtpUsername: { Length: > 0 }, SmtpPassword: { Length: > 0 } })
            {
                logger.LogInformation("Retrying email send via SMTP fallback.");
                await SendViaSmtpAsync(message);
                logger.LogInformation("Email sent via SMTP fallback to {Recipient}.", _options.NotifyEmail);
            }
        }
    }

    private async Task SendViaSmtpAsync(EmailMessage message)
    {
        var mime = BuildMimeMessage(message);

        using var client = new SmtpClient();
        await client.ConnectAsync(_options.SmtpHost, _options.SmtpPort, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_options.SmtpUsername, _options.SmtpPassword);
        await client.SendAsync(mime);
        await client.DisconnectAsync(true);
    }

    private async Task SendViaResendAsync(EmailMessage message)
    {
        var payload = new Dictionary<string, object?>
        {
            ["from"] = $"{_options.FromName} <{_options.FromEmail}>",
            ["to"] = new[] { _options.NotifyEmail.Trim() },
            ["subject"] = message.Subject,
            ["html"] = message.HtmlBody
        };

        if (message.Attachments.Count > 0)
        {
            payload["attachments"] = message.Attachments.Select(a => new
            {
                filename = a.FileName,
                content = Convert.ToBase64String(a.Data)
            }).ToArray();
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.resend.com/emails");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.ResendApiKey);
        request.Content = new StringContent(JsonSerializer.Serialize(payload, JsonOptions), Encoding.UTF8, "application/json");

        var client = httpClientFactory.CreateClient(nameof(EmailSender));
        using var response = await client.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Resend API returned {(int)response.StatusCode}: {body}");
        }
    }

    private async Task SendViaGmailRelayAsync(EmailMessage message)
    {
        var payload = new
        {
            secret = _options.GmailRelaySecret,
            to = _options.NotifyEmail.Trim(),
            subject = message.Subject,
            htmlBody = message.HtmlBody,
            fromName = _options.FromName,
            attachments = message.Attachments.Select(a => new
            {
                filename = a.FileName,
                contentType = a.ContentType,
                content = Convert.ToBase64String(a.Data)
            }).ToArray()
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, _options.GmailRelayUrl);
        request.Content = new StringContent(JsonSerializer.Serialize(payload, JsonOptions), Encoding.UTF8, "application/json");

        var client = httpClientFactory.CreateClient(nameof(EmailSender));
        using var response = await client.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Gmail relay returned {(int)response.StatusCode}: {body}");
        }

        using var document = JsonDocument.Parse(body);
        if (document.RootElement.TryGetProperty("success", out var success) && success.ValueKind == JsonValueKind.False)
        {
            var error = document.RootElement.TryGetProperty("message", out var messageNode)
                ? messageNode.GetString()
                : body;
            throw new InvalidOperationException($"Gmail relay failed: {error}");
        }
    }

    private MimeMessage BuildMimeMessage(EmailMessage message)
    {
        var mime = new MimeMessage();
        mime.From.Add(new MailboxAddress(_options.FromName, _options.FromEmail));
        mime.To.Add(MailboxAddress.Parse(_options.NotifyEmail.Trim()));
        mime.Subject = message.Subject;

        var builder = new BodyBuilder { HtmlBody = message.HtmlBody };
        foreach (var attachment in message.Attachments)
        {
            builder.Attachments.Add(attachment.FileName, attachment.Data, ContentType.Parse(attachment.ContentType));
        }

        mime.Body = builder.ToMessageBody();
        return mime;
    }
}
