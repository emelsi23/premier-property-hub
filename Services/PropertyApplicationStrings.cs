using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public sealed class PropertyApplicationStrings
{
    public required string FormTitle { get; init; }
    public required string FormSubtitle { get; init; }
    public required string HighlightRefundable { get; init; }
    public required string HighlightVisit { get; init; }
    public required string HighlightAgent { get; init; }
    public required string SectionPersonal { get; init; }
    public required string SectionVisit { get; init; }
    public required string SectionArea { get; init; }
    public required string SectionTenant { get; init; }
    public required string SectionEmployment { get; init; }
    public required string SectionAdditional { get; init; }
    public required string SectionPayment { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Phone { get; init; }
    public required string Email { get; init; }
    public required string DateOfBirth { get; init; }
    public required string SsnItin { get; init; }
    public required string SsnHint { get; init; }
    public required string VisitDate { get; init; }
    public required string VisitTime { get; init; }
    public required string ZipCode { get; init; }
    public required string UsCitizen { get; init; }
    public required string Occupants { get; init; }
    public required string LeaseLength { get; init; }
    public required string MoveInDate { get; init; }
    public required string Smokes { get; init; }
    public required string Employed { get; init; }
    public required string Employer { get; init; }
    public required string Income { get; init; }
    public required string AvailableFunds { get; init; }
    public required string Pets { get; init; }
    public required string AcceptReservationDeposit { get; init; }
    public required string ProgramTitle { get; init; }
    public required string ProgramIntro { get; init; }
    public required string ProgramBullet1 { get; init; }
    public required string ProgramBullet2 { get; init; }
    public required string ProgramBullet3 { get; init; }
    public required string WillPayVisit { get; init; }
    public required string PaymentMethod { get; init; }
    public required string SelectPaymentMethod { get; init; }
    public required string TermsLabel { get; init; }
    public required string SubmitButton { get; init; }
    public required string Yes { get; init; }
    public required string No { get; init; }
    public required string ServicesTitle { get; init; }
    public required string ServicesSubtitle { get; init; }
    public required string LeaseLink { get; init; }
    public required string StampsLink { get; init; }
    public required string LanguageEnglish { get; init; }
    public required string LanguageSpanish { get; init; }

    public static PropertyApplicationStrings Get(PropertyContentLanguage language, decimal depositAmount)
    {
        var amount = depositAmount.ToString("N0");
        return language == PropertyContentLanguage.Spanish ? Spanish(amount) : English(amount);
    }

    private static PropertyApplicationStrings English(string amount) => new()
    {
        FormTitle = "Rental application",
        FormSubtitle = "Book your certified visit to tour this property. Secure, professional process with a fully refundable deposit.",
        HighlightRefundable = "Refundable deposit",
        HighlightVisit = "30-minute visit",
        HighlightAgent = "Licensed agent",
        SectionPersonal = "Personal information",
        SectionVisit = "Visit details",
        SectionArea = "Property area",
        SectionTenant = "Tenant information",
        SectionEmployment = "Employment & income",
        SectionAdditional = "Additional information",
        SectionPayment = "Payment options",
        FirstName = "First name",
        LastName = "Last name",
        Phone = "Phone / WhatsApp",
        Email = "Email address",
        DateOfBirth = "Date of birth",
        SsnItin = "SSN / ITIN",
        SsnHint = "Required for identity verification.",
        VisitDate = "Visit date",
        VisitTime = "Visit time",
        ZipCode = "Zip code",
        UsCitizen = "Are you a U.S. citizen?",
        Occupants = "How many people will live in the unit?",
        LeaseLength = "How long do you want the lease?",
        MoveInDate = "Earliest move-in date",
        Smokes = "Do you or anyone living in the unit smoke?",
        Employed = "Are you currently employed?",
        Employer = "Employer / company name",
        Income = "Monthly or weekly income (USD)",
        AvailableFunds = "How much do you have available now to secure the property? (USD)",
        Pets = "Do you have pets?",
        AcceptReservationDeposit = "Do you accept paying a reservation deposit if approved?",
        ProgramTitle = "Certified visit program",
        ProgramIntro = $"By joining our rental program and paying the certified visit application fee of ${amount} USD, you get exclusive access to tour and rent our available properties.",
        ProgramBullet1 = "If the property is not a fit, your fee is fully refunded.",
        ProgramBullet2 = $"If you decide to rent, the ${amount} USD is fully applied toward your security deposit.",
        ProgramBullet3 = "Guaranteed refund when you arrive on time · Reschedule with at least 2 hours notice.",
        WillPayVisit = $"Will you pay the certified visit fee of ${amount} USD?",
        PaymentMethod = "Payment method",
        SelectPaymentMethod = "Select a payment method",
        TermsLabel = "I agree to the terms and policies",
        SubmitButton = "Submit application",
        Yes = "Yes",
        No = "No",
        ServicesTitle = "Documents & services",
        ServicesSubtitle = "Complete these steps for this property when you are ready.",
        LeaseLink = "Lease contract",
        StampsLink = "Stamps & seals",
        LanguageEnglish = "English",
        LanguageSpanish = "Español"
    };

    private static PropertyApplicationStrings Spanish(string amount) => new()
    {
        FormTitle = "Solicitud de alquiler",
        FormSubtitle = "Reserva tu cita certificada para visitar la propiedad. Proceso seguro, profesional y con depósito totalmente reembolsable.",
        HighlightRefundable = "Depósito reembolsable",
        HighlightVisit = "Cita en 30 minutos",
        HighlightAgent = "Corredor autorizado",
        SectionPersonal = "Información personal",
        SectionVisit = "Detalles de la cita",
        SectionArea = "Zona de la vivienda",
        SectionTenant = "Información del inquilino",
        SectionEmployment = "Empleo e ingresos",
        SectionAdditional = "Información adicional",
        SectionPayment = "Opciones de pago",
        FirstName = "Nombre",
        LastName = "Apellido",
        Phone = "Teléfono / WhatsApp",
        Email = "Correo electrónico",
        DateOfBirth = "Fecha de nacimiento",
        SsnItin = "SSN / ITIN",
        SsnHint = "Requerido para verificación de identidad.",
        VisitDate = "Fecha de la cita",
        VisitTime = "Hora de la cita",
        ZipCode = "Código postal",
        UsCitizen = "¿Es usted ciudadano/a americano?",
        Occupants = "¿Cuántas personas vivirán en la unidad?",
        LeaseLength = "¿Por cuánto tiempo quiere el contrato?",
        MoveInDate = "¿Cuál es la fecha más temprana en la que puede mudarse?",
        Smokes = "¿Usted fuma o alguien que va a vivir en la propiedad fuma?",
        Employed = "¿Está usted empleado actualmente?",
        Employer = "Nombre de la compañía donde trabaja",
        Income = "Salario mensual o semanal (USD)",
        AvailableFunds = "¿Cuánto tiene disponible ahora para asegurar la propiedad? (USD)",
        Pets = "¿Tiene mascotas?",
        AcceptReservationDeposit = "¿Acepta pagar un depósito de reserva si se aprueba?",
        ProgramTitle = "Programa de renta y cita certificada",
        ProgramIntro = $"Al ingresar a nuestro Programa de Renta mediante el pago de la Aplicación de Cita Certificada por ${amount} USD, obtiene acceso exclusivo para visitar y alquilar nuestras propiedades disponibles.",
        ProgramBullet1 = "Si la propiedad no es de su agrado, se reembolsa en su totalidad.",
        ProgramBullet2 = $"Si decide alquilar, los ${amount} USD se descuentan del depósito de seguridad.",
        ProgramBullet3 = "Reembolso garantizado al llegar puntualmente · Reprogramación con 2 h de aviso.",
        WillPayVisit = $"¿Pagará la cita certificada de ${amount} USD?",
        PaymentMethod = "Método de pago",
        SelectPaymentMethod = "Selecciona un método de pago",
        TermsLabel = "Estoy de acuerdo con los términos y políticas",
        SubmitButton = "Enviar solicitud",
        Yes = "Sí",
        No = "No",
        ServicesTitle = "Documentos y servicios",
        ServicesSubtitle = "Complete estos pasos para esta propiedad cuando esté listo.",
        LeaseLink = "Contrato de arrendamiento",
        StampsLink = "Stampillas y sellos",
        LanguageEnglish = "English",
        LanguageSpanish = "Español"
    };
}
