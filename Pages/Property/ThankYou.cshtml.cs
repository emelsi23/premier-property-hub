using ApartamentosRenta.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Property;

public class ThankYouModel(AppDbContext context) : PageModel
{
    public string PropertyTitle { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        var propiedad = await context.Propiedades
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Slug == slug);

        if (propiedad is null)
        {
            return NotFound();
        }

        PropertyTitle = propiedad.Titulo;
        Address = $"{propiedad.Direccion}, {propiedad.Ciudad}";
        ViewData["Title"] = "Request received";
        return Page();
    }
}
