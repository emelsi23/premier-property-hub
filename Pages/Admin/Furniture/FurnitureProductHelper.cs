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
        product.AllowColorPreview = input.AllowColorPreview;
        product.UpdatedAt = DateTime.UtcNow;
    }

    public static async Task ReplaceColorsAsync(AppDbContext context, FurnitureProduct product, FurnitureProductInput input)
    {
        var existing = await context.FurnitureColorOptions
            .Where(c => c.ProductId == product.Id)
            .ToListAsync();
        context.FurnitureColorOptions.RemoveRange(existing);
        await context.SaveChangesAsync();

        var order = 0;
        foreach (var (name, hex) in input.ParseColors())
        {
            context.FurnitureColorOptions.Add(new FurnitureColorOption
            {
                ProductId = product.Id,
                Name = name,
                HexColor = hex,
                SortOrder = order,
                IsDefault = order == 0
            });
            order++;
        }

        await context.SaveChangesAsync();
    }

    public static async Task ReplacePhotosAsync(
        AppDbContext context,
        FurnitureProduct product,
        IReadOnlyList<(string Url, string? ColorName)> lines)
    {
        var existing = await context.FurniturePhotos.Where(f => f.ProductId == product.Id).ToListAsync();
        context.FurniturePhotos.RemoveRange(existing);

        var colors = await context.FurnitureColorOptions
            .Where(c => c.ProductId == product.Id)
            .ToListAsync();

        var order = 0;
        foreach (var (url, colorName) in lines.Where(u => !string.IsNullOrWhiteSpace(u.Url)))
        {
            int? colorId = null;
            if (!string.IsNullOrWhiteSpace(colorName))
            {
                var match = colors.FirstOrDefault(c =>
                    c.Name.Equals(colorName, StringComparison.OrdinalIgnoreCase)
                    || c.HexColor.Equals(colorName, StringComparison.OrdinalIgnoreCase));
                colorId = match?.Id;
            }

            context.FurniturePhotos.Add(new FurniturePhoto
            {
                ProductId = product.Id,
                Url = url.Trim(),
                SortOrder = order,
                IsPrimary = order == 0,
                ColorOptionId = colorId
            });
            order++;
        }

        await context.SaveChangesAsync();
    }
}
