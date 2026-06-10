namespace ApartamentosRenta.Services.Catalog;

internal static class MinnesotaCatalog
{
    public static CatalogProperty[] Properties =>
    [
        Entry("7025-agate-trail-inver-grove-heights-mn", "Ives of Inver Grove — Luxury 2 Bed", "7025 Agate Trail", "Inver Grove Heights, MN", 1905, 2, 2, 1120, 0,
            "New luxury community minutes from downtown St. Paul with speakeasy, pool, and rooftop deck.",
            "Saltwater Pool, Speakeasy, Rooftop Deck, Golf Simulator, 24/7 Fitness",
            IvesPhotos),
        Entry("the-luxe-ridgedale-minnetonka-mn", "The Luxe at Ridgedale — Minnetonka", "12501 Ridgedale Dr", "Minnetonka, MN", 2995, 2, 2, 1504, 1,
            "Premium west-metro apartments at Ridgedale Center with designer finishes.", "Pool, Fitness Center, Concierge, Garage Parking"),
        Entry("eleven-co-minneapolis-mn", "Eleven Co — Minneapolis", "1100 S Marquette Ave", "Minneapolis, MN", 2450, 1, 1, 820, 2,
            "Downtown Minneapolis high-rise steps from Nicollet Mall and the Mississippi riverfront.", "Rooftop Lounge, Fitness Center, Coworking, Concierge"),
        Entry("latitude-45-minneapolis-mn", "Latitude 45 — Minneapolis", "313 Washington Ave N", "Minneapolis, MN", 2350, 2, 2, 1050, 3,
            "North Loop loft-style living in Minneapolis warehouse district.", "Fitness Center, Courtyard, Pet Friendly, Garage"),
        Entry("flux-minneapolis-mn", "Flux Apartments — Minneapolis", "1300 Nicollet Mall", "Minneapolis, MN", 2280, 1, 1, 760, 4,
            "Nicollet Mall address with walkable access to downtown employers and dining.", "Pool, Fitness Center, Skyway Access, Package Room"),
        Entry("nic-on-fifth-minneapolis-mn", "The Nic on Fifth — Minneapolis", "465 Nicollet Mall", "Minneapolis, MN", 2600, 2, 2, 1100, 0,
            "Luxury tower on Nicollet Mall with panoramic city views.", "Pool, Fitness Center, Concierge, Valet Parking"),
        Entry("mill-district-minneapolis-mn", "Mill District City Apartments", "300 S 2nd St", "Minneapolis, MN", 2200, 2, 2, 980, 1,
            "Historic Mill District location near Guthrie Theater and Stone Arch Bridge.", "Fitness Center, River Views, Controlled Access"),
        Entry("village-green-edina-mn", "Village Green — Edina", "7300 York Ave S", "Edina, MN", 2180, 2, 2, 1050, 2,
            "Edina 55435 location near Southdale and top Twin Cities schools.", "Pool, Fitness Center, Tennis, Garage"),
        Entry("onesouthdale-edina-mn", "OneSouthdale — Edina", "6800 France Ave S", "Edina, MN", 2400, 2, 2, 1120, 3,
            "Walkable Edina community adjacent to Southdale Center.", "Pool, Fitness Studio, Clubroom, Pet Friendly"),
        Entry("elysian-edina-mn", "The Elysian — Edina", "5100 Edina Industrial Blvd", "Edina, MN", 2550, 1, 1, 880, 4,
            "Boutique Edina apartments with modern interiors and west-metro convenience.", "Fitness Center, Courtyard, Garage, Package Lockers"),
        Entry("pinnacle-st-louis-park-mn", "Pinnacle on Lake — St. Louis Park", "3800 Dakota Ave S", "St. Louis Park, MN", 2100, 2, 2, 1020, 0,
            "St. Louis Park community on Cedar Lake with quick Minneapolis access.", "Pool, Fitness Center, Lake Access, Pet Friendly"),
        Entry("city-vue-eden-prairie-mn", "City Vue — Eden Prairie", "8255 Eden Prairie Rd", "Eden Prairie, MN", 2050, 2, 2, 1080, 1,
            "Eden Prairie location near major corporate campuses and southwest metro trails.", "Pool, Fitness Center, Business Center, Garage"),
        Entry("voyager-plymouth-mn", "Voyager at Plymouth Town Center", "4300 Plymouth Blvd", "Plymouth, MN", 1980, 2, 2, 1040, 2,
            "Plymouth Town Center apartments with shopping and dining at your doorstep.", "Fitness Center, Clubroom, Garage, Controlled Access"),
        Entry("the-grove-maple-grove-mn", "The Grove — Maple Grove", "9750 Grove Dr N", "Maple Grove, MN", 2189, 2, 2, 1150, 3,
            "Maple Grove premium community near Arbor Lakes retail district.", "Pool, Fitness Center, Dog Park, Garage"),
        Entry("park-place-maple-grove-mn", "Park Place — Maple Grove", "12000 Elm Creek Blvd N", "Maple Grove, MN", 2050, 1, 1, 780, 4,
            "Northwest metro living with Arbor Lakes shopping and freeway access.", "Fitness Center, Courtyard, Package Room, Pet Friendly"),
        Entry("the-pacer-golden-valley-mn", "The Pacer — Golden Valley", "800 Olson Memorial Hwy", "Golden Valley, MN", 1906, 2, 2, 990, 0,
            "Golden Valley location between Minneapolis and western suburbs.", "Pool, Fitness Center, Garage, Bike Storage"),
        Entry("station-44-hopkins-mn", "Station 44 — Hopkins", "44 N 8th Ave", "Hopkins, MN", 1850, 1, 1, 720, 1,
            "Hopkins main street living on the Southwest LRT corridor.", "Fitness Center, Courtyard, Transit Access, Pet Friendly"),
        Entry("crossings-penn-richfield-mn", "The Crossings at Penn — Richfield", "6416 Penn Ave S", "Richfield, MN", 1750, 2, 2, 950, 2,
            "Richfield apartments with quick access to MSP Airport and Mall of America.", "Pool, Fitness Center, Garage, Playground"),
        Entry("vantage-bloomington-mn", "Vantage Apartments — Bloomington", "9800 Lyndale Ave S", "Bloomington, MN", 1820, 2, 2, 1000, 3,
            "Bloomington location near Mall of America and MSP International Airport.", "Pool, Fitness Center, Business Center, Garage"),
        Entry("stonebridge-lofts-st-paul-mn", "Stonebridge Lofts — St. Paul", "101 E 7th St", "St. Paul, MN", 1950, 1, 1, 840, 4,
            "Downtown St. Paul loft living near Xcel Energy Center and Lowertown.", "Fitness Center, Rooftop Terrace, Skyway, Controlled Access")
    ];

    private static readonly string[] IvesPhotos =
        CatalogPhotoLibrary.MergeWithListingPhotos(
        [
            "https://ivesinvergrove.com/application/files/5617/7920/5117/penthouse-living-room-kitchen..jpg",
            "https://ivesinvergrove.com/application/files/6817/7928/9201/ives-inver-grove-pool.jpg",
            "https://ivesinvergrove.com/application/files/3617/7915/8363/ives-inver-grove-apartments-exterior.jpg",
            "https://ivesinvergrove.com/application/files/8917/7919/1596/apartment-rooftop-terrace.jpg"
        ],
        "7025-agate-trail-inver-grove-heights-mn");

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
        string amenities,
        string[]? customPhotos = null) =>
        new(
            slug,
            title,
            address,
            city,
            BulkCatalogGenerator.ApplySilentDiscount(rent),
            beds,
            baths,
            sqft,
            CatalogDefaults.BuildDescription(title, city, detail),
            amenities,
            photoVariant,
            customPhotos ?? CatalogPhotoLibrary.GetPhotosForSlug(slug));
}
