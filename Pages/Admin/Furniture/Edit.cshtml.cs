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
            .Include(p => p.Photos).ThenInclude(ph => ph.ColorOption)
            .Include(p => p.ColorOptions)
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
            .Include(p => p.ColorOptions)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }

        CurrentSlug = product.Slug;
        await LoadCategoriesAsync();

        var lines = Input.ParseFotoLines().ToList();
        if (lines.Count == 0 && FotoUploads.All(f => f.Length == 0))
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

        await FurnitureProductHelper.ReplaceColorsAsync(context, product, Input);

        var uploaded = await photoUpload.SaveAsync(product.Id, FotoUploads);
        var uploadColor = string.IsNullOrWhiteSpace(Input.UploadColorName) ? null : Input.UploadColorName.Trim();
        var allLines = lines
            .Concat(uploaded.Select(url => (Url: url, ColorName: uploadColor)))
            .ToList();

        var keptUrls = allLines.Select(x => x.Url).ToHashSet(StringComparer.OrdinalIgnoreCase);
        foreach (var url in product.Photos
                     .Select(p => p.Url)
                     .Where(u => u.StartsWith("/uploads/furniture/", StringComparison.OrdinalIgnoreCase)
                                 && !keptUrls.Contains(u)))
        {
            photoUpload.TryDeleteLocalUrl(url);
        }

        await FurnitureProductHelper.ReplacePhotosAsync(context, product, allLines);
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
