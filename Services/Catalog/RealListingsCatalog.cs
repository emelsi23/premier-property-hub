namespace ApartamentosRenta.Services.Catalog;

internal static class RealListingsCatalog
{
    public static CatalogProperty[] Properties =>
    [
        // ═══════════════════════════════════════════════════════════════
        // CALIFORNIA (29 properties)
        // ═══════════════════════════════════════════════════════════════

        // CA-1: Josephine DTLA, Downtown LA
        new(
            "801-s-hope-st-los-angeles-ca",
            "Josephine DTLA — 1 bd · 1 ba · Downtown",
            "801 S Hope St",
            "Los Angeles, CA",
            1695,
            1,
            1,
            758,
            """
            Luxury high-rise in South Park DTLA with stainless steel appliances, quartz countertops, keyless entry, and Nest thermostats. 22 stories with rooftop pool and hot tub.

            Located in the vibrant South Park neighborhood near LA Live, Staples Center, and the Arts District. Modern residences with premium finishes and panoramic city views.
            """.Trim(),
            "Pool, Hot Tub, Fitness Center, In Unit Washer & Dryer, Walk-In Closets, Balcony, Concierge, Pets Allowed",
            0,
            JosephineDtlaPhotos),

        // CA-2: Fusion Hollywood, Hollywood
        new(
            "5750-hollywood-blvd-los-angeles-ca",
            "Fusion Hollywood — 1 bd · 1 ba · Hollywood",
            "5750 Hollywood Blvd",
            "Los Angeles, CA",
            1364,
            1,
            1,
            479,
            """
            Modern apartment community on Hollywood Blvd with studios to 2-bedrooms. Features include in-unit washer/dryers, stainless steel appliances, and Matterport 3D tours available.

            Steps from the Walk of Fame, Hollywood nightlife, and Metro Red Line. Contemporary living with rooftop deck and controlled access in the heart of the entertainment capital.
            """.Trim(),
            "Fitness Center, In Unit Washer & Dryer, Rooftop Deck, Pet Friendly, Controlled Access, Package Lockers",
            0,
            FusionHollywoodPhotos),

        // CA-3: Hollywood Vista, Hollywood
        new(
            "7428-hollywood-blvd-los-angeles-ca",
            "Hollywood Vista — 1 bd · 1 ba · Hollywood",
            "7428 Hollywood Blvd",
            "Los Angeles, CA",
            1610,
            1,
            1,
            609,
            """
            One bedroom apartment in the heart of Hollywood with move-in specials. Features hardwood floors, controlled access, and abundant natural light throughout.

            Prime Hollywood location with easy access to restaurants, shopping, entertainment venues, and public transit. Classic LA living with modern updates and community laundry.
            """.Trim(),
            "On-Site Laundry, Controlled Access, Hardwood Floors, Air Conditioning, Refrigerator, Stove",
            0,
            HollywoodVistaPhotos),

        // CA-4: 1111 Echo Park Ave, Echo Park
        new(
            "1111-echo-park-ave-los-angeles-ca",
            "1111 Echo Park Ave — 1 bd · 1 ba · Echo Park",
            "1111 Echo Park Ave",
            "Los Angeles, CA",
            1855,
            1,
            1,
            740,
            """
            Newly-constructed 11-unit luxury building with spacious floorplans, private terraces with Echo Park views, chef's kitchen with quartz countertops, in-unit washer/dryer.

            Boutique living in one of LA's most creative neighborhoods near Echo Park Lake, Sunset Blvd dining, and the 101 freeway for easy commutes to Downtown and Hollywood.
            """.Trim(),
            "Washer/Dryer, Dishwasher, Hardwood Floors, Elevator, Gated Parking, Balcony, Microwave, Refrigerator",
            0,
            EchoParkAvePhotos),

        // CA-5: 02700AB Abbot Kinney, Venice
        new(
            "2700-abbot-kinney-blvd-venice-ca",
            "02700AB Abbot Kinney — 2 bd · 1 ba · Venice",
            "2700 Abbot Kinney Blvd",
            "Venice, CA",
            1887,
            2,
            1,
            800,
            """
            Beautifully remodeled 2-bedroom gem on Abbot Kinney with stainless steel appliances, granite countertops, original hardwood floors. Steps from Venice Beach and farmers market.

            Located on LA's coolest street with boutique shops, gourmet restaurants, and art galleries at your doorstep. Classic Venice character with modern kitchen and spacious living areas.
            """.Trim(),
            "Dishwasher, Microwave, Hardwood Floors, On-Site Laundry, Off-Street Parking, Double Pane Windows",
            0,
            AbbotKinneyPhotos),

        // CA-6: 4402 Los Feliz Blvd, Los Feliz
        new(
            "4402-los-feliz-blvd-los-angeles-ca",
            "4402 Los Feliz Blvd — 1 bd · 1 ba · Los Feliz",
            "4402 Los Feliz Blvd",
            "Los Angeles, CA",
            1467,
            1,
            1,
            600,
            """
            Renovated mid-century modern apartment in prime Los Feliz. Top floor corner unit with plenty of light, new quartz countertops and cabinets. Minutes from Griffith Park hiking trails.

            Charming neighborhood with walkable cafes, vintage shops, and the historic Los Feliz Village. Easy access to Griffith Observatory, the Greek Theatre, and Silver Lake.
            """.Trim(),
            "On-Site Laundry, Parking, Quartz Countertops, Stainless Steel Appliances, Wall AC, Large Closet",
            0,
            LosFelizBlvdPhotos),

        // CA-7: The Chadwick, Koreatown
        new(
            "209-s-westmoreland-ave-los-angeles-ca",
            "The Chadwick — 1 bd · 1 ba · Koreatown",
            "209 S Westmoreland Ave",
            "Los Angeles, CA",
            1334,
            1,
            1,
            680,
            """
            Urban resort-style living in Koreatown with stunning views, premium stainless-steel appliances, granite countertops, designer wood-inspired flooring. Two pools and fire pit.

            A true oasis in K-Town with basketball court, hot tub, and pet-friendly policies. Near Metro Purple Line, incredible Korean dining, and Wilshire Center shopping district.
            """.Trim(),
            "Pool, Hot Tub, Fitness Center, Basketball Court, Fire Pit, In Unit Washer & Dryer, Pet Friendly, Controlled Access",
            0,
            TheChadwickPhotos),

        // CA-8: eaves Los Feliz, Los Feliz
        new(
            "3100-riverside-dr-los-angeles-ca",
            "eaves Los Feliz — 1 bd · 1 ba · Los Feliz",
            "3100 Riverside Dr",
            "Los Angeles, CA",
            1559,
            1,
            1,
            695,
            """
            Furnished and unfurnished apartments near Griffith Park with renovated kitchens featuring quartz countertops and stainless steel appliances. Self-guided tours available.

            Nestled along the LA River near Atwater Village and Silver Lake. Resort-style pool, modern fitness center, and pet-friendly community with easy freeway access.
            """.Trim(),
            "Pool, Fitness Center, In Unit Washer & Dryer, Hard Surface Flooring, Stainless Steel Appliances, Pet Friendly",
            0,
            EavesLosFelizPhotos),

        // CA-9: Rise Koreatown, Koreatown
        new(
            "750-s-oxford-ave-los-angeles-ca",
            "Rise Koreatown — 1 bd · 1 ba · Koreatown",
            "750 S Oxford Ave",
            "Los Angeles, CA",
            1803,
            1,
            1,
            540,
            """
            Koreatown's most anticipated new address with designer residences and styled amenities. Built in 2022, 7 stories, 363 units. Modern apartments meet K-Town culture.

            Rooftop pool with skyline views, state-of-the-art fitness center, and co-working spaces. Steps from the best Korean BBQ, karaoke, and nightlife in Los Angeles.
            """.Trim(),
            "Pool, Fitness Center, Rooftop Deck, In Unit Washer & Dryer, Pet Friendly, Controlled Access, Package Lockers",
            0,
            RiseKoreatownPhotos),

        // CA-10: Instrata Little Italy, San Diego
        new(
            "1980-kettner-blvd-san-diego-ca",
            "Instrata Little Italy — 1 bd · 1 ba · Little Italy",
            "1980 Kettner Blvd",
            "San Diego, CA",
            1681,
            1,
            1,
            562,
            """
            Amalfi-inspired coastal resort experience in the heart of Little Italy with endless bay views. Built in 2014, 199 units, 6 stories. Designer lifestyle apartments.

            Walking distance to the Little Italy Mercato farmers market, waterfront dining, and the Embarcadero. Rooftop pool, concierge services, and stunning Pacific Ocean sunsets.
            """.Trim(),
            "Pool, Fitness Center, Rooftop Terrace, In Unit Washer & Dryer, Controlled Access, Concierge, Pet Friendly",
            0,
            InstrataLittleItalyPhotos),

        // CA-11: Vici Luxury Rentals, Little Italy
        new(
            "550-w-date-st-san-diego-ca",
            "Vici Luxury Rentals — 1 bd · 1 ba · Little Italy",
            "550 W Date St",
            "San Diego, CA",
            1750,
            1,
            1,
            537,
            """
            Upscale urban apartment in Little Italy offering European style living with dining, shopping, weekly farmers markets, and bay views from expansive rooftop terrace.

            Boutique living in San Diego's most walkable neighborhood with world-class Italian restaurants, craft breweries, and art galleries. Pet services and concierge on site.
            """.Trim(),
            "Rooftop Terrace, Concierge, Pet Services, On-Site Laundry, Fitness Center, BBQ Area, Controlled Access",
            0,
            ViciLittleItalyPhotos),

        // CA-12: Parkline North Park, San Diego
        new(
            "4250-oregon-st-san-diego-ca",
            "Parkline North Park — 1 bd · 1 ba · North Park",
            "4250 Oregon St",
            "San Diego, CA",
            1472,
            1,
            1,
            398,
            """
            Modern apartment community in North Park built in 2023. 94 units across 6 stories with contemporary finishes and community amenities in trendy neighborhood.

            In the heart of North Park's craft beer scene, boutique shopping, and diverse dining. Rooftop deck with city views, bike storage, and easy access to Balboa Park.
            """.Trim(),
            "Fitness Center, Rooftop Deck, In Unit Washer & Dryer, Pet Friendly, Bike Storage, Package Lockers, Controlled Access",
            0,
            ParklineNorthParkPhotos),

        // CA-13: AZUL North Park, San Diego
        new(
            "4499-ohio-st-san-diego-ca",
            "AZUL North Park — 1 bd · 1 ba · North Park",
            "4499 Ohio St",
            "San Diego, CA",
            1957,
            1,
            1,
            579,
            """
            Modern luxury apartment community in North Park with studio to 2-bedroom options. Contemporary design with high-end finishes and community spaces.

            Located in San Diego's trendiest neighborhood with craft breweries, independent coffee shops, and vibrant nightlife. Pool, rooftop deck, and pet-friendly living.
            """.Trim(),
            "Pool, Fitness Center, Rooftop Deck, In Unit Washer & Dryer, Pet Friendly, Bike Storage, Controlled Access",
            0,
            AzulNorthParkPhotos),

        // CA-14: AVA Pacific Beach, San Diego
        new(
            "3883-ingraham-st-san-diego-ca",
            "AVA Pacific Beach — 1 bd · 1 ba · Pacific Beach",
            "3883 Ingraham St",
            "San Diego, CA",
            1506,
            1,
            1,
            405,
            """
            Furnished and unfurnished studios and apartments on Crown Point/Pacific Beach with 40-person whirlpool spa, stunning pool, and brand new 5,000 SF fitness center.

            Steps from Mission Bay and Pacific Beach boardwalk. Perfect for beach lovers with kayaking, paddleboarding, and surfing at your doorstep. Self-guided tours available.
            """.Trim(),
            "Pool, Spa, Fitness Center, DIY Space, Pet Spa, Self-Guided Tours, Air Conditioning, Spacious Closets",
            0,
            AvaPacificBeachPhotos),

        // CA-15: IMT Mission Valley, San Diego
        new(
            "10343-san-diego-mission-rd-san-diego-ca",
            "IMT Mission Valley — 1 bd · 1 ba · Mission Valley",
            "10343 San Diego Mission Rd",
            "San Diego, CA",
            1680,
            1,
            1,
            720,
            """
            Remodeled apartments with open-concept kitchens, stainless steel appliances, ice white quartz countertops, European white gloss cabinetry and dual master suites.

            Centrally located in Mission Valley with easy access to freeways, Fashion Valley Mall, and Qualcomm Stadium. Trolley station nearby for car-free commuting.
            """.Trim(),
            "Pool, Fitness Center, In Unit Washer & Dryer, Pet Friendly, Controlled Access, Parking, Stainless Steel Appliances",
            0,
            ImtMissionValleyPhotos),

        // CA-16: Metro Mission Valley, San Diego
        new(
            "5080-camino-del-arroyo-san-diego-ca",
            "Metro Mission Valley — 1 bd · 1 ba · Mission Valley",
            "5080 Camino Del Arroyo",
            "San Diego, CA",
            1767,
            1,
            1,
            399,
            """
            Luxurious and active lifestyle apartments featuring spacious floor plans, upscale amenities, and environmentally-conscious values in Mission Valley.

            Near the San Diego River Trail, Mission Valley shopping centers, and major freeways. EV charging, rooftop deck with views, and modern fitness center included.
            """.Trim(),
            "Pool, Fitness Center, Rooftop Deck, In Unit Washer & Dryer, Pet Friendly, Bike Storage, EV Charging",
            0,
            MetroMissionValleyPhotos),

        // CA-17: West Park, Mission Valley San Diego
        new(
            "7777-westside-dr-san-diego-ca",
            "West Park — 1 bd · 1 ba · Mission Valley",
            "7777 Westside Dr",
            "San Diego, CA",
            1749,
            1,
            1,
            650,
            """
            Exclusive community in Civita master-planned development in Mission Valley with rooftop lounges, sun decks, and state-of-the-art fitness center. Near Fashion Valley Mall.

            Part of the award-winning Civita community with parks, trails, and community events. Premium finishes, controlled access, and stunning valley views throughout.
            """.Trim(),
            "Pool, Fitness Center, Rooftop Lounge, Sun Decks, Controlled Access, Pet Friendly, Parking, EV Charging",
            0,
            WestParkPhotos),

        // CA-18: Alira, Sacramento
        new(
            "4100-innovator-dr-sacramento-ca",
            "Alira — 1 bd · 1 ba · Natomas",
            "4100 Innovator Dr",
            "Sacramento, CA",
            1271,
            1,
            1,
            572,
            """
            Modern apartment community in Natomas Crossing near Regal Natomas Marketplace. Studio to 3-bedroom options with community perks and convenient location.

            Easy access to I-5 and I-80 for commutes to Downtown Sacramento and the airport. Resort-style pool, modern fitness center, and family-friendly community.
            """.Trim(),
            "Pool, Fitness Center, In Unit Washer & Dryer, Pet Friendly, Controlled Access, Package Lockers, Parking",
            0,
            AliraPhotos),

        // CA-19: Miramonte and Trovas, Sacramento
        new(
            "4850-natomas-blvd-sacramento-ca",
            "Miramonte and Trovas — 1 bd · 1 ba · Natomas",
            "4850 Natomas Blvd",
            "Sacramento, CA",
            1222,
            1,
            1,
            700,
            """
            Budget-friendly apartment homes in North Natomas with resort-inspired amenities including two pools, poolside fire-pit, 24-hour fitness center, and community BBQs.

            Spacious floor plans in a quiet residential setting near parks, schools, and shopping. Easy freeway access for commutes to downtown Sacramento and beyond.
            """.Trim(),
            "Pool, Fire Pit, Fitness Center, BBQ Area, Pet Friendly, Controlled Access, On-Site Laundry, Parking",
            0,
            MiramonteAndTrovasPhotos),

        // CA-20: Sutter Green Apartments, Sacramento
        new(
            "2205-natomas-park-dr-sacramento-ca",
            "Sutter Green — 1 bd · 1 ba · Natomas",
            "2205 Natomas Park Dr",
            "Sacramento, CA",
            1344,
            1,
            1,
            548,
            """
            Urban sophistication meets suburban tranquility near Garden Highway. Phase II features brand-new luxury apartments with upscale interiors. Elite 1% ORA Power Rankings.

            Smart home features, EV charging, and resort-style pool and spa. Near Sacramento River parkway trails and Natomas marketplace shopping and dining.
            """.Trim(),
            "Pool, Spa, Fitness Center, BBQ Area, Pet Friendly, In Unit Washer & Dryer, Smart Home Features, EV Charging",
            0,
            SutterGreenPhotos),

        // CA-21: 188 Octavia, San Francisco
        new(
            "188-octavia-st-san-francisco-ca",
            "188 Octavia — 1 bd · 1 ba · Hayes Valley",
            "188 Octavia St",
            "San Francisco, CA",
            1715,
            1,
            1,
            367,
            """
            Boutique apartment community in Hayes Valley with studio and 2-bedroom options. Near Civic Center Plaza and Lower Haight with rooftop deck and panoramic views.

            One of SF's most desirable neighborhoods with Patricia's Green, Blue Bottle Coffee, and world-class dining steps away. Walkable to BART and Muni for easy transit.
            """.Trim(),
            "Rooftop Deck, In Unit Washer & Dryer, Stainless Steel Appliances, Pet Friendly, Controlled Access, Package Lockers",
            0,
            OctaviaPhotos),

        // CA-22: Hanover Soma West, San Francisco
        new(
            "1140-harrison-st-san-francisco-ca",
            "Hanover Soma West — 1 bd · 1 ba · SoMa",
            "1140 Harrison St",
            "San Francisco, CA",
            1714,
            1,
            1,
            422,
            """
            Luxury 377-unit community in SoMa with 4 outdoor courtyards, Jumbotron screen, grilling station. Near Trader Joe's, Whole Foods, and BART. Breathtaking SF views.

            Modern high-rise living in the tech hub of San Francisco with concierge, smart home features, and resort-style pool. Walking distance to Oracle Park and Chase Center.
            """.Trim(),
            "Pool, Fitness Center, Rooftop Lounge, Courtyard, In Unit Washer & Dryer, Smart Home, Concierge, Pet Friendly",
            0,
            HanoverSomaWestPhotos),

        // CA-23: Elan Beachlofts, Pacific Beach
        new(
            "852-chalcedony-st-pacific-beach-ca",
            "Elan Beachlofts — 1 bd · 1 ba · Pacific Beach",
            "852 Chalcedony St",
            "Pacific Beach, CA",
            1694,
            1,
            1,
            650,
            """
            Coastal living community in Pacific Beach featuring one-bedroom apartments with state-of-the-art integrated electronics and finest features. Pet-friendly.

            Just blocks from the beach and boardwalk in San Diego's premier beach community. Surf, sand, and sunset living with modern amenities and controlled access.
            """.Trim(),
            "Fitness Center, Pet Friendly, Stainless Steel Appliances, Hard Surface Flooring, Controlled Access, Parking",
            0,
            ElanBeachloftsPhotos),

        // CA-24: Avaz Pacific Beach, San Diego
        new(
            "2710-grand-ave-san-diego-ca",
            "Avaz Pacific Beach — 1 bd · 1 ba · Pacific Beach",
            "2710 Grand Ave",
            "San Diego, CA",
            1677,
            1,
            1,
            508,
            """
            Modern apartment community on Grand Ave in Pacific Beach with multiple 3D tours available. Walking distance to beach, dining, and nightlife.

            In the heart of Pacific Beach's vibrant Grand Avenue with rooftop deck, pool, and ocean breezes. Steps from bars, restaurants, and the famous PB boardwalk.
            """.Trim(),
            "Fitness Center, Pool, In Unit Washer & Dryer, Pet Friendly, Controlled Access, Rooftop Deck",
            0,
            AvazPacificBeachPhotos),

        // CA-25: Pacific Beach Shores, San Diego
        new(
            "4820-cass-st-san-diego-ca",
            "Pacific Beach Shores — 1 bd · 1 ba · Pacific Beach",
            "4820 Cass St",
            "San Diego, CA",
            1193,
            1,
            1,
            543,
            """
            Affordable apartment community in the Pacific Beach neighborhood of San Diego. One-bedroom units available with community amenities and beach proximity.

            Budget-friendly beach living just minutes from the sand. Near shops, restaurants, and the lively PB nightlife scene with easy bus access to downtown San Diego.
            """.Trim(),
            "On-Site Laundry, Controlled Access, Community Room, Parking, Near Beach, Near Shopping",
            0,
            PacificBeachShoresPhotos),

        // CA-26: Ice House Midtown, Sacramento
        new(
            "1710-r-st-sacramento-ca",
            "Ice House — 1 bd · 1 ba · Midtown",
            "1710 R St",
            "Sacramento, CA",
            1155,
            1,
            1,
            550,
            """
            Sophisticated urban living in the ICE Blocks, Midtown Sacramento's coolest neighborhood. Steps from Philz Coffee, Beast & Bounty, and Safeway. Rooftop lounge and firepit.

            Sacramento's most walkable neighborhood with art galleries, farm-to-fork restaurants, and weekend farmers markets. Bike-friendly with trails to the Capitol and river.
            """.Trim(),
            "Rooftop Lounge, Fire Pit, BBQ Area, Fitness Center, In Unit Washer & Dryer, Pet Friendly, Controlled Access, Bike Storage",
            0,
            IceHouseMidtownPhotos),

        // CA-27: The Mod at Midtown, Sacramento
        new(
            "728-16th-st-sacramento-ca",
            "The Mod — 1 bd · 1 ba · Midtown",
            "728 16th St",
            "Sacramento, CA",
            1049,
            1,
            1,
            640,
            """
            Studio, 1, and 2-bedroom apartments in Downtown Sacramento with in-home washer/dryer, onsite parking, and wall-to-wall windows with abundant natural light.

            Central Midtown location near the Capitol, Golden 1 Center, and Sacramento's thriving restaurant scene. Social lounge and modern fitness center for residents.
            """.Trim(),
            "In Unit Washer & Dryer, Fitness Center, Social Lounge, Parking, Pet Friendly, Package Lockers, Controlled Access",
            0,
            TheModMidtownPhotos),

        // CA-28: 1190 Mission at Trinity Place, San Francisco
        new(
            "1190-mission-st-san-francisco-ca",
            "1190 Mission at Trinity Place — 1 bd · 1 ba · SoMa",
            "1190 Mission St",
            "San Francisco, CA",
            1635,
            1,
            1,
            478,
            """
            Award-winning architecture by Arquitectonica in SF's performing arts district. Four towers with exquisite finishes, modern cabinetry, and central courtyard with Venus statue.

            Near BART, Civic Center, and the arts corridor including SF Symphony, Opera, and Ballet. Concierge services, fitness center, and controlled access in a landmark building.
            """.Trim(),
            "Fitness Center, Courtyard, In Unit Washer & Dryer, Controlled Access, Concierge, Pet Friendly, Near BART",
            0,
            TrinityPlacePhotos),

        // CA-29: Soma Residences, San Francisco
        new(
            "1045-mission-st-san-francisco-ca",
            "Soma Residences — 1 bd · 1 ba · SoMa",
            "1045 Mission St",
            "San Francisco, CA",
            1245,
            1,
            1,
            475,
            """
            Vibrant location in the heart of SOMA, San Francisco with studio and one-bedroom apartments. Modern finishes with nearby museums, dining, and entertainment.

            Walking distance to SFMOMA, Yerba Buena Gardens, and Moscone Center. Rooftop deck with city views, modern fitness center, and near multiple BART and Muni lines.
            """.Trim(),
            "Fitness Center, Rooftop Deck, In Unit Washer & Dryer, Controlled Access, Package Lockers, Pet Friendly, Near Transit",
            0,
            SomaResidencesPhotos),

        // ═══════════════════════════════════════════════════════════════
        // HOUSTON, TX (26 properties)
        // ═══════════════════════════════════════════════════════════════

        // TX-1: Hanover Montrose, Montrose
        new(
            "3400-montrose-blvd-houston-tx",
            "Hanover Montrose — 1 bd · 1 ba · Montrose",
            "3400 Montrose Blvd",
            "Houston, TX",
            1783,
            1,
            1,
            889,
            """
            Luxury high-rise in the heart of Montrose with impressive Houston views and easy access to downtown and the Medical Center. Built in 2016, 327 units across 31 stories.

            Resort-style pool deck with private cabanas, 9th floor loggia with downtown views, and concierge services. Near Museum District, Buffalo Bayou Park, and Menil Collection.
            """.Trim(),
            "Resort-Style Pool, Private Cabanas, Fitness Center, Rooftop Terrace, Controlled Access, Concierge",
            0,
            HanoverMontrosePhotos),

        // TX-2: Lumen, Montrose
        new(
            "2400-w-dallas-st-houston-tx",
            "Lumen — 1 bd · 1 ba · Montrose",
            "2400 W Dallas St",
            "Houston, TX",
            1260,
            1,
            1,
            967,
            """
            Modern luxury apartments in Montrose near Buffalo Bayou Park, Downtown, and the Museum District. Contemporary finishes with spacious floor plans.

            Rooftop deck with city views, resort-style pool, and self-guided tours available. Walking distance to Montrose restaurants, galleries, and the Buffalo Bayou trail system.
            """.Trim(),
            "Self-Guided Tours, Fitness Center, Pool, Pet Friendly, Controlled Access, Rooftop Deck",
            0,
            LumenPhotos),

        // TX-3: City Place Montrose, Montrose
        new(
            "306-mcgowen-st-houston-tx",
            "City Place Montrose — 1 bd · 1 ba · Montrose",
            "306 McGowen St",
            "Houston, TX",
            1190,
            1,
            1,
            780,
            """
            Premier luxury apartments near downtown Houston and Montrose with open floor plans and upscale features. Elegant one and two bedroom layouts with sophisticated design.

            Centrally located between Midtown and Montrose with easy access to freeways, light rail, and Houston's best dining and nightlife. Rooftop terrace with skyline views.
            """.Trim(),
            "Pool, Fitness Center, Controlled Access, Pet Friendly, Business Center, Rooftop Terrace",
            0,
            CityPlaceMontrosePhotos),

        // TX-4: UNITI Montrose, Montrose
        new(
            "701-richmond-ave-houston-tx",
            "UNITI Montrose — 1 bd · 1 ba · Montrose",
            "701 Richmond Ave",
            "Houston, TX",
            1155,
            1,
            1,
            575,
            """
            Vibrant co-living and traditional apartments in the eclectic Montrose neighborhood. Fully-furnished units with flexible lease terms and modern amenities.

            Rooftop pool, podcast room, library, and co-working spaces. In the heart of Houston's most diverse neighborhood with galleries, vintage shops, and farm-to-table dining.
            """.Trim(),
            "Pool, Rooftop Deck, Fitness Center, Co-Working Spaces, Podcast Room, Library, Club Lounge, Furnished Options",
            0,
            UnitiMontrosePhotos),

        // TX-5: The Sovereign at Regent Square, Montrose
        new(
            "3233-w-dallas-st-houston-tx",
            "The Sovereign — 1 bd · 1 ba · Montrose",
            "3233 W Dallas St",
            "Houston, TX",
            1540,
            1,
            1,
            850,
            """
            Modern 21-story high-rise over Buffalo Bayou with majestic views and ultimate comfort. Features private balconies, floor-to-ceiling windows, and 10-15 foot ceilings.

            Luxurious 75-foot lap pool, zen garden, concierge service, and valet parking. Buffalo Bayou Park is just a mile away for jogging, biking, and kayaking.
            """.Trim(),
            "75-Foot Lap Pool, Zen Garden, Concierge, Valet Parking, Fitness Center, Sun Lounge, Oversized Tubs",
            0,
            TheSovereignPhotos),

        // TX-6: Midtown on the Rail, Midtown
        new(
            "2310-main-st-houston-tx",
            "Midtown on the Rail — 1 bd · 1 ba · Midtown",
            "2310 Main St",
            "Houston, TX",
            1022,
            1,
            1,
            696,
            """
            Boutique mid-rise apartment community in the heart of Midtown Houston with Walk Score of 91. Close to Buffalo Bayou Park, Discovery Green, and Hermann Park.

            Steps from the METRORail Main Street line for car-free commuting to Downtown, Museum District, and Medical Center. Vibrant nightlife and dining on your doorstep.
            """.Trim(),
            "Ceiling Fans, Elevator, Controlled Access, Fitness Center, Pool, Walk Score 91",
            0,
            MidtownOnTheRailPhotos),

        // TX-7: Midtown One80, Midtown
        new(
            "180-w-gray-st-houston-tx",
            "Midtown One80 — 1 bd · 1 ba · Midtown",
            "180 W Gray St",
            "Houston, TX",
            1169,
            1,
            1,
            810,
            """
            Modern apartment community in Midtown Houston built in 2019 with 201 units across 6 stories. Offers one and two bedroom layouts with contemporary finishes.

            Prime Midtown location near Bagby Street, Midtown Park, and the METRORail. Easy access to Downtown offices, Theater District, and Discovery Green.
            """.Trim(),
            "Pool, Fitness Center, Controlled Access, Elevator, Pet Friendly, In Unit Washer & Dryer, Stainless Steel Appliances",
            0,
            MidtownOne80Photos),

        // TX-8: Midtown Houston Living, Midtown
        new(
            "2900-milam-st-houston-tx",
            "Midtown Houston Living — 1 bd · 1 ba · Midtown",
            "2900 Milam St",
            "Houston, TX",
            1050,
            1,
            1,
            740,
            """
            Boutique-style apartments in vibrant Midtown with pedestrian-friendly access to shopping, dining, and entertainment. Features miles of jogging and biking trails nearby.

            Coffee maker lounge, sparkling pool, and elevator access. Near the METRORail, Hermann Park, and Houston's top restaurants and bars along Main Street.
            """.Trim(),
            "Pool, Coffee Maker Lounge, Elevator, Fitness Center, Controlled Access, Near Parks",
            0,
            MidtownHoustonLivingPhotos),

        // TX-9: Pearl Midtown, Midtown
        new(
            "3101-smith-st-houston-tx",
            "Pearl Midtown — 1 bd · 1 ba · Midtown",
            "3101 Smith St",
            "Houston, TX",
            1225,
            1,
            1,
            869,
            """
            Best boutique-style living in Midtown Houston close to top hot spots. European-style cabinetry, quartzite countertops, and plank-style flooring throughout.

            Resort-style pool with grilling area, walk to METRORail station, and modern fitness center. Central to Downtown, Montrose, and the Museum District.
            """.Trim(),
            "Resort-Style Pool, Grilling Area, Fitness Center, Near Train Station, Controlled Access, Modern Appliances",
            0,
            PearlMidtownPhotos),

        // TX-10: SkyHouse River Oaks, River Oaks
        new(
            "2031-westcreek-ln-houston-tx",
            "SkyHouse River Oaks — 1 bd · 1 ba · River Oaks",
            "2031 Westcreek Ln",
            "Houston, TX",
            1470,
            1,
            1,
            780,
            """
            Premium high-rise with floor-to-ceiling windows, kitchen islands, and solar shades. Two rooftop pools, outdoor lounge, near Memorial Park and the Galleria.

            Self-guided tours available with conference rooms and built-in desks for work-from-home professionals. Upscale River Oaks dining and shopping minutes away.
            """.Trim(),
            "Two Rooftop Pools, Conference Room, Business Center, Floor-to-Ceiling Windows, Self-Guided Tours",
            0,
            SkyHouseRiverOaksPhotos),

        // TX-11: 24Eleven Washington, Washington Ave
        new(
            "2411-washington-ave-houston-tx",
            "24Eleven Washington — 1 bd · 1 ba · Washington Ave",
            "2411 Washington Ave",
            "Houston, TX",
            1203,
            1,
            1,
            825,
            """
            Bold blend of luxury nestled between the Washington Corridor and Houston's Art District. Designed with Houston's vibrant lifestyle in mind, blending soulful and artful dynamics.

            Rooftop terrace with grilling area, resort-style pool, and steps from Washington Avenue's legendary nightlife, restaurants, and breweries.
            """.Trim(),
            "Pool, Fitness Center, Controlled Access, Pet Friendly, In Unit Washer & Dryer, Rooftop Terrace, Grilling Area",
            0,
            TwentyFourElevenWashingtonPhotos),

        // TX-12: Heights West End, Washington Ave
        new(
            "4020-koehler-st-houston-tx",
            "Heights West End — 1 bd · 1 ba · Washington Ave",
            "4020 Koehler St",
            "Houston, TX",
            1085,
            1,
            1,
            650,
            """
            Located in Washington Ave neighborhood near Memorial Park, Buffalo Bayou Park, and the Bayou Bend Collection. Studio to two-bedroom layouts with multiple floor plans.

            Quiet residential setting with easy access to Houston's best parks, trails, and outdoor recreation. Pet-friendly with on-site fitness and sparkling pool.
            """.Trim(),
            "Pool, Fitness Center, Controlled Access, Pet Friendly, Near Parks, Laundry Facilities",
            0,
            HeightsWestEndPhotos),

        // TX-13: Pearl Washington, Washington Ave
        new(
            "5454-washington-ave-houston-tx",
            "Pearl Washington — 1 bd · 1 ba · Washington Ave",
            "5454 Washington Ave",
            "Houston, TX",
            1071,
            1,
            1,
            764,
            """
            Wide variety of one, two, and three-bedroom floor plans with soaring ceilings. Walking distance to Memorial Park with vibrant arts, dining, and entertainment nearby.

            Luxurious swimming pool, resort-inspired courtyard, and Central Bark pet playground. Deluxe kitchens with stainless steel appliances and granite countertops.
            """.Trim(),
            "Pool, Resort Courtyard, Pet Playground, Fitness Center, Stainless Steel Appliances, Near Memorial Park",
            0,
            PearlWashingtonPhotos),

        // TX-14: AveCDC Washington Courtyards, Washington Ave
        new(
            "2505-washington-ave-houston-tx",
            "AveCDC Washington Courtyards — 2 bd · 1 ba · Washington Ave",
            "2505 Washington Ave",
            "Houston, TX",
            820,
            2,
            1,
            779,
            """
            Budget-friendly apartment living in Houston's Sixth Ward near shopping, dining, entertainment, and schools. Built in 2000 with 74 units.

            Gated community with pool on the popular Washington Corridor. Affordable two-bedroom living with easy access to Downtown, the Heights, and Memorial Park.
            """.Trim(),
            "Pool, Gated Access, Laundry Facilities, Controlled Access, Near Shopping, Washington Corridor Location",
            0,
            AveCdcWashingtonPhotos),

        // TX-15: 2125 Yale Apartments, The Heights
        new(
            "2125-yale-st-houston-tx",
            "2125 Yale — 2 bd · 2 ba · The Heights",
            "2125 Yale St",
            "Houston, TX",
            1579,
            2,
            2,
            1087,
            """
            Heart of Houston Heights with quality touches and comfortable elegance. Built-in desks, gourmet kitchens, and upgraded lighting with outdoor lounge and fire pit.

            Indoor/outdoor cabana, courtyard with water feature, and conference room. Near Heights Bike Trail, White Oak Music Hall, and 19th Street shopping district.
            """.Trim(),
            "Outdoor Lounge, Cabana, Courtyard, Fire Pit, Water Feature, Conference Room, Cyber Cafe, Pet Friendly",
            0,
            YaleApartmentsPhotos),

        // TX-16: Alexan Junction Heights, Washington Ave
        new(
            "3003-summer-st-houston-tx",
            "Alexan Junction Heights — 1 bd · 1 ba · Washington Ave",
            "3003 Summer St",
            "Houston, TX",
            1330,
            1,
            1,
            800,
            """
            Comfortable, stylish, and convenient apartment community in the Washington Ave neighborhood. Studio to two-bedroom layouts with modern finishes.

            Near Buffalo Bayou Park with Matterport 3D tours available. Pet-friendly community with fitness center, sparkling pool, and controlled access entry.
            """.Trim(),
            "Fitness Center, Pool, Controlled Access, Pet Friendly, Near Buffalo Bayou Park",
            0,
            AlexanJunctionPhotos),

        // TX-17: Elan Memorial Park, Washington Ave
        new(
            "920-westcott-st-houston-tx",
            "Elan Memorial Park — 1 bd · 1 ba · Washington Ave",
            "920 Westcott St",
            "Houston, TX",
            1260,
            1,
            1,
            850,
            """
            The ultimate destination with Memorial Park as your backyard. Soaring skyline views, high-end modern detailing, and comprehensive amenities in the Washington Ave area.

            Sky lounge with panoramic views, resort-style pool, and self-guided tours available. Adjacent to Memorial Park's 1,500 acres of trails, golf, and recreation.
            """.Trim(),
            "Sky Lounge, Pool, Fitness Center, Self-Guided Tours, Controlled Access, Pet Friendly",
            0,
            ElanMemorialParkPhotos),

        // TX-18: Cortland Museum District, Museum District
        new(
            "5280-caroline-st-houston-tx",
            "Cortland Museum District — 1 bd · 1 ba · Museum District",
            "5280 Caroline St",
            "Houston, TX",
            1680,
            1,
            1,
            750,
            """
            High-rise apartment community in the Museum District convenient to Medical Center and Downtown Houston. Near Hermann Park, Buffalo Bayou Park, and 19 museums.

            Rooftop terrace with city views, co-working space, and modern fitness center. Walk to the Museum of Fine Arts, Contemporary Arts Museum, and Rice University campus.
            """.Trim(),
            "Pool, Fitness Center, Rooftop Terrace, Co-Working Space, Controlled Access, Near Museums",
            0,
            CortlandMuseumPhotos),

        // TX-19: Venue Museum District, Museum District
        new(
            "5353-fannin-st-houston-tx",
            "Venue Museum District — 1 bd · 1 ba · Museum District",
            "5353 Fannin St",
            "Houston, TX",
            1470,
            1,
            1,
            750,
            """
            Luxury apartments in the Museum District near Hermann Park, the Houston Zoo, and 19 museums. Convenient to Texas Medical Center and Rice University.

            Open floor plans with double vanity bathrooms and kitchen bars. Self-guided tours available with modern fitness center and sparkling pool.
            """.Trim(),
            "Pool, Fitness Center, Self-Guided Tours, Double Vanity Bathrooms, Open Floor Plans, Kitchen Bar",
            0,
            VenueMuseumPhotos),

        // TX-20: The Heron Museum District, Museum District
        new(
            "4343-woodhead-st-houston-tx",
            "The Heron — 1 bd · 1 ba · Museum District",
            "4343 Woodhead St",
            "Houston, TX",
            1610,
            1,
            1,
            700,
            """
            Elegant apartment residences near Texas Medical Center and Rice University. Gracious service and details typical of custom homes and fine hotels in Boulevard Oaks Historic District.

            Near Menil Collection and H-E-B Montrose Market. Premium finishes with sweeping views and controlled access in one of Houston's most prestigious neighborhoods.
            """.Trim(),
            "Near Menil Collection, Premium Finishes, Sweeping Views, Controlled Access, By Appointment Tours",
            0,
            TheHeronMuseumPhotos),

        // TX-21: Allure Hermann Park at Med Center, Medical Center
        new(
            "5927-almeda-rd-houston-tx",
            "Allure Hermann Park — 1 bd · 1 ba · Medical Center",
            "5927 Almeda Rd",
            "Houston, TX",
            1330,
            1,
            1,
            750,
            """
            Luxury high-rise in the Medical Center with infinity pool, private cabanas, and stunning city views. Near Hermann Park, NRG Stadium, and Rice University.

            Ideal for medical professionals with easy access to Texas Medical Center hospitals and research facilities. Matterport 3D tours and property site map available.
            """.Trim(),
            "Infinity Pool, Private Cabanas, Fitness Center, City Views, Controlled Access",
            0,
            AllureHermannParkPhotos),

        // TX-22: Latitude Med Center, Medical Center
        new(
            "1850-old-main-st-houston-tx",
            "Latitude Med Center — 1 bd · 1 ba · Medical Center",
            "1850 Old Main St",
            "Houston, TX",
            1190,
            1,
            1,
            650,
            """
            Modern luxury in Houston's premier Texas Medical Center. Immediate proximity to Rice University, Rice Village, Hermann Park, and Houston's culinary and art scene.

            Sky lounge, co-working space, and micro units available. Virtual tours offered with pet-friendly policies and modern fitness center overlooking the Medical Center.
            """.Trim(),
            "Virtual Tours, Fitness Center, Pool, Co-Working Space, Pet Friendly, Sky Lounge",
            0,
            LatitudeMedCenterPhotos),

        // TX-23: Memorial West, Memorial
        new(
            "14900-memorial-dr-houston-tx",
            "Memorial West — 1 bd · 1 ba · Memorial",
            "14900 Memorial Dr",
            "Houston, TX",
            1063,
            1,
            1,
            763,
            """
            Luxury apartments close to Memorial City Mall and City Centre in the Energy Corridor. Near Bear Creek, Nottingham, and Terry Hershey Parks within Spring Branch School District.

            Easy I-10 access for commutes, resort-style pool, and pet-friendly community. Near world-class shopping, dining, and entertainment at Memorial City and CityCentre.
            """.Trim(),
            "Pool, Fitness Center, Virtual Tours, Pet Friendly, Controlled Access, Near Terry Hershey Park, Easy I-10 Access",
            0,
            MemorialWestPhotos),

        // TX-24: Galleria Parc Apartments, Galleria
        new(
            "3363-mccue-rd-houston-tx",
            "Galleria Parc — 1 bd · 1 ba · Galleria",
            "3363 McCue Rd",
            "Houston, TX",
            980,
            1,
            1,
            659,
            """
            Mixing the thrill of Uptown Houston living with the serenity of home. Near the Galleria, Nature Discovery Center, and Houston Arboretum.

            Resort-style pool, modern fitness center, and controlled access. Steps from world-class shopping at the Galleria and Uptown Park dining district.
            """.Trim(),
            "Pool, Fitness Center, Controlled Access, Pet Friendly, Near Galleria, Business Center",
            0,
            GalleriaParcPhotos),

        // TX-25: The James River Oaks, River Oaks
        new(
            "2303-mid-ln-houston-tx",
            "The James River Oaks — 1 bd · 1 ba · River Oaks",
            "2303 Mid Ln",
            "Houston, TX",
            1190,
            1,
            1,
            700,
            """
            Luxury mid-rise in Houston's prestigious River Oaks with striking views. Concierge services, private resident bar, and luxurious pool deck near the Galleria.

            Hardwood flooring, granite countertops, and premium finishes throughout. In the heart of River Oaks with fine dining, boutique shopping, and Highland Village nearby.
            """.Trim(),
            "Concierge, Private Resident Bar, Pool Deck, Fitness Center, Hardwood Flooring, Granite Countertops",
            0,
            TheJamesRiverOaksPhotos),

        // TX-26: San Paloma, Energy Corridor
        new(
            "1255-eldridge-pky-houston-tx",
            "San Paloma — 1 bd · 1 ba · Energy Corridor",
            "1255 Eldridge Pky",
            "Houston, TX",
            1050,
            1,
            1,
            814,
            """
            Luxury community in Houston's Energy Corridor with resort-inspired features. Near Terry Hershey Park, Villages Shopping Center, and Texas Children's Hospital West Campus.

            Olympic-sized pool, heated spa, tanning deck with cabanas, and dog park. Business center, playground, and easy access to the Westpark Tollway and I-10.
            """.Trim(),
            "Olympic-Sized Pool, Heated Spa, Tanning Deck, Cabanas, Fitness Center, Dog Park, Playground, Business Center",
            0,
            SanPalomaPhotos),
    ];

