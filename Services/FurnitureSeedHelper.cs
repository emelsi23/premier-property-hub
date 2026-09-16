using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class FurnitureSeedHelper
{
    public static async Task EnsureCatalogAsync(AppDbContext context)
    {
        await EnsureCategoriesAsync(context);

        var categories = await context.FurnitureCategories.ToDictionaryAsync(c => c.Slug, c => c.Id);
        var existingSkus = await context.FurnitureProducts
            .Select(p => p.Sku)
            .ToListAsync();
        var existingSkuSet = existingSkus.ToHashSet(StringComparer.OrdinalIgnoreCase);

        var now = DateTime.UtcNow;
        var toAdd = new List<FurnitureProduct>();

        foreach (var s in FurnitureCatalogSeed.All)
        {
            if (existingSkuSet.Contains(s.Sku) || !categories.TryGetValue(s.CategorySlug, out var categoryId))
            {
                continue;
            }

            var baseSlug = $"{SlugHelper.FromText(s.Title)}-{s.Sku.ToLowerInvariant().Replace("iw-", "", StringComparison.OrdinalIgnoreCase)}";
            var slug = await SlugHelper.EnsureUniqueFurnitureProductAsync(context, baseSlug);

            toAdd.Add(new FurnitureProduct
            {
                Title = s.Title,
                Slug = slug,
                Sku = s.Sku,
                ShortDescription = s.Short,
                Description = s.Description,
                Price = s.Price,
                CompareAtPrice = s.CompareAt,
                CategoryId = categoryId,
                IsActive = true,
                IsFeatured = s.Featured,
                CreatedAt = now,
                UpdatedAt = now,
                Photos = s.Photos.Select((url, i) => new FurniturePhoto
                {
                    Url = url,
                    SortOrder = i,
                    IsPrimary = i == 0
                }).ToList()
            });

            existingSkuSet.Add(s.Sku);
        }

        if (toAdd.Count == 0)
        {
            return;
        }

        context.FurnitureProducts.AddRange(toAdd);
        await context.SaveChangesAsync();
        Console.WriteLine($"Furniture catalog seeded: +{toAdd.Count} products (catalog size {FurnitureCatalogSeed.All.Count}).");
    }

    private static async Task EnsureCategoriesAsync(AppDbContext context)
    {
        var definitions = new (string Name, string Slug, int Sort)[]
        {
            ("Living Room", "living-room", 1),
            ("Bedroom", "bedroom", 2),
            ("Dining", "dining", 3),
            ("Home Office", "home-office", 4),
            ("Outdoor", "outdoor", 5),
            ("Mattresses", "mattresses", 6),
            ("Sale", "sale", 7)
        };

        var existing = await context.FurnitureCategories.Select(c => c.Slug).ToListAsync();
        foreach (var (name, slug, sort) in definitions)
        {
            if (existing.Contains(slug, StringComparer.OrdinalIgnoreCase))
            {
                continue;
            }

            context.FurnitureCategories.Add(new FurnitureCategory
            {
                Name = name,
                Slug = slug,
                SortOrder = sort,
                IsActive = true
            });
        }

        await context.SaveChangesAsync();
    }
}
