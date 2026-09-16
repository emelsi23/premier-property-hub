using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class FurnitureLocalizer
{
    private static readonly Dictionary<string, (string Es, string En)> Categories = new(StringComparer.OrdinalIgnoreCase)
    {
        ["living-room"] = ("Sala", "Living Room"),
        ["bedroom"] = ("Dormitorio", "Bedroom"),
        ["dining"] = ("Comedor", "Dining"),
        ["home-office"] = ("Oficina en casa", "Home Office"),
        ["outdoor"] = ("Exterior", "Outdoor"),
        ["mattresses"] = ("Colchones", "Mattresses"),
        ["sale"] = ("Ofertas", "Sale")
    };

    public static string CategoryName(FurnitureCategory? category)
    {
        if (category is null)
        {
            return UiText.T("Furniture.Category");
        }

        return CategoryName(category.Slug, category.Name);
    }

    public static string CategoryName(string? slug, string? fallbackName = null)
    {
        if (!string.IsNullOrWhiteSpace(slug) && Categories.TryGetValue(slug, out var pair))
        {
            return SiteCulture.IsEnglish ? pair.En : pair.Es;
        }

        return fallbackName ?? UiText.T("Furniture.Category");
    }

    public static string Short(FurnitureProduct product)
    {
        if (SiteCulture.IsEnglish)
        {
            var fromCatalog = FurnitureCatalogSeed.All.FirstOrDefault(x =>
                x.Sku.Equals(product.Sku, StringComparison.OrdinalIgnoreCase));
            if (fromCatalog is not null && !string.IsNullOrWhiteSpace(fromCatalog.ShortEn))
            {
                return fromCatalog.ShortEn;
            }

            return $"{product.Title} — quality furniture from Ironwood.";
        }

        return product.ShortDescription;
    }

    public static string Description(FurnitureProduct product)
    {
        if (SiteCulture.IsEnglish)
        {
            var fromCatalog = FurnitureCatalogSeed.All.FirstOrDefault(x =>
                x.Sku.Equals(product.Sku, StringComparison.OrdinalIgnoreCase));
            if (fromCatalog is not null && !string.IsNullOrWhiteSpace(fromCatalog.DescriptionEn))
            {
                return fromCatalog.DescriptionEn;
            }

            var room = CategoryName(product.Category?.Slug, product.Category?.Name);
            return $"{product.Title} (SKU {product.Sku}) for your {room.ToLowerInvariant()} space. " +
                   "Ask about finishes, dimensions, and delivery on WhatsApp.";
        }

        return product.Description;
    }
}
