using ApartamentosRenta.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ApartamentosRenta.Services;

public static class ReservaGenericaPdfDocument
{
    private static readonly Color RemaxBlue = Color.FromHex("#0054A4");
    private static readonly Color RemaxRed = Color.FromHex("#E31837");
    private static readonly Color TextDark = Color.FromHex("#1A1A1B");
    private static readonly Color TextMuted = Color.FromHex("#4B5563");

    public static byte[] Generate(ReservaGenerica reserva)
    {
        var estado = reserva.Estado switch
        {
            EstadoReservaGenerica.EsperandoConfirmacion => "Verificando pago",
            EstadoReservaGenerica.Completada => "Confirmada",
            EstadoReservaGenerica.EsperandoPago => "Esperando pago",
            EstadoReservaGenerica.EsperandoIdentidad => "Esperando identidad",
            EstadoReservaGenerica.Cancelada => "Cancelada",
            _ => reserva.Estado.ToString()
        };

        var metodo = reserva.MetodoPago switch
        {
            MetodoPagoReserva.Zelle => "Zelle",
            MetodoPagoReserva.CodigoBarras => "Código de barras",
            _ => "—"
        };

        var codigoVisible = reserva.Estado == EstadoReservaGenerica.Completada
            ? reserva.CodigoConfirmacion
            : "(se entrega al confirmar)";

        return Document.Create(document =>
        {
            document.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.MarginHorizontal(42);
                page.MarginVertical(36);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial").FontColor(TextDark));

                page.Header().Element(ComposeHeader);

                page.Content().PaddingTop(12).Column(column =>
                {
                    column.Spacing(8);

                    column.Item().Text("PROTOCOLO DE SEGURIDAD Y RESERVA DE PROPIEDAD — FORMULARIO COMPLETADO")
                        .Bold().FontSize(12).FontColor(TextDark);
                    column.Item().Text($"Estado: {estado} · Enviado: {reserva.FechaSolicitud.ToLocalTime():g}")
                        .FontSize(9).FontColor(TextMuted);

                    column.Item().PaddingTop(6).Element(c => SectionTitle(c, "1. INFORMACIÓN DEL SOLICITANTE"));
                    column.Item().Element(c => DataRow(c, "Nombre completo", reserva.NombreCompleto));
                    column.Item().Element(c => DataRow(c, "Teléfono", reserva.Telefono));
                    column.Item().Element(c => DataRow(c, "Correo electrónico", reserva.Email));
                    column.Item().Element(c => DataRow(c, "Fecha y hora de visita", reserva.FechaVisita.ToLocalTime().ToString("dddd, MMM d, yyyy · h:mm tt")));

                    column.Item().PaddingTop(4).Element(c => SectionTitle(c, "2. REQUERIMIENTOS DE RESIDENCIA"));
                    column.Item().Element(c => DataRow(c, "Ocupantes totales", reserva.OcupantesTotales.ToString()));
                    column.Item().Element(c => DataRow(c, "¿Posee hijos?", reserva.PoseeHijos ? "Sí" : "No"));
                    column.Item().Element(c => DataRow(c, "Cantidad de vehículos", reserva.CantidadVehiculos.ToString()));
                    column.Item().Element(c => DataRow(c, "¿Posee mascotas?", reserva.PoseeMascotas ? "Sí" : "No"));

                    column.Item().PaddingTop(4).Element(c => SectionTitle(c, "3. DEPÓSITO Y PAGO"));
                    column.Item().Element(c => DataRow(c, "Monto del depósito", $"${reserva.DepositAmount:N2} USD"));
                    column.Item().Element(c => DataRow(c, "Método de pago", metodo));
                    column.Item().Element(c => DataRow(c, "Código de confirmación", codigoVisible));
                    if (reserva.PaymentProofUploadedAt.HasValue)
                    {
                        column.Item().Element(c => DataRow(c, "Comprobante subido", reserva.PaymentProofUploadedAt.Value.ToLocalTime().ToString("g")));
                    }

                    if (reserva.FechaCompletada.HasValue)
                    {
                        column.Item().Element(c => DataRow(c, "Confirmada el", reserva.FechaCompletada.Value.ToLocalTime().ToString("g")));
                    }

                    column.Item().PaddingTop(4).Element(c => SectionTitle(c, "4. DECLARACIÓN Y FIRMA"));
                    column.Item().Text(reserva.AceptaTerminos
                            ? "El solicitante aceptó los términos y condiciones del protocolo de reserva."
                            : "Términos: no registrados.")
                        .FontSize(9).FontColor(TextMuted);

                    if (reserva.FirmaData is { Length: > 0 })
                    {
                        column.Item().PaddingTop(6).Text("Firma digital del solicitante").Bold().FontSize(9);
                        column.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).AlignCenter()
                            .MaxHeight(120).Image(reserva.FirmaData).FitArea();
                    }
                    else
                    {
                        column.Item().Text("Firma no disponible.").FontSize(9).FontColor(TextMuted);
                    }
                });

                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("Premier Property Hub By RE/MAX · Documento generado ").FontSize(8).FontColor(TextMuted);
                    text.Span($"{DateTime.UtcNow.ToLocalTime():g}").FontSize(8).FontColor(TextMuted);
                    text.Span(" · Página ").FontSize(8).FontColor(TextMuted);
                    text.CurrentPageNumber().FontSize(8).FontColor(TextMuted);
                    text.Span(" / ").FontSize(8).FontColor(TextMuted);
                    text.TotalPages().FontSize(8).FontColor(TextMuted);
                });
            });

            if (reserva.IdentidadData is { Length: > 0 } || reserva.PaymentProofData is { Length: > 0 })
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.MarginHorizontal(42);
                    page.MarginVertical(36);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial").FontColor(TextDark));
                    page.Header().Element(ComposeHeader);

                    page.Content().PaddingTop(12).Column(column =>
                    {
                        column.Spacing(10);

                        if (reserva.IdentidadData is { Length: > 0 })
                        {
                            column.Item().Element(c => SectionTitle(c, "5. VERIFICACIÓN DE IDENTIDAD (ID + SELFIE)"));
                            if (reserva.IdentidadUploadedAt.HasValue)
                            {
                                column.Item().Text($"Subido: {reserva.IdentidadUploadedAt.Value.ToLocalTime():g}")
                                    .FontSize(9).FontColor(TextMuted);
                            }

                            column.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(6).AlignCenter()
                                .MaxHeight(320).Image(reserva.IdentidadData).FitArea();
                        }

                        if (reserva.PaymentProofData is { Length: > 0 })
                        {
                            column.Item().PaddingTop(8).Element(c => SectionTitle(c, "6. COMPROBANTE DE PAGO"));
                            column.Item().Text($"Método: {metodo} · Monto: ${reserva.DepositAmount:N2} USD")
                                .FontSize(9).FontColor(TextMuted);
                            column.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(6).AlignCenter()
                                .MaxHeight(320).Image(reserva.PaymentProofData).FitArea();
                        }
                    });

                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span($"{reserva.NombreCompleto} · Página ").FontSize(8).FontColor(TextMuted);
                        text.CurrentPageNumber().FontSize(8).FontColor(TextMuted);
                        text.Span(" / ").FontSize(8).FontColor(TextMuted);
                        text.TotalPages().FontSize(8).FontColor(TextMuted);
                    });
                });
            }
        }).GeneratePdf();
    }

    private static void ComposeHeader(IContainer container)
    {
        container.Column(col =>
        {
            col.Item().Row(row =>
            {
                row.RelativeItem().Column(left =>
                {
                    left.Item().Text(text =>
                    {
                        text.Span("RE").FontColor(RemaxBlue).Bold().FontSize(22);
                        text.Span("/").FontColor(RemaxRed).Bold().FontSize(22);
                        text.Span("MAX").FontColor(RemaxRed).Bold().FontSize(22);
                    });
                    left.Item().Text("Premier Property Hub · Departamento Jurídico")
                        .FontSize(9).FontColor(TextMuted);
                });
                row.RelativeItem().AlignRight().Column(right =>
                {
                    right.Item().AlignRight().Text("Documento REMAX-ELITE-2026-V")
                        .FontSize(8).FontColor(TextMuted);
                    right.Item().AlignRight().Text("Copia administrativa del protocolo")
                        .FontSize(8).FontColor(TextMuted);
                });
            });
            col.Item().PaddingTop(6).LineHorizontal(1.5f).LineColor(RemaxRed);
        });
    }

    private static void SectionTitle(IContainer container, string title) =>
        container.Text(title).Bold().FontSize(10).FontColor(RemaxBlue);

    private static void DataRow(IContainer container, string label, string value)
    {
        container.Row(row =>
        {
            row.ConstantItem(150).Text(label + ":").FontSize(9).FontColor(TextMuted);
            row.RelativeItem().Text(value).Bold().FontSize(10);
        });
    }
}