    // ═══════════════════════════════════════════════════════════════
    // CALIFORNIA PHOTO ARRAYS
    // ═══════════════════════════════════════════════════════════════

    private static readonly string[] JosephineDtlaPhotos =
    [
        "https://images1.apartments.com/i2/IgxvkWGpvSrxEs992ch0ncbMvBK8wVMshCLR8TjEpSw/111/josephine-dtla-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/-Qnd3Yh-VvzV_BSIXmqdXgPspEInpT05IKpqHpx3ZQg/117/josephine-dtla-los-angeles-ca-b7.jpg",
        "https://images1.apartments.com/i2/IINh0SkM3pyEECYOC6uqr2HI0XpNiSYMub_AqxPhQMc/117/josephine-dtla-los-angeles-ca-pool.jpg",
        "https://images1.apartments.com/i2/huXsxQNXTS-lSimGgnwlhoQ8HRf5vBUSbg_R3NUAb8Q/117/josephine-dtla-los-angeles-ca-towel-service.jpg",
        "https://images1.apartments.com/i2/vRvbl_oGs8nH9jBySoV6OghJ_WlG8QjJUPQsI9q4mhU/117/josephine-dtla-los-angeles-ca-hot-tub.jpg",
    ];

    private static readonly string[] FusionHollywoodPhotos =
    [
        "https://images1.apartments.com/i2/ROyapbFrTohonSRuYEaTDK1Fv0mmH5d5uHCQWVebrvE/111/fusion-hollywood-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/Bw-aOjIZnU_w65yd__Z5VeWX5co5OlMBHVcHMbWzWyY/117/fusion-hollywood-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/pAyms4fW1tmUZUkoOvwKzNwUZbDc5pjbVkRRfX86mkw/117/fusion-hollywood-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/UamWT2p_8hnObOBQKh0EUkf-FkD3KUdPSqUZkear0PQ/117/fusion-hollywood-los-angeles-ca-entrance.jpg",
        "https://images1.apartments.com/i2/5ny7OuKkg67_wHYm19WO_diaNOZ3VWW1ZK4ItBXgSgg/117/fusion-hollywood-los-angeles-ca-lobby-photo.jpg",
    ];

