using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Agents;

public class IndexModel(AppDbContext context) : PageModel
{
    public IList<Models.Agente> Agentes { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Agentes = await context.Agentes
            .OrderByDescending(a => a.FechaCreacion)
            .ToListAsync();
    }

    public string BuildProfileLink(string slug) =>
        $"{Request.Scheme}://{Request.Host}/agente/{slug}";

    public string BuildApiLink(string slug) =>
        $"{Request.Scheme}://{Request.Host}/api/agentes/{slug}";
}
