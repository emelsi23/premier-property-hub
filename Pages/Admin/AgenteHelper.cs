using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;

namespace ApartamentosRenta.Pages.Admin;

public static class AgenteHelper
{
    public static async Task<string> BuildSlugAsync(AppDbContext context, string nombre, string? preferredSlug, int? excludeId = null)
    {
        var baseSlug = string.IsNullOrWhiteSpace(preferredSlug)
            ? SlugHelper.FromText(nombre)
            : SlugHelper.FromText(preferredSlug);

        return await SlugHelper.EnsureUniqueAgenteAsync(context, baseSlug, excludeId);
    }

    public static string GenerateVerificationCode()
    {
        const string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        var random = Random.Shared;
        var suffix = new string(Enumerable.Range(0, 4).Select(_ => alphabet[random.Next(alphabet.Length)]).ToArray());
        return $"PPH-{suffix}";
    }

    public static void ApplyInput(Models.Agente agente, AgenteInput input)
    {
        agente.NombreCompleto = input.NombreCompleto.Trim();
        agente.FotoUrl = input.FotoUrl.Trim();
        agente.RolTitulo = input.RolTitulo.Trim();
        agente.Calificacion = Math.Clamp(input.Calificacion, 0m, 5m);
        agente.TotalResenas = Math.Max(0, input.TotalResenas);
        agente.NumeroLicencia = input.NumeroLicencia.Trim();
        agente.EstadoLicencia = input.EstadoLicencia.Trim();
        agente.AnosExperiencia = Math.Max(0, input.AnosExperiencia);
        agente.Biografia = input.Biografia.Trim();
        agente.WhatsAppNumber = input.WhatsAppNumber.Trim();
        agente.Email = input.Email.Trim();
        agente.Telefono = input.Telefono.Trim();
        agente.AreasServicio = input.AreasServicio.Trim();
        agente.Idiomas = string.IsNullOrWhiteSpace(input.Idiomas) ? "Español, Inglés" : input.Idiomas.Trim();
        agente.PropiedadesActivas = Math.Max(0, input.PropiedadesActivas);
        agente.TiempoRespuestaHoras = Math.Clamp(input.TiempoRespuestaHoras, 0m, 168m);
        agente.PorcentajeRespuesta = Math.Clamp(input.PorcentajeRespuesta, 0, 100);
        agente.Verificado = input.Verificado;
        agente.Activo = input.Activo;

        if (!string.IsNullOrWhiteSpace(input.CodigoVerificacion))
        {
            agente.CodigoVerificacion = input.CodigoVerificacion.Trim().ToUpperInvariant();
        }
        else if (string.IsNullOrWhiteSpace(agente.CodigoVerificacion))
        {
            agente.CodigoVerificacion = GenerateVerificationCode();
        }

        if (input.Verificado && agente.FechaVerificacion is null)
        {
            agente.FechaVerificacion = DateTime.UtcNow;
        }

        if (!input.Verificado)
        {
            agente.FechaVerificacion = null;
        }

        agente.FechaActualizacion = DateTime.UtcNow;
    }

    public static AgenteInput FromEntity(Models.Agente agente) => new()
    {
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
        WhatsAppNumber = agente.WhatsAppNumber,
        Email = agente.Email,
        Telefono = agente.Telefono,
        AreasServicio = agente.AreasServicio,
        Idiomas = agente.Idiomas,
        PropiedadesActivas = agente.PropiedadesActivas,
        TiempoRespuestaHoras = agente.TiempoRespuestaHoras,
        PorcentajeRespuesta = agente.PorcentajeRespuesta,
        CodigoVerificacion = agente.CodigoVerificacion,
        Verificado = agente.Verificado,
        Activo = agente.Activo
    };
}
