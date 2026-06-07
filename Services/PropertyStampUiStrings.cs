using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public sealed class PropertyStampUiStrings
{
    public required string PurchaseQuestion { get; init; }
    public required string StampsOnly { get; init; }
    public required string SealsOnly { get; init; }
    public required string BothOptions { get; init; }
    public required string YourTotal { get; init; }
    public required string ClientSignature { get; init; }
    public required string SelectPurchase { get; init; }
    public required string LeaseContractLink { get; init; }

    public static PropertyStampUiStrings Get(PropertyContentLanguage language) =>
        language == PropertyContentLanguage.Spanish ? Spanish() : English();

    private static PropertyStampUiStrings English() => new()
    {
        PurchaseQuestion = "What would you like to purchase?",
        StampsOnly = "Stamps only",
        SealsOnly = "Seals only",
        BothOptions = "Stamps & seals",
        YourTotal = "Your total:",
        ClientSignature = "Client signature",
        SelectPurchase = "Select stamps, seals, or both, then sign to authorize the purchase or submit proposed changes.",
        LeaseContractLink = "Lease contract"
    };

    private static PropertyStampUiStrings Spanish() => new()
    {
        PurchaseQuestion = "¿Qué desea comprar?",
        StampsOnly = "Solo stampillas",
        SealsOnly = "Solo sellos",
        BothOptions = "Stampillas y sellos",
        YourTotal = "Su total:",
        ClientSignature = "Firma del cliente",
        SelectPurchase = "Seleccione stampillas, sellos o ambos, luego firme para autorizar la compra o envíe cambios propuestos.",
        LeaseContractLink = "Contrato de arrendamiento"
    };
}
