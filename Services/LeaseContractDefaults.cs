using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class LeaseContractDefaults
{
    public const string NoticeHtml = """
        <strong>Important:</strong> This agreement is a standard residential lease template for apartment rentals in the United States.
        State and local laws (including security-deposit limits, notice periods, and habitability rules) may vary.
        Both parties should review applicable statutes before signing. This document does not constitute legal advice.
        """;

    public const string BodyHtml = """
        <section class="contract-section">
            <h2>1. Parties &amp; Premises</h2>
            <p>
                This Residential Lease Agreement (“Agreement”) is entered into between
                <span class="contract-blank">Premier Property Hub / ___________________________</span> (“Landlord”)
                and <span class="contract-blank">___________________________</span> (“Tenant”).
            </p>
            <p>
                Landlord leases to Tenant the residential unit located at
                <span class="contract-blank">___________________________</span>,
                Unit <span class="contract-blank">_____</span>,
                <span class="contract-blank">City, State, ZIP</span> (“Premises”), for use solely as a private residence.
            </p>
        </section>
        <section class="contract-section">
            <h2>2. Term</h2>
            <p>
                The lease term begins on <span class="contract-blank">__ / __ / ____</span>
                and ends on <span class="contract-blank">__ / __ / ____</span>,
                unless terminated earlier in accordance with this Agreement or applicable law.
            </p>
        </section>
        <section class="contract-section">
            <h2>3. Rent</h2>
            <ul>
                <li>Monthly rent: <span class="contract-blank">$________</span>, due on the <span class="contract-blank">___</span> day of each month.</li>
                <li>Payment method: Zelle, certified check, money order, or other method approved by Landlord in writing.</li>
                <li>Late fee: <span class="contract-blank">$________</span> or the maximum amount permitted by applicable state law, whichever is less.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>4. Security Deposit</h2>
            <p>
                Tenant shall pay a security deposit of <span class="contract-blank">$________</span> before occupancy.
                The security deposit is not rent and may not be applied as the last month’s rent unless Landlord agrees in writing.
            </p>
            <ul>
                <li>Landlord may deduct for unpaid rent, damages beyond normal wear and tear, and other lawful charges.</li>
                <li>Landlord shall return the balance with an itemized statement within the time required by applicable state and local law.</li>
                <li>Normal wear and tear is not chargeable to Tenant.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>5. Visit &amp; Application Deposit</h2>
            <p>
                Refundable visit deposits paid via Zelle may be credited toward the security deposit or first month’s rent upon execution of this Agreement, if stated in writing.
            </p>
        </section>
        <section class="contract-section">
            <h2>6. Cell Phones, Wireless Devices &amp; Telecommunications</h2>
            <ul>
                <li>Tenant may use personal cell phones and wireless devices in compliance with federal, state, and local law.</li>
                <li>Landlord does not guarantee cellular signal strength or internet availability inside the unit.</li>
                <li>No external antennas or signal boosters without Landlord’s written consent and FCC compliance.</li>
                <li>Tenant is responsible for all mobile carrier charges.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>7. Utilities &amp; Services</h2>
            <p>Unless stated in an addendum, Tenant is responsible for activating and paying all utilities.</p>
        </section>
        <section class="contract-section">
            <h2>8. Use, Occupancy &amp; Compliance</h2>
            <ul>
                <li>Maximum occupants as approved in writing by Landlord.</li>
                <li>No illegal activity or unauthorized commercial use.</li>
                <li>Tenant shall comply with building rules and all applicable U.S. federal, state, and local laws.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>9. Maintenance &amp; Repairs</h2>
            <ul>
                <li>Tenant shall keep the Premises clean and report maintenance issues promptly.</li>
                <li>Landlord shall maintain habitability as required by applicable landlord-tenant law.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>10. Landlord Entry</h2>
            <p>Landlord may enter with reasonable notice as required by state law, except in emergencies.</p>
        </section>
        <section class="contract-section">
            <h2>11. Pets, Smoking &amp; Alterations</h2>
            <ul>
                <li>Pets only with written approval. Service animals handled per Fair Housing Act.</li>
                <li>Smoking and vaping prohibited inside the unit unless allowed in writing.</li>
                <li>No alterations without Landlord’s written consent.</li>
            </ul>
        </section>
        <section class="contract-section">
            <h2>12. Quiet Enjoyment</h2>
            <p>Tenant shall not create excessive noise or disturbances that interfere with neighbors’ quiet enjoyment.</p>
        </section>
        <section class="contract-section">
            <h2>13. Insurance</h2>
            <p>Tenant is encouraged to maintain renter’s insurance covering personal property and liability.</p>
        </section>
        <section class="contract-section">
            <h2>14. Default &amp; Remedies</h2>
            <p>Upon default, Landlord may pursue remedies available under applicable law.</p>
        </section>
        <section class="contract-section">
            <h2>15. Move-Out</h2>
            <p>Tenant shall provide required notice, return keys, and leave the unit broom-clean.</p>
        </section>
        <section class="contract-section">
            <h2>16. Required Disclosures (U.S.)</h2>
            <p>Landlord shall provide separate disclosures required by federal or state law (lead paint, mold, flood zone, etc.).</p>
        </section>
        <section class="contract-section">
            <h2>17. Governing Law</h2>
            <p>This Agreement is governed by the laws of the applicable U.S. state. Amendments must be in writing and signed by both parties.</p>
        </section>
        """;

    public static LeaseContract Create() => new()
    {
        Id = 1,
        Title = "Residential Lease Agreement",
        Subtitle = "Apartment rental · United States",
        NoticeHtml = NoticeHtml,
        BodyHtml = BodyHtml,
        UpdatedAt = DateTime.UtcNow
    };
}
