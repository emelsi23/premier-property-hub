using ApartamentosRenta.Services;

namespace ApartamentosRenta.Services.Catalog;

internal static class BulkCatalogGenerator
{
    private const decimal SilentDiscountFactor = 0.7m;
    private const int PerStateTarget = 260;

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

    private static readonly MarketCity[] CaliforniaCities =
    [
        new("San Francisco", "CA", "san-francisco", 3600, 1.15m),
        new("San Jose", "CA", "san-jose", 3480, 1.10m),
        new("Los Angeles", "CA", "los-angeles", 2600, 1.00m),
        new("San Diego", "CA", "san-diego", 3000, 1.05m),
        new("Oakland", "CA", "oakland", 2800, 0.98m),
        new("Santa Monica", "CA", "santa-monica", 3200, 1.12m),
        new("Irvine", "CA", "irvine", 3100, 1.08m),
        new("Sacramento", "CA", "sacramento", 2250, 0.88m),
        new("Long Beach", "CA", "long-beach", 2450, 0.92m),
        new("Pasadena", "CA", "pasadena", 2700, 0.96m),
        new("Anaheim", "CA", "anaheim", 2550, 0.94m),
        new("Fremont", "CA", "fremont", 3350, 1.06m),
        new("Berkeley", "CA", "berkeley", 2900, 1.02m),
        new("Santa Clara", "CA", "santa-clara", 3400, 1.09m),
        new("Sunnyvale", "CA", "sunnyvale", 3450, 1.10m),
        new("Palo Alto", "CA", "palo-alto", 3800, 1.18m),
        new("Mountain View", "CA", "mountain-view", 3600, 1.14m),
        new("Manhattan Beach", "CA", "manhattan-beach", 3500, 1.12m),
        new("Huntington Beach", "CA", "huntington-beach", 2850, 1.00m),
        new("Riverside", "CA", "riverside", 2100, 0.82m),
        new("Glendale", "CA", "glendale", 2650, 0.97m),
        new("Burbank", "CA", "burbank", 2750, 0.99m),
        new("Costa Mesa", "CA", "costa-mesa", 2900, 1.01m),
        new("Torrance", "CA", "torrance", 2680, 0.96m),
        new("Santa Barbara", "CA", "santa-barbara", 3150, 1.07m),
        new("West Hollywood", "CA", "west-hollywood", 3050, 1.05m)
    ];

    private static readonly MarketCity[] MinnesotaCities =
    [
        new("Minneapolis", "MN", "minneapolis", 2400, 1.05m),
        new("St. Paul", "MN", "st-paul", 1950, 0.92m),
        new("Edina", "MN", "edina", 2180, 1.00m),
        new("Minnetonka", "MN", "minnetonka", 2995, 1.12m),
        new("Maple Grove", "MN", "maple-grove", 2189, 1.02m),
        new("Eden Prairie", "MN", "eden-prairie", 2050, 0.98m),
        new("Bloomington", "MN", "bloomington", 1820, 0.90m),
        new("Plymouth", "MN", "plymouth", 1980, 0.94m),
        new("Hopkins", "MN", "hopkins", 1850, 0.89m),
        new("St. Louis Park", "MN", "st-louis-park", 2100, 0.96m),
        new("Golden Valley", "MN", "golden-valley", 1906, 0.91m),
        new("Richfield", "MN", "richfield", 1750, 0.87m),
        new("Burnsville", "MN", "burnsville", 1680, 0.85m),
        new("Eagan", "MN", "eagan", 1880, 0.90m),
        new("Woodbury", "MN", "woodbury", 1920, 0.91m),
        new("Lakeville", "MN", "lakeville", 1780, 0.86m),
        new("Chaska", "MN", "chaska", 1770, 0.86m),
        new("Chanhassen", "MN", "chanhassen", 1950, 0.93m),
        new("Rochester", "MN", "rochester", 1663, 0.84m),
        new("Inver Grove Heights", "MN", "inver-grove-heights", 1905, 0.92m),
        new("Brooklyn Park", "MN", "brooklyn-park", 1368, 0.78m),
        new("Coon Rapids", "MN", "coon-rapids", 1420, 0.80m),
        new("Blaine", "MN", "blaine", 1550, 0.83m),
        new("Apple Valley", "MN", "apple-valley", 1620, 0.84m),
        new("Roseville", "MN", "roseville", 1451, 0.79m),
        new("Shoreview", "MN", "shoreview", 1680, 0.85m)
    ];

    public static CatalogProperty[] GenerateAll() =>
        GenerateForState(CaliforniaCities, "ca", 1)
            .Concat(GenerateForState(MinnesotaCities, "mn", 100_000))
            .ToArray();

    private static IEnumerable<CatalogProperty> GenerateForState(MarketCity[] cities, string stateTag, int seedOffset)
    {
        var perCity = (int)Math.Ceiling(PerStateTarget / (double)cities.Length);
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
                var slug = $"rental-{city.SlugKey}-{stateTag}-{unit:D3}";
                var detail = $"Well-located community in {city.Name} with modern interiors, strong transit access, and resort-style shared amenities.";
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

            if (globalIndex >= PerStateTarget)
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

    private sealed record MarketCity(string Name, string StateCode, string SlugKey, decimal BaseTwoBedRent, decimal Tier);
}
