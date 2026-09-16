using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Furniture;

public class CreateModel(AppDbContext context, FurniturePhotoUploadService photoUpload) : PageModel
{
    [BindProperty]
    public FurnitureProductInput Input { get; set; } = new();

    [BindProperty]
    public List<IFormFile> FotoUploads { get; set; } = [];

    public List<SelectListItem> CategoryOptions { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Input.ColorsText = "Natural Beige|#E8DCC8\nWarm Taupe|#B8A08A\nCharcoal|#2C2C2C\nNavy|#1B2A4A";
        Input.AllowColorPreview = true;
        await LoadCategoriesAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadCategoriesAsync();

        var lines = Input.ParseFotoLines().ToList();
        if (lines.Count == 0 && FotoUploads.All(f => f.Length == 0))
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

        var slug = await FurnitureProductHelper.BuildSlugAsync(context, Input.Title, Input.Slug);
        var product = new FurnitureProduct
        {
            Slug = slug,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        FurnitureProductHelper.ApplyInput(product, Input);

        context.FurnitureProducts.Add(product);
        await context.SaveChangesAsync();

        await FurnitureProductHelper.ReplaceColorsAsync(context, product, Input);

        var uploaded = await photoUpload.SaveAsync(product.Id, FotoUploads);
        var uploadColor = string.IsNullOrWhiteSpace(Input.UploadColorName) ? null : Input.UploadColorName.Trim();
        var allLines = lines
            .Concat(uploaded.Select(url => (Url: url, ColorName: uploadColor)))
            .ToList();
        await FurnitureProductHelper.ReplacePhotosAsync(context, product, allLines);

        return RedirectToPage("Index");
    }

    private async Task LoadCategoriesAsync()
    {
        CategoryOptions = await context.FurnitureCategories
            .Where(c => c.IsActive)
            .OrderBy(c => c.SortOrder)
            .Select(c => new SelectListItem(c.Name, c.Id.ToString(), c.Id == Input.CategoryId))
            .ToListAsync();
        ViewData["CategoryOptions"] = CategoryOptions;
    }
}
