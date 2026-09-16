using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Furniture;

public class IndexModel(AppDbContext context) : PageModel
{
    public List<FurnitureCategory> Categories { get; private set; } = [];

    public List<FurnitureProduct> Featured { get; private set; } = [];

    public List<FurnitureProduct> OnSale { get; private set; } = [];

    public List<FurnitureProduct> Newest { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Categories = await context.FurnitureCategories.AsNoTracking()
            .Where(c => c.IsActive)
            .OrderBy(c => c.SortOrder)
            .ToListAsync();

        Featured = await context.FurnitureProducts.AsNoTracking()
            .Include(p => p.Photos)
            .Include(p => p.Category)
            .Where(p => p.IsActive && p.IsFeatured)
            .OrderByDescending(p => p.UpdatedAt)
            .Take(12)
            .ToListAsync();

        OnSale = await context.FurnitureProducts.AsNoTracking()
            .Include(p => p.Photos)
            .Where(p => p.IsActive && p.CompareAtPrice != null && p.CompareAtPrice > p.Price)
            .OrderByDescending(p => p.UpdatedAt)
            .Take(10)
            .ToListAsync();

        Newest = await context.FurnitureProducts.AsNoTracking()
            .Include(p => p.Photos)
            .Where(p => p.IsActive)
            .OrderByDescending(p => p.CreatedAt)
            .Take(10)
            .ToListAsync();
    }
}
