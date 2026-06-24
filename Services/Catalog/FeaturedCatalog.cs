namespace ApartamentosRenta.Services.Catalog;

internal static class FeaturedCatalog
{
    public static CatalogProperty[] Properties =>
    [
        new(
            "7025-agate-trail-inver-grove-heights-mn",
            "Ives of Inver Grove — Luxury 2 Bed Apartment",
            "7025 Agate Trail",
            "Inver Grove Heights, MN",
            1905,
            2,
            2,
            1120,
            """
            Tucked in a quiet pocket of Inver Grove Heights—just minutes from downtown St. Paul—Ives of Inver Grove brings understated elegance to everyday living. Soft-close cabinetry, built-in benches, and natural finishes throughout every home.

            This 2-bedroom, 2-bath residence offers boutique-inspired interiors with refined finishes, expansive windows, and thoughtfully designed living spaces. The community features a 24/7 fitness center, saltwater pool, remote work lounges, on-site speakeasy, rooftop terrace with grilling stations, golf simulator lounge, and controlled-access entry.
            """.Trim(),
            "24/7 Fitness Center, Saltwater Pool, Speakeasy Lounge, Rooftop Deck, Golf Simulator, Remote Work Lounges, Controlled Access, Package Lockers, Pet Friendly",
            0,
            IvesPhotos),
    ];

    private static readonly string[] IvesPhotos =
    [
        "https://ivesinvergrove.com/application/files/5617/7920/5117/penthouse-living-room-kitchen..jpg",
        "https://ivesinvergrove.com/application/files/6817/7928/9201/ives-inver-grove-pool.jpg",
        "https://ivesinvergrove.com/application/files/3617/7915/8363/ives-inver-grove-apartments-exterior.jpg",
        "https://ivesinvergrove.com/application/files/1317/7915/8364/apartment-golf-simulator-lounge.jpg",
        "https://ivesinvergrove.com/application/files/3917/7915/8364/apartment-fitness-center-spin-bikes.jpg",
        "https://ivesinvergrove.com/application/files/2617/7915/8364/apartment-speakeasy-lounge.jpg",
        "https://ivesinvergrove.com/application/files/8917/7919/1596/apartment-rooftop-terrace.jpg",
        "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=960&h=640&fit=crop&q=80&auto=format",
    ];
}
