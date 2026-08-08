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
        var subject = $"Solicitud de visita recibida — {property.Titulo}";
        var html = $"""
            <div style="font-family:Inter,Arial,sans-serif;color:#1a1a1b;line-height:1.6;max-width:560px;">
                <p style="color:#e31837;font-weight:700;font-size:12px;text-transform:uppercase;">RE/MAX · Premier Property Hub</p>
                <h1 style="font-size:22px;margin:0 0 12px;">Recibimos tu solicitud de visita</h1>
                <p>Hola {appointment.NombreCliente.Trim()},</p>
                <p>Gracias por solicitar visitar <strong>{property.Titulo}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                    <tr><td style="padding:6px 0;color:#64748b;">Propiedad</td><td style="padding:6px 0;"><strong>{property.Titulo}</strong></td></tr>
                    <tr><td style="padding:6px 0;color:#64748b;">Dirección</td><td style="padding:6px 0;">{property.Direccion}, {property.Ciudad}</td></tr>
                    <tr><td style="padding:6px 0;color:#64748b;">Visita solicitada</td><td style="padding:6px 0;">{visitLocal:dd/MM/yyyy} a las {visitLocal:HH:mm}</td></tr>
                    <tr><td style="padding:6px 0;color:#64748b;">Método de pago</td><td style="padding:6px 0;">Zelle</td></tr>
                </table>
                <p>Siguiente paso: tras una revisión rápida, completarás el depósito de visita vía <strong>Zelle</strong> en la página de la propiedad.</p>
                <p style="margin:12px 0;"><strong>Este pago es reembolsable al momento de irse de la propiedad.</strong></p>
                <p style="color:#64748b;font-size:14px;">Si no solicitaste esto, puedes ignorar este correo.</p>
            </div>
            """;

        await emailSender.SendAsync(appointment.Email.Trim(), subject, html, cancellationToken);
    }
}
