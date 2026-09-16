using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Furniture;

public class ItemModel(AppDbContext context) : PageModel
{
    public FurnitureProduct? Product { get; private set; }

    public string WhatsAppUrl { get; private set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        Product = await context.FurnitureProducts.AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.Photos)
            .Include(p => p.ColorOptions)
            .FirstOrDefaultAsync(p => p.Slug == slug && p.IsActive);

        if (Product is null)
        {
            return Page();
        }

        var productUrl = $"{Request.Scheme}://{Request.Host}/furniture/item/{Product.Slug}";
        var defaultColor = Product.ColorOptions.OrderBy(c => c.SortOrder).FirstOrDefault();
        var colorPart = defaultColor is null ? "" : $" · Color: {defaultColor.Name}";
        var message =
            $"Hola, me interesa: {Product.Title} (SKU {Product.Sku}){colorPart} — {productUrl}";
        WhatsAppUrl = WhatsAppLinkHelper.BuildUrl(null, message);

        return Page();
    }
}
