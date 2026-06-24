namespace ApartamentosRenta.Services.Catalog;

internal static class BulkCatalogGenerator
{
    private const decimal SilentDiscountFactor = 0.7m;

    private static readonly string[] BuildingPrefixes =
    [
        "The", "Park", "Metro", "Lakeview", "Skyline", "Avalon", "Harbor", "Cedar", "Summit", "Vista",
        "Royal", "Grand", "Urban", "Crown", "Silver", "Golden", "Pacific", "North", "South", "East"
    ];

    private static readonly string[] BuildingNames =
    [
        "Meridian", "Commons", "Heights", "Reserve", "Station", "Pointe", "Crossing", "Terrace", "Flats", "Lofts",
        "Gardens", "Place", "House", "Towers", "Row", "Walk", "Square", "Villas", "Court", "Landing"
    ];

    private static readonly string[] StreetNames =
    [
        "Oak", "Maple", "Cedar", "Pine", "Lake", "Park", "Market", "Main", "Broadway", "Washington",
        "Madison", "Jefferson", "Lincoln", "Highland", "Valley", "River", "Summit", "Union", "Central", "Grand"
    ];

    private static readonly string[] StreetTypes = ["St", "Ave", "Blvd", "Dr", "Way"];

    private static readonly string[][] AmenitySets =
    [
        ["Pool", "Fitness Center", "Controlled Access", "Package Lockers", "Pet Friendly"],
        ["Rooftop Deck", "Fitness Studio", "Garage Parking", "Coworking Lounge", "EV Charging"],
        ["Saltwater Pool", "Clubroom", "Business Center", "Dog Park", "Bike Storage"],
        ["Fitness Center", "Courtyard", "In-Unit Laundry", "Garage", "Concierge"],
        ["Pool", "Spa", "Fitness Center", "Tennis Court", "Guest Suites"]
    ];

    public static IEnumerable<CatalogProperty> GenerateAll()
    {
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
                var seed = seedOffset + globalIndex * 17 + unit * 3;
                var beds = 1 + (seed % 3);
                var baths = beds == 1 ? 1 : beds == 2 ? 2 : 2 + (seed % 2);
                var sqft = beds switch
                {
                    1 => 620 + (seed % 280),
                    2 => 980 + (seed % 320),
                    _ => 1180 + (seed % 450)
                };

                var marketRent = CalculateMarketRent(city.BaseTwoBedRent, city.Tier, beds, unit);
                var listedRent = ApplySilentDiscount(marketRent);
                var prefix = BuildingPrefixes[seed % BuildingPrefixes.Length];
                var name = BuildingNames[(seed / 3) % BuildingNames.Length];
                var title = $"{prefix} {name} — {city.Name}";
                var street = StreetNames[(seed / 5) % StreetNames.Length];
                var streetType = StreetTypes[(seed / 7) % StreetTypes.Length];
                var streetNumber = 100 + (unit * 17) + (seed % 200);
                var address = $"{streetNumber} {street} {streetType}";
                var slug = $"rental-us-{stateTag}-{city.SlugKey}-{unit:D3}";
                var detail =
                    $"Well-located rental home in {city.Name}, {city.StateCode} with modern interiors, strong transit access, and resort-style shared amenities.";
                var amenities = string.Join(", ", AmenitySets[seed % AmenitySets.Length]);
                var photos = CatalogPhotoLibrary.GetPhotosForSlug(slug);

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

            if (globalIndex >= perStateTarget)
            {
                yield break;
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

