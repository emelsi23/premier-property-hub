using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ApartamentosRenta.Services;

public static class RemaxBrandedPdfDocuments
{
    private const string DocumentCodeProtocol = "PPH-ELITE-2026-V";
    private const string DocumentCodeCash = "PPH-CASH-2026-V";
    private const string Phone = "+1 (945) 384-6408";
    private const string Website = "www.premier-property-hub.onrender.com";
    private const string Email = "info@premierpropertyhub.com";

    private static readonly Color RemaxBlue = Color.FromHex("#0054A4");
    private static readonly Color RemaxRed = Color.FromHex("#E31837");
    private static readonly Color TextDark = Color.FromHex("#1A1A1B");
    private static readonly Color TextMuted = Color.FromHex("#4B5563");

    public static byte[] GenerateProtocoloReserva() =>
        Document.Create(document =>
        {
            document.Page(page =>
            {
                ConfigurePage(page);
                page.Content().Column(column =>
                {
                    column.Spacing(8);
                    column.Item().Element(ComposeProtocolHeader);
                    column.Item().PaddingTop(6).Text("PROTOCOLO DE SEGURIDAD Y RESERVA DE PROPIEDAD")
                        .Bold().FontSize(13).FontColor(TextDark);
                    column.Item().Text("Departamento Jurídico y Gestión de Propiedades.")
                        .FontSize(10).FontColor(TextMuted);

                    column.Item().PaddingTop(10).Element(c => SectionTitle(c, "1. INFORMACIÓN DEL SOLICITANTE (EL CLIENTE)."));
                    column.Item().Element(c => FieldLine(c, "NOMBRE COMPLETO:"));
                    column.Item().Element(c => FieldLine(c, "TELÉFONO DE CONTACTO:"));
                    column.Item().Element(c => FieldLine(c, "CORREO ELECTRÓNICO:"));
                    column.Item().Element(c => FieldLine(c, "FECHA Y HORA DE VISITA:", "____ / ____ / ______ Hora: ___________"));

                    column.Item().PaddingTop(8).Element(c => SectionTitle(c, "2. REQUERIMIENTOS DE RESIDENCIA."));
                    column.Item().Text("Cantidad de Ocupantes Totales: ________").FontSize(10);
                    column.Item().Text("¿Posee hijos? [ ] Sí [ ] No").FontSize(10);
                    column.Item().Text("Cantidad de vehículos: ________").FontSize(10);
                    column.Item().Text("¿Posee mascotas? [ ] Sí [ ] No").FontSize(10);
                    column.Item().PaddingTop(4).Text(
                        "La veracidad de estos datos es indispensable para la validación del perfil del arrendatario por parte de nuestro equipo legal.")
                        .FontSize(9).FontColor(TextMuted);

                    column.Item().PaddingTop(8).Element(c => SectionTitle(c, "3. TÉRMINOS DEL DEPÓSITO DE RESERVA."));
                    column.Item().Text(
                        "Para formalizar la cita y asegurar la exclusividad temporal de la propiedad, el cliente constituye un depósito de $125.00 USD, bajo las siguientes condiciones:")
                        .FontSize(10);
                    column.Item().PaddingTop(4).Element(ComposeDepositBulletsPage1);
                });
            });

            document.Page(page =>
            {
                ConfigurePage(page);
                page.Content().Column(column =>
                {
                    column.Spacing(8);
                    column.Item().Element(ComposeProtocolHeader);
                    column.Item().PaddingTop(4).Element(c => SectionTitle(c, "4. DECLARACIÓN DE LEGALIDAD Y GARANTÍA DE FONDO."));
                    column.Item().Text(
                        "El presente protocolo forma parte de los procedimientos administrativos internos debidamente estructurados bajo principios de legalidad y transparencia en gestión inmobiliaria.")
                        .FontSize(10);
                    column.Item().Text(
                        "Ningún pago realizado bajo este acuerdo se pierde fuera de las condiciones previamente estipuladas, contando el cliente con respaldo documental y garantía de reembolso conforme a los términos establecidos.")
                        .FontSize(10);

                    column.Item().PaddingTop(24).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                    column.Item().PaddingTop(8).Text("PREMIER PROPERTY HUB BY RE/MAX")
                        .Bold().FontSize(11).FontColor(TextDark);
                    column.Item().Text("Departamento Jurídico y Gestión Patrimonial")
                        .FontSize(10).FontColor(TextMuted);

                    column.Item().PaddingTop(20).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                    column.Item().PaddingTop(4).AlignCenter().Text("FIRMA DEL SOLICITANTE").Bold().FontSize(10);
                    column.Item().AlignCenter().Text("Acepto los términos y condiciones").FontSize(9).FontColor(TextMuted);

                    column.Item().PaddingTop(20).AlignCenter().Text($"Premier Property Hub by RE/MAX © {DateTime.UtcNow.Year}. Todos los derechos reservados.")
                        .FontSize(8).FontColor(TextMuted);
                    column.Item().AlignCenter().Text("Documento amparado bajo normativas de transparencia inmobiliaria.")
                        .FontSize(8).FontColor(TextMuted);
                    column.Item().AlignCenter().Text(Email).FontSize(8).FontColor(TextMuted);
                    column.Item().AlignCenter().Text($"Tel: {Phone}").FontSize(8).FontColor(TextMuted);
                    column.Item().AlignCenter().Text(Website).FontSize(8).FontColor(TextMuted);
                });
            });
        }).GeneratePdf();

