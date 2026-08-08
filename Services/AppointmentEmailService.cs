using ApartamentosRenta.Models;
using ApartamentosRenta.Options;
using Microsoft.Extensions.Options;

namespace ApartamentosRenta.Services;

public sealed class AppointmentEmailService(
    IEmailSender emailSender,
    IOptions<EmailOptions> options)
{
    public async Task TrySendApplicationReceivedAsync(Cita appointment, Propiedad property, CancellationToken cancellationToken = default)
    {
        if (!options.Value.Enabled)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(appointment.Email))
        {
            return;
        }

        var visitLocal = appointment.FechaHora.ToLocalTime();
        var subject = $"Visit request received — {property.Titulo}";
        var html = $"""
            <div style="font-family:Inter,Arial,sans-serif;color:#1a1a1b;line-height:1.6;max-width:560px;">
                <p style="color:#e31837;font-weight:700;font-size:12px;text-transform:uppercase;">RE/MAX · Premier Property Hub</p>
                <h1 style="font-size:22px;margin:0 0 12px;">We received your visit request</h1>
                <p>Hi {appointment.NombreCliente.Trim()},</p>
                <p>Thank you for applying to tour <strong>{property.Titulo}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                    <tr><td style="padding:6px 0;color:#64748b;">Property</td><td style="padding:6px 0;"><strong>{property.Titulo}</strong></td></tr>
                    <tr><td style="padding:6px 0;color:#64748b;">Address</td><td style="padding:6px 0;">{property.Direccion}, {property.Ciudad}</td></tr>
                    <tr><td style="padding:6px 0;color:#64748b;">Requested visit</td><td style="padding:6px 0;">{visitLocal:MMMM d, yyyy} at {visitLocal:h:mm tt}</td></tr>
                    <tr><td style="padding:6px 0;color:#64748b;">Payment method</td><td style="padding:6px 0;">Zelle</td></tr>
                </table>
                <p>Next step: after quick review, you will complete your visit deposit via <strong>Zelle</strong> on the property page.</p>
                <p style="color:#64748b;font-size:14px;">If you did not request this, you can ignore this email.</p>
            </div>
            """;

        await emailSender.SendAsync(appointment.Email.Trim(), subject, html, cancellationToken);
    }
}
