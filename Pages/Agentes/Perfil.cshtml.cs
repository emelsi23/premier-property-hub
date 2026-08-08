using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Agentes;

public class PerfilModel(AppDbContext context) : PageModel
{
    public Models.Agente PerfilAgente { get; private set; } = null!;

    public string WhatsAppUrl { get; private set; } = string.Empty;

    public string PerfilUrl { get; private set; } = string.Empty;

    public IReadOnlyList<string> AreasList { get; private set; } = [];

    public IReadOnlyList<string> IdiomasList { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        var agente = await context.Agentes
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Slug == slug && a.Activo);

        if (agente is null)
        {
            return NotFound();
        }

        PerfilAgente = agente;
        PerfilUrl = $"{Request.Scheme}://{Request.Host}/agente/{agente.Slug}";
        WhatsAppUrl = WhatsAppLinkHelper.BuildUrl(
            agente.WhatsAppNumber,
            $"Hola {agente.NombreCompleto}, quiero confirmar que eres agente verificado de Premier Property Hub. Perfil: {PerfilUrl}");

        AreasList = SplitCsv(agente.AreasServicio);
        IdiomasList = SplitCsv(agente.Idiomas);
        return Page();
    }

    public static IReadOnlyList<string> SplitCsv(string value) =>
        string.IsNullOrWhiteSpace(value)
            ? []
            : value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    public static string FormatResponseTime(decimal hours) =>
        hours < 1m
            ? $"{Math.Round(hours * 60)} min"
            : hours == 1m
                ? "1 hora"
                : $"{hours:0.#} horas";
}
