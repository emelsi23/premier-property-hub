using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class StampSealContractDefaults
{
    public const string NoticeHtml = """
        <strong>Important:</strong> This agreement covers the purchase of official <strong>stamps</strong> and/or <strong>seals</strong>
        required for rental documentation related to <strong>{{PropertyTitle}}</strong> at {{Address}}, {{City}}.
        You may select stamps only ({{StampsAmount}}), seals only ({{SealsAmount}}), or both ({{TotalAmount}}).
        """;

    public const string BodyHtml = """
        <section class="contract-section">
            <h2>1. Purpose</h2>
            <p>
                The client (“Purchaser”) agrees to buy official stamps and seals through
                <strong>{{LandlordName}}</strong> for the rental file of
                <strong>{{PropertyTitle}}</strong>, located at <strong>{{Address}}, {{City}}</strong>.
            </p>
        </section>
        <section class="contract-section">
            <h2>2. Items &amp; Fees</h2>
            <ul>
                <li>Official stamps package: <strong>{{StampsAmount}}</strong></li>
                <li>Official seals package: <strong>{{SealsAmount}}</strong></li>
                <li><strong>Total due:</strong> {{TotalAmount}}</li>
            </ul>
            <p>Fees cover preparation, procurement, and recording of required stamp and seal documentation under applicable U.S. state and local rules.</p>
        </section>
        <section class="contract-section">
            <h2>3. Payment</h2>
            <ul>
                <li>Payment method: Zelle to <strong>{{ZelleContact}}</strong> or other method approved in writing.</li>
                <li>Payment is due upon signing this agreement unless otherwise agreed.</li>
                <li>Monthly rent reference for this unit: {{MonthlyRent}} (stamps/seals fees are separate from rent).</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>4. Delivery &amp; Use</h2>
            <ul>
                <li>Stamps and seals are issued for use solely on documents related to this rental transaction.</li>
                <li>Purchaser shall not transfer, resell, or misuse official stamps or seals.</li>
                <li>Processing time: typically 1–3 business days after payment confirmation.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>5. Refunds &amp; Cancellations</h2>
            <p>
                Once stamps or seals are ordered or applied to a file, fees are non-refundable except where required by law.
                If the rental application is cancelled before processing begins, a partial refund may be issued at Landlord’s discretion.
            </p>
        </section>
        <section class="contract-section">
            <h2>6. Acknowledgment</h2>
            <p>
                Purchaser confirms that stamps and seals are required for compliance with local recording and lease formalities,
                and agrees to the total amount of <strong>{{TotalAmount}}</strong>.
            </p>
        </section>
        """;

    public static StampSealContract CreateForProperty(int propiedadId) => new()
    {
        PropiedadId = propiedadId,
        Title = "Stamps & Seals Purchase Agreement",
        Subtitle = "Official documentation · United States",
        NoticeHtml = NoticeHtml,
        BodyHtml = BodyHtml,
        UpdatedAt = DateTime.UtcNow
    };
}
