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
        var existing = await context.FurnitureProducts
            .Include(p => p.Photos)
            .ToListAsync();
        var bySku = existing.ToDictionary(p => p.Sku, StringComparer.OrdinalIgnoreCase);

        var now = DateTime.UtcNow;
        var added = 0;
        var refreshed = 0;

        foreach (var s in FurnitureCatalogSeed.All)
        {
            if (!categories.TryGetValue(s.CategorySlug, out var categoryId))
            {
                continue;
            }

            if (bySku.TryGetValue(s.Sku, out var product))
            {
                if (PhotosNeedRefresh(product.Photos, s.Photos))
                {
                    context.FurniturePhotos.RemoveRange(product.Photos);
                    product.Photos = s.Photos.Select((url, i) => new FurniturePhoto
                    {
                        ProductId = product.Id,
                        Url = url,
                        SortOrder = i,
                        IsPrimary = i == 0
                    }).ToList();
                    product.UpdatedAt = now;
                    refreshed++;
                }

                continue;
            }

            var baseSlug = $"{SlugHelper.FromText(s.Title)}-{s.Sku.ToLowerInvariant().Replace("iw-", "", StringComparison.OrdinalIgnoreCase)}";
            var slug = await SlugHelper.EnsureUniqueFurnitureProductAsync(context, baseSlug);

            context.FurnitureProducts.Add(new FurnitureProduct
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
            added++;
        }

        if (added > 0 || refreshed > 0)
        {
            await context.SaveChangesAsync();
            Console.WriteLine($"Furniture catalog: +{added} products, refreshed photos on {refreshed} (library {FurniturePhotoLibrary.Count} unique images).");
        }
    }

    private static bool PhotosNeedRefresh(IReadOnlyList<FurniturePhoto> existing, IReadOnlyList<string> desired)
    {
        if (existing.Count == 0)
        {
            return desired.Count > 0;
        }

        // Refresh if any Unsplash/broken pool URL remains, or set doesn't match catalog assignment.
        if (existing.Any(p =>
                p.Url.Contains("images.unsplash.com", StringComparison.OrdinalIgnoreCase)
                || p.Url.Contains("photo-1532372320572", StringComparison.OrdinalIgnoreCase)
                || p.Url.Contains("photo-1518455027359", StringComparison.OrdinalIgnoreCase)
                || p.Url.Contains("photo-1594026112284", StringComparison.OrdinalIgnoreCase)
                || p.Url.Contains("photo-1593062096033", StringComparison.OrdinalIgnoreCase)
                || p.Url.Contains("photo-1600047509807", StringComparison.OrdinalIgnoreCase)))
        {
            return true;
        }

        var current = existing.OrderBy(p => p.SortOrder).Select(p => p.Url).ToList();
        if (current.Count != desired.Count)
        {
            return true;
        }

        for (var i = 0; i < desired.Count; i++)
        {
            if (!string.Equals(current[i], desired[i], StringComparison.Ordinal))
            {
                return true;
            }
        }

        return false;
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
