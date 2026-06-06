using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin;

public class IndexModel(AppDbContext context) : PageModel
{
    public IList<Propiedad> Propiedades { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Propiedades = await context.Propiedades
            .Include(p => p.Fotos)
            .Include(p => p.Citas)
            .OrderByDescending(p => p.FechaCreacion)
            .ToListAsync();
    }

    public string BuildLink(string slug) =>
        $"{Request.Scheme}://{Request.Host}/property/{slug}";
}
