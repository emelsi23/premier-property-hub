using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public class SubmissionEmailService(EmailSender emailSender)
{
    public Task SendLeaseSubmissionAsync(ContractSubmission submission, Propiedad propiedad) =>
        emailSender.SendAsync(
            BuildLeaseMessage(submission, propiedad),
            submission.TenantName,
            submission.TenantEmail);

    public Task SendStampSealSubmissionAsync(StampSealSubmission submission, Propiedad propiedad) =>
        emailSender.SendAsync(
            BuildStampSealMessage(submission, propiedad),
            submission.ClientName,
            submission.ClientEmail);

    public Task SendPaymentProofAsync(Cita cita, Propiedad propiedad) =>
        emailSender.SendAsync(
            BuildPaymentProofMessage(cita, propiedad),
            cita.NombreCompleto,
            cita.Email);

    private EmailMessage BuildLeaseMessage(ContractSubmission submission, Propiedad propiedad)
    {
        var body = BuildLeaseBody(submission, propiedad);
        return new EmailMessage
        {
            Subject = submission.SubmissionType == ContractSubmissionType.Signature
                ? $"Lease contract signed — {propiedad.Titulo}"
                : $"Lease change request — {propiedad.Titulo}",
            HtmlBody = body,
            Attachments = BuildSignatureAttachment(
                submission.SignatureImageData,
                submission.SignatureImageContentType,
                $"lease-signature-{submission.Id}")
        };
    }

    private EmailMessage BuildStampSealMessage(StampSealSubmission submission, Propiedad propiedad)
    {
        var body = BuildStampSealBody(submission, propiedad);
        return new EmailMessage
        {
            Subject = submission.SubmissionType == ContractSubmissionType.Signature
                ? $"Stamps & seals signed — {propiedad.Titulo}"
                : $"Stamps & seals change request — {propiedad.Titulo}",
            HtmlBody = body,
            Attachments = BuildSignatureAttachment(
                submission.SignatureImageData,
                submission.SignatureImageContentType,
                $"stamp-seal-signature-{submission.Id}")
        };
    }

    private EmailMessage BuildPaymentProofMessage(Cita cita, Propiedad propiedad)
    {
        var amount = VisitDepositSettings.GetAmount(propiedad);
        var body = new System.Text.StringBuilder();
        body.Append("<h2>Zelle deposit payment proof</h2>");
        body.Append("<table style=\"border-collapse:collapse;font-family:sans-serif;font-size:14px;\">");
        AppendRow(body, "Property", propiedad.Titulo);
        AppendRow(body, "Address", $"{propiedad.Direccion}, {propiedad.Ciudad}");
        AppendRow(body, "Deposit amount", $"${amount:N0}");
        AppendRow(body, "Client name", cita.NombreCompleto);
        AppendRow(body, "Client email", cita.Email);
        AppendRow(body, "Client phone", cita.Telefono);
        AppendRow(body, "Visit date", cita.FechaHora.ToString("yyyy-MM-dd HH:mm"));
        AppendRow(body, "Uploaded at (UTC)", cita.PaymentProofUploadedAt?.ToString("yyyy-MM-dd HH:mm") ?? "—");
        body.Append("</table>");
        body.Append("<p><strong>Payment screenshot</strong> is attached to this email.</p>");

        return new EmailMessage
        {
            Subject = $"Zelle deposit proof — {propiedad.Titulo} — {cita.NombreCompleto}",
            HtmlBody = body.ToString(),
            Attachments = BuildSignatureAttachment(
                cita.PaymentProofData,
                cita.PaymentProofContentType,
                $"zelle-proof-{cita.Id}")
        };
    }

    private static IReadOnlyList<EmailAttachment> BuildSignatureAttachment(
        byte[]? imageData,
        string? contentType,
        string fileBaseName)
    {
        if (imageData is not { Length: > 0 })
        {
            return [];
        }

        var normalizedType = contentType ?? "image/png";
        var extension = normalizedType switch
        {
            "image/jpeg" => ".jpg",
            "image/webp" => ".webp",
            "image/gif" => ".gif",
            _ => ".png"
        };

        return
        [
            new EmailAttachment
            {
                FileName = $"{fileBaseName}{extension}",
                ContentType = normalizedType,
                Data = imageData
            }
        ];
    }

    private static string BuildLeaseBody(ContractSubmission submission, Propiedad propiedad)
    {
        var sb = new System.Text.StringBuilder();
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
        var sb = new System.Text.StringBuilder();
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

    private static void AppendRow(System.Text.StringBuilder sb, string label, string value)
    {
        var encoded = System.Net.WebUtility.HtmlEncode(value).Replace("\n", "<br />");
        sb.Append("<tr><td style=\"padding:6px 12px 6px 0;font-weight:600;vertical-align:top;\">")
            .Append(System.Net.WebUtility.HtmlEncode(label))
            .Append("</td><td style=\"padding:6px 0;vertical-align:top;\">")
            .Append(encoded)
            .Append("</td></tr>");
    }
}
