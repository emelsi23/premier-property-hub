using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class StampSealContractDefaults
{
    public const string NoticeHtml = """
        <strong>Importante:</strong> Este acuerdo cubre la compra de <strong>estampillas</strong> y/o <strong>sellos</strong> oficiales
        requeridos para la documentación del alquiler de <strong>{{PropertyTitle}}</strong> en {{Address}}, {{City}}.
        Puedes seleccionar solo estampillas ({{StampsAmount}}), solo sellos ({{SealsAmount}}) o ambos ({{TotalAmount}}).
        """;

    public const string BodyHtml = """
        <section class="contract-section">
            <h2>1. Objeto</h2>
            <p>
                El cliente (“Comprador”) acuerda comprar <span class="contract-dynamic-items-long">estampillas y sellos oficiales</span> a través de
                <strong>{{LandlordName}}</strong> para el expediente de alquiler de
                <strong>{{PropertyTitle}}</strong>, ubicado en <strong>{{Address}}, {{City}}</strong>.
            </p>
        </section>
        <section class="contract-section">
            <h2>2. Artículos y tarifas</h2>
            <ul>
                <li data-purchase-line="stamps">Paquete de estampillas oficiales: <strong>{{StampsAmount}}</strong></li>
                <li data-purchase-line="seals">Paquete de sellos oficiales: <strong>{{SealsAmount}}</strong></li>
                <li><strong>Total a pagar:</strong> <strong class="contract-dynamic-total">{{TotalAmount}}</strong></li>
            </ul>
            <p>Las tarifas cubren preparación, gestión y registro de la documentación de <span class="contract-dynamic-doc">estampilla y sello</span> requerida conforme a las normas estatales y locales de EE. UU.</p>
        </section>
        <section class="contract-section">
            <h2>3. Pago</h2>
            <ul>
                <li>Método de pago: Zelle a <strong>{{ZelleContact}}</strong> u otro método aprobado por escrito.</li>
                <li>El pago vence al firmar este acuerdo, salvo otro acuerdo.</li>
                <li>Referencia de alquiler mensual de esta unidad: {{MonthlyRent}} (las tarifas de estampillas/sellos son aparte del alquiler).</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>4. Entrega y uso</h2>
            <ul>
                <li><span class="contract-dynamic-items-cap">Estampillas y sellos</span> <span class="contract-dynamic-verb">son</span> emitidos solo para documentos relacionados con este alquiler.</li>
                <li>El Comprador no transferirá, revenderá ni hará mal uso de <span class="contract-dynamic-misuse">estampillas o sellos</span> oficiales.</li>
                <li>Plazo de procesamiento: normalmente 1–3 días hábiles tras confirmar el pago.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>5. Reembolsos y cancelaciones</h2>
            <p>
                Una vez ordenadas o aplicadas las <span class="contract-dynamic-refund">estampillas o sellos</span> al expediente, las tarifas no son reembolsables excepto cuando la ley lo exija.
                Si la solicitud de alquiler se cancela antes de iniciar el proceso, puede aplicarse un reembolso parcial a discreción del Arrendador.
            </p>
        </section>
        <section class="contract-section">
            <h2>6. Reconocimiento</h2>
            <p>
                El Comprador confirma que las <span class="contract-dynamic-items">estampillas y sellos</span> son necesarios para cumplir con los requisitos locales de registro y formalización del arrendamiento,
                y acepta el monto total de <strong class="contract-dynamic-total">{{TotalAmount}}</strong>.
            </p>
        </section>
        """;

    public static StampSealContract CreateForProperty(int propiedadId) => new()
    {
        PropiedadId = propiedadId,
        Title = "Acuerdo de compra de estampillas y sellos",
        Subtitle = "Documentación oficial · Estados Unidos",
        NoticeHtml = NoticeHtml,
        BodyHtml = BodyHtml,
        UpdatedAt = DateTime.UtcNow
    };
}