    private static readonly string[] HollywoodVistaPhotos =
    [
        "https://images1.apartments.com/i2/duuSaopFryWLP2qaUhGVGkzCsvPX67AxhL33FEFYLBs/111/hollywood-vista-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/k6eITf-M2adYNkPDYGoWx6Mltou5nsCXqvowr6xYMEM/117/hollywood-vista-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/qj12iYyLI2wO-kA2zy8tNIIqpwM3ctMSXJRuqjIIJcw/117/hollywood-vista-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/fOZ5gGDPER-usss3yKpu7m3Fa6N5FQVVtK4FvFbP-GQ/117/hollywood-vista-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/sGCm8QmPpSsD24jC3m5mxVEZq7WfJsAC5PLMb1wxSg4/117/hollywood-vista-los-angeles-ca-building-photo.jpg",
    ];

    private static readonly string[] EchoParkAvePhotos =
    [
        "https://images1.apartments.com/i2/15-Y2lT3HiZM7XJIGbKkxfX3fbd7aw0EcYbJjsgmBQo/111/1111-echo-park-ave-unit-202-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/u6leKYDOm5c2vHgrOUwlf78-QLt7z6Tfh3mHVJPm_Xw/117/1111-echo-park-ave-unit-202-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/4UtB44d0RwmrNq5Rp-zubD0h-0U-R-n7qWPEOgs_ZvY/117/1111-echo-park-ave-unit-202-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/w0GRMVtKWpsS4kF8pdUmf6zbtY3P9DJayx0q65bxEqY/117/1111-echo-park-ave-unit-202-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/gA5jFYyn0FrLV3YrR26GsDTo5LQbNxR6Qukj9K0q5U4/117/1111-echo-park-ave-unit-202-los-angeles-ca-building-photo.jpg",
    ];

