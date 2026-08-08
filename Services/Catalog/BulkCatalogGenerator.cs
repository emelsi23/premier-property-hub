namespace ApartamentosRenta.Services.Catalog;

internal static class BulkCatalogGenerator
{
    private const decimal SilentDiscountFactor = 0.7m;
    private static int _globalListingIndex;

    private static readonly string[] StreetNames =
    [
        "Oak", "Maple", "Cedar", "Pine", "Lake", "Park", "Market", "Main", "Broadway", "Washington",
        "Madison", "Jefferson", "Lincoln", "Highland", "Valley", "River", "Summit", "Union", "Central", "Grand",
        "Willow", "Birch", "Elm", "Cherry", "Walnut", "Hickory", "Magnolia", "Laurel", "Hazel", "Aspen"
    ];

    private static readonly string[] StreetTypes = ["St", "Ave", "Blvd", "Dr", "Ln", "Ct", "Way", "Pl"];

    private static readonly string[] PropertyTypes = ["Apartamento", "Condominio", "Townhouse", "Casa en alquiler", "Loft"];

    private static readonly string[][] AmenitySets =
    [
        ["Lavandería en unidad", "Gimnasio", "Acceso controlado", "Casilleros para paquetes", "Se admiten mascotas"],
        ["Terraza en la azotea", "Estudio de fitness", "Estacionamiento en garaje", "Sala coworking", "Carga para vehículos eléctricos"],
        ["Piscina", "Sala club", "Centro de negocios", "Parque para perros", "Almacenamiento para bicicletas"],
        ["Gimnasio", "Patio interior", "Balcón", "Garaje", "Administración en el sitio"],
        ["Piscina", "Spa", "Gimnasio", "Área de juegos", "Estacionamiento para visitas"]
    ];

    private static readonly string[] DescriptionIntros =
    [
        "Luminoso y listo para mudarse, con plano abierto y cocina actualizada.",
        "Ambiente residencial tranquilo con fácil acceso a autopistas y comercios cercanos.",
        "Interiores recién renovados con pisos vinílicos de lujo y encimeras de cuarzo.",
        "Distribución amplia con closets generosos y ventanas grandes.",
        "Barrio caminable cerca de parques, escuelas y opciones de transporte."
    ];

    public static IEnumerable<CatalogProperty> GenerateAll()
    {
        CatalogPhotoLibrary.ResetAssignmentTracking();
        _globalListingIndex = 0;

        var seedOffset = 0;
        foreach (var state in UsRentalMarkets.All)
        {
            var stateTag = state.StateCode.ToLowerInvariant();
            foreach (var property in GenerateForState(
                state.Cities,
                stateTag,
                seedOffset,
                StateListingCounts.GetForState(state.StateCode)))
            {
                yield return property;
            }

            seedOffset += 100_000;
        }
    }

    private static IEnumerable<CatalogProperty> GenerateForState(
        CatalogMarketCity[] cities,
        string stateTag,
        int seedOffset,
        int perStateTarget)
    {
        var perCity = (int)Math.Ceiling(perStateTarget / (double)cities.Length);
        var globalIndex = 0;

        foreach (var city in cities)
        {
            for (var unit = 1; unit <= perCity; unit++)
            {
                globalIndex++;
                if (globalIndex > perStateTarget)
                {
                    yield break;
                }

                var seed = seedOffset + globalIndex * 1_003 + unit * 97;
                var beds = 1 + (seed % 3);
                var baths = beds == 1 ? 1 : beds == 2 ? 2 : 2 + (seed % 2);
                var sqft = beds switch
                {
                    1 => 640 + (seed % 260),
                    2 => 980 + (seed % 340),
                    _ => 1240 + (seed % 480)
                };

                var marketRent = CalculateMarketRent(city.BaseTwoBedRent, city.Tier, beds, unit);
                var listedRent = ApplySilentDiscount(marketRent);
                var propertyType = PropertyTypes[seed % PropertyTypes.Length];
                var street = StreetNames[(seed / 3) % StreetNames.Length];
                var streetType = StreetTypes[(seed / 5) % StreetTypes.Length];
                var streetNumber = 118 + (globalIndex * 137) + (unit * 23) + (seed % 89);
                var unitNumber = 100 + unit + (seed % 40);
                var address = propertyType is "Apartamento" or "Condominio" or "Loft"
                    ? $"{streetNumber} {street} {streetType} #{unitNumber}"
                    : $"{streetNumber} {street} {streetType}";
                var slug = $"rental-us-{stateTag}-{city.SlugKey}-{streetNumber}-{unitNumber}";
                var bedLabel = beds == 1 ? "1 hab" : $"{beds} hab";
                var bathLabel = baths == 1 ? "1 baño" : $"{baths} baños";
                var title = $"{bedLabel} · {bathLabel} {propertyType} · {address}";
                var intro = DescriptionIntros[seed % DescriptionIntros.Length];
                var detail =
                    $"{intro} Este {bedLabel}, {bathLabel} {propertyType.ToLowerInvariant()} en {city.Name} ofrece {sqft:N0} pies² de espacio habitable.";
                var amenities = string.Join(", ", AmenitySets[seed % AmenitySets.Length]);
                var listingIndex = _globalListingIndex++;
                var photos = CatalogPhotoLibrary.AssignExclusivePhotos(listingIndex, slug);

                yield return new CatalogProperty(
                    slug,
                    title,
                    address,
                    $"{city.Name}, {city.StateCode}",
                    listedRent,
                    beds,
                    baths,
                    sqft,
                    CatalogDefaults.BuildDescription(title, $"{city.Name}, {city.StateCode}", detail),
                    amenities,
                    seed % 5,
                    photos);
            }
        }
    }

    private static decimal CalculateMarketRent(decimal baseTwoBed, decimal tier, int beds, int unit)
    {
        var bedFactor = beds switch
        {
            1 => 0.78m,
            2 => 1.00m,
            _ => 1.28m
        };

        var unitVariance = 1m + ((unit % 9) - 4) * 0.018m;
        return Math.Round(baseTwoBed * tier * bedFactor * unitVariance, 0, MidpointRounding.AwayFromZero);
    }

    internal static decimal ApplySilentDiscount(decimal marketRent) =>
        Math.Round(marketRent * SilentDiscountFactor, 0, MidpointRounding.AwayFromZero);
}
