namespace ApartamentosRenta.Services;

/// <summary>Public UI strings for Spanish / English. Admin stays in Spanish.</summary>
public static class UiText
{
    private static readonly Dictionary<string, (string Es, string En)> Map = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Nav.Listings"] = ("Listados", "Listings"),
        ["Nav.Affiliate"] = ("Portal afiliado", "Affiliate portal"),
        ["Nav.ViewRentals"] = ("Ver alquileres", "View rentals"),
        ["Nav.OpenMenu"] = ("Abrir menú", "Open menu"),
        ["Nav.ChatWhatsApp"] = ("Chatear por WhatsApp", "Chat on WhatsApp"),
        ["Nav.OpenWhatsApp"] = ("Abrir chat de WhatsApp", "Open WhatsApp chat"),
        ["Nav.Language"] = ("Idioma", "Language"),
        ["Nav.Spanish"] = ("Español", "Spanish"),
        ["Nav.English"] = ("Inglés", "English"),
        ["Footer.Rights"] = ("Todos los derechos reservados.", "All rights reserved."),
        ["Wa.LayoutMessage"] = (
            "Hola, me gustaría ayuda para encontrar un alquiler en Premier Property Hub.",
            "Hi, I would like help finding a rental on Premier Property Hub."),

        ["Catalog.Title"] = ("Buscar alquileres", "Search rentals"),
        ["Catalog.PrevPhoto"] = ("Foto anterior", "Previous photo"),
        ["Catalog.NextPhoto"] = ("Foto siguiente", "Next photo"),
        ["Catalog.CarouselPhotos"] = ("Fotos del carrusel", "Carousel photos"),
        ["Catalog.PhotoN"] = ("Foto {0}", "Photo {0}"),
        ["Catalog.Search"] = ("Buscar", "Search"),
        ["Catalog.SearchPlaceholder"] = ("Ciudad, dirección, amenidades…", "City, address, amenities…"),
        ["Catalog.State"] = ("Estado", "State"),
        ["Catalog.AllStates"] = ("Todos los estados", "All states"),
        ["Catalog.Beds"] = ("Habit.", "Beds"),
        ["Catalog.Any"] = ("Cualquiera", "Any"),
        ["Catalog.MinRent"] = ("Alquiler mín.", "Min rent"),
        ["Catalog.MaxRent"] = ("Alquiler máx.", "Max rent"),
        ["Catalog.Sort"] = ("Orden", "Sort"),
        ["Catalog.SortPriceAsc"] = ("Precio ↑", "Price ↑"),
        ["Catalog.SortPriceDesc"] = ("Precio ↓", "Price ↓"),
        ["Catalog.SortBeds"] = ("Habitaciones", "Bedrooms"),
        ["Catalog.SortNewest"] = ("Más recientes", "Newest"),
        ["Catalog.SearchListings"] = ("Buscar listados", "Search listings"),
        ["Catalog.ClearFilters"] = ("Limpiar filtros", "Clear filters"),
        ["Catalog.Result"] = ("resultado", "result"),
        ["Catalog.Results"] = ("resultados", "results"),
        ["Catalog.PageOf"] = ("Página {0} de {1}", "Page {0} of {1}"),
        ["Catalog.EmptyTitle"] = ("No hay listados que coincidan con tu búsqueda", "No listings match your search"),
        ["Catalog.EmptyBody"] = ("Prueba otro estado, rango de precio o palabra de búsqueda.", "Try another state, price range, or search term."),
        ["Catalog.ViewAll"] = ("Ver todos los alquileres", "View all rentals"),
        ["Catalog.ListingsAria"] = ("Listados de alquiler", "Rental listings"),
        ["Catalog.NoPhoto"] = ("Sin foto", "No photo"),
        ["Catalog.Verified"] = ("Verificado", "Verified"),
        ["Catalog.PerMonth"] = ("/mes", "/mo"),
        ["Catalog.BedsShort"] = ("hab.", "bd"),
        ["Catalog.BathsShort"] = ("baños", "ba"),
        ["Catalog.SqFt"] = ("pies²", "sq ft"),
        ["Catalog.DepositFrom"] = ("Depósito de visita desde ${0}", "Tour deposit from ${0}"),
        ["Catalog.ScheduleTour"] = ("Agendar visita", "Schedule tour"),
        ["Catalog.Prev"] = ("Anterior", "Previous"),
        ["Catalog.Next"] = ("Siguiente", "Next"),
        ["Catalog.Pagination"] = ("Páginas de listados", "Listing pages"),