    public static byte[] GeneratePagoEfectivoBarcode() =>
        Document.Create(document =>
        {
            document.Page(page =>
            {
                ConfigurePage(page);
                page.Content().Column(column =>
                {
                    column.Spacing(10);
                    column.Item().Element(ComposeCashHeader);
                    column.Item().PaddingTop(8).Text("PAGO EN EFECTIVO - PROCEDIMIENTO MEDIANTE CÓDIGO DE BARRAS.")
                        .Bold().FontSize(12).FontColor(TextDark);

                    column.Item().PaddingTop(8).Text(
                        "Si usted desea realizar el pago en efectivo, podemos proceder utilizando el sistema de código de barras, el cual permite realizar un depósito directo a la empresa.")
                        .FontSize(10);
                    column.Item().Text("Este proceso puede realizarse en cualquiera de los siguientes establecimientos:")
                        .FontSize(10);

                    column.Item().PaddingTop(6).Column(list =>
                    {
                        list.Item().Text("- 7-Eleven").FontSize(10);
                        list.Item().Text("- CVS Pharmacy").FontSize(10);
                        list.Item().Text("- Dollar General").FontSize(10);
                        list.Item().Text("- Walgreens").FontSize(10);
                        list.Item().Text("- Family Dollar").FontSize(10);
                    });

                    column.Item().PaddingTop(8).Text(
                        "Una vez que seleccione el establecimiento más cercano, se le generará un código de barras personalizado, emitido directamente por la empresa. Este código será escaneado en la tienda para completar el pago.")
                        .FontSize(10);
                    column.Item().PaddingTop(8).Text(
                        "Por favor, indíqueme cuál de estos establecimientos le queda más cerca, para así continuar con el proceso y explicarle paso a paso cómo proceder con el depósito.")
                        .FontSize(10);

                    column.Item().PaddingTop(24).AlignCenter().Text($"Tel: {Phone} · {Website}")
                        .FontSize(8).FontColor(TextMuted);
                });
            });
        }).GeneratePdf();

    public static void WriteToWebRoot(string webRootPath)
    {
        var folder = Path.Combine(webRootPath, "documentos");
        Directory.CreateDirectory(folder);
        File.WriteAllBytes(Path.Combine(folder, "Protocolo-Reserva-PREMAX.pdf"), GenerateProtocoloReserva());
        File.WriteAllBytes(Path.Combine(folder, "Pago-Efectivo-Barcode-PREMAX.pdf"), GeneratePagoEfectivoBarcode());
    }

    private static void ConfigurePage(PageDescriptor page)
    {
        page.Size(PageSizes.A4);
        page.MarginHorizontal(48);
        page.MarginVertical(40);
        page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial").FontColor(TextDark));
    }

    private static void ComposeProtocolHeader(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(col =>
            {
                col.Item().Text(text =>
                {
                    text.Span("RE").FontColor(RemaxBlue).Bold().FontSize(26);
                    text.Span("/").FontColor(RemaxRed).Bold().FontSize(26);
                    text.Span("MAX").FontColor(RemaxRed).Bold().FontSize(26);
                });
                col.Item().Text("Premier Property Hub").Bold().FontSize(11).FontColor(TextDark);
            });

            row.RelativeItem().AlignRight().Column(col =>
            {
                col.Item().AlignRight().Text($"Código de Documento: {DocumentCodeProtocol}")
                    .FontSize(9).FontColor(TextMuted);
            });
        });
    }

    private static void ComposeCashHeader(IContainer container)
    {
        container.Column(col =>
        {
            col.Item().Text(text =>
            {
                text.Span("RE").FontColor(RemaxBlue).Bold().FontSize(22);
                text.Span("/").FontColor(RemaxRed).Bold().FontSize(22);
                text.Span("MAX").FontColor(RemaxRed).Bold().FontSize(22);
            });
            col.Item().Text("PREMIER PROPERTY HUB BY RE/MAX - Proceso para Agendar una Cita de Visita")
                .Bold().FontSize(11).FontColor(TextDark);
            col.Item().Text($"Código de Documento: {DocumentCodeCash}")
                .FontSize(8).FontColor(TextMuted);
        });
    }

    private static void SectionTitle(IContainer container, string title) =>
        container.Text(title).Bold().FontSize(10).FontColor(TextDark);

    private static void ComposeDepositBulletsPage1(IContainer container)
    {
        container.Column(col =>
        {
            col.Spacing(6);
            col.Item().Text("• Garantía de Reembolso:").Bold().FontSize(10);
            col.Item().Text("Si tras la visita el cliente decide no proceder con la propiedad, el monto de $125.00 USD será reintegrado en su totalidad.")
                .FontSize(10);
            col.Item().Text("• Crédito a Renta:").Bold().FontSize(10);
            col.Item().Text("En caso de arrendamiento, el 100% del depósito se aplicará como pago inicial del contrato.")
                .FontSize(10);
            col.Item().Text("• Política de Inasistencia:").Bold().FontSize(10);
            col.Item().Text("La cancelación o inasistencia sin aviso previo de 24h conlleva una retención de $5.00 USD por gastos de gestión, reembolsando $120.00 USD.")
                .FontSize(10);
            col.Item().Text("• Seguridad:").Bold().FontSize(10);
            col.Item().Text("Este proceso garantiza que la propiedad no sea mostrada a terceros durante el periodo de reserva del cliente.")
                .FontSize(10);
        });
    }

    private static void FieldLine(IContainer container, string label, string? valueSuffix = null)
    {
        container.PaddingBottom(4).Row(row =>
        {
            row.AutoItem().Text(label + " ").FontSize(10);
            row.RelativeItem().Text(valueSuffix ?? "_______________________________________________")
                .FontSize(10).FontColor(Colors.Grey.Medium);
        });
    }
}
