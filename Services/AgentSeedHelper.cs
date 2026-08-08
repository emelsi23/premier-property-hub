using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class AgentSeedHelper
{
    public static async Task EnsureSampleAgentAsync(AppDbContext context)
    {
        if (await context.Agentes.AnyAsync())
        {
            return;
        }

        var agente = new Agente
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

        context.Agentes.Add(agente);
        await context.SaveChangesAsync();
        Console.WriteLine("Agente de ejemplo sembrado: sofia-ramirez");
    }
}