        ["Trust.Aria"] = ("Por qué confían en nosotros", "Why people trust us"),
        ["Trust.Eyebrow"] = ("Proceso de alquiler confiable", "Trusted rental process"),
        ["Trust.Title"] = ("Diseñado para dar confianza en cada paso", "Built for confidence at every step"),
        ["Trust.Lead"] = (
            "Desde tu primera búsqueda hasta la documentación firmada, Premier Property Hub mantiene el proceso profesional, seguro y transparente.",
            "From your first search to signed paperwork, Premier Property Hub keeps the process professional, secure, and transparent."),
        ["Trust.AlertStrong"] = ("Antes de cualquier pago:", "Before any payment:"),
        ["Trust.AlertBody"] = (
            " verifica que tu agente tenga perfil {0} en este sitio — con foto, licencia y código de verificación. No envíes depósitos, Zelle ni pagos de sellos si no puedes confirmar el perfil oficial.",
            " confirm your agent has a {0} profile on this site — with photo, license, and verification code. Do not send deposits, Zelle, or stamp payments if you cannot confirm the official profile."),
        ["Trust.VerifiedAgent"] = ("Agente verificado", "Verified agent"),
        ["Trust.VerifiedListings"] = ("Listados verificados", "Verified listings"),
        ["Trust.VerifiedListingsBody"] = (
            "Cada propiedad se revisa antes de publicarse. Sin spam ni anuncios falsos — solo hogares reales listos para visitar.",
            "Every property is reviewed before publishing. No spam or fake ads — only real homes ready to tour."),
        ["Trust.SecureTour"] = ("Reserva segura de visita", "Secure tour booking"),
        ["Trust.SecureTourBody"] = (
            "Agenda una visita certificada de 30 minutos con depósito reembolsable y pasos claros.",
            "Book a certified 30-minute tour with a refundable deposit and clear steps."),
        ["Trust.OfficialContracts"] = ("Contratos oficiales", "Official contracts"),
        ["Trust.OfficialContractsBody"] = (
            "Acuerdos de arrendamiento digitales adaptados a cada propiedad con firma electrónica.",
            "Digital lease agreements tailored to each property with e-signature."),
        ["Trust.Stamps"] = ("Sellos y estampillas", "Stamps & seals"),
        ["Trust.StampsBody"] = (
            "Paquetes de documentación oficial cuando se requiera — sellos, estampillas o ambos.",
            "Official documentation packages when required — seals, stamps, or both."),
        ["Trust.AgentBody"] = (
            "Pide el enlace del perfil oficial de tu agente. Debe mostrar licencia, código único y sello de verificación antes de que compartas datos o realices un pago.",
            "Ask for your agent’s official profile link. It must show a license, unique code, and verification badge before you share data or make a payment."),
        ["Trust.SecurePayments"] = ("Pagos seguros", "Secure payments"),
        ["Trust.SecurePaymentsBody"] = (
            "Solo después de verificar al agente: depósito vía Zelle con comprobante y revisión administrativa. Sin perfil verificado, no pagues.",
            "Only after verifying the agent: Zelle deposit with proof and admin review. Without a verified profile, do not pay."),
        ["Trust.LicensedSupport"] = ("Soporte con licencia", "Licensed support"),
        ["Trust.LicensedSupportBody"] = (
            "Nuestro equipo confirma las citas por teléfono o {0} una vez aprobado tu depósito.",
            "Our team confirms appointments by phone or {0} once your deposit is approved."),
        ["Trust.SealPropertyHub"] = ("Centro de propiedades", "Property hub"),
        ["Trust.SealPartner"] = ("Red asociada", "Partner network"),
        ["Trust.SealSecure"] = ("Navegación segura", "Secure browsing"),
        ["Trust.SealContract"] = ("Contrato y sellos", "Contract & seals"),
        ["Trust.SealVerify"] = ("Verifica antes de pagar", "Verify before paying"),
        ["Trust.SealRefund"] = ("Depósito de visita", "Tour deposit"),
        ["Trust.Docs"] = ("Documentos oficiales (PDF):", "Official documents (PDF):"),
        ["Trust.Protocol"] = ("Protocolo de reserva", "Reservation protocol"),
        ["Trust.CashPay"] = ("Pago en efectivo (código de barras)", "Cash payment (barcode)"),

