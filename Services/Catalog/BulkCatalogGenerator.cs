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

    private static readonly string[] PropertyTypes = ["Apartment", "Condo", "Townhome", "Rental Home", "Loft"];

    private static readonly string[][] AmenitySets =
    [
        ["In-Unit Laundry", "Fitness Center", "Controlled Access", "Package Lockers", "Pet Friendly"],
        ["Rooftop Deck", "Fitness Studio", "Garage Parking", "Coworking Lounge", "EV Charging"],
        ["Pool", "Clubroom", "Business Center", "Dog Park", "Bike Storage"],
        ["Fitness Center", "Courtyard", "Balcony", "Garage", "On-Site Management"],
        ["Pool", "Spa", "Fitness Center", "Playground", "Guest Parking"]
    ];

    private static readonly string[] DescriptionIntros =
    [
        "Bright and move-in ready with an open floor plan and updated kitchen.",
        "Quiet residential setting with easy freeway access and nearby shopping.",
        "Recently refreshed interiors with luxury vinyl flooring and quartz counters.",
        "Spacious layout with generous closet space and large windows.",
        "Walkable neighborhood close to parks, schools, and transit options."
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
                var address = propertyType is "Apartment" or "Condo" or "Loft"
                    ? $"{streetNumber} {street} {streetType} #{unitNumber}"
                    : $"{streetNumber} {street} {streetType}";
                var slug = $"rental-us-{stateTag}-{city.SlugKey}-{streetNumber}-{unitNumber}";
                var bedLabel = beds == 1 ? "1 bd" : $"{beds} bd";
                var bathLabel = baths == 1 ? "1 ba" : $"{baths} ba";
                var title = $"{bedLabel} · {bathLabel} {propertyType} · {address}";
                var intro = DescriptionIntros[seed % DescriptionIntros.Length];
                var detail =
                    $"{intro} This {bedLabel}, {bathLabel} {propertyType.ToLowerInvariant()} in {city.Name} offers {sqft:N0} sq ft of living space.";
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
