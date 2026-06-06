using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartamentosRenta.Pages.Admin;

public class CreateModel(AppDbContext context) : PageModel
{
    [BindProperty]
    public PropertyInput Input { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!Input.ParseFotoUrls().Any())
        {
            ModelState.AddModelError("Input.FotosUrls", "Add at least one photo URL.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var slug = await PropiedadHelper.BuildSlugAsync(context, Input.Direccion, Input.Ciudad);

        var propiedad = new Propiedad
        {
            Titulo = Input.Titulo.Trim(),
            Slug = slug,
            Descripcion = Input.Descripcion.Trim(),
            Direccion = Input.Direccion.Trim(),
            Ciudad = Input.Ciudad.Trim(),
            PrecioMensual = Input.PrecioMensual,
            Habitaciones = Input.Habitaciones,
            Banos = Input.Banos,
            MetrosCuadrados = Input.MetrosCuadrados,
            Disponible = Input.Disponible,
            Amenidades = Input.Amenidades.Trim(),
            FechaCreacion = DateTime.UtcNow
        };

        await PropiedadHelper.ApplyFotosAsync(context, propiedad, Input.ParseFotoUrls());
        context.Propiedades.Add(propiedad);
        await context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
