using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public sealed class PropertyContractUiStrings
{
    public required string AmountSummary { get; init; }
    public required string MonthlyRent { get; init; }
    public required string SecurityDeposit { get; init; }
    public required string VisitDeposit { get; init; }
    public required string TenantSignature { get; init; }
    public required string ReviewSign { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string PhoneOptional { get; init; }
    public required string SignAgreement { get; init; }
    public required string RequestChanges { get; init; }
    public required string DrawSignature { get; init; }
    public required string Clear { get; init; }
    public required string AgreeLease { get; init; }
    public required string ProposedChanges { get; init; }
    public required string AdditionalNotes { get; init; }
    public required string SubmitSignature { get; init; }
    public required string BackToProperty { get; init; }
    public required string Print { get; init; }

    public static PropertyContractUiStrings Get(PropertyContentLanguage language) =>
        language == PropertyContentLanguage.Spanish ? Spanish() : English();

    private static PropertyContractUiStrings English() => new()
    {
        AmountSummary = "Amount summary (from monthly rent)",
        MonthlyRent = "Monthly rent",
        SecurityDeposit = "Security deposit",
        VisitDeposit = "Visit deposit",
        TenantSignature = "Tenant signature",
        ReviewSign = "Review the agreement above, then sign or submit proposed changes.",
        FullName = "Full legal name",
        Email = "Email",
        PhoneOptional = "Phone (optional)",
        SignAgreement = "Sign agreement",
        RequestChanges = "Request changes",
        DrawSignature = "Draw your signature",
        Clear = "Clear",
        AgreeLease = "I have read this agreement and agree to its terms.",
        ProposedChanges = "Proposed changes",
        AdditionalNotes = "Additional notes (optional)",
        SubmitSignature = "Submit signature",
        BackToProperty = "← Back to property",
        Print = "Print contract"
    };

    private static PropertyContractUiStrings Spanish() => new()
    {
        AmountSummary = "Resumen de montos (según renta mensual)",
        MonthlyRent = "Renta mensual",
        SecurityDeposit = "Depósito de seguridad",
        VisitDeposit = "Depósito de visita",
        TenantSignature = "Firma del inquilino",
        ReviewSign = "Revise el acuerdo arriba, luego firme o envíe cambios propuestos.",
        FullName = "Nombre legal completo",
        Email = "Correo electrónico",
        PhoneOptional = "Teléfono (opcional)",
        SignAgreement = "Firmar acuerdo",
        RequestChanges = "Solicitar cambios",
        DrawSignature = "Dibuje su firma",
        Clear = "Borrar",
        AgreeLease = "He leído este acuerdo y acepto sus términos.",
        ProposedChanges = "Cambios propuestos",
        AdditionalNotes = "Notas adicionales (opcional)",
        SubmitSignature = "Enviar firma",
        BackToProperty = "← Volver a la propiedad",
        Print = "Imprimir contrato"
    };
}
