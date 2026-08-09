using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public sealed class AgenteApiResponse
{
    public int Id { get; init; }
    public string NombreCompleto { get; init; } = string.Empty;
    public string Slug { get; init; } = string.Empty;
    public string FotoUrl { get; init; } = string.Empty;
    public string RolTitulo { get; init; } = string.Empty;
    public decimal Calificacion { get; init; }
    public int TotalResenas { get; init; }
    public string NumeroLicencia { get; init; } = string.Empty;
    public string EstadoLicencia { get; init; } = string.Empty;
    public int AnosExperiencia { get; init; }
    public string Biografia { get; init; } = string.Empty;
    public string? Email { get; init; }
    public string? Telefono { get; init; }
    public string? WhatsAppNumber { get; init; }
    public string AreasServicio { get; init; } = string.Empty;
    public string Idiomas { get; init; } = string.Empty;
    public int PropiedadesActivas { get; init; }
    public decimal TiempoRespuestaHoras { get; init; }
    public int PorcentajeRespuesta { get; init; }
    public string CodigoVerificacion { get; init; } = string.Empty;
    public bool Verificado { get; init; }
    public bool Activo { get; init; }
    public DateTime? FechaVerificacion { get; init; }
    public string PerfilUrl { get; init; } = string.Empty;
    public string? WhatsAppUrl { get; init; }

    public static AgenteApiResponse From(Agente agente, string baseUrl)
    {
        var perfilUrl = $"{baseUrl.TrimEnd('/')}/agente/{agente.Slug}";
        var whatsAppUrl = WhatsAppLinkHelper.BuildAgentContactUrl(
            agente.WhatsAppNumber,
            agente.Telefono,
            $"Hola {agente.NombreCompleto}, quiero confirmar que eres agente verificado de Premier Property Hub. Perfil: {perfilUrl}");

        return new AgenteApiResponse
        {
            Id = agente.Id,
            NombreCompleto = agente.NombreCompleto,
            Slug = agente.Slug,
            FotoUrl = agente.FotoUrl,
            RolTitulo = agente.RolTitulo,
            Calificacion = agente.Calificacion,
            TotalResenas = agente.TotalResenas,
            NumeroLicencia = agente.NumeroLicencia,
            EstadoLicencia = agente.EstadoLicencia,
            AnosExperiencia = agente.AnosExperiencia,
            Biografia = agente.Biografia,
            Email = string.IsNullOrWhiteSpace(agente.Email) ? null : agente.Email,
            Telefono = string.IsNullOrWhiteSpace(agente.Telefono) ? null : agente.Telefono,
            WhatsAppNumber = string.IsNullOrWhiteSpace(agente.WhatsAppNumber) ? null : agente.WhatsAppNumber,
            AreasServicio = agente.AreasServicio,
            Idiomas = agente.Idiomas,
            PropiedadesActivas = agente.PropiedadesActivas,
            TiempoRespuestaHoras = agente.TiempoRespuestaHoras,
            PorcentajeRespuesta = agente.PorcentajeRespuesta,
            CodigoVerificacion = agente.CodigoVerificacion,
            Verificado = agente.Verificado,
            Activo = agente.Activo,
            FechaVerificacion = agente.FechaVerificacion,
            PerfilUrl = perfilUrl,
            WhatsAppUrl = whatsAppUrl
        };
    }
}
