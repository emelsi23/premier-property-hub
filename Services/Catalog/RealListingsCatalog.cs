namespace ApartamentosRenta.Services.Catalog;

internal static class RealListingsCatalog
{
    public static CatalogProperty[] Properties =>
    [
        // Houston, TX — Hanover Montrose
        new(
            "3400-montrose-blvd-houston-tx",
            "Hanover Montrose — 2 bd · 2 ba · Luxury High-Rise",
            "3400 Montrose Blvd",
            "Houston, TX",
            2741,
            2,
            2,
            1200,
            """
            Hanover Montrose offers luxury penthouse-style living in the heart of Houston's vibrant Montrose neighborhood. Studio, one, two, and three-bedroom floor plans with wood-style flooring, double-hung walk-in closets, and open-air loggias with skyline views.

            Residents enjoy a resort-style pool deck with cabanas, 9th-floor loggia with dining areas overlooking downtown Houston, state-of-the-art fitness center, and easy access to museums, restaurants, and nightlife. Built to the highest standards with modern finishes throughout.
            """.Trim(),
            "Resort Pool, Skyline Loggia, Fitness Center, Penthouse Units, Dog Park, Controlled Access, Concierge",
            0,
            HanoverPhotos),

        // Houston, TX — Aspire Post Oak
        new(
            "1616-post-oak-blvd-houston-tx",
            "Aspire Post Oak — 2 bd · 2 ba · Uptown Galleria",
            "1616 Post Oak Blvd",
            "Houston, TX",
            3550,
            2,
            2,
            1346,
            """
            High-rise luxury residences located at the corner of Post Oak Blvd and San Felipe in Houston's iconic Uptown District. Aspire Post Oak delivers an unparalleled living experience with panoramic city views and world-class amenities.

            Floor plans feature premium finishes, floor-to-ceiling windows, chef-inspired kitchens, and spa-like bathrooms. Community amenities include infinity-edge pool, rooftop sky lounge, private dining room, 24-hour concierge, and direct access to the Galleria shopping district.
            """.Trim(),
            "Infinity Pool, Sky Lounge, 24h Concierge, Private Dining, Fitness Center, Valet Parking, Pet Friendly",
            0,
            AspirePhotos),

        // Austin, TX — The Met
        new(
            "10101-metropolitan-dr-austin-tx",
            "The Met — 2 bd · 2 ba · North Austin Near The Domain",
            "10101 Metropolitan Dr",
            "Austin, TX",
            2407,
            2,
            2,
            1020,
            """
            Experience The Met, a contemporary collection of apartment residences in North Austin near The Domain. Modern interiors available in studio, one, and two-bedroom floorplans with designer finishes, smart technology, and unparalleled views of Austin.

            Community amenities include coworking spaces, rooftop lounge, resort-style pool, dog park, state-of-the-art fitness center, and controlled-access entry. Built in 2023 with 297 units across 5 stories. Pet-friendly community with on-site management.
            """.Trim(),
            "Coworking, Rooftop Lounge, Resort Pool, Dog Park, Fitness Center, Smart Home Tech, Package Lockers",
            0,
            TheMetPhotos),

        // Austin, TX — The Modern Austin Residences
        new(
            "610-davis-st-austin-tx",
            "The Modern Austin Residences — Luxury High-Rise · Rainey Street",
            "610 Davis St",
            "Austin, TX",
            4500,
            2,
            2,
            1350,
            """
            Find your new home at The Modern Austin Residences, a stunning 56-story luxury high-rise in the Rainey Street district. This 2025-built tower offers 320 residences with sweeping views of Lady Bird Lake and the Austin skyline.

            Premium finishes include quartz countertops, designer cabinetry, and floor-to-ceiling windows. Building amenities feature rooftop infinity pool, private fitness studios, resident lounge, 24-hour concierge, and direct access to Austin's top dining and nightlife on Rainey Street.
            """.Trim(),
            "Rooftop Pool, 24h Concierge, Fitness Studios, Resident Lounge, EV Charging, Valet, Pet Spa",
            0,
            ModernAustinPhotos),

        // Los Angeles, CA — The Abbey
        new(
            "3550-w-6th-st-los-angeles-ca",
            "The Abbey — 1 bd · 1 ba · Koreatown Los Angeles",
            "3550 W 6th St",
            "Los Angeles, CA",
            2295,
            1,
            1,
            715,
            """
            The Abbey is a beautifully restored apartment community in the heart of Koreatown, Los Angeles. This character-rich building combines historic charm with modern upgrades, offering stylish one-bedroom residences with updated interiors.

            Features include hardwood-style flooring, modern kitchens with stainless appliances, and abundant natural light. Located steps from LA's best Korean BBQ, nightlife, and the Metro Purple Line for easy access to downtown, Hollywood, and beyond.
            """.Trim(),
            "Updated Interiors, Laundry Facility, Controlled Access, Near Metro, Pet Friendly, Courtyard",
            0,
            AbbeyPhotos),

        // Los Angeles, CA — 616 Kenmore
        new(
            "616-s-kenmore-st-los-angeles-ca",
            "616 Kenmore — 1 bd · 1 ba · Rooftop Terrace · Koreatown",
            "616 S Kenmore St",
            "Los Angeles, CA",
            2395,
            1,
            1,
            700,
            """
            616 Kenmore is a modern boutique apartment building in Koreatown featuring a stunning rooftop terrace with panoramic city views. One-bedroom residences offer contemporary design with clean lines and premium finishes throughout.

            Amenities include a landscaped rooftop deck, common lounge, in-unit washer/dryer, and controlled-access entry. Perfectly situated near restaurants, shopping, and public transit with easy access to DTLA, Hollywood, and the Westside.
            """.Trim(),
            "Rooftop Terrace, Common Lounge, In-Unit W/D, Controlled Access, Near Metro, City Views",
            0,
            KenmorePhotos),
    ];

