using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class LeaseContractDefaults
{
    public const string NoticeHtml = """
        <strong>Important:</strong> This agreement applies to <strong>{{PropertyTitle}}</strong> at {{Address}}, {{City}}.
        Amounts shown are based on the monthly rent of {{MonthlyRent}}. State and local laws may vary.
        This document does not constitute legal advice.
        """;

    public const string BodyHtml = """
        <section class="contract-section">
            <h2>1. Parties &amp; Premises</h2>
            <p>
                This Residential Lease Agreement (“Agreement”) is entered into between
                <strong>{{LandlordName}}</strong> (“Landlord”) and the undersigned tenant (“Tenant”).
            </p>
            <p>
                Landlord leases to Tenant the residential unit known as
                <strong>{{PropertyTitle}}</strong>, located at
                <strong>{{Address}}, {{City}}</strong> (“Premises”),
                with {{Bedrooms}} bedroom(s) and {{Bathrooms}} bathroom(s),
                approximately {{SquareFeet}} sq m, for use solely as a private residence.
            </p>
        </section>
        <section class="contract-section">
            <h2>2. Term</h2>
            <p>
                The lease term begins on <span class="contract-blank">__ / __ / ____</span>
                and ends on <span class="contract-blank">__ / __ / ____</span>,
                unless terminated earlier in accordance with this Agreement or applicable U.S. law.
            </p>
        </section>
        <section class="contract-section">
            <h2>3. Rent</h2>
            <ul>
                <li>Monthly rent: <strong>{{MonthlyRent}}</strong>, due on the 1st day of each month.</li>
                <li>Late fee: <strong>{{LateFee}}</strong> or the maximum permitted by applicable state law, whichever is less.</li>
                <li>Payment method: Zelle to <strong>{{ZelleContact}}</strong>, certified check, or other method approved by Landlord in writing.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>4. Security Deposit</h2>
            <p>
                Tenant shall pay a security deposit of <strong>{{SecurityDeposit}}</strong> (equal to one month’s rent)
                before occupancy. The deposit is not rent and may not be used as the last month’s rent unless agreed in writing.
            </p>
            <ul>
                <li>Landlord may deduct for unpaid rent, damages beyond normal wear and tear, and other lawful charges.</li>
                <li>Balance shall be returned with an itemized statement within the time required by applicable state law.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>5. Visit &amp; Move-In Amounts</h2>
            <ul>
                <li>Visit / holding deposit: <strong>{{VisitDeposit}}</strong></li>
                <li>First month’s rent + security deposit: <strong>{{FirstMonthTotal}}</strong></li>
                <li>Estimated total due at move-in (including visit deposit): <strong>{{MoveInTotal}}</strong></li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>6. Cell Phones &amp; Wireless Devices</h2>
            <ul>
                <li>Tenant may use personal cell phones and wireless devices in compliance with U.S. federal, state, and local law.</li>
                <li>Landlord does not guarantee cellular signal or internet availability in the unit.</li>
                <li>No external antennas or signal boosters without Landlord’s written consent and FCC compliance.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>7. Utilities, Maintenance &amp; Entry</h2>
            <p>Tenant pays utilities unless stated in an addendum. Landlord maintains habitability as required by law and may enter with reasonable notice.</p>
        </section>
        <section class="contract-section">
            <h2>8. Use, Pets &amp; Compliance</h2>
            <p>Tenant shall comply with building rules and all applicable U.S. laws. Pets, smoking, and alterations require written approval.</p>
        </section>
        <section class="contract-section">
            <h2>9. Governing Law</h2>
            <p>This Agreement is governed by applicable U.S. state and local landlord-tenant law. Amendments must be in writing and signed by both parties.</p>
        </section>
        """;

    public static LeaseContract CreateForProperty(int propiedadId) => new()
    {
        PropiedadId = propiedadId,
        Title = "Residential Lease Agreement",
        Subtitle = "Apartment rental · United States",
        NoticeHtml = NoticeHtml,
        BodyHtml = BodyHtml,
        UpdatedAt = DateTime.UtcNow
    };
}
