namespace ApartamentosRenta.Services.Catalog;

internal static class CatalogIndex
{
    private static CatalogProperty[]? _all;
    private static Dictionary<string, CatalogProperty>? _bySlug;

    public static CatalogProperty[] All => _all ??= BuildAll();

    public static IReadOnlyDictionary<string, CatalogProperty> BySlug =>
        _bySlug ??= All.ToDictionary(p => p.Slug, StringComparer.OrdinalIgnoreCase);

    private static CatalogProperty[] BuildAll() =>
        FeaturedCatalog.Properties
            .Concat(BulkCatalogGenerator.GenerateAll())
            .GroupBy(p => p.Slug, StringComparer.OrdinalIgnoreCase)
            .Select(g => g.First())
            .ToArray();
}
