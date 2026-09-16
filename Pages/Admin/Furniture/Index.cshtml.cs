using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Furniture;

public class IndexModel(AppDbContext context) : PageModel
{
    public List<FurnitureProduct> Products { get; private set; } = [];

    public string? Query { get; private set; }

    public int? CategoryId { get; private set; }

    public List<SelectListItem> CategoryOptions { get; private set; } = [];

    public async Task OnGetAsync(string? q, int? categoryId)
    {
        Query = q?.Trim();
        CategoryId = categoryId;

        CategoryOptions = await context.FurnitureCategories
            .OrderBy(c => c.SortOrder)
            .Select(c => new SelectListItem(c.Name, c.Id.ToString(), categoryId == c.Id))
            .ToListAsync();

        var query = context.FurnitureProducts
            .AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.Photos)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(Query))
        {
            var term = Query.ToLowerInvariant();
            query = query.Where(p =>
                p.Title.ToLower().Contains(term)
                || p.Sku.ToLower().Contains(term)
                || p.Slug.ToLower().Contains(term));
        }

        if (categoryId is > 0)
        {
            query = query.Where(p => p.CategoryId == categoryId);
        }

        Products = await query
            .OrderByDescending(p => p.UpdatedAt)
            .Take(200)
            .ToListAsync();
    }
}
