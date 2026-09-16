using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Furniture;

public class EditModel(AppDbContext context, FurniturePhotoUploadService photoUpload) : PageModel
{
    [BindProperty]
    public FurnitureProductInput Input { get; set; } = new();

    [BindProperty]
    public List<IFormFile> FotoUploads { get; set; } = [];

    public string CurrentSlug { get; private set; } = string.Empty;

    public List<SelectListItem> CategoryOptions { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var product = await context.FurnitureProducts
            .Include(p => p.Photos)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }

        Input = FurnitureProductInput.FromEntity(product);
        CurrentSlug = product.Slug;
        await LoadCategoriesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var product = await context.FurnitureProducts
            .Include(p => p.Photos)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }

        CurrentSlug = product.Slug;
        await LoadCategoriesAsync();

        var urlList = Input.ParseFotoUrls().ToList();
        if (urlList.Count == 0 && FotoUploads.All(f => f.Length == 0))
        {
            ModelState.AddModelError("FotoUploads", "Deja al menos una foto (URL o archivo nuevo).");
        }

        foreach (var error in photoUpload.ValidateFiles(FotoUploads))
        {
            ModelState.AddModelError("FotoUploads", error);
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        product.Slug = await FurnitureProductHelper.BuildSlugAsync(context, Input.Title, Input.Slug, id);
        FurnitureProductHelper.ApplyInput(product, Input);
        await context.SaveChangesAsync();

        var uploaded = await photoUpload.SaveAsync(product.Id, FotoUploads);
        var allUrls = urlList.Concat(uploaded).ToList();

        var removedLocal = product.Photos
            .Select(p => p.Url)
            .Where(u => u.StartsWith("/uploads/furniture/", StringComparison.OrdinalIgnoreCase)
                        && !allUrls.Contains(u, StringComparer.OrdinalIgnoreCase));
        foreach (var url in removedLocal)
        {
            photoUpload.TryDeleteLocalUrl(url);
        }

        await FurnitureProductHelper.ReplacePhotosAsync(context, product, allUrls);
        CurrentSlug = product.Slug;
        return RedirectToPage("Index");
    }

    private async Task LoadCategoriesAsync()
    {
        CategoryOptions = await context.FurnitureCategories
            .OrderBy(c => c.SortOrder)
            .Select(c => new SelectListItem(c.Name, c.Id.ToString(), c.Id == Input.CategoryId))
            .ToListAsync();
        ViewData["CategoryOptions"] = CategoryOptions;
    }
}