    private static readonly string[] AbbotKinneyPhotos =
    [
        "https://images1.apartments.com/i2/6CnkgiIRVGjmp6fFuzvCR7UJfGTsv9yzut5e6udvLeQ/111/02700ab-venice-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/TEl3EbFCgP-ST6Qav9DoYdYLfKpW85PIvFnK-LzWoBs/117/02700ab-venice-ca-2bd-1ba---825sf---ktichen.jpg",
        "https://images1.apartments.com/i2/Yndq2X_3XQvQ0g5gg5vTakE9eCSMIrGFVzHHue1oqfI/117/02700ab-venice-ca-2bd-1ba---825sf---dining-room.jpg",
        "https://images1.apartments.com/i2/GsvsA5Z5jSU25w5TSaYde0YsosSb1kPIQoMosOzSCBU/117/02700ab-venice-ca-2bd-1ba---825sf---dining-room.jpg",
        "https://images1.apartments.com/i2/bvFpzf81W-up-Z1q_R3cLulwzY4nefNNOMKouDOTcpw/117/02700ab-venice-ca-2bd-1ba---825sf---living-room.jpg",
    ];

    private static readonly string[] LosFelizBlvdPhotos =
    [
        "https://images1.apartments.com/i2/41tPEwYow26bMzpduB7fgT71cSxAoymtYPl2LT-bxtM/111/4402-los-feliz-blvd-unit-205-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/3CwEIVzuY6C-cKSgWgyISIGDD6pzPV4hp8f2bty4lIs/117/4402-los-feliz-blvd-unit-205-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/kxwyqVndtQpwgB3kz5NyMTjN2E4fQANWpkmGzRB0LL4/117/4402-los-feliz-blvd-unit-205-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/iZ03KJj7ATI7Oq3Aoca26OaijHxg1J5Ozqg4fssgGhM/117/4402-los-feliz-blvd-unit-205-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/7N0fJiQEDK8ixWwL3FuyXTYo1iDrXk8N3IG2aX80t8o/117/4402-los-feliz-blvd-unit-205-los-angeles-ca-building-photo.jpg",
    ];

