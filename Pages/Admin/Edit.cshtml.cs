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
    public string ContractLinkPreview { get; private set; } = string.Empty;
    public string StampsLinkPreview { get; private set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var propiedad = await context.Propiedades
            .Include(p => p.Fotos)
            .Include(p => p.LeaseContract)
            .Include(p => p.StampSealContract)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (propiedad is null)
        {
            return NotFound();
        }

        Input = PropertyInput.FromEntity(propiedad);
        LinkPreview = $"{Request.Scheme}://{Request.Host}/property/{propiedad.Slug}";
        ContractLinkPreview = $"{Request.Scheme}://{Request.Host}/property/{propiedad.Slug}/contract";
        StampsLinkPreview = $"{Request.Scheme}://{Request.Host}/property/{propiedad.Slug}/stamps";
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
            .Include(p => p.LeaseContract)
            .Include(p => p.StampSealContract)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (propiedad is null)
        {
            return NotFound();
        }

        propiedad.Slug = await PropiedadHelper.BuildSlugAsync(context, Input.Direccion, Input.Ciudad, id);
        PropiedadHelper.ApplyInput(propiedad, Input);
        var contract = PropiedadHelper.ApplyContractInput(propiedad, Input);
        if (propiedad.LeaseContract is null)
        {
            propiedad.LeaseContract = contract;
            context.LeaseContracts.Add(contract);
        }

        var stampSeal = PropiedadHelper.ApplyStampSealInput(propiedad, Input);
        if (propiedad.StampSealContract is null)
        {
            propiedad.StampSealContract = stampSeal;
            context.StampSealContracts.Add(stampSeal);
        }

        await PropiedadHelper.ApplyFotosAsync(context, propiedad, Input.ParseFotoUrls());
        await context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
