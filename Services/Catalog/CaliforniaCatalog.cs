namespace ApartamentosRenta.Services.Catalog;

internal static class CaliforniaCatalog
{
    public static CatalogProperty[] Properties =>
    [
        Entry("the-avery-san-francisco-ca", "The Avery — San Francisco", "488 Folsom St", "San Francisco, CA", 4200, 2, 2, 1180, 0,
            "SoMa high-rise with Bay views, concierge, and rooftop terrace.", "Concierge, Rooftop Pool, Fitness Center, Pet Spa, Coworking Lounge"),
        Entry("nema-san-francisco-ca", "NEMA San Francisco", "8 Tenth St", "San Francisco, CA", 3950, 1, 1, 780, 1,
            "Award-winning tower steps from Mid-Market and Civic Center.", "Pool, Fitness Center, Basketball Court, Demo Kitchen, 24/7 Security"),
        Entry("the-hayes-san-jose-ca", "The Hayes — San Jose", "55 S Market St", "San Jose, CA", 3480, 2, 2, 1050, 2,
            "Downtown San Jose living near SAP Center and tech employers.", "Rooftop Deck, Fitness Studio, Package Lockers, EV Charging"),
        Entry("miro-san-jose-ca", "Miro San Jose", "955 S First St", "San Jose, CA", 3290, 1, 1, 720, 3,
            "Silicon Valley location with modern studio and 1-bed homes.", "Pool, Yoga Studio, Pet Friendly, Garage Parking"),
        Entry("echelon-san-jose-ca", "Echelon Apartments — San Jose", "350 E Taylor St", "San Jose, CA", 3150, 2, 2, 980, 4,
            "Walkable downtown San Jose community with resort-style amenities.", "Saltwater Pool, Clubroom, Fitness Center, BBQ Areas"),
        Entry("the-grand-la-ca", "The Grand by Gehry — Los Angeles", "100 S Grand Ave", "Los Angeles, CA", 3800, 2, 2, 1100, 0,
            "Iconic DTLA tower with skyline views and luxury finishes.", "Pool, Fitness Center, Screening Room, Valet, Concierge"),
        Entry("avalon-wilshire-la-ca", "Avalon Wilshire — Los Angeles", "1234 Wilshire Blvd", "Los Angeles, CA", 2950, 1, 1, 850, 1,
            "Mid-Wilshire location between DTLA and Westside employment centers.", "Pool, Fitness Center, Pet Friendly, Garage"),
        Entry("figueroa-eight-la-ca", "The Figueroa Eight — Los Angeles", "801 S Figueroa St", "Los Angeles, CA", 2750, 2, 2, 1020, 2,
            "South Park DTLA apartments near LA Live and Crypto.com Arena.", "Rooftop Lounge, Fitness Center, Controlled Access"),
        Entry("ava-little-tokyo-la-ca", "AVA Little Tokyo — Los Angeles", "300 S Los Angeles St", "Los Angeles, CA", 2680, 1, 1, 680, 3,
            "Arts District adjacent community with industrial-chic design.", "Fitness Center, Courtyard, Bike Storage, Pet Friendly"),
        Entry("the-dean-santa-monica-ca", "The Dean — Santa Monica", "1448 Lincoln Blvd", "Santa Monica, CA", 3400, 2, 2, 950, 4,
            "Santa Monica location minutes from the beach and Third Street Promenade.", "Pool, Fitness Center, Rooftop Deck, Package Room"),
        Entry("wilshire-vt-la-ca", "Wilshire Vermont — Los Angeles", "3800 Wilshire Blvd", "Los Angeles, CA", 2550, 1, 1, 750, 0,
            "Koreatown metro-adjacent tower with city views.", "Pool, Fitness Center, Metro Access, Controlled Entry"),
        Entry("park-12-san-diego-ca", "Park 12 — San Diego", "100 Park Blvd", "San Diego, CA", 3200, 2, 2, 1080, 1,
            "East Village high-rise near Petco Park and Gaslamp Quarter.", "Pool, Fitness Center, Concierge, Coworking Space"),
        Entry("pacific-gate-san-diego-ca", "Pacific Gate — San Diego", "888 W E St", "San Diego, CA", 3500, 2, 2, 1150, 2,
            "Waterfront luxury tower with panoramic bay and ocean views.", "Pool, Spa, Fitness Center, Wine Room, Concierge"),
        Entry("eviva-oakland-ca", "EVIVA on Oakland — Oakland", "255 19th St", "Oakland, CA", 2850, 1, 1, 820, 3,
            "Uptown Oakland living near BART and Lake Merritt.", "Rooftop Deck, Fitness Center, Pet Friendly, Garage"),
        Entry("the-landing-oakland-ca", "The Landing — Oakland", "1399 Market St", "West Oakland, CA", 2650, 2, 2, 990, 4,
            "West Oakland community with quick access to San Francisco.", "Pool, Fitness Center, Package Lockers, Bike Storage"),
        Entry("the-press-sacramento-ca", "The Press — Sacramento", "1801 Capitol Ave", "Sacramento, CA", 2250, 2, 2, 1050, 0,
            "Midtown Sacramento loft-style apartments near dining and nightlife.", "Fitness Center, Courtyard, Controlled Access, Garage"),
        Entry("ice-house-sacramento-ca", "ICE House — Sacramento", "1025 R St", "Sacramento, CA", 2100, 1, 1, 720, 1,
            "R Street corridor community in walkable Midtown Sacramento.", "Pool, Fitness Center, Clubroom, Pet Friendly"),
        Entry("irvine-spectrum-ca", "Los Olivos — Irvine Spectrum", "670 Spectrum Center Dr", "Irvine, CA", 3100, 2, 2, 1120, 2,
            "Orange County location at Irvine Spectrum with top-rated schools nearby.", "Pool, Fitness Center, Business Center, Garage"),
        Entry("westdrift-manhattan-beach-ca", "Westdrift — Manhattan Beach", "1400 Parkview Ave", "Manhattan Beach, CA", 3600, 2, 2, 980, 3,
            "South Bay coastal living between LAX and downtown Manhattan Beach.", "Pool, Fitness Center, Tennis, Pet Friendly"),
        Entry("the-village-mission-viejo-ca", "The Village at Mission Viejo", "26051 Marguerite Pkwy", "Mission Viejo, CA", 2800, 2, 2, 1040, 4,
            "Master-planned South Orange County community with lake and trail access.", "Pool, Fitness Center, Clubhouse, Covered Parking")
    ];

    private static CatalogProperty Entry(
        string slug,
        string title,
        string address,
        string city,
        decimal rent,
        int beds,
        int baths,
        decimal sqft,
        int photoVariant,
        string detail,
        string amenities) =>
        new(
            slug,
            title,
            address,
            city,
            rent,
            beds,
            baths,
            sqft,
            CatalogDefaults.BuildDescription(title, city, detail),
            amenities,
            photoVariant);
}