    private static readonly string[] HanoverPhotos =
    [
        "https://images1.apartments.com/i2/724QVtTAM_jo2CXWB6bXBWP5jOAjZYOJo02DlsA_A04/111/hanover-montrose-houston-tx-conveniently-located-in-montrose-offerin.jpg",
        "https://images1.apartments.com/i2/bA2lKLGmOt5XpA_fuNYBFseectom7sd7e0Fm7Wet75M/117/hanover-montrose-houston-tx-resort-style-pool-deck-with-a-variety-of.jpg",
        "https://images1.apartments.com/i2/dH9VXBZUnBn5kDybgIq-a6UgT7C355COECNCNHXMdkI/117/hanover-montrose-houston-tx-resort-style-pool-deck-offering-both-sun.jpg",
        "https://images1.apartments.com/i2/Kk0UdAlOq40BrTr8Fm50H1zQ5eWcc24pm3xmu1NRTu8/117/hanover-montrose-houston-tx-elevated-pool-deck-with-private-poolside.jpg",
        "https://images1.apartments.com/i2/1g1tRLXHgAxp0x_V_CzGDgLkCtEXAs6ED_IyXt2eCGw/117/hanover-montrose-houston-tx-9th-floor-loggia-offering-views-of-downt.jpg",
    ];

    private static readonly string[] AspirePhotos =
    [
        "https://images1.apartments.com/i2/efu2-fQp998O7BE3v47RNjBZPxtRuau8HN08-wq_tsU/111/aspire-post-oak-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/IIbttnKp334aaLTjjuwJxQoQlLRqh6ZSHlVTlAf1-zE/117/aspire-post-oak-houston-tx-1aspirepo0052.jpg",
        "https://images1.apartments.com/i2/WwWCufg7KaiFWQ2puL-T-0vrLVW5HUSON0n9JV0Lxbs/117/aspire-post-oak-houston-tx-1aspirepo0055.jpg",
        "https://images1.apartments.com/i2/YctW67SZz7dlC1_vRx7DIT1QeBgoFWA1a2mIUcHUah8/117/aspire-post-oak-houston-tx-1aspirepo0064.jpg",
        "https://images1.apartments.com/i2/4Blao4hKVxWLxh3JYCOyn8Pb493FHvfTHBGNI3by7G8/117/aspire-post-oak-houston-tx-1aspirepo0075.jpg",
    ];