    private static readonly string[] TheChadwickPhotos =
    [
        "https://images1.apartments.com/i2/eL0rRopzU-vGHioN_1uNxfOqsX-7VQ4iCEBnr1o5C6w/111/the-chadwick-los-angeles-ca-newly-renovated-diningroom.jpg",
        "https://images1.apartments.com/i2/Qd3PIrVIdRMfyQGwOlpzBy0iiv71ND19QBvGnV6bk18/117/the-chadwick-los-angeles-ca-newly-renovated-kitchen.jpg",
        "https://images1.apartments.com/i2/F6s11EpNUAtreqggARau-akFu7O0bWmE6Uq9Zm38rTM/117/the-chadwick-los-angeles-ca-come-home-today.jpg",
        "https://images1.apartments.com/i2/ZIvu7B-VphT7RS8vmLEAVSRwoHl0L590lngztZeU018/117/the-chadwick-los-angeles-ca-newly-renovated-bathroom.jpg",
        "https://images1.apartments.com/i2/JlX5mDtje6kuyOGsJnFW_uzs50h03160CMQQpNmGf00/117/the-chadwick-los-angeles-ca-newly-renovated-bedroom.jpg",
    ];

    private static readonly string[] EavesLosFelizPhotos =
    [
        "https://images1.apartments.com/i2/Sn8riM3ud6u_nk8rjyk5x3J-4bMOzWVsg6EobyztWVg/111/eaves-los-feliz-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/CP5fN7SLXWSFkKNgqdJlM5t9g5J_rwLm9NUkuP2hDJE/117/eaves-los-feliz-los-angeles-ca-renovated-i-kitchen-with-quartz-countert.jpg",
        "https://images1.apartments.com/i2/nu4YjaP0Yn4x3iMiMdWepX7Uf4pTv50w1xY4LstFSQE/117/eaves-los-feliz-los-angeles-ca-renovated-i-kitchen-and-living-areas.jpg",
        "https://images1.apartments.com/i2/DoNYAwn6boWaiW9BHcRTYyq1DJrxLdBcbrxWTCv463U/117/eaves-los-feliz-los-angeles-ca-renovated-i-kitchen-dining-and-living-ar.jpg",
        "https://images1.apartments.com/i2/zjbajCJPk8TIdhCecNVamA-pqDHC9B8vUuQM6FVEwLk/117/eaves-los-feliz-los-angeles-ca-renovated-i-bedroom.jpg",
    ];

    private static readonly string[] RiseKoreatownPhotos =
    [
        "https://images1.apartments.com/i2/xao6PFJRLAkjdkEG9YsuWLOfmoEzA5z_w_HjeemaL4s/111/rise-koreatown-los-angeles-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/wasGd5P1rUFjskyN25CbyyFWnJTf59f7eXboNKT3u1k/117/rise-koreatown-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/yX4cOh7JFZVxmegI9koIbbtzpv_JDhuKxfK9hqosq3c/117/rise-koreatown-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/xgyuEgBg0OGrAfGo9SCTsilBJs-SoJdtetRKe3ssAes/117/rise-koreatown-los-angeles-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/SxQbZVW_q9rybh-ZYsOPVWtTHT5spUNf3E1KwxVsx80/117/rise-koreatown-los-angeles-ca-building-photo.jpg",
    ];

    private static readonly string[] InstrataLittleItalyPhotos =
    [
        "https://images1.apartments.com/i2/bn0lE3WqFCAdxtfPfFloimcanY8R6oGsidPJfL5TAdY/111/instrata-little-italy-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/4ko_MYZQeErQX2Z2x4mmzIBQJ0VBvPQG4MJVy2D4QTs/117/instrata-little-italy-san-diego-ca-2-br-2-ba---loft---1105-sf.jpg",
        "https://images1.apartments.com/i2/ZvNVRz2XyEsx__XNv39UHgpoRNiJLN71w16aZTQHGUM/117/instrata-little-italy-san-diego-ca-2-br-2-ba---loft---1105-sf.jpg",
        "https://images1.apartments.com/i2/CeAaa22KvyIFel3scWvrq06Oc4KHDaTh7yHNZPiOBLg/117/instrata-little-italy-san-diego-ca-pool-side-lounge-area.jpg",
        "https://images1.apartments.com/i2/6eMXz-sr28F-rAFjcBXbEoJOQpY2AECAB4Rvw9Vu_Po/117/instrata-little-italy-san-diego-ca-con-amore.jpg",
    ];

