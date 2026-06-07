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
            Slug = slug,
            FechaCreacion = DateTime.UtcNow
        };
        PropiedadHelper.ApplyInput(propiedad, Input);

        await PropiedadHelper.ApplyFotosAsync(context, propiedad, Input.ParseFotoUrls());
        context.Propiedades.Add(propiedad);
        await context.SaveChangesAsync();

        var contract = PropiedadHelper.ApplyContractInput(propiedad, Input);
        context.LeaseContracts.Add(contract);
        var stampSeal = PropiedadHelper.ApplyStampSealInput(propiedad, Input);
        context.StampSealContracts.Add(stampSeal);
        await context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
