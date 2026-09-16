using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Furniture;

public class CategoryModel(AppDbContext context) : PageModel
{
    public FurnitureCategory? Category { get; private set; }

    public List<FurnitureProduct> Products { get; private set; } = [];

    public string Sort { get; private set; } = "featured";

    public async Task<IActionResult> OnGetAsync(string category, string? sort)
    {
        if (string.Equals(category, "item", StringComparison.OrdinalIgnoreCase))
        {
            return NotFound();
        }

        Category = await context.FurnitureCategories.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Slug == category && c.IsActive);

        if (Category is null)
        {
            return Page();
        }

        Sort = string.IsNullOrWhiteSpace(sort) ? "featured" : sort.Trim().ToLowerInvariant();

        var query = context.FurnitureProducts.AsNoTracking()
            .Include(p => p.Photos)
            .Where(p => p.IsActive && p.CategoryId == Category.Id);

        Products = Sort switch
        {
            "price-asc" => await query.OrderBy(p => p.Price).ToListAsync(),
            "price-desc" => await query.OrderByDescending(p => p.Price).ToListAsync(),
            "name" => await query.OrderBy(p => p.Title).ToListAsync(),
            _ => await query
                .OrderByDescending(p => p.IsFeatured)
                .ThenByDescending(p => p.UpdatedAt)
                .ToListAsync()
        };

        return Page();
    }
}
