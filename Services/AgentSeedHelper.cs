using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class AgentSeedHelper
{
    private static readonly DateTime MariaAngelicaVerificationDate =
        new(2019, 1, 4, 0, 0, 0, DateTimeKind.Utc);

    private static readonly DateTime RobertoJGuzmanVerificationDate =
        new(2015, 1, 4, 0, 0, 0, DateTimeKind.Utc);

    private static readonly DateTime MarisolDelgadoVerificationDate =
        new(2017, 1, 4, 0, 0, 0, DateTimeKind.Utc);

    private static readonly DateTime VictorSanchezVerificationDate =
        new(2021, 3, 15, 0, 0, 0, DateTimeKind.Utc);

    private static readonly DateTime BeboVerificationDate =
        new(2020, 6, 8, 0, 0, 0, DateTimeKind.Utc);

    public static async Task EnsureSampleAgentAsync(AppDbContext context)
    {
        await EnsureAgentAsync(context, BuildMariaAngelica());
        await EnsureAgentAsync(context, BuildRobertoJGuzman());
        await EnsureAgentAsync(context, BuildSofiaRamirez());
        await EnsureAgentAsync(context, BuildMarisolDelgado());
        await RenameAgentSlugAsync(context, "victor-sanchez", "victor-lopez");
        await EnsureAgentAsync(context, BuildVictorSanchez());
        await EnsureAgentAsync(context, BuildBebo());
        await SyncAgentWhatsAppFromTelefonoAsync(context);
    }

    private static async Task RenameAgentSlugAsync(AppDbContext context, string fromSlug, string toSlug)
    {
        var from = await context.Agentes.FirstOrDefaultAsync(a => a.Slug == fromSlug);
        if (from is null)
        {
            return;
        }

        var to = await context.Agentes.FirstOrDefaultAsync(a => a.Slug == toSlug);
        if (to is not null)
        {
            return;
        }

        from.Slug = toSlug;
        from.FechaActualizacion = DateTime.UtcNow;
        await context.SaveChangesAsync();
    }

    private static async Task EnsureAgentAsync(AppDbContext context, Agente definition)
    {
        var existing = await context.Agentes
            .FirstOrDefaultAsync(a => a.Slug == definition.Slug);

        if (existing is null)
        {
            context.Agentes.Add(definition);
            await context.SaveChangesAsync();
            Console.WriteLine($"Agente sembrado: {definition.Slug}");
            return;
        }

        existing.NombreCompleto = definition.NombreCompleto;
        if (string.IsNullOrWhiteSpace(existing.FotoUrl)
            || existing.FotoUrl.StartsWith("/images/agents/", StringComparison.OrdinalIgnoreCase)
            || existing.FotoUrl.Contains("unsplash.com", StringComparison.OrdinalIgnoreCase))
        {
            existing.FotoUrl = definition.FotoUrl;
        }
        existing.RolTitulo = definition.RolTitulo;
        existing.Calificacion = definition.Calificacion;
        existing.TotalResenas = definition.TotalResenas;
        existing.NumeroLicencia = definition.NumeroLicencia;
        existing.EstadoLicencia = definition.EstadoLicencia;
        existing.AnosExperiencia = definition.AnosExperiencia;
        existing.Biografia = definition.Biografia;
        if (string.IsNullOrWhiteSpace(existing.Telefono))
        {
            existing.Telefono = definition.Telefono;
        }

        SyncWhatsAppNumber(existing, definition);
        existing.Email = definition.Email;
        existing.AreasServicio = definition.AreasServicio;
        existing.Idiomas = definition.Idiomas;
        existing.PropiedadesActivas = definition.PropiedadesActivas;
        existing.TiempoRespuestaHoras = definition.TiempoRespuestaHoras;
        existing.PorcentajeRespuesta = definition.PorcentajeRespuesta;
        existing.Verificado = definition.Verificado;
        existing.Activo = definition.Activo;
        existing.FechaActualizacion = DateTime.UtcNow;

        if (definition.Slug == "maria-angelica")
        {
            existing.FechaVerificacion = MariaAngelicaVerificationDate;
        }
        else if (definition.Slug == "roberto-j-guzman")
        {
            existing.FechaVerificacion = RobertoJGuzmanVerificationDate;
        }
        else if (definition.Slug == "marisol-delgado")
        {
            existing.FechaVerificacion = MarisolDelgadoVerificationDate;
        }
        else if (definition.Slug == "victor-lopez")
        {
            existing.FechaVerificacion = VictorSanchezVerificationDate;
        }
        else if (definition.Slug == "bebo")
        {
            existing.FechaVerificacion = BeboVerificationDate;
        }
        else if (existing.Verificado && existing.FechaVerificacion is null)
        {
            existing.FechaVerificacion = DateTime.UtcNow;
        }

        await context.SaveChangesAsync();
        Console.WriteLine($"Agente actualizado: {definition.Slug}");
    }

    private static void SyncWhatsAppNumber(Agente existing, Agente definition)
    {
        if (!string.IsNullOrWhiteSpace(existing.WhatsAppNumber)
            && !WhatsAppLinkHelper.UsesSiteDefaultNumber(existing.WhatsAppNumber))
        {
            return;
        }

        var fromTelefono = WhatsAppLinkHelper.TryNormalizeNumber(existing.Telefono);
        if (fromTelefono is not null && fromTelefono != WhatsAppLinkHelper.DefaultNumber)
        {
            existing.WhatsAppNumber = fromTelefono;
            return;
        }

        if (string.IsNullOrWhiteSpace(existing.WhatsAppNumber)
            || WhatsAppLinkHelper.UsesSiteDefaultNumber(existing.WhatsAppNumber))
        {
            existing.WhatsAppNumber = definition.WhatsAppNumber;
        }
    }

    private static async Task SyncAgentWhatsAppFromTelefonoAsync(AppDbContext context)
    {
        var agentes = await context.Agentes.ToListAsync();
        var updated = 0;

        foreach (var agente in agentes)
        {
            var telefonoNorm = WhatsAppLinkHelper.TryNormalizeNumber(agente.Telefono);
            if (telefonoNorm is null || telefonoNorm == WhatsAppLinkHelper.DefaultNumber)
            {
                continue;
            }

            if (!string.IsNullOrWhiteSpace(agente.WhatsAppNumber)
                && !WhatsAppLinkHelper.UsesSiteDefaultNumber(agente.WhatsAppNumber))
            {
                continue;
            }

            agente.WhatsAppNumber = telefonoNorm;
            agente.FechaActualizacion = DateTime.UtcNow;
            updated++;
        }

        if (updated > 0)
        {
            await context.SaveChangesAsync();
            Console.WriteLine($"WhatsApp personal sincronizado para {updated} agente(s).");
        }
    }

    private static string AgentWhatsAppFromTelefono(string telefono) =>
        WhatsAppLinkHelper.ResolveAgentContactNumber(null, telefono)
        ?? WhatsAppLinkHelper.TryNormalizeNumber(telefono)
        ?? telefono;

    private static Agente BuildMariaAngelica() => new()
    {
        NombreCompleto = "Maria Angelica",
        Slug = "maria-angelica",
        FotoUrl = "/images/agents/maria-angelica.png",
        RolTitulo = "Agente inmobiliario RE/MAX · Florida",
        Calificacion = 4.9m,
        TotalResenas = 94,
        NumeroLicencia = "FL-SL-3485921",
        EstadoLicencia = "Florida",
        AnosExperiencia = 6,
        Biografia =
            "Agente licenciada en Florida con enfoque en alquileres residenciales en el sur y centro del estado. Acompaño a clientes en español e inglés con perfiles verificados, visitas coordinadas y documentación clara para un proceso seguro y profesional.",
        WhatsAppNumber = AgentWhatsAppFromTelefono("(458) 331-7759"),
        Email = "maria.angelica@premierpropertyhub.com",
        Telefono = "(458) 331-7759",
        AreasServicio = "Miami, Fort Lauderdale, Orlando, Tampa, Jacksonville, Florida",
        Idiomas = "Español, Inglés",
        PropiedadesActivas = 28,
        TiempoRespuestaHoras = 1m,
        PorcentajeRespuesta = 99,
        CodigoVerificacion = "PPH-M8A3",
        Verificado = true,
        Activo = true,
        FechaVerificacion = MariaAngelicaVerificationDate,
        FechaCreacion = MariaAngelicaVerificationDate,
        FechaActualizacion = DateTime.UtcNow
    };

    private static Agente BuildRobertoJGuzman() => new()
    {
        NombreCompleto = "Roberto J. Guzman",
        Slug = "roberto-j-guzman",
        FotoUrl = "/images/agents/roberto-j-guzman.png",
        RolTitulo = "Agente inmobiliario licenciado · California DRE",
        Calificacion = 4.8m,
        TotalResenas = 156,
        NumeroLicencia = "02154783",
        EstadoLicencia = "California",
        AnosExperiencia = 10,
        Biografia =
            "Agente licenciado por el California Department of Real Estate (DRE) con más de diez años en el mercado de alquileres residenciales. Atiendo clientes en Los Angeles, Orange County, San Diego y el Bay Area con un proceso transparente: perfil verificable, visitas coordinadas, contratos claros y respuesta rápida en español e inglés. Puede confirmar mi licencia y código de verificación en este perfil oficial antes de cualquier trámite.",
        WhatsAppNumber = AgentWhatsAppFromTelefono("+1 (945) 384-6408"),
        Email = "roberto.guzman@premierpropertyhub.com",
        Telefono = "+1 (945) 384-6408",
        AreasServicio = "Los Angeles, Orange County, San Diego, San Francisco, Sacramento, California",
        Idiomas = "Español, Inglés",
        PropiedadesActivas = 36,
        TiempoRespuestaHoras = 1.2m,
        PorcentajeRespuesta = 97,
        CodigoVerificacion = "PPH-RJG7",
        Verificado = true,
        Activo = true,
        FechaVerificacion = RobertoJGuzmanVerificationDate,
        FechaCreacion = RobertoJGuzmanVerificationDate,
        FechaActualizacion = DateTime.UtcNow
    };

    private static Agente BuildSofiaRamirez() => new()
    {
        NombreCompleto = "Sofía Ramírez",
        Slug = "sofia-ramirez",
        FotoUrl = "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?w=640&q=80",
        RolTitulo = "Agente inmobiliario RE/MAX",
        Calificacion = 4.9m,
        TotalResenas = 127,
        NumeroLicencia = "TX-RE-2847193",
        EstadoLicencia = "Texas",
        AnosExperiencia = 8,
        Biografia =
            "Especialista en alquileres residenciales en Houston y el área metropolitana. Ayudo a familias y profesionales a encontrar propiedades verificadas con un proceso transparente, documentación clara y respuesta rápida.",
        WhatsAppNumber = AgentWhatsAppFromTelefono("(945) 384-6408"),
        Email = "sofia.ramirez@premierpropertyhub.com",
        Telefono = "(945) 384-6408",
        AreasServicio = "Houston, Katy, Sugar Land, The Woodlands, Dallas",
        Idiomas = "Español, Inglés",
        PropiedadesActivas = 42,
        TiempoRespuestaHoras = 1.5m,
        PorcentajeRespuesta = 98,
        CodigoVerificacion = "PPH-K7R4",
        Verificado = true,
        Activo = true,
        FechaVerificacion = DateTime.UtcNow,
        FechaCreacion = DateTime.UtcNow,
        FechaActualizacion = DateTime.UtcNow
    };

    private static Agente BuildMarisolDelgado() => new()
    {
        NombreCompleto = "Marisol Delgado",
        Slug = "marisol-delgado",
        FotoUrl = "/images/agents/marisol-delgado.png",
        RolTitulo = "Agente inmobiliario RE/MAX",
        Calificacion = 4.9m,
        TotalResenas = 118,
        NumeroLicencia = "NY-RE-4192837",
        EstadoLicencia = "New York",
        AnosExperiencia = 9,
        Biografia =
            "Agente verificada con amplia experiencia en alquileres residenciales. Guío a mis clientes con transparencia, documentación clara y un proceso seguro desde la primera consulta hasta la firma.",
        WhatsAppNumber = AgentWhatsAppFromTelefono("(945) 384-6408"),
        Email = "marisol.delgado@premierpropertyhub.com",
        Telefono = "(945) 384-6408",
        AreasServicio = "New York, Brooklyn, Queens, Manhattan, Bronx",
        Idiomas = "Español, Inglés",
        PropiedadesActivas = 31,
        TiempoRespuestaHoras = 1m,
        PorcentajeRespuesta = 98,
        CodigoVerificacion = "PPH-MD17",
        Verificado = true,
        Activo = true,
        FechaVerificacion = MarisolDelgadoVerificationDate,
        FechaCreacion = MarisolDelgadoVerificationDate,
        FechaActualizacion = DateTime.UtcNow
    };

    private static Agente BuildVictorSanchez() => new()
    {
        NombreCompleto = "Victor Lopez",
        Slug = "victor-lopez",
        FotoUrl = "https://images.unsplash.com/photo-1560250097-0b93528c311a?w=640&q=80",
        RolTitulo = "Agente inmobiliario verificado · Premier Property Hub",
        Calificacion = 4.9m,
        TotalResenas = 86,
        NumeroLicencia = "FL-SL-5821047",
        EstadoLicencia = "Florida",
        AnosExperiencia = 7,
        Biografia =
            "Agente verificado de Premier Property Hub. Atiendo alquileres residenciales en español e inglés, con visitas coordinadas, perfil público y un proceso claro antes de cualquier pago o reserva.",
        WhatsAppNumber = AgentWhatsAppFromTelefono("(407) 555-0148"),
        Email = "victor.lopez@premierpropertyhub.com",
        Telefono = "(407) 555-0148",
        AreasServicio = "Orlando, Kissimmee, Tampa, Miami, Florida",
        Idiomas = "Español, Inglés",
        PropiedadesActivas = 22,
        TiempoRespuestaHoras = 1m,
        PorcentajeRespuesta = 99,
        CodigoVerificacion = "PPH-VL24",
        Verificado = true,
        Activo = true,
        FechaVerificacion = VictorSanchezVerificationDate,
        FechaCreacion = VictorSanchezVerificationDate,
        FechaActualizacion = DateTime.UtcNow
    };

    private static Agente BuildBebo() => new()
    {
        NombreCompleto = "Bebo",
        Slug = "bebo",
        FotoUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=640&q=80",
        RolTitulo = "Agente inmobiliario verificado · Premier Property Hub",
        Calificacion = 4.8m,
        TotalResenas = 74,
        NumeroLicencia = "TX-RE-6102948",
        EstadoLicencia = "Texas",
        AnosExperiencia = 6,
        Biografia =
            "Agente verificado de Premier Property Hub. Acompaño a clientes en alquileres residenciales con documentación clara, visitas coordinadas y respuesta rápida en español e inglés.",
        WhatsAppNumber = AgentWhatsAppFromTelefono("(713) 555-0192"),
        Email = "bebo@premierpropertyhub.com",
        Telefono = "(713) 555-0192",
        AreasServicio = "Houston, Katy, Sugar Land, Dallas, Texas",
        Idiomas = "Español, Inglés",
        PropiedadesActivas = 18,
        TiempoRespuestaHoras = 1.5m,
        PorcentajeRespuesta = 98,
        CodigoVerificacion = "PPH-BB24",
        Verificado = true,
        Activo = true,
        FechaVerificacion = BeboVerificationDate,
        FechaCreacion = BeboVerificationDate,
        FechaActualizacion = DateTime.UtcNow
    };
}