        ["Agent.Verified"] = ("Agente verificado", "Verified agent"),
        ["Agent.Reviews"] = ("reseñas", "reviews"),
        ["Agent.YearsExp"] = ("Años de experiencia", "Years of experience"),
        ["Agent.ActiveProps"] = ("Propiedades activas", "Active listings"),
        ["Agent.ResponseRate"] = ("Tasa de respuesta", "Response rate"),
        ["Agent.ResponseTime"] = ("Tiempo de respuesta", "Response time"),
        ["Agent.ContactWa"] = ("Contactar por WhatsApp", "Contact on WhatsApp"),
        ["Agent.ViewRentals"] = ("Ver alquileres", "View rentals"),
        ["Agent.IdVerify"] = ("Verificación de identidad", "Identity verification"),
        ["Agent.VerifiedBadge"] = ("Verificado", "Verified"),
        ["Agent.AuthTitle"] = ("Perfil autenticado por Premier Property Hub", "Profile authenticated by Premier Property Hub"),
        ["Agent.AuthBody"] = (
            "Este agente está registrado en nuestra red. La licencia y el código de verificación pueden usarse para confirmar que el perfil es legítimo antes de compartir información personal o realizar pagos.",
            "This agent is registered in our network. Use the license and verification code to confirm the profile is legitimate before sharing personal information or making payments."),
        ["Agent.LicenseNumber"] = ("Número de licencia", "License number"),
        ["Agent.LicenseState"] = ("Estado de licencia", "License state"),
        ["Agent.VerifyCode"] = ("Código de verificación", "Verification code"),
        ["Agent.VerifiedOn"] = ("Verificado el", "Verified on"),
        ["Agent.About"] = ("Sobre el agente", "About the agent"),
        ["Agent.Areas"] = ("Áreas de servicio", "Service areas"),
        ["Agent.Languages"] = ("Idiomas", "Languages"),
        ["Agent.DirectContact"] = ("Contacto directo", "Direct contact"),
        ["Agent.Phone"] = ("Teléfono", "Phone"),
        ["Agent.Email"] = ("Email", "Email"),
        ["Agent.PublicProfile"] = ("Perfil público", "Public profile"),
        ["Agent.Tip"] = (
            "Tip: pide al agente que confirme su código {0} antes de enviar documentos o pagos.",
            "Tip: ask the agent to confirm their code {0} before sending documents or payments."),
        ["Agent.RatingAria"] = ("Calificación {0} de 5", "Rating {0} out of 5"),
        ["Agent.Hour"] = ("1 hora", "1 hour"),
        ["Agent.Hours"] = ("{0} horas", "{0} hours"),
        ["Agent.Minutes"] = ("{0} min", "{0} min"),
        ["Agent.WaMessage"] = (
            "Hola {0}, quiero confirmar que eres agente verificado de Premier Property Hub. Perfil: {1}",
            "Hi {0}, I want to confirm you are a verified Premier Property Hub agent. Profile: {1}"),

        ["Property.PerMonth"] = ("/mes", "/mo"),
        ["Property.Beds"] = ("Habitaciones", "Bedrooms"),
        ["Property.Baths"] = ("Baños", "Baths"),
        ["Property.About"] = ("Sobre esta propiedad", "About this property"),
        ["Property.Amenities"] = ("Amenidades", "Amenities"),
        ["Property.PrevPhoto"] = ("Foto anterior", "Previous photo"),
        ["Property.NextPhoto"] = ("Foto siguiente", "Next photo"),
        ["Property.PhotoN"] = ("Foto {0}", "Photo {0}"),
        ["Property.ApplicationTitle"] = ("Solicitud de alquiler", "Rental application"),
        ["Property.ApplicationLead"] = (
            "Reserva tu visita certificada para conocer esta propiedad. Proceso seguro y profesional con depósito totalmente reembolsable.",
            "Book your certified tour to see this property. Secure, professional process with a fully refundable deposit."),
        ["Property.RefundableDeposit"] = ("Depósito reembolsable", "Refundable deposit"),
        ["Property.PaymentProof"] = ("Captura del pago", "Payment screenshot"),
        ["Property.ChatWa"] = ("Chatear por WhatsApp", "Chat on WhatsApp"),

