namespace ApartamentosRenta.Services.Catalog;

internal sealed record CatalogMarketCity(
    string Name,
    string StateCode,
    string SlugKey,
    decimal BaseTwoBedRent,
    decimal Tier);

internal sealed record CatalogMarketState(string StateCode, CatalogMarketCity[] Cities);
