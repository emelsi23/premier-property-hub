using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartamentosRenta.Pages.Admin;

public class CreateModel(AppDbContext context, PropertyPhotoUploadService photoUpload) : PageModel
{
    [BindProperty]
    public PropertyInput Input { get; set; } = new();

    [BindProperty]
    public List<IFormFile> FotoUploads { get; set; } = [];

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var urlList = Input.ParseFotoUrls().ToList();

        if (!PropertyInput.HasPhotoSources(urlList, FotoUploads))
        {
            ModelState.AddModelError("FotoUploads", "Sube al menos una imagen o agrega una URL.");
        }

        foreach (var error in photoUpload.ValidateFiles(FotoUploads))
        {
            ModelState.AddModelError("FotoUploads", error);
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

        context.Propiedades.Add(propiedad);
        await context.SaveChangesAsync();

        var uploadedUrls = await photoUpload.SaveAsync(propiedad.Id, FotoUploads);
        var allPhotoUrls = urlList.Concat(uploadedUrls).ToList();
        await PropiedadHelper.ApplyFotosAsync(context, propiedad, allPhotoUrls);

        var contract = PropiedadHelper.ApplyContractInput(propiedad, Input);
        context.LeaseContracts.Add(contract);
        var stampSeal = PropiedadHelper.ApplyStampSealInput(propiedad, Input);
        context.StampSealContracts.Add(stampSeal);
        await context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
