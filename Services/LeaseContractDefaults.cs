using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class LeaseContractDefaults
{
    public const string NoticeHtml = """
        <strong>Importante:</strong> Este acuerdo aplica a <strong>{{PropertyTitle}}</strong> en {{Address}}, {{City}}.
        Los montos mostrados se basan en el alquiler mensual de {{MonthlyRent}}. Las leyes estatales y locales pueden variar.
        Este documento no constituye asesoría legal.
        """;

    public const string BodyHtml = """
        <section class="contract-section">
            <h2>1. Partes y propiedad</h2>
            <p>
                Este Contrato de Arrendamiento Residencial (“Contrato”) se celebra entre
                <strong>{{LandlordName}}</strong> (“Arrendador”) y el arrendatario firmante (“Arrendatario”).
            </p>
            <p>
                El Arrendador entrega en arrendamiento al Arrendatario la unidad residencial conocida como
                <strong>{{PropertyTitle}}</strong>, ubicada en
                <strong>{{Address}}, {{City}}</strong> (“Propiedad”),
                con {{Bedrooms}} habitación(es) y {{Bathrooms}} baño(s),
                aproximadamente {{SquareFeet}} m², para uso exclusivo como residencia privada.
            </p>
        </section>
        <section class="contract-section">
            <h2>2. Plazo</h2>
            <p>
                El plazo del arrendamiento comienza el <span class="contract-blank">__ / __ / ____</span>
                y termina el <span class="contract-blank">__ / __ / ____</span>,
                salvo terminación anticipada conforme a este Contrato o la ley aplicable en EE. UU.
            </p>
        </section>
        <section class="contract-section">
            <h2>3. Alquiler</h2>
            <ul>
                <li>Alquiler mensual: <strong>{{MonthlyRent}}</strong>, pagadero el primer día de cada mes.</li>
                <li>Cargo por mora: <strong>{{LateFee}}</strong> o el máximo permitido por la ley del estado, el menor de los dos.</li>
                <li>Método de pago: Zelle a <strong>{{ZelleContact}}</strong>, cheque certificado u otro método aprobado por escrito por el Arrendador.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>4. Depósito de seguridad</h2>
            <p>
                El Arrendatario pagará un depósito de seguridad de <strong>{{SecurityDeposit}}</strong> (equivalente a un mes de alquiler)
                antes de la ocupación. El depósito no es alquiler y no puede usarse como último mes salvo acuerdo escrito.
            </p>
            <ul>
                <li>El Arrendador puede deducir alquileres impagos, daños más allá del uso normal y otros cargos permitidos por ley.</li>
                <li>El saldo se devolverá con un desglose dentro del plazo exigido por la ley del estado aplicable.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>5. Montos de visita y mudanza</h2>
            <ul>
                <li>Depósito de visita / reserva: <strong>{{VisitDeposit}}</strong></li>
                <li>Primer mes + depósito de seguridad: <strong>{{FirstMonthTotal}}</strong></li>
                <li>Total estimado al mudarse (incluye depósito de visita): <strong>{{MoveInTotal}}</strong></li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>6. Teléfonos celulares y dispositivos</h2>
            <ul>
                <li>El Arrendatario puede usar teléfonos y dispositivos inalámbricos conforme a la ley federal, estatal y local de EE. UU.</li>
                <li>El Arrendador no garantiza señal celular ni internet en la unidad.</li>
                <li>No se permiten antenas externas o amplificadores sin consentimiento escrito del Arrendador y cumplimiento de la FCC.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>7. Servicios, mantenimiento y acceso</h2>
            <p>El Arrendatario paga los servicios salvo addendum. El Arrendador mantiene la habitabilidad según la ley y puede ingresar con aviso razonable.</p>
        </section>
        <section class="contract-section">
            <h2>8. Uso, mascotas y cumplimiento</h2>
            <p>El Arrendatario cumplirá las reglas del edificio y todas las leyes de EE. UU. Mascotas, tabaco y modificaciones requieren aprobación escrita.</p>
        </section>
        <section class="contract-section">
            <h2>9. Ley aplicable</h2>
            <p>Este Contrato se rige por la ley de arrendamientos del estado y local aplicable en EE. UU. Las modificaciones deben ser por escrito y firmadas por ambas partes.</p>
        </section>
        """;

    public static LeaseContract CreateForProperty(int propiedadId) => new()
    {
        PropiedadId = propiedadId,
        Title = "Contrato de arrendamiento residencial",
        Subtitle = "Alquiler de apartamento · Estados Unidos",
        NoticeHtml = NoticeHtml,
        BodyHtml = BodyHtml,
        UpdatedAt = DateTime.UtcNow
    };
}