        ["Form.FirstName"] = ("Nombre", "First name"),
        ["Form.LastName"] = ("Apellido", "Last name"),
        ["Form.Dob"] = ("Fecha de nacimiento", "Date of birth"),
        ["Form.Email"] = ("Correo electrónico", "Email address"),
        ["Form.Phone"] = ("Teléfono / WhatsApp", "Phone / WhatsApp"),
        ["Form.VisitDate"] = ("Fecha de visita", "Tour date"),
        ["Form.VisitTime"] = ("Hora de visita", "Tour time"),
        ["Form.Zip"] = ("Código postal", "ZIP code"),
        ["Form.UsCitizen"] = ("¿Eres ciudadano de EE. UU.?", "Are you a U.S. citizen?"),
        ["Form.Occupants"] = ("¿Cuántas personas vivirán en la unidad?", "How many people will live in the unit?"),
        ["Form.LeaseLength"] = ("¿Cuánto tiempo quieres el contrato?", "How long do you want the lease?"),
        ["Form.MoveIn"] = ("Fecha de mudanza más temprana", "Earliest move-in date"),
        ["Form.Smokes"] = ("¿Tú o alguien en la unidad fuma?", "Do you or anyone in the unit smoke?"),
        ["Form.Employed"] = ("¿Estás empleado actualmente?", "Are you currently employed?"),
        ["Form.Employer"] = ("Nombre del empleador / empresa", "Employer / company name"),
        ["Form.Income"] = ("Ingreso mensual o semanal (USD)", "Monthly or weekly income (USD)"),
        ["Form.AvailableFunds"] = ("¿Cuánto tienes disponible ahora para asegurar la propiedad? (USD)", "How much do you have available now to secure the property? (USD)"),
        ["Form.Pets"] = ("¿Tienes mascotas?", "Do you have pets?"),
        ["Form.AcceptDeposit"] = ("¿Aceptas pagar un depósito de reserva si eres aprobado?", "Do you agree to pay a holding deposit if approved?"),
        ["Form.PayTourFee"] = ("¿Pagarás la tarifa de visita certificada?", "Will you pay the certified tour fee?"),
        ["Form.PaymentMethod"] = ("Método de pago", "Payment method"),
        ["Form.Ssn"] = ("SSN / ITIN (opcional)", "SSN / ITIN (optional)"),
        ["Form.SsnHint"] = (
            "Opcional — para verificación de identidad si lo proporcionas.",
            "Optional — for identity verification if you provide it."),
        ["Form.Terms"] = ("Acepto los términos y políticas", "I accept the terms and policies"),
        ["Form.Yes"] = ("Sí", "Yes"),
        ["Form.No"] = ("No", "No"),
        ["Form.Submit"] = ("Enviar solicitud", "Submit application"),
        ["Form.PersonalInfo"] = ("Información personal", "Personal information"),
        ["Form.TourDetails"] = ("Detalles de la visita", "Tour details"),
        ["Form.PropertyArea"] = ("Zona de la propiedad", "Property area"),
        ["Form.TenantInfo"] = ("Información del arrendatario", "Tenant information"),
        ["Form.Employment"] = ("Empleo e ingresos", "Employment & income"),
        ["Form.Additional"] = ("Información adicional", "Additional information"),
        ["Form.CompanyPlaceholder"] = ("Nombre de la empresa", "Company name"),
        ["Form.LeasePlaceholder"] = ("12 meses", "12 months"),
        ["Form.CertifiedProgram"] = ("Programa de visita certificada", "Certified tour program"),
        ["Form.CertifiedProgramBody"] = (
            "Al unirte a nuestro programa de alquiler y pagar la tarifa de solicitud de visita certificada de <strong>${0} USD</strong>, obtienes acceso exclusivo para visitar y alquilar nuestras propiedades disponibles mediante un proceso ordenado, seguro y profesional.",
            "By joining our rental program and paying the certified tour application fee of <strong>${0} USD</strong>, you get exclusive access to tour and rent our available properties through an orderly, secure, and professional process."),
        ["Form.RefundableNote"] = (
            "Este pago es reembolsable al momento de irse de la propiedad.",
            "This payment is refundable when you leave the property."),
        ["Form.RefundBullet1"] = (
            "Si la propiedad no es adecuada, tu tarifa se reembolsa por completo.",
            "If the property is not a fit, your fee is fully refunded."),
        ["Form.RefundBullet2"] = (
            "Si decides alquilar, los ${0} USD se aplican íntegramente a tu depósito de seguridad.",
            "If you decide to rent, the ${0} USD applies in full toward your security deposit."),
        ["Form.RefundBullet3"] = (
            "Reembolso garantizado si llegas a tiempo · Reprograma con al menos 2 horas de anticipación.",
            "Guaranteed refund if you arrive on time · Reschedule at least 2 hours in advance."),
        ["Form.PaymentOptions"] = ("Opciones de pago", "Payment options"),
        ["Form.PayTourFeeAmount"] = (
            "¿Pagarás la tarifa de visita certificada de ${0} USD?",
            "Will you pay the certified tour fee of ${0} USD?"),
        ["Form.ZelleAfterApproval"] = (
            "Tu depósito de visita se paga vía Zelle tras una aprobación rápida.",
            "Your tour deposit is paid via Zelle after a quick approval."),
    };

    public static string T(string key)
    {
        if (!Map.TryGetValue(key, out var pair))
        {
            return key;
        }

        return SiteCulture.IsEnglish ? pair.En : pair.Es;
    }

    public static string T(string key, params object[] args) =>
        string.Format(T(key), args);
}
