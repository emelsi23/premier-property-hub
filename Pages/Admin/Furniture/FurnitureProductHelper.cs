using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Furniture;

public static class FurnitureProductHelper
{
    public static async Task<string> BuildSlugAsync(AppDbContext context, string title, string? preferredSlug, int? excludeId = null)
    {
        var baseSlug = string.IsNullOrWhiteSpace(preferredSlug)
            ? SlugHelper.FromText(title)
            : AdminUsers.Slugify(preferredSlug);

        if (string.IsNullOrEmpty(baseSlug))
        {
            baseSlug = SlugHelper.FromText(title);
        }

        return await SlugHelper.EnsureUniqueFurnitureProductAsync(context, baseSlug, excludeId);
    }

    public static void ApplyInput(FurnitureProduct product, FurnitureProductInput input)
    {
        product.Title = input.Title.Trim();
        product.Sku = input.Sku.Trim();
        product.ShortDescription = input.ShortDescription.Trim();
        product.Description = input.Description.Trim();
        product.Price = input.Price;
        product.CompareAtPrice = input.CompareAtPrice is > 0 ? input.CompareAtPrice : null;
        product.CategoryId = input.CategoryId;
        product.IsActive = input.IsActive;
        product.IsFeatured = input.IsFeatured;
        product.UpdatedAt = DateTime.UtcNow;
    }

    public static async Task ReplacePhotosAsync(AppDbContext context, FurnitureProduct product, IReadOnlyList<string> urls)
    {
        var existing = await context.FurniturePhotos.Where(f => f.ProductId == product.Id).ToListAsync();
        context.FurniturePhotos.RemoveRange(existing);

        var order = 0;
        foreach (var url in urls.Where(u => !string.IsNullOrWhiteSpace(u)))
        {
            context.FurniturePhotos.Add(new FurniturePhoto
            {
                ProductId = product.Id,
                Url = url.Trim(),
                SortOrder = order,
                IsPrimary = order == 0
            });
            order++;
        }

        await context.SaveChangesAsync();
    }
}
