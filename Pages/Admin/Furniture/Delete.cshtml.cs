using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Furniture;

public class DeleteModel(AppDbContext context, FurniturePhotoUploadService photoUpload) : PageModel
{
    public string Title { get; private set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var product = await context.FurnitureProducts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }

        Title = product.Title;
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

        context.FurnitureProducts.Remove(product);
        await context.SaveChangesAsync();
        photoUpload.TryDeleteProductFolder(id);
        return RedirectToPage("Index");
    }
}
