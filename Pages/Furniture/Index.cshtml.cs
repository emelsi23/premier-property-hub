using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Furniture;

public class IndexModel(AppDbContext context) : PageModel
{
    public List<FurnitureCategory> Categories { get; private set; } = [];

    public List<FurnitureProduct> Featured { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Categories = await context.FurnitureCategories.AsNoTracking()
            .Where(c => c.IsActive)
            .OrderBy(c => c.SortOrder)
            .ToListAsync();

        Featured = await context.FurnitureProducts.AsNoTracking()
            .Include(p => p.Photos)
            .Where(p => p.IsActive && p.IsFeatured)
            .OrderByDescending(p => p.UpdatedAt)
            .Take(12)
            .ToListAsync();
    }
}
