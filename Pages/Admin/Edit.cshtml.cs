using ApartamentosRenta.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin;

public class EditModel(AppDbContext context) : PageModel
{
    [BindProperty]
    public PropertyInput Input { get; set; } = new();

    public string LinkPreview { get; private set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var propiedad = await context.Propiedades
            .Include(p => p.Fotos)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (propiedad is null)
        {
            return NotFound();
        }

        Input = PropertyInput.FromEntity(propiedad);
        LinkPreview = $"{Request.Scheme}://{Request.Host}/property/{propiedad.Slug}";
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!Input.ParseFotoUrls().Any())
        {
            ModelState.AddModelError("Input.FotosUrls", "Add at least one photo URL.");
        }

        if (!ModelState.IsValid)
        {
            LinkPreview = $"{Request.Scheme}://{Request.Host}/property/preview";
            return Page();
        }

        var propiedad = await context.Propiedades
            .Include(p => p.Fotos)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (propiedad is null)
        {
            return NotFound();
        }

        propiedad.Titulo = Input.Titulo.Trim();
        propiedad.Descripcion = Input.Descripcion.Trim();
        propiedad.Direccion = Input.Direccion.Trim();
        propiedad.Ciudad = Input.Ciudad.Trim();
        propiedad.PrecioMensual = Input.PrecioMensual;
        propiedad.Habitaciones = Input.Habitaciones;
        propiedad.Banos = Input.Banos;
        propiedad.MetrosCuadrados = Input.MetrosCuadrados;
        propiedad.Disponible = Input.Disponible;
        propiedad.Amenidades = Input.Amenidades.Trim();
        propiedad.Slug = await PropiedadHelper.BuildSlugAsync(context, Input.Direccion, Input.Ciudad, id);

        await PropiedadHelper.ApplyFotosAsync(context, propiedad, Input.ParseFotoUrls());
        await context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