    private static readonly string[] ViciLittleItalyPhotos =
    [
        "https://images1.apartments.com/i2/OWXVyRKIbPb5eFcQXw_drs1LgwmlZ0rZJZc_PBeBwiw/111/vici-luxury-rentals---little-italy-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/24Emb_ZQmhjdhyWTM2weRFFvF5GpN1p7cOrQExYhUEI/117/vici-luxury-rentals---little-italy-san-diego-ca-rooftop-lounge.jpg",
        "https://images1.apartments.com/i2/QJ7f0hhBZXIFFrDnAFlOvcwNR1E5E8JLOHNxRnUvPe4/117/vici-luxury-rentals---little-italy-san-diego-ca-1br-1ba--904sf.jpg",
        "https://images1.apartments.com/i2/gmupof1_bS0WKKJQRGlQDc6pevP2fZ_iN8u_5mGFqB8/117/vici-luxury-rentals---little-italy-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/sc-3TKx3F3BD-shnF9RBkR-FRnG64olVNR1ZDL5WZ7c/117/vici-luxury-rentals---little-italy-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] ParklineNorthParkPhotos =
    [
        "https://images1.apartments.com/i2/HTA_5DvqWjpxgUkfLY4xc8jBGJAtZIHO4QXcOjQ4Gxc/111/parkline-north-park-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/5Y6yORkOgl2-gsy7GzZlCrwLrynKv07IdwQkBUt6TU8/117/parkline-north-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/WDlXO_nBEOWPJOk4JQ81BOeTlmrTTjT2PhprB-XzJjs/117/parkline-north-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/kjH5HD33JjJpiRiqd6PLjM6jICQ7On5b20ctjO4npLg/117/parkline-north-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/Y9XC47fyk48fEw_CXeJY8CkDvj-eHzyYZH19gnm6m4Q/117/parkline-north-park-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] AzulNorthParkPhotos =
    [
        "https://images1.apartments.com/i2/d1QpkF5ZUnQp0dsFOwH_kZMGCdzWhbm3Ishf3VUiWS4/111/azul-north-park-san-diego-ca-fountain-sunset.jpg",
        "https://images1.apartments.com/i2/JeJKLjfBs4EX-nGM0lqa0ovZRjmffoO1-lL4mTwn6fw/117/azul-north-park-san-diego-ca-north-park-building-signage.jpg",
        "https://images1.apartments.com/i2/4RgGOmCyK2aJJ4ht0sKjxOrxiei95KoOIt8cMT8r3jU/117/azul-north-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/picClGRW2oCcQ1iVviU-AXbkCWiaTpW5tLeHf5I96nI/117/azul-north-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/dXEO5rHc77yec5_8MpNj8CB3TY55DB3S7r2TKQDvfWM/117/azul-north-park-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] AvaPacificBeachPhotos =
    [
        "https://images1.apartments.com/i2/OzYTo1_iUdXKYMTvOI6dAooHRxzlp64xVoKI9NoU2Q0/111/ava-pacific-beach-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/9p0Ms77lsYxwb_koDdqjqI4XTfPrYFNFGjKvCg87_Ck/117/ava-pacific-beach-san-diego-ca-one-bedroom-dining-area.jpg",
        "https://images1.apartments.com/i2/bDsh7dutJ-jOVv2TTjbmEMgZy-rC-wLMtsF8hUIBtaw/117/ava-pacific-beach-san-diego-ca-two-bedroom-kitchen.jpg",
        "https://images1.apartments.com/i2/VKIOPXAUW9aBgPB-DXOasjbSx-eaNkBA_prLmgNVbGQ/117/ava-pacific-beach-san-diego-ca-two-bedroom-living-room.jpg",
        "https://images1.apartments.com/i2/Dx8kgq4TWTv4_bZplGT-_0FNfxYX8A5JOvgKuwsp9m4/117/ava-pacific-beach-san-diego-ca-two-bedroom-master-bedroom.jpg",
    ];

    private static readonly string[] ImtMissionValleyPhotos =
    [
        "https://images1.apartments.com/i2/U8aPV8Ojw-1XYfBf29YFiMb8eRCN9uEgFB49XWqXzgU/111/imt-mission-valley-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/esGdyM5hrWc7Efj2jvoSSka2IZpTEBWO_MzHXTtVGeo/117/imt-mission-valley-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/SwXWG2VpbnfA_ly4Bs8ho6jJf277JbuYWJTez8Dakk8/117/imt-mission-valley-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/eELjbOtM6Ae-OsavA0_Zjv1qygwOw8_ztR24xOyj9co/117/imt-mission-valley-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/2nPmiDL8tF417aQoiuqSmOzepTa967iwGsBxeTc5-us/117/imt-mission-valley-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] MetroMissionValleyPhotos =
    [
        "https://images1.apartments.com/i2/SXcoLV-d1x3WVIcsRftAB-_avFhfuXY8tIXLhSQSaZ0/111/metro-mission-valley-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/Ut_dyovKlgS-n_XrP230-j_aPAJ6dmp8JAPV7bC2F5k/117/metro-mission-valley-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/3K6tO5r2kdb-aHbIStzcvyYrtySgcKLtJSWSLcDVBaM/117/metro-mission-valley-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/kcRmbyXemM51KYdZiAQq3cZajOKVLDOwFRHnHlP6dyk/117/metro-mission-valley-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/AbO8OVLS2bm2Yw-2fBRvQF09ziMDW91IQ2R9NF81eNM/117/metro-mission-valley-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] WestParkPhotos =
    [
        "https://images1.apartments.com/i2/3Z5vknDa5SRl7qoGkojUV0pHph9-TJgZYsKnHRx2q6g/111/west-park-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/804mNh8yzuHY0UpB38xNe9ED2Dq45HFRRP8aex6-pSs/117/west-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/fC7dH3Q5Njz5XAtFfAgoT7y-kBrJTpPqnYZU-ZnXjsQ/117/west-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/UdMeoGwuaAs_6wBZdy9Ou9i50ruxqIxGMHEobTzztr8/117/west-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/xFtlkVtdDv3z6kC4J6UjhtHkg-iXVgkNdjHIZnkxhms/117/west-park-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] AliraPhotos =
    [
        "https://images1.apartments.com/i2/rGk-TKYEPsNXSSHoeZp8mwNSkzCMwYB71DRNwXd9IfY/111/alira-sacramento-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/z6JMC1puzcVoPGTQjOwIZ-rc4XTs5IMS5TjVgz4YxE0/117/alira-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/XS8D4KcR621we1ceaEZ5WmuPFuzMG2xoQRRmEg6xTvI/117/alira-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/d5t9ztoKdp6zuA2gP-KHDkobsvLSdTAK1N6ylMc6MUw/117/alira-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/wgH_SkFJ_cO3m-Vpj4XZpd7ONVhjvDZfQgTXhjXEDRI/117/alira-sacramento-ca-building-photo.jpg",
    ];

    private static readonly string[] MiramonteAndTrovasPhotos =
    [
        "https://images1.apartments.com/i2/_Mv8RAketGIWqdkppA1BUweJbKctjD4N2xmPT36yVtQ/111/miramonte-and-trovas-sacramento-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/RyHSuWxfQD7JX_fQJgRAFD8bRBP9XI2NKx_OER4lS2I/117/miramonte-and-trovas-sacramento-ca-2br-2ba---1060sf---kitchen.jpg",
        "https://images1.apartments.com/i2/B5d6OmqTdxOLGgUHsTttYr1of22SecxDOaUhudyciFA/117/miramonte-and-trovas-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/jvuQyRr2P_evZqd7DvyBNXasGjG7Fjob4fKi8EbwXzY/117/miramonte-and-trovas-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/h3r6xBW61IFAXIHOO6t4p4G9TOCckzxNbIuaYMtPJG0/117/miramonte-and-trovas-sacramento-ca-2br-2ba---1060sf---dining-room.jpg",
    ];

    private static readonly string[] SutterGreenPhotos =
    [
        "https://images1.apartments.com/i2/PzKn44qWxXayk_lznoADAoVQLJCe8FKCDTAEkdQ3CX4/111/sutter-green-apartments-sacramento-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/pfza1e5wVVPPlzo40TTifBsr2hDl2caFlspEVAeLsvo/117/sutter-green-apartments-sacramento-ca-lanai-media-retreat-phase-ii.jpg",
        "https://images1.apartments.com/i2/09v8Saw9h06vyrCUENdpIwM61Pln9EtLTrCO6lsgu9g/117/sutter-green-apartments-sacramento-ca-oasis-retreat-pool-amp-spa---phase-ii.jpg",
        "https://images1.apartments.com/i2/dLTtJn1z5pObCnyvB9O7DWvrlqgOt73-1C84tOtU5N8/117/sutter-green-apartments-sacramento-ca-sutter-green-phase-ii.jpg",
        "https://images1.apartments.com/i2/5fOs5IJLbqAWVBLliF6tx3raSDz1gzoKXIC2nrxLHSE/117/sutter-green-apartments-sacramento-ca-grill-amp-gather-pavilion---phase-ii.jpg",
    ];

    private static readonly string[] OctaviaPhotos =
    [
        "https://images1.apartments.com/i2/Eng_C6O8nD3I0GQUv1ZfNMOA57DEkVuGhrUpoysokXM/111/188-octavia-san-francisco-ca-2-bedroom.jpg",
        "https://images1.apartments.com/i2/N0OLySF-O1HZl1-9BAKWtx3apAGxSzPpHYWbQ28-gh0/117/188-octavia-san-francisco-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/u_CqVT06K_k6_Us27jMIXjxPGV6u8BYP8o6xew2uUp4/117/188-octavia-san-francisco-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/FHD31l5GtwEXM3u727hdBRyXlA0Xj14GiFOKVODR9KQ/117/188-octavia-san-francisco-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/T2k43h7aJnnviZLwLWKaWL2iIS0LHl-j-ErZpoRxxvc/117/188-octavia-san-francisco-ca-building-photo.jpg",
    ];

    private static readonly string[] HanoverSomaWestPhotos =
    [
        "https://images1.apartments.com/i2/EdxMLcKRAb35Ohw6qIYmQXi5hrT1oxVJ6Kg4AQCS1yw/111/hanover-soma-west-san-francisco-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/q4vsDp1Ied8jFNe4iP64hOcnZ7NXcSIF_daRAtKjLAI/117/hanover-soma-west-san-francisco-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/NuE8mpqa3cBsq3ZBeWF7GOqLioXPB3zRXrMr6FizGCk/117/hanover-soma-west-san-francisco-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/vENGSa--3OW_oJMbUXSFA7bP6h758JtJ9DXhITakckE/117/hanover-soma-west-san-francisco-ca-entrance.jpg",
        "https://images1.apartments.com/i2/GYo00zfQcTSZuCXYLH35uHPjWpT57rV0rEz_FbRFZDI/117/hanover-soma-west-san-francisco-ca-resident-lobby-with-smart-tv.jpg",
    ];

    private static readonly string[] ElanBeachloftsPhotos =
    [
        "https://images1.apartments.com/i2/StZsn-8TO0DcoYKFHD4drAQ_-LMfhfR5E4IhSFC8KNk/111/elan-beachlofts-pacific-beach-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/YVi2Zzpg9UukBKxjp32QSxNgsK4QLpRxBkVBwFtCszk/117/elan-beachlofts-pacific-beach-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/FXfQQ7UfqGmqibcf-v5PMUEIgnRDFJYSzq5i3Gs77FE/117/elan-beachlofts-pacific-beach-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/ZQbthGoZrf0sIiPdvMlKLNafozD6sWtUhyX4xYyW36A/117/elan-beachlofts-pacific-beach-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/fymtLc_OwZFK7V4dHUNSbJ1DxRGO8dfRba3k5eKi4Uw/117/elan-beachlofts-pacific-beach-ca-building-photo.jpg",
    ];

    private static readonly string[] AvazPacificBeachPhotos =
    [
        "https://images1.apartments.com/i2/Xgln9jb6ufvFdNAT1dACGecf_Mtb5joms4niNhxjFyA/111/avaz-pacific-beach-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/re-HjFCDprqDyux14IjG6yCBnr6C3woCEOw4HhKuJX4/117/avaz-pacific-beach-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/h17TefZSuCfcPltlpct24GAOv0PAXGPI-V0eI66bFR4/117/avaz-pacific-beach-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/c7wTc0YFkVGkP8kP0c6nmezmN7Rqk9lR4f8dShrD7PY/117/avaz-pacific-beach-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/MAlhmxh2t4or6_EDqJ6F2ZXqtkteRYrZQuyZkIYmdTc/117/avaz-pacific-beach-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] PacificBeachShoresPhotos =
    [
        "https://images1.apartments.com/i2/myEmbpETcmaQ-PWpgd-kYtL13LLFC6yne2kR1u6hqc0/111/pacific-beach-shores-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/IRjilmOZFEg0JlG1d-cehHv2KVTEMEmPONbm7-p-_qM/117/pacific-beach-shores-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/AGLwa0yVl1NhD70ghxZNDMSzl1bFwywf8CW68EvsY0E/117/pacific-beach-shores-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/ac7s6TGORqWljoIc8AYiCQPb0yCFPVpurLoSMGzlF6s/117/pacific-beach-shores-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/12fKsq9R9EiPnHmfGKomkG4iRUPBYC3PY7xgUUFU7rY/117/pacific-beach-shores-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] IceHouseMidtownPhotos =
    [
        "https://images1.apartments.com/i2/-O93WDePqAiQGsw7yU-OUoZs3dTd2PvTlivbCGv8W2I/111/ice-house-midtown-sacramento-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/-6DZEfFIzpwvxqD2kSU3-CxmaxPe-PZ-dehcNGTPiSE/117/ice-house-midtown-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/bJK952igLzW4soCw51MdSGD0saPWgAsCKkbM0BleAps/117/ice-house-midtown-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/T6RR1sHI-l5EJSSwrZBQCX4x9IF13vi3boMZp9CzVRE/117/ice-house-midtown-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/_Y_jbgzhHhKZ9y32zP0imTOSVcSzBvNSdHcFwgGdSFA/117/ice-house-midtown-sacramento-ca-building-photo.jpg",
    ];

    private static readonly string[] TheModMidtownPhotos =
    [
        "https://images1.apartments.com/i2/RqKvISKMDW3VXpVltLH3D6O4UwYmhjpYv5j2dKEuQVY/111/the-mod-at-midtown-sacramento-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/K4rwqYAR_4-dAwRADzIJbNwau4rO5fjXO5EP9hn2t0E/117/the-mod-at-midtown-sacramento-ca-a-13-1br-1ba---640sf---living-room.jpg",
        "https://images1.apartments.com/i2/2e4W4EAxZsOXPns5Boy2hDE6aYonAIHIdEi7v6cxz0Y/117/the-mod-at-midtown-sacramento-ca-social-lounge.jpg",
        "https://images1.apartments.com/i2/d7_lDsaNoNmX0LmH4ziHsDdbtQzt9RLw4AIovoOtPfQ/117/the-mod-at-midtown-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/dfCYfbecQYxno_Z0EURP-nIQWXqsbYfl12EkWIEbs90/115/fpi-management-logo.jpg",
    ];

    private static readonly string[] TrinityPlacePhotos =
    [
        "https://images1.apartments.com/i2/pIPbPUPvogKgHHoJ1QrH3BQj-_Odoc0NhOSgy8MEB0k/111/1190-mission-at-trinity-place-san-francisco-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/Sg1ViWUN4m8QtNqStFApI347MrP4KOI9SPlZEpbzFzE/117/1190-mission-at-trinity-place-san-francisco-ca-jr-1br-1ba--478sf.jpg",
        "https://images1.apartments.com/i2/c_X2dwn-m4VRGcZsc7G-sYDt_jdhJoMaCGhbg4N_ER4/117/1190-mission-at-trinity-place-san-francisco-ca-jr-1br-1ba--478sf.jpg",
        "https://images1.apartments.com/i2/QAzrMXJYZMwJAmxg4GxP9AG-jSSgL5gIyeeEPSUWxRk/117/1190-mission-at-trinity-place-san-francisco-ca-jr-1br-1ba--478sf.jpg",
        "https://images1.apartments.com/i2/rg5hjYp5GxchwZPNIIvlASEsN8MWgaHWP6GzIKP7CX4/117/1190-mission-at-trinity-place-san-francisco-ca-jr-1br-1ba--478sf.jpg",
    ];

    private static readonly string[] SomaResidencesPhotos =
    [
        "https://images1.apartments.com/i2/ZKPExvQZ58W9lt34iCGAqTN7f8Nik4Qd1udd0WL_2wY/111/soma-residences-san-francisco-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/gP3u_0pvRisLnPh_dEoJRGUXCoIXlxfhoK_mAW3cDrs/117/soma-residences-san-francisco-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/BH82f-HQYnNfQCGUDX1BQgt6NCxuFUrMj3Z1RbX-xnk/117/soma-residences-san-francisco-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/xSFMUMGsiGZeym4DMsfAoTAqKKsTXuwkZ5kWwaYb1g0/117/soma-residences-san-francisco-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/ML_ilHLrZ5BDovgzs4irv_VTIC47WN6Vws7FkLCQ1ME/117/soma-residences-san-francisco-ca-kitchen.jpg",
    ];

    // ═══════════════════════════════════════════════════════════════
    // HOUSTON PHOTO ARRAYS
    // ═══════════════════════════════════════════════════════════════

    private static readonly string[] HanoverMontrosePhotos =
    [
        "https://images1.apartments.com/i2/724QVtTAM_jo2CXWB6bXBWP5jOAjZYOJo02DlsA_A04/111/hanover-montrose-houston-tx-conveniently-located-in-montrose-offerin.jpg",
        "https://images1.apartments.com/i2/bA2lKLGmOt5XpA_fuNYBFseectom7sd7e0Fm7Wet75M/117/hanover-montrose-houston-tx-resort-style-pool-deck-with-a-variety-of.jpg",
        "https://images1.apartments.com/i2/dH9VXBZUnBn5kDybgIq-a6UgT7C355COECNCNHXMdkI/117/hanover-montrose-houston-tx-resort-style-pool-deck-offering-both-sun.jpg",
        "https://images1.apartments.com/i2/Kk0UdAlOq40BrTr8Fm50H1zQ5eWcc24pm3xmu1NRTu8/117/hanover-montrose-houston-tx-elevated-pool-deck-with-private-poolside.jpg",
        "https://images1.apartments.com/i2/1g1tRLXHgAxp0x_V_CzGDgLkCtEXAs6ED_IyXt2eCGw/117/hanover-montrose-houston-tx-9th-floor-loggia-offering-views-of-downt.jpg",
    ];

    private static readonly string[] LumenPhotos =
    [
        "https://images1.apartments.com/i2/CZf7NPHA63GTb9p6td2rA-piU54J0LEF4ZUAs955wtA/111/lumen-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/eXxVVYgwdFI2A2TJksJp0Jgp0k2HJ88w15bg1TD4jL4/117/lumen-houston-tx-1br-1ba---967sf.jpg",
        "https://images1.apartments.com/i2/6o4rrD2lHrxEWBEsRHWKGl0wUUrvMlgTh1iqYE9_W1k/117/lumen-houston-tx-1br-1ba---967sf.jpg",
        "https://images1.apartments.com/i2/q7RvtIv2_fv_L04SubLoNV2VvI9VnVP-waKVZMMt9mc/117/lumen-houston-tx-1br-1ba---967sf.jpg",
        "https://images1.apartments.com/i2/QjvhErwc4oZuTkDDzPyK8TNo_aMurhp4FqekxPmifYw/117/lumen-houston-tx-1br-1ba---967sf.jpg",
    ];

    private static readonly string[] CityPlaceMontrosePhotos =
    [
        "https://images1.apartments.com/i2/DZ1rlNfDkqnz9j98O6D5Lidtpod7y8n4q8yefl4ARmc/111/city-place-montrose-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/VSbupzx7Ewh3Q4haMrUMbxf2eS7r2elK2TFtlRu895Q/117/city-place-montrose-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/V_R65HmoIvxbbbCPbYj7cguxXLLSn0T2_NOP50mEoq0/117/city-place-montrose-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/xb3UX3WHCiqHa8ktDibO797v9auYK8G4p9nDWZBY_fo/117/city-place-montrose-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/8IOMbjgzy9fhoMTbSg9RqRDNpWnryc8tODp7sVhoUHo/117/city-place-montrose-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] UnitiMontrosePhotos =
    [
        "https://images1.apartments.com/i2/IjJR4rXVooFM6sKiav5eaH25tfWM-0qgckX6Z1PuerQ/111/uniti-montrose-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/nT_k0w1hWhe3PtquJMwOalhT2Lo7L6YT1CV5840XCEo/117/uniti-montrose-houston-tx-club-lounge.jpg",
        "https://images1.apartments.com/i2/bDg761Gxaw83AeAXukcyHyFK9zTJscoM6ED6TTSMa34/117/uniti-montrose-houston-tx-pool.jpg",
        "https://images1.apartments.com/i2/W1c-eOf7-X0YdbNJ4nFngMb4gJOBadFyvOGJQkMoQS0/117/uniti-montrose-houston-tx-club-lounge.jpg",
        "https://images1.apartments.com/i2/S1V6p9D0AOe_8JPOkwTRB8Ah4jd69fS8iafZx2PeopI/117/uniti-montrose-houston-tx-club-lounge.jpg",
    ];

    private static readonly string[] TheSovereignPhotos =
    [
        "https://images1.apartments.com/i2/nvWjy0TrgO6cM4wv08ITKfpmBXNIPe1fn2SANviD2b4/111/the-sovereign-at-regent-square-houston-tx-stunning-residences-with-gorgeous-views.jpg",
        "https://images1.apartments.com/i2/nqYk64OxZzsUs56WHz9eaP8NUTmOx3oU90tNhgxykWw/117/the-sovereign-at-regent-square-houston-tx-luxurious-75-lap-pool-with-sun-lounge.jpg",
        "https://images1.apartments.com/i2/cAnhgeBCLqKDyUl1NJwTrPAYtx6FfCz5NBlNaYmIM1g/117/the-sovereign-at-regent-square-houston-tx-our-community-features-a-zen-garden.jpg",
        "https://images1.apartments.com/i2/2LE8mnQw7TOLogUSnIRVYgyYHhy_vUJ20IO7Bihq7SY/117/the-sovereign-at-regent-square-houston-tx-master-bath-with-luxurious-oversized-ova.jpg",
        "https://images1.apartments.com/i2/Xz37n8nScbt5AL1zsx4yOOIl41WxAvmD9b7zbEFb5yU/117/the-sovereign-at-regent-square-houston-tx-buffalo-bayou-park-is-just-a-mile-away.jpg",
    ];

    private static readonly string[] MidtownOnTheRailPhotos =
    [
        "https://images1.apartments.com/i2/Zn21UaG2ZLppMFzye1A40XCZiPZlkEyU6SkFFb-O1O8/111/midtown-on-the-rail-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/V3vB2MEp2ADs3j21kwvWsKRdEHynJzjDo1kXH0LahMY/117/midtown-on-the-rail-houston-tx-rendering-photo.jpg",
        "https://images1.apartments.com/i2/X6x1xXZLEldDsYGCnGn8ZDRqBQtHtpiAuKUXZyrku3k/117/midtown-on-the-rail-houston-tx-interior-photo.jpg",
        "https://images1.apartments.com/i2/YsB9heUv_ljw0IjVmxpDCn8apyKJsZ_iVYku08aRAk0/117/midtown-on-the-rail-houston-tx-interior-photo.jpg",
        "https://images1.apartments.com/i2/Oi0c3L7CGezLPgUXFyAtYPpKCg9c6F9M6Z1TolTkhMM/117/midtown-on-the-rail-houston-tx-interior-photo.jpg",
    ];

    private static readonly string[] MidtownOne80Photos =
    [
        "https://images1.apartments.com/i2/k1Qf28LVgNlPOnCl8Zk8uHxexCpPwpGjwxoHE11yzEI/111/midtown-one80-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/f8RKrUpdr5gmmjsNr_gErFFaod2aIQ25UCLfSVNHF04/117/midtown-one80-houston-tx-living-room.jpg",
        "https://images1.apartments.com/i2/emRW_nmhmt3Kc7HkmXpZelpc7NysG8ISm2nzVOyDixM/117/midtown-one80-houston-tx-living-room.jpg",
        "https://images1.apartments.com/i2/UQlq94oPjG4kpgE2xcBpAfGdDe5l0H-jbHihnvEp__A/117/midtown-one80-houston-tx-kitchen.jpg",
        "https://images1.apartments.com/i2/PSpWd-SmOqbQK8EPUCIo_Mdhim5VzyNKG3C8lNMJbHw/117/midtown-one80-houston-tx-kitchen.jpg",
    ];

    private static readonly string[] MidtownHoustonLivingPhotos =
    [
        "https://images1.apartments.com/i2/tUppaYMuMxPozlDndPZDohIlNPLZ5CzQWEwmVgkvjcg/111/midtown-houston-living-houston-tx-is-it-pool-time-yet.jpg",
        "https://images1.apartments.com/i2/bgWtTpma5QuX5eWEietFexAEARQYytW51t67slz6yjY/117/midtown-houston-living-houston-tx-kitchen.jpg",
        "https://images1.apartments.com/i2/yiC5VKSliGqXVlRmkiIQD5RrTtnxGJmU_sigqP2EySE/117/midtown-houston-living-houston-tx-leasing-office.jpg",
        "https://images1.apartments.com/i2/J4nZAcN5spfTdau2DRTwpKWoFcVVlCxGcPo02wQRARc/117/midtown-houston-living-houston-tx-elevator-lobby.jpg",
        "https://images1.apartments.com/i2/koDzoYBk1DkloqCfhyMd-p8HARNhLASYkVYpRobxHNk/117/midtown-houston-living-houston-tx-coffee-maker.jpg",
    ];

    private static readonly string[] PearlMidtownPhotos =
    [
        "https://images1.apartments.com/i2/NfftoAby1MN_fA43nzrxNYjHgpbBIoguwtc8WMbc_SM/111/pearl-midtown-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/6zWib_b3jI3Ka3EvwLcnfA6tQ2gG3QehVpvR_EvFo_I/117/pearl-midtown-houston-tx-bedroom.jpg",
        "https://images1.apartments.com/i2/2RsWhW8A8w2sdCdihQp23K3Sb8vb3PRxeRy-NTxcrNs/117/pearl-midtown-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/xu5bCumuqYdeoItusDHz2LItEosNF2TBXjGZyJ3vSCs/117/pearl-midtown-houston-tx-kitchen.jpg",
        "https://images1.apartments.com/i2/Xi9dRC9VDn90fHSJLeahYWOkaeR6xsJzwhF5ux9hs0Q/117/pearl-midtown-houston-tx-living-area.jpg",
    ];

    private static readonly string[] SkyHouseRiverOaksPhotos =
    [
        "https://images1.apartments.com/i2/nBiG03TSoPUUycwjjMCMdktlbNulhKCDSironi7vBGI/111/skyhouse-river-oaks-apartments-houston-tx-two-resort-style-rooftop-pools.jpg",
        "https://images1.apartments.com/i2/2hHSLqrAi_9NQ4GdyCHphTMxlz3IdmzOR5Qt_l5_R80/117/skyhouse-river-oaks-apartments-houston-tx-upgraded-kitchenaid-stainless-steel-appl.jpg",
        "https://images1.apartments.com/i2/N0z-TUJz-6ou-ILVFkRijrgS_yZvPzS5E4YIiQOYqvo/117/skyhouse-river-oaks-apartments-houston-tx-hardwood-style-flooring-in-kitchen-livin.jpg",
        "https://images1.apartments.com/i2/GsLZhma-m7FBl85RoE-MzC78XSIicznqztcrnOK7UIU/117/skyhouse-river-oaks-apartments-houston-tx-spacious-bedrooms-with-floor-to-ceiling-.jpg",
        "https://images1.apartments.com/i2/wgSMHd6y_hfI2cS9sOzrUgrwlKMXfxNGFGIclIdU_g8/117/skyhouse-river-oaks-apartments-houston-tx-resort-style-pools-with-sun-shelves.jpg",
    ];

    private static readonly string[] TwentyFourElevenWashingtonPhotos =
    [
        "https://images1.apartments.com/i2/QE7dKcF3wAwlHOqMMmowzsQIpJo5y0LrMyusGojZQKM/111/24eleven-washington-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/3x030moYirflEaKRFW6c9FslwCaDE6jMuwK81jZixLQ/117/24eleven-washington-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/zKYQOO66240I85ITcFRQrQmkhWsY8VXKbvLty0GrQG0/117/24eleven-washington-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/Ybh3flEm7UE8YrptJZnOiSaV-DAmBtscKNLQNy5B-RA/117/24eleven-washington-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/TTyfraaIiqI-d86AUCPYsalN9YMShEiv0kEpVAHaAII/117/24eleven-washington-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] HeightsWestEndPhotos =
    [
        "https://images1.apartments.com/i2/oYd7xluBn5TVLeZ0WQgSpIx0ik8Iu7QDpw8tKu1TwyE/111/heights-west-end-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/cu9ROHmH5vCvFcZXfNq1z_d4BcKboYo-OFQT5S9SDzQ/117/heights-west-end-houston-tx-hmd4559.jpg",
        "https://images1.apartments.com/i2/lo8dB7snymPuDuMBlpD4EItXDDgxCJDaKSSMAlQhn3o/117/heights-west-end-houston-tx-hmd4562.jpg",
        "https://images1.apartments.com/i2/kcqzY4IKuixXZSk7js_Ir4sxhUSeHXzWAypLUUBeXmI/117/heights-west-end-houston-tx-hmd4580.jpg",
        "https://images1.apartments.com/i2/Zs5iOeL1Z3rIkWlfh6CitGuGFZwC_nVgOKnXlIg11UI/117/heights-west-end-houston-tx-hmd4586.jpg",
    ];

    private static readonly string[] PearlWashingtonPhotos =
    [
        "https://images1.apartments.com/i2/GwKj8NECAiS4EIK9sZO4F_BNQTdwMgb1Qf5-kMN82NI/111/pearl-washington-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/eluvZJr2j_HCmBvyTQKwVxJwFcSHgDsmuQwnD1TCquk/117/pearl-washington-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/ZRBe7AwqjwKfNFJn1e9v-erocAbnEMCtUPZINVKwgPQ/117/pearl-washington-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/p0HF9kkYXpfk0jOLAIh4ASrOP12j-xfdWugBIBgRHq8/117/pearl-washington-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/ekTn1UPGebjsBJf4ccDmSeaneaR2DP7-CDS45QM_KIU/117/pearl-washington-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] AveCdcWashingtonPhotos =
    [
        "https://images1.apartments.com/i2/cEJ2e9cUC5hxeWV31zT4bXZTZs4AuJA1dvbIoKL7mKY/111/avecdc-washington-courtyards-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/E3ZGsGxvI9VkGdnQ5gVMtn-WZUWCLkBG-7X8Js1-R38/117/avecdc-washington-courtyards-houston-tx-washington-courtyards.jpg",
        "https://images1.apartments.com/i2/EzIF31lxJXA2M0AZM-BLyyTxUOk8FTSlHATYyLu3n-g/117/avecdc-washington-courtyards-houston-tx-washington-courtyards.jpg",
        "https://images1.apartments.com/i2/4UrMao8xfnU8cundVCC6xD9L74p_Q_R8G80ihVRpWWU/117/avecdc-washington-courtyards-houston-tx-pool.jpg",
        "https://images1.apartments.com/i2/29vmZ5yNGySTizj0hFA45LNMpcT-tqmjuJYWnwA5MEg/117/avecdc-washington-courtyards-houston-tx-building-photo.png",
    ];

    private static readonly string[] YaleApartmentsPhotos =
    [
        "https://images1.apartments.com/i2/MiktdnmUbdaHvEOKPrft1GN7y4hxlyU3LupmTUKmYKc/111/2125-yale-apartments-houston-tx-upgraded-kitchens-with-quartz-countertop.jpg",
        "https://images1.apartments.com/i2/fUh0pYMwQjUTqbZtmDxGDI7IeL4bidjSkNsBr51lvOc/117/2125-yale-apartments-houston-tx-select-homes-feature-a-separate-dining-a.jpg",
        "https://images1.apartments.com/i2/Kp0ZhRKc5Q_KoDgAujNSB_fN2b92KnJSDsvrwvLxcKc/117/2125-yale-apartments-houston-tx-open-layout-with-upgraded-lighting-and-f.jpg",
        "https://images1.apartments.com/i2/WItmfQhhnJfPlbjFapLNwlyS66IE96fiRd6mL6AMy5E/117/2125-yale-apartments-houston-tx-remodeled-bathrooms-with-luxury-vinyl-pl.jpg",
        "https://images1.apartments.com/i2/D3COLOcD5XzaolEvYJpK2DJ8a1XJPHjnyXRcrIavwQk/117/2125-yale-apartments-houston-tx-ceiling-fans-in-living-and-bedroom-areas.jpg",
    ];

    private static readonly string[] AlexanJunctionPhotos =
    [
        "https://images1.apartments.com/i2/D3U3OjkxmB0IoMpaYTVcaOWoxqDxv_PKGz5lic0fYj0/111/alexan-junction-heights-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/QqeQ28kr3jElg8KFK9YutU4msyL8nSU5MhjRiFxCgls/117/alexan-junction-heights-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/qwk8Fo82hfKBM8DsRKqxTkRCC6nhIaXUqplLUiJCbPY/117/alexan-junction-heights-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/LUqJmjGFibg0lQlCv1-FZJIEq6ThUXNzqtPvBSh-WuM/117/alexan-junction-heights-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/fQqlnboWlhbguzTFnQxGD7f0BtGTHcgJYeqs6bMekXc/117/alexan-junction-heights-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] ElanMemorialParkPhotos =
    [
        "https://images1.apartments.com/i2/XIv5IR5c__0IQ4COBBkK_xz5fmEbmI8Kx8XwRtie5SI/111/elan-memorial-park-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/-vCK2qQ6sD9X1rMpySeGkoct6W5fydGUZUH_eB4rJhQ/117/elan-memorial-park-houston-tx-2br-2ba---1262sf.jpg",
        "https://images1.apartments.com/i2/-FFexH5brgqL5CBurL-ukIGHs5gzVxNZGRs1LmHwjn0/117/elan-memorial-park-houston-tx-2br-2ba---1262sf.jpg",
        "https://images1.apartments.com/i2/BYHLgZCRNuvDCp4Cs5cHAHvMHIUIgwkU6ed-hLuowdk/117/elan-memorial-park-houston-tx-2br-2ba---1262sf.jpg",
        "https://images1.apartments.com/i2/GPqahY5zKJgP3tuKhCd5PMf1JQbwpa3Wp__VWCumT9A/117/elan-memorial-park-houston-tx-2br-2ba---1262sf.jpg",
    ];

    private static readonly string[] CortlandMuseumPhotos =
    [
        "https://images1.apartments.com/i2/04fSYThxSi99LXaDb7N69a9uSNG8y0lPOm0qAcnSHOM/111/cortland-museum-district-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/4CBnQxLC3mG-W6PCg-ymKDTEV0PCUpSu3Fbe7L_1u-Q/117/cortland-museum-district-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/cwdtEbfXdHKu1aySwqVEBHvYVl3RKDzLiRUNrKEe9aI/117/cortland-museum-district-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/dxEw7C2RdPIKTPhRxQkVcDdOjLBW7yvPt1EBFCGpitY/117/cortland-museum-district-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/zyI3dCewe2A5CNu6EqZ_4CGRULNM63sIIof_S5HDQGU/117/cortland-museum-district-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] VenueMuseumPhotos =
    [
        "https://images1.apartments.com/i2/NgDq0q_cit4GSvgI6QFJmPUJdur7oCNiarYD_w0pc0U/111/venue-museum-district-houston-tx-bathroom-w-double-vanity.jpg",
        "https://images1.apartments.com/i2/AhDBpFgIMw7TaA2NbrYxeeTtFFFwKo5HvwgH17jHkpk/117/venue-museum-district-houston-tx-street-view.jpg",
        "https://images1.apartments.com/i2/JcSb7PSL9B80DjRKOoIl-WOM6poYDf3erXrT2B_pSek/117/venue-museum-district-houston-tx-open-living-space.jpg",
        "https://images1.apartments.com/i2/xCRfRY3s3TpBZhZoIEWkNCB6Gfy5-z9tsPS6gdHrQE4/117/venue-museum-district-houston-tx-kitchen-w-bar.jpg",
        "https://images1.apartments.com/i2/FV-2owejEQtWOsEmlRVzoeHRO73HcDa47t323Lg3iuc/117/venue-museum-district-houston-tx-open-floor-plan-layout.jpg",
    ];

    private static readonly string[] TheHeronMuseumPhotos =
    [
        "https://images1.apartments.com/i2/L3Jf4TsV5MHwR10yq1em2k4YUoZkCoNfpEheQwBmDKs/111/the-heron-museum-district-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/w2NGX61jq8OITQDGNpLaAaHdlbLGkdIsOweRCoM3Uss/117/the-heron-museum-district-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/jpuDnht0dRfFYJJe_Ng_UNKCz2P_wWqOivgGmzbLjZg/117/the-heron-museum-district-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/nUbgIp04peytJUlA99EGQ3S7mSuPP5iwkRobBJ5LJr8/117/the-heron-museum-district-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/j2V-OKEQNuPKO5IhdE11mYL-3cUI6ymDugUyeFbufvI/117/the-heron-museum-district-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] AllureHermannParkPhotos =
    [
        "https://images1.apartments.com/i2/nE-Z8AZ3k0_v43aAYgLjrxBS5f6USpAgoG2OQwmhrWk/111/allure-hermann-park-at-med-center-houston-tx-allure-hermann-park-houston-medical-cent.jpg",
        "https://images1.apartments.com/i2/eIXTE57me1PGjiO7iy4WlIXU44UVHNbVAR-lIY5vK2I/117/allure-hermann-park-at-med-center-houston-tx-allure-hermann-park-entry.jpg",
        "https://images1.apartments.com/i2/IfgjcpVRv4r0EVoIfs9PU14HHh-aJGBAA_KX-EiiQBE/117/allure-hermann-park-at-med-center-houston-tx-allure-hermann-park-infinity-pool-with-p.jpg",
        "https://images1.apartments.com/i2/OKFnrSEvpeVMpMEc7dmajwmosdELjgP1CNlpSnr-lSA/117/allure-hermann-park-at-med-center-houston-tx-allure-hermann-park-kitchen-with-city-vi.jpg",
        "https://images1.apartments.com/i2/aj0GiaW8Yy-MuZXGl49QPmSyR7eSA6RAGpoO3HsHuDU/117/allure-hermann-park-at-med-center-houston-tx-interior-photo.jpg",
    ];

    private static readonly string[] LatitudeMedCenterPhotos =
    [
        "https://images1.apartments.com/i2/Dg2Gvkobhw38CT795tqadDR2YGLtctPYdMR2qFbisRk/111/latitude-med-center-houston-tx-latitude-med-center-exterior-building.jpg",
        "https://images1.apartments.com/i2/9WDZXuJQrieWO2s52PrsHrwV-0xYxaWqHXL0FUbZjeE/117/latitude-med-center-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/z6BtCm_UhpFhnB1PTq9tMQmS-hQaqc80GIqT9uihBRM/117/latitude-med-center-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/NEPaKRCHoj1qCcmU2JseoQEGiY9EhwTipFqKr3XsbWQ/117/latitude-med-center-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/lBdpe9D1cYzNLob7DV3kvCdDGozK6b-gV5f8f0VOD_k/117/latitude-med-center-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] MemorialWestPhotos =
    [
        "https://images1.apartments.com/i2/cGnMqgH-hayX-2cEleHLsjeEgzQJxhwjkR9lH0gM2xU/111/memorial-west-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/GKo_xnaYWhnpXJ09PHWT4ECrPlebqxF8MGJH1lg8RWg/117/memorial-west-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/-vv4gAVA910-ts6-2c1AiK8Qzo8xL2wzDAsxxeRU8Qo/117/memorial-west-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/X-mcklAKHx-yTy9kZOsXcp5Ad9NHna1S-sxnB7azPcs/117/memorial-west-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/7Ql9ErTi6JFkB5AVvqUSglmW1xzhKCqe7yR7duWLay8/117/memorial-west-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] GalleriaParcPhotos =
    [
        "https://images1.apartments.com/i2/7ZKRbvdJaZPbvYmwKPqV7CZU8Q6EMyc2HNRvA7DN98Q/111/galleria-parc-apartments-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/3vTiZNkHibVPQZiUZFv5X9mrW2422drPBkZmN3GTy7I/117/galleria-parc-apartments-houston-tx-2br-2ba---mondrian---master-bedroom.jpg",
        "https://images1.apartments.com/i2/2S_jaEO1Xa0CJQ26GhE6LNiX_jlst7k2ow9anWxuYsI/117/galleria-parc-apartments-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/SQz9MJoV6gA-Bv_w5ofczCXA7M-u5pbS8dKOznoXe5Q/117/galleria-parc-apartments-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/MYTDpC-How6EfyGnUyUkIV0pQbtuhqbbn9dewACdPik/117/galleria-parc-apartments-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] TheJamesRiverOaksPhotos =
    [
        "https://images1.apartments.com/i2/TxRFKEUO7UqaoDwtryWxwKxKUaaZrHwI9Qq8VKAgIcI/111/the-james-river-oaks-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/5hwtXgz6rF08OD7rP3OSEsQwoBEonZ1BE3RUQWwcmIk/117/the-james-river-oaks-houston-tx-primary.jpg",
        "https://images1.apartments.com/i2/GByzd4hVaG95965lw59pHWnMzmMWQcu2-j9vKbbw-fs/117/the-james-river-oaks-houston-tx-building-entrance.jpg",
        "https://images1.apartments.com/i2/1Sn6M7VlHC8XyeOlOTzcIniT1BlggfAfuuWaqTnzj4s/117/the-james-river-oaks-houston-tx-lobby.jpg",
        "https://images1.apartments.com/i2/tsCqHHPlTKAIKNWCKgcEAX6JDwenr_ZHHth3Jc9eakQ/117/the-james-river-oaks-houston-tx-lobby.jpg",
    ];

    private static readonly string[] SanPalomaPhotos =
    [
        "https://images1.apartments.com/i2/a4GDoiwe2wWZ5DyXfieldDuwc501BVBk_0cn4ZsCJRM/111/san-paloma-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/p1GaNHW-gUvLIQBa4gR9jApg6BOKEhWbAdDn_yx9PdY/117/san-paloma-houston-tx-leasing-office.jpg",
        "https://images1.apartments.com/i2/GPI4KcodJX1TVciH41UdsB6l3VFh7MPBx9CVzafEce4/117/san-paloma-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/3g1HKIffrgWua4JfAAJdsP2IblLs4XvM1SDL8tDfM58/117/san-paloma-houston-tx-entrance.jpg",
        "https://images1.apartments.com/i2/5GBdQjv8mORIUU1Rsbu5ZHF1xsNeOftnVJxC3sahwwM/117/san-paloma-houston-tx-clubroom.jpg",
    ];
}
