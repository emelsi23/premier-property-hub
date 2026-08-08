using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class AgentSeedHelper
{
    public static async Task EnsureSampleAgentAsync(AppDbContext context)
    {
        await EnsureAgentAsync(context, BuildMariaAngelica());
        await EnsureAgentAsync(context, BuildRobertoJGuzman());
        await EnsureAgentAsync(context, BuildSofiaRamirez());
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
        existing.FotoUrl = definition.FotoUrl;
        existing.RolTitulo = definition.RolTitulo;
        existing.Calificacion = definition.Calificacion;
        existing.TotalResenas = definition.TotalResenas;
        existing.NumeroLicencia = definition.NumeroLicencia;
        existing.EstadoLicencia = definition.EstadoLicencia;
        existing.AnosExperiencia = definition.AnosExperiencia;
        existing.Biografia = definition.Biografia;
        existing.WhatsAppNumber = definition.WhatsAppNumber;
        existing.Email = definition.Email;
        existing.Telefono = definition.Telefono;
        existing.AreasServicio = definition.AreasServicio;
        existing.Idiomas = definition.Idiomas;
        existing.PropiedadesActivas = definition.PropiedadesActivas;
        existing.TiempoRespuestaHoras = definition.TiempoRespuestaHoras;
        existing.PorcentajeRespuesta = definition.PorcentajeRespuesta;
        existing.Verificado = definition.Verificado;
        existing.Activo = definition.Activo;
        existing.FechaActualizacion = DateTime.UtcNow;

        if (existing.Verificado && existing.FechaVerificacion is null)
        {
            existing.FechaVerificacion = DateTime.UtcNow;
        }

        await context.SaveChangesAsync();
        Console.WriteLine($"Agente actualizado: {definition.Slug}");
    }

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
        WhatsAppNumber = WhatsAppLinkHelper.DefaultNumber,
        Email = "maria.angelica@premierpropertyhub.com",
        Telefono = "(945) 384-6408",
        AreasServicio = "Miami, Fort Lauderdale, Orlando, Tampa, Jacksonville, Florida",
        Idiomas = "Español, Inglés",
        PropiedadesActivas = 28,
        TiempoRespuestaHoras = 1m,
        PorcentajeRespuesta = 99,
        CodigoVerificacion = "PPH-M8A3",
        Verificado = true,
        Activo = true,
        FechaVerificacion = DateTime.UtcNow,
        FechaCreacion = DateTime.UtcNow,
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
        WhatsAppNumber = WhatsAppLinkHelper.DefaultNumber,
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
        FechaVerificacion = DateTime.UtcNow,
        FechaCreacion = DateTime.UtcNow,
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
        WhatsAppNumber = WhatsAppLinkHelper.DefaultNumber,
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
}
