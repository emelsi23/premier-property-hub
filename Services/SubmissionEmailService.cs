using System.Net;
using System.Net.Mail;
using System.Text;
using ApartamentosRenta.Models;
using Microsoft.Extensions.Options;

namespace ApartamentosRenta.Services;

public class SubmissionEmailService(
    IOptions<SmtpEmailOptions> options,
    ILogger<SubmissionEmailService> logger)
{
    private readonly SmtpEmailOptions _options = options.Value;

    public Task SendLeaseSubmissionAsync(ContractSubmission submission, Propiedad propiedad) =>
        SendAsync(
            subject: submission.SubmissionType == ContractSubmissionType.Signature
                ? $"Lease contract signed — {propiedad.Titulo}"
                : $"Lease change request — {propiedad.Titulo}",
            body: BuildLeaseBody(submission, propiedad),
            clientEmail: submission.TenantEmail,
            clientName: submission.TenantName,
            submission);

    public Task SendStampSealSubmissionAsync(StampSealSubmission submission, Propiedad propiedad) =>
        SendAsync(
            subject: submission.SubmissionType == ContractSubmissionType.Signature
                ? $"Stamps & seals signed — {propiedad.Titulo}"
                : $"Stamps & seals change request — {propiedad.Titulo}",
            body: BuildStampSealBody(submission, propiedad),
            clientEmail: submission.ClientEmail,
            clientName: submission.ClientName,
            submission);

    private async Task SendAsync(
        string subject,
        string body,
        string clientEmail,
        string clientName,
        object submission)
    {
        if (!_options.IsConfigured)
        {
            logger.LogInformation("SMTP email skipped: Smtp section is disabled or incomplete.");
            return;
        }

        try
        {
            using var message = new MailMessage
            {
                From = new MailAddress(_options.FromEmail, _options.FromName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8
            };

            message.To.Add(_options.NotifyEmail.Trim());

            if (submission is ContractSubmission lease)
            {
                AddSignatureAttachment(message, lease.SignatureImageData, lease.SignatureImageContentType, $"lease-signature-{lease.Id}");
            }
            else if (submission is StampSealSubmission stamp)
            {
                AddSignatureAttachment(message, stamp.SignatureImageData, stamp.SignatureImageContentType, $"stamp-seal-signature-{stamp.Id}");
            }

            using var client = new SmtpClient(_options.Host, _options.Port)
            {
                EnableSsl = _options.UseSsl,
                Credentials = new NetworkCredential(_options.Username, _options.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            await client.SendMailAsync(message);
            logger.LogInformation("Submission email sent to {Recipient} for {ClientName} ({ClientEmail}).", _options.NotifyEmail, clientName, clientEmail);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to send submission email for {ClientName} ({ClientEmail}).", clientName, clientEmail);
        }
    }

    private static void AddSignatureAttachment(
        MailMessage message,
        byte[]? imageData,
        string? contentType,
        string fileBaseName)
    {
        if (imageData is not { Length: > 0 })
        {
            return;
        }

        var extension = contentType switch
        {
            "image/jpeg" => ".jpg",
            "image/webp" => ".webp",
            _ => ".png"
        };

        var stream = new MemoryStream(imageData);
        var attachment = new Attachment(stream, $"{fileBaseName}{extension}", contentType ?? "image/png");
        message.Attachments.Add(attachment);
    }

    private static string BuildLeaseBody(ContractSubmission submission, Propiedad propiedad)
    {
        var sb = new StringBuilder();
        sb.Append("<h2>Lease contract submission</h2>");
        sb.Append("<table style=\"border-collapse:collapse;font-family:sans-serif;font-size:14px;\">");
        AppendRow(sb, "Type", submission.SubmissionType == ContractSubmissionType.Signature ? "Signature" : "Change request");
        AppendRow(sb, "Property", propiedad.Titulo);
        AppendRow(sb, "Address", $"{propiedad.Direccion}, {propiedad.Ciudad}");
        AppendRow(sb, "Monthly rent", $"${propiedad.PrecioMensual:N0}");
        AppendRow(sb, "Tenant name", submission.TenantName);
        AppendRow(sb, "Tenant email", submission.TenantEmail);
        AppendRow(sb, "Tenant phone", submission.TenantPhone ?? "—");
        AppendRow(sb, "Submitted at (UTC)", submission.SubmittedAt.ToString("yyyy-MM-dd HH:mm"));
        AppendRow(sb, "Property page", $"/property/{propiedad.Slug}");
        AppendRow(sb, "Contract page", $"/property/{propiedad.Slug}/contract");
        if (!string.IsNullOrWhiteSpace(submission.ProposedChanges))
        {
            AppendRow(sb, "Notes / changes", submission.ProposedChanges);
        }
        sb.Append("</table>");

        if (submission.SignatureImageData is { Length: > 0 })
        {
            sb.Append("<p><strong>Signature image</strong> is attached to this email.</p>");
        }

        return sb.ToString();
    }

    private static string BuildStampSealBody(StampSealSubmission submission, Propiedad propiedad)
    {
        var sb = new StringBuilder();
        sb.Append("<h2>Stamps &amp; seals submission</h2>");
        sb.Append("<table style=\"border-collapse:collapse;font-family:sans-serif;font-size:14px;\">");
        AppendRow(sb, "Type", submission.SubmissionType == ContractSubmissionType.Signature ? "Signature" : "Change request");
        AppendRow(sb, "Property", propiedad.Titulo);
        AppendRow(sb, "Address", $"{propiedad.Direccion}, {propiedad.Ciudad}");
        AppendRow(sb, "Purchase", StampSealSettings.GetLabel(submission.PurchaseOption));
        AppendRow(sb, "Amount", $"${submission.SelectedAmount:N0}");
        AppendRow(sb, "Client name", submission.ClientName);
        AppendRow(sb, "Client email", submission.ClientEmail);
        AppendRow(sb, "Client phone", submission.ClientPhone ?? "—");
        AppendRow(sb, "Submitted at (UTC)", submission.SubmittedAt.ToString("yyyy-MM-dd HH:mm"));
        AppendRow(sb, "Property page", $"/property/{propiedad.Slug}");
        AppendRow(sb, "Stamps page", $"/property/{propiedad.Slug}/stamps");
        if (!string.IsNullOrWhiteSpace(submission.ProposedChanges))
        {
            AppendRow(sb, "Notes / changes", submission.ProposedChanges);
        }
        sb.Append("</table>");

        if (submission.SignatureImageData is { Length: > 0 })
        {
            sb.Append("<p><strong>Signature image</strong> is attached to this email.</p>");
        }

        return sb.ToString();
    }

    private static void AppendRow(StringBuilder sb, string label, string value)
    {
        var encoded = WebUtility.HtmlEncode(value).Replace("\n", "<br />");
        sb.Append("<tr><td style=\"padding:6px 12px 6px 0;font-weight:600;vertical-align:top;\">")
            .Append(WebUtility.HtmlEncode(label))
            .Append("</td><td style=\"padding:6px 0;vertical-align:top;\">")
            .Append(encoded)
            .Append("</td></tr>");
    }
}