    private static readonly string[] TheMetPhotos =
    [
        "https://images1.apartments.com/i2/zq6ri1XKA1yfmFUSH8CtHWyzcbe5RLZIMrbsCjVFPgY/111/the-met-austin-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/PMp0vS-LqQFckIHZRFR4Vwsc1Cb5HJ6AmaTVVrN1_GI/117/the-met-austin-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/uqlRM3DB8QGUVQloPmaXp1GDUJ_3ZD_dtixa1hVbgw0/117/the-met-austin-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/jbXzyU2m_TVBbExSvt8P7v_a3HkUzNTleV96eAsCieI/117/the-met-austin-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/a-Ue9jZnAOYm5zh1NCy06g3ZdVIDSlcdC2nJCK-LafQ/117/the-met-austin-tx-building-photo.jpg",
    ];

    private static readonly string[] ModernAustinPhotos =
    [
        "https://images1.apartments.com/i2/2E27uoGldvNio3TI4tR4ywLkVKDcq6JxHGVu735wyBI/111/the-modern-austin-residences-austin-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/nchHca7WAQNIdIq5k_9FqlcUvgplNMB5P0dzoBfuppo/111/the-modern-austin-residences-austin-tx-aerial-photo.jpg",
        "https://images1.apartments.com/i2/CU8zx315-uM8g73Uqjdn0MAXw3Q2N7iY5FHfjp0JP2I/111/the-modern-austin-residences-austin-tx-aerial-photo.jpg",
    ];

    private static readonly string[] AbbeyPhotos =
    [
        "https://images1.apartments.com/i2/k2F_sNqAm-opL4qLr2CYr_XCYZoCwBY4xXDhx1x4JVQ/111/the-abbey-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/dYX1x267ki-cTsSgb71aRUGyZxywMDUq4ue_ZB1wFPM/117/the-abbey-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/Wu7uKGrvNZVA4nsq8xYy2v_4lVPk_tFWi5APwbbMUb4/117/the-abbey-los-angeles-ca-interior-photo.jpg",
        "https://images1.apartments.com/i2/FXufN7yw1ecp7gxKxPIKh-Gr3Yw-Et8FEDwHLgKQoMo/117/the-abbey-los-angeles-ca-interior-photo.jpg",
        "https://images1.apartments.com/i2/aIN6lrR06LtmuuIf6EQtt7bxqvqsO70qr90lHJhNti0/117/the-abbey-los-angeles-ca-interior-photo.jpg",
    ];

    private static readonly string[] KenmorePhotos =
    [
        "https://images1.apartments.com/i2/nu1HGvJt-dtE0REfd403Du-UEKZFPAeLwmEHkUmfmF0/111/616-kenmore-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/zH74sQbv0BVwrlwkhWWNCIhrno4FDeAbm-EjEgD1lr4/117/616-kenmore-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/gopaeiFHccPfybggIgYjYasu2MXNQSyp-N6BJpYhDBI/117/616-kenmore-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/9iXBNMk5nD6-QG1joeXCXmPRirVaihMvuc_ue6ZHQiI/117/616-kenmore-los-angeles-ca-rooftop-terrace.jpg",
        "https://images1.apartments.com/i2/h_bYT-aNUlCMNAh3vReQzn43Jh1IdASX9NbJ2TkS2I8/117/616-kenmore-los-angeles-ca-common-room.jpg",
    ];
}
