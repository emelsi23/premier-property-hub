namespace ApartamentosRenta.Services.Catalog;

internal static class RealListingsCatalog
{
    public static CatalogProperty[] Properties =>
    [
        // ═══════════════════════════════════════════════════════════════
        // CALIFORNIA (50 properties)
        // ═══════════════════════════════════════════════════════════════

        // CA-1: The Abbey, Koreatown LA
        new(
            "3550-w-6th-st-los-angeles-ca",
            "The Abbey — 1 bd · 1 ba · Koreatown",
            "3550 W 6th St",
            "Los Angeles, CA",
            1607,
            1,
            1,
            715,
            """
            The Abbey is a beautifully restored apartment community in the heart of Koreatown, Los Angeles. This character-rich building combines historic charm with modern upgrades, offering stylish one-bedroom residences with updated interiors and hardwood-style flooring.

            Located steps from LA's best Korean BBQ, nightlife, and the Metro Purple Line for easy access to downtown, Hollywood, and the Westside. Modern kitchens with stainless appliances and abundant natural light throughout.
            """.Trim(),
            "Updated Interiors, Laundry Facility, Controlled Access, Near Metro, Pet Friendly, Courtyard",
            0,
            AbbeyPhotos),

        // CA-2: 616 Kenmore, Koreatown LA
        new(
            "616-s-kenmore-st-los-angeles-ca",
            "616 Kenmore — 1 bd · 1 ba · Koreatown",
            "616 S Kenmore St",
            "Los Angeles, CA",
            1677,
            1,
            1,
            700,
            """
            616 Kenmore is a modern boutique apartment building in Koreatown featuring a stunning rooftop terrace with panoramic city views. One-bedroom residences offer contemporary design with clean lines and premium finishes throughout.

            Amenities include a landscaped rooftop deck, common lounge, in-unit washer/dryer, and controlled-access entry. Perfectly situated near restaurants, shopping, and public transit with easy access to DTLA and the Westside.
            """.Trim(),
            "Rooftop Terrace, Common Lounge, In-Unit W/D, Controlled Access, Near Metro, City Views",
            0,
            KenmorePhotos),

        // CA-3: Garden Apartments, Hancock Park LA
        new(
            "260-s-sycamore-ave-los-angeles-ca",
            "The Garden Apartments — 1 bd · 1 ba · Hancock Park",
            "260 S Sycamore Ave",
            "Los Angeles, CA",
            1397,
            1,
            1,
            650,
            """
            The Garden Apartments offer classic Los Angeles living near the Miracle Mile and The Grove. Charming one-bedroom units with original architectural details updated for modern comfort, surrounded by lush courtyard landscaping.

            Walk to LACMA, the Petersen Automotive Museum, and dozens of restaurants on 3rd Street. Quiet residential street with easy access to La Brea, Fairfax, and the 10 freeway. Gated parking and on-site laundry.
            """.Trim(),
            "Gated Parking, Laundry On-Site, Courtyard Garden, Near The Grove, Hardwood Floors, Pet Friendly",
            0,
            AbbeyPhotos),

        // CA-4: Parkline North Park, San Diego
        new(
            "4501-north-park-way-san-diego-ca",
            "Parkline North Park — 1 bd · 1 ba · North Park",
            "4501 North Park Way",
            "San Diego, CA",
            1540,
            1,
            1,
            680,
            """
            Parkline North Park places you in the center of San Diego's most vibrant neighborhood. Modern one-bedroom apartments with clean design, quartz countertops, and energy-efficient appliances throughout.

            Walk to craft breweries, independent restaurants, and the Thursday night farmers market on 30th Street. Near Balboa Park and excellent transit connections. Rooftop deck with city views available to residents.
            """.Trim(),
            "Rooftop Deck, Quartz Counters, Near Balboa Park, Walkable, EV Charging, Bike Storage",
            0,
            SdNorthParkPhotos),

        // CA-5: The Park, San Diego
        new(
            "4077-park-blvd-san-diego-ca",
            "The Park — 1 bd · 1 ba · University Heights",
            "4077 Park Blvd",
            "San Diego, CA",
            1607,
            1,
            1,
            650,
            """
            The Park offers stylish one-bedroom residences along the Park Boulevard corridor in University Heights. Contemporary design with wood-style flooring, stainless appliances, and private balconies with neighborhood views.

            Perfectly positioned between Hillcrest and North Park with walkable access to dining, nightlife, and Balboa Park. On-site fitness center, pool, and pet-friendly policies make this an ideal San Diego home.
            """.Trim(),
            "Pool, Fitness Center, Private Balconies, Pet Friendly, Near Balboa Park, Walkable",
            0,
            SdNorthParkPhotos),

        // CA-6: Stanza Little Italy, San Diego
        new(
            "2220-columbia-st-san-diego-ca",
            "Stanza Little Italy — Studio · 1 ba · Little Italy",
            "2220 Columbia St",
            "San Diego, CA",
            1712,
            0,
            1,
            550,
            """
            Stanza Little Italy is a modern boutique community in San Diego's premier dining and nightlife district. Efficient studio layouts with premium finishes, full kitchens, and oversized windows with natural light.

            Steps from the Mercato farmers market, waterfront parks, and dozens of acclaimed Italian restaurants. Near the Santa Fe Depot for Coaster and Amtrak access. Rooftop lounge with bay views.
            """.Trim(),
            "Rooftop Lounge, Bay Views, Walk Score 97, Near Waterfront, Full Kitchen, Package Lockers",
            0,
            SdLittleItalyPhotos),

        // CA-7: Niima, San Diego
        new(
            "4140-30th-st-san-diego-ca",
            "Niima — 1 bd · 1 ba · North Park",
            "4140 30th St",
            "San Diego, CA",
            1644,
            1,
            1,
            700,
            """
            Niima delivers contemporary apartment living on 30th Street in the heart of North Park. One-bedroom residences with designer finishes, in-unit washer/dryer, and smart home features integrated throughout.

            Surrounded by San Diego's best craft beer scene, boutique shopping, and diverse restaurants. Walk to Bird Park and Morley Field. Community amenities include courtyard, bike storage, and controlled access.
            """.Trim(),
            "In-Unit W/D, Smart Home, Courtyard, Bike Storage, Controlled Access, Walk Score 90",
            0,
            SdNorthParkPhotos),

        // CA-8: Loma Village, San Diego
        new(
            "3175-cauby-st-san-diego-ca",
            "Loma Village — 1 bd · 1 ba · Point Loma",
            "3175 Cauby St",
            "San Diego, CA",
            1505,
            1,
            1,
            720,
            """
            Loma Village Apartments is a peaceful community in Point Loma offering one-bedroom residences with updated interiors and generous living spaces. Enjoy cool ocean breezes and a laid-back coastal lifestyle year-round.

            Near Liberty Station shops and restaurants, Shelter Island marina, and Cabrillo National Monument. Easy access to the 8 and 5 freeways. Pool, laundry facilities, and assigned parking included.
            """.Trim(),
            "Pool, Ocean Breezes, Near Liberty Station, Assigned Parking, Laundry, Updated Interiors",
            0,
            SdCoastalPhotos),

        // CA-9: West Park, San Diego
        new(
            "1765-avenida-del-mundo-san-diego-ca",
            "West Park — 1 bd · 1 ba · Coronado Area",
            "1765 Avenida del Mundo",
            "San Diego, CA",
            1749,
            1,
            1,
            750,
            """
            West Park is a resort-style community offering spacious one-bedroom apartments near Coronado. Premium finishes with granite countertops, stainless appliances, and wood-style flooring throughout.

            Resort-caliber amenities including multiple pools, spa, fitness center, and clubhouse. Near shopping, dining, and San Diego Bay. Easy freeway access to downtown and the beaches.
            """.Trim(),
            "Resort Pool, Spa, Fitness Center, Clubhouse, Granite Counters, Near Bay",
            0,
            SdMissionValleyPhotos),

        // CA-10: Pinnacle on The Park, San Diego
        new(
            "575-park-blvd-san-diego-ca",
            "Pinnacle on The Park — 1 bd · 1 ba · East Village",
            "575 Park Blvd",
            "San Diego, CA",
            1680,
            1,
            1,
            720,
            """
            Pinnacle on The Park is a luxury high-rise in San Diego's East Village adjacent to Petco Park. One-bedroom residences with premium finishes, floor-to-ceiling windows, and stunning ballpark and city views.

            Walk to the Gaslamp Quarter, Convention Center, and waterfront. Sky-level amenities include rooftop pool, fitness center, resident lounge, and concierge services. Steps from trolley stops.
            """.Trim(),
            "Rooftop Pool, City Views, Concierge, Near Gaslamp, Fitness Center, Floor-to-Ceiling Windows",
            0,
            SdCoastalPhotos),

        // CA-11: The Helm, San Diego
        new(
            "2125-pacific-hwy-san-diego-ca",
            "The Helm — 1 bd · 1 ba · Little Italy",
            "2125 Pacific Hwy",
            "San Diego, CA",
            1677,
            1,
            1,
            680,
            """
            The Helm is a waterfront apartment community on Pacific Highway in Little Italy. One-bedroom residences with harbor views, modern kitchens, and open-concept living spaces designed for coastal living.

            Walk to Little Italy restaurants, the Embarcadero, and the USS Midway Museum. Amenities include rooftop pool with bay views, fitness center, and bike storage. Near trolley and bus lines.
            """.Trim(),
            "Harbor Views, Rooftop Pool, Near Embarcadero, Fitness Center, Bike Storage, Walk Score 95",
            0,
            SdLittleItalyPhotos),

        // CA-12: Vici Luxury Little Italy, San Diego
        new(
            "2330-india-st-san-diego-ca",
            "Vici Luxury Rentals — 1 bd · 1 ba · Little Italy",
            "2330 India St",
            "San Diego, CA",
            1750,
            1,
            1,
            700,
            """
            Vici Luxury Rentals delivers upscale one-bedroom living in the heart of Little Italy. Designer interiors with quartz waterfall countertops, custom cabinetry, and floor-to-ceiling windows offering city views.

            Steps from San Diego's best restaurants, the waterfront, and Piazza della Famiglia. Premium amenities include infinity pool, sky lounge, concierge, and state-of-the-art fitness center.
            """.Trim(),
            "Infinity Pool, Sky Lounge, Concierge, Quartz Counters, City Views, Floor-to-Ceiling Windows",
            0,
            SdLittleItalyPhotos),

        // CA-13: River Run Village, San Diego
        new(
            "10845-rio-san-diego-dr-san-diego-ca",
            "River Run Village — 1 bd · 1 ba · Mission Valley",
            "10845 Rio San Diego Dr",
            "San Diego, CA",
            1733,
            1,
            1,
            740,
            """
            River Run Village offers peaceful one-bedroom living along the San Diego River in Mission Valley. Spacious residences with updated interiors, private patios, and scenic river trail access for jogging and biking.

            Walk to Fashion Valley Mall, trolley station, and numerous restaurants. Near the 8 and 163 freeways for easy commuting. Resort-style pool, spa, fitness center, and lush landscaping.
            """.Trim(),
            "River Trail, Resort Pool, Spa, Private Patios, Near Trolley, Fashion Valley Adjacent",
            0,
            SdMissionValleyPhotos),

        // CA-14: IMT Mission Valley, San Diego
        new(
            "7649-mission-gorge-rd-san-diego-ca",
            "IMT Mission Valley — 1 bd · 1 ba · Mission Valley",
            "7649 Mission Gorge Rd",
            "San Diego, CA",
            1705,
            1,
            1,
            730,
            """
            IMT Mission Valley is a well-appointed community offering one-bedroom apartments in San Diego's central Mission Valley location. Updated interiors with granite counters, stainless steel appliances, and wood-style flooring.

            Adjacent to Qualcomm trolley station and minutes from major shopping centers. Community features include two pools, spa, fitness center, business center, and covered parking.
            """.Trim(),
            "Two Pools, Spa, Fitness Center, Near Trolley, Covered Parking, Business Center",
            0,
            SdMissionValleyPhotos),

        // CA-15: The Archer, Sacramento
        new(
            "817-fulton-ave-sacramento-ca",
            "The Archer — 1 bd · 1 ba · Arden-Arcade",
            "817 Fulton Ave",
            "Sacramento, CA",
            1152,
            1,
            1,
            600,
            """
            The Archer provides comfortable one-bedroom apartments in Sacramento's Arden-Arcade neighborhood. Clean, well-maintained units with updated flooring, modern appliances, and good natural light throughout.

            Near Arden Fair Mall, Sacramento State University, and American River Parkway trails. Easy access to Highway 50 and Business 80. On-site laundry, pool, and assigned parking.
            """.Trim(),
            "Pool, Assigned Parking, Near Arden Fair, On-Site Laundry, Updated Flooring, Near Highway 50",
            0,
            SacramentoPhotos),

        // CA-16: Crossing at Riverlake, Sacramento
        new(
            "1070-lake-front-dr-sacramento-ca",
            "Crossing at Riverlake — 1 bd · 1 ba · Pocket",
            "1070 Lake Front Dr",
            "Sacramento, CA",
            1208,
            1,
            1,
            752,
            """
            Crossing at Riverlake is a peaceful lakeside community in Sacramento's desirable Pocket neighborhood. Spacious one-bedroom apartments with vaulted ceilings, walk-in closets, and private patios or balconies.

            Adjacent to walking trails and parks with views of the Sacramento River. Near I-5 for easy commuting to downtown. Resort-style pool, spa, fitness center, and lush landscaping.
            """.Trim(),
            "Lakeside, Resort Pool, Spa, Fitness Center, Vaulted Ceilings, Private Patio, Walk-In Closets",
            0,
            SacramentoPhotos),

        // CA-17: Reserve at Cadillac, Sacramento
        new(
            "61-cadillac-dr-sacramento-ca",
            "Reserve at Cadillac — 1 bd · 1 ba · Natomas",
            "61 Cadillac Dr",
            "Sacramento, CA",
            1260,
            1,
            1,
            955,
            """
            Reserve at Cadillac offers generously sized one-bedroom apartments in the Natomas area of Sacramento. Open floor plans with breakfast bars, walk-in closets, and attached garages available on select units.

            Near Natomas Marketplace shopping and dining. Quick freeway access to downtown Sacramento and the airport via I-5 and I-80. Community pool, spa, dog park, and fitness center.
            """.Trim(),
            "Attached Garages, Dog Park, Pool, Spa, Fitness Center, Near I-5, Open Floor Plans",
            0,
            SacramentoPhotos),

        // CA-18: Peacock Apartments, Sacramento
        new(
            "2125-fair-oaks-blvd-sacramento-ca",
            "Peacock Apartments — 2 bd · 1 ba · Arden-Arcade",
            "2125 Fair Oaks Blvd",
            "Sacramento, CA",
            1327,
            2,
            1,
            875,
            """
            Peacock Apartments offers spacious two-bedroom residences on Fair Oaks Boulevard in the Arden area. Well-maintained units with large living rooms, full-size kitchens, and generous bedroom sizes for comfortable living.

            Conveniently located near shopping, restaurants, and American River College. Easy access to Highway 50 and I-80. On-site laundry, ample parking, and a shaded courtyard for residents.
            """.Trim(),
            "Spacious 2BD, Shaded Courtyard, Ample Parking, On-Site Laundry, Near Shopping, Full Kitchen",
            0,
            SacramentoPhotos),

        // CA-19: Kinect at Southport, Sacramento
        new(
            "7950-pocket-rd-sacramento-ca",
            "Kinect at Southport — 1 bd · 1 ba · Pocket",
            "7950 Pocket Rd",
            "Sacramento, CA",
            1243,
            1,
            1,
            700,
            """
            Kinect at Southport is a modern community in Sacramento's quiet Pocket neighborhood. One-bedroom apartments with contemporary finishes, quartz countertops, and energy-efficient features throughout.

            Near the Sacramento River and miles of walking trails. Easy I-5 access for commuting to downtown or Elk Grove. Community pool, fitness center, clubhouse, and EV charging stations.
            """.Trim(),
            "EV Charging, Pool, Fitness Center, Clubhouse, Quartz Counters, Near River Trails",
            0,
            SacramentoPhotos),

        // CA-20: Sutter Green, Sacramento
        new(
            "77-cadillac-dr-sacramento-ca",
            "Sutter Green — 2 bd · 2 ba · Natomas",
            "77 Cadillac Dr",
            "Sacramento, CA",
            1344,
            2,
            2,
            900,
            """
            Sutter Green Apartments offers two-bedroom, two-bath residences in the well-connected Natomas neighborhood. Spacious layouts with dual master suites, full-size washer/dryer connections, and private patios.

            Near major employers, shopping centers, and Sacramento International Airport. Quick I-5 and I-80 freeway access. Pool, spa, fitness center, playground, and picnic areas for residents.
            """.Trim(),
            "Dual Masters, W/D Connections, Pool, Spa, Playground, Near Airport, Private Patios",
            0,
            SacramentoPhotos),

        // CA-21: Hollywood Hills Apartments, LA
        new(
            "1425-n-cherokee-ave-los-angeles-ca",
            "Cherokee Lofts — 1 bd · 1 ba · Hollywood",
            "1425 N Cherokee Ave",
            "Los Angeles, CA",
            1540,
            1,
            1,
            680,
            """
            Cherokee Lofts provides stylish one-bedroom residences in the heart of Hollywood, steps from the Walk of Fame and entertainment venues. Units feature high ceilings, modern kitchens, and large windows with city views.

            Walking distance to the Hollywood/Vine Metro station, Pantages Theatre, and top restaurants. Controlled access, rooftop views, and on-site laundry complete this prime Hollywood address.
            """.Trim(),
            "High Ceilings, Near Metro, Rooftop Access, Controlled Access, Laundry On-Site, Walk Score 95",
            0,
            KenmorePhotos),

        // CA-22: Silver Lake Terrace, LA
        new(
            "2910-glendale-blvd-los-angeles-ca",
            "Silver Lake Terrace — 1 bd · 1 ba · Silver Lake",
            "2910 Glendale Blvd",
            "Los Angeles, CA",
            1680,
            1,
            1,
            725,
            """
            Silver Lake Terrace is a boutique community in one of LA's most desirable neighborhoods. One-bedroom residences feature modern finishes, quartz countertops, and private balconies with neighborhood views.

            Steps from Silver Lake Reservoir walking trail, Sunset Junction shops, and acclaimed restaurants like Sqirl and Pine & Crane. The perfect blend of urban convenience and residential tranquility.
            """.Trim(),
            "Private Balconies, Quartz Counters, Near Reservoir, Walkable, Bike Storage, Pet Friendly",
            0,
            KenmorePhotos),

        // CA-23: Echo Park Vista, LA
        new(
            "1521-echo-park-ave-los-angeles-ca",
            "Echo Park Vista — 1 bd · 1 ba · Echo Park",
            "1521 Echo Park Ave",
            "Los Angeles, CA",
            1470,
            1,
            1,
            660,
            """
            Echo Park Vista puts you in the center of one of LA's most vibrant neighborhoods. Bright one-bedroom apartments with updated kitchens, hardwood floors, and generous closet space throughout.

            Walk to Echo Park Lake, Dodger Stadium, and the best tacos in the city. Quick commute to DTLA via Sunset Blvd. Secured entry, on-site laundry, and responsive management.
            """.Trim(),
            "Hardwood Floors, Near Echo Park Lake, Secured Entry, On-Site Laundry, Updated Kitchen, Near DTLA",
            0,
            AbbeyPhotos),

        // CA-24: West LA Apartments, LA
        new(
            "11740-w-pico-blvd-los-angeles-ca",
            "Pico West Apartments — 1 bd · 1 ba · West LA",
            "11740 W Pico Blvd",
            "Los Angeles, CA",
            1575,
            1,
            1,
            700,
            """
            Pico West Apartments delivers comfortable one-bedroom living in West Los Angeles near the 405 freeway and Westwood. Spacious layouts with full-size kitchens, ample storage, and natural light.

            Minutes from UCLA, Santa Monica, and Century City. Easy freeway access for commuters with on-site parking included. Laundry facilities, courtyard area, and friendly on-site management.
            """.Trim(),
            "Near UCLA, Parking Included, Laundry Facility, Courtyard, Near 405, Spacious Layouts",
            0,
            AbbeyPhotos),

        // CA-25: DTLA Lofts, LA
        new(
            "315-s-broadway-los-angeles-ca",
            "Broadway Lofts — Studio · 1 ba · DTLA",
            "315 S Broadway",
            "Los Angeles, CA",
            1750,
            0,
            1,
            550,
            """
            Broadway Lofts occupies a historic building in Downtown LA's vibrant Broadway corridor. Studio loft residences with soaring ceilings, exposed brick, oversized windows, and open floor plans designed for modern living.

            Walk to Grand Central Market, The Broad museum, and Walt Disney Concert Hall. Steps from multiple Metro stations for car-free commuting. Rooftop deck with downtown skyline views.
            """.Trim(),
            "Exposed Brick, High Ceilings, Rooftop Deck, Walk Score 98, Near Metro, Historic Building",
            0,
            KenmorePhotos),

        // CA-26: Venice Beach Living
        new(
            "520-venice-blvd-los-angeles-ca",
            "Venice Boardwalk Flats — 1 bd · 1 ba · Venice",
            "520 Venice Blvd",
            "Los Angeles, CA",
            1890,
            1,
            1,
            620,
            """
            Venice Boardwalk Flats offers laid-back one-bedroom living blocks from the iconic Venice Beach Boardwalk. Bright units with beachy modern finishes, open kitchens, and coastal light throughout.

            Walk to Abbot Kinney boutiques, Muscle Beach, and the Venice Canals. Bike to Santa Monica Pier in minutes. On-site bike storage, laundry, and courtyard seating area for residents.
            """.Trim(),
            "Near Beach, Bike Storage, Courtyard, Near Abbot Kinney, Laundry, Coastal Vibes",
            0,
            AbbeyPhotos),

        // CA-27: Los Feliz Apartments
        new(
            "5420-russell-ave-los-angeles-ca",
            "Russell Gardens — 1 bd · 1 ba · Los Feliz",
            "5420 Russell Ave",
            "Los Angeles, CA",
            1715,
            1,
            1,
            730,
            """
            Russell Gardens is a charming courtyard community in the desirable Los Feliz neighborhood. One-bedroom apartments with vintage character, updated kitchens, and peaceful garden views from private patios.

            Walk to Hillhurst Avenue shops, the Vista Theatre, and Griffith Park trails. Close to the Red Line Metro for downtown access. Pet-friendly community with on-site laundry and guest parking.
            """.Trim(),
            "Courtyard Garden, Private Patios, Near Griffith Park, Pet Friendly, Guest Parking, Vintage Charm",
            0,
            KenmorePhotos),

        // CA-28: DTLA South Park
        new(
            "1240-s-figueroa-st-los-angeles-ca",
            "Figueroa Place — Studio · 1 ba · South Park DTLA",
            "1240 S Figueroa St",
            "Los Angeles, CA",
            1435,
            0,
            1,
            500,
            """
            Figueroa Place provides modern studio living in DTLA's South Park district. Efficient layouts with full kitchenettes, contemporary bathrooms, and built-in storage solutions to maximize every square foot.

            Walk to LA Live, Crypto.com Arena, and the Convention Center. Multiple Metro lines nearby for easy commuting. Shared lounge, laundry room, and secured entry with camera system.
            """.Trim(),
            "Near LA Live, Secured Entry, Shared Lounge, Laundry Room, Near Metro, Built-In Storage",
            0,
            AbbeyPhotos),

        // CA-29: Koreatown Mid-Rise
        new(
            "3750-wilshire-blvd-los-angeles-ca",
            "Wilshire Royale — 1 bd · 1 ba · Koreatown",
            "3750 Wilshire Blvd",
            "Los Angeles, CA",
            1750,
            1,
            1,
            740,
            """
            Wilshire Royale is an elegant mid-rise on Wilshire Boulevard offering refined one-bedroom residences in Koreatown. Units feature crown molding, walk-in closets, and full-size in-unit washer/dryer.

            Steps from the Purple Line Metro and surrounded by world-class Korean cuisine, spas, and nightlife. Building amenities include fitness room, rooftop sundeck, and 24-hour security.
            """.Trim(),
            "In-Unit W/D, Fitness Room, Rooftop Sundeck, 24hr Security, Valet Parking, Crown Molding",
            0,
            KenmorePhotos),

        // CA-30: East Hollywood
        new(
            "5320-hollywood-blvd-los-angeles-ca",
            "Hollywood Palms — 1 bd · 1 ba · East Hollywood",
            "5320 Hollywood Blvd",
            "Los Angeles, CA",
            1330,
            1,
            1,
            620,
            """
            Hollywood Palms offers affordable one-bedroom living in East Hollywood with easy access to the Red Line Metro. Recently renovated units feature new flooring, updated bathrooms, and modern light fixtures.

            Close to Thai Town restaurants, Griffith Park hiking trails, and the Barnsdall Art Park. Quiet community with gated entry, on-site management, and covered parking options for residents.
            """.Trim(),
            "Renovated Units, Gated Entry, Covered Parking, Near Metro, On-Site Management, Cat Friendly",
            0,
            AbbeyPhotos),

        // CA-31: SF SOMA
        new(
            "88-bluxome-st-san-francisco-ca",
            "Bluxome Place — Studio · 1 ba · SOMA",
            "88 Bluxome St",
            "San Francisco, CA",
            1890,
            0,
            1,
            480,
            """
            Bluxome Place offers modern studio living in San Francisco's SOMA district near the Caltrain station. Compact but well-designed residences with full kitchens, in-unit washer/dryer, and contemporary finishes.

            Walk to Oracle Park, the Embarcadero, and countless tech offices. Near Muni and BART for easy transit across the Bay Area. Rooftop deck, bike room, and package lockers included.
            """.Trim(),
            "In-Unit W/D, Rooftop Deck, Near Caltrain, Bike Room, Package Lockers, Walk Score 97",
            0,
            KenmorePhotos),

        // CA-32: SF Mission
        new(
            "2788-mission-st-san-francisco-ca",
            "Mission Flats — 1 bd · 1 ba · Mission District",
            "2788 Mission St",
            "San Francisco, CA",
            1960,
            1,
            1,
            600,
            """
            Mission Flats provides one-bedroom apartments in San Francisco's vibrant Mission District. Bright units with modern kitchens, hardwood floors, and generous windows overlooking the bustling neighborhood.

            Steps from 24th Street BART, Mission Dolores Park, and the best taquerias in the city. Surrounded by murals, boutiques, and nightlife. Laundry on-site and bike parking available.
            """.Trim(),
            "Near BART, Hardwood Floors, Near Dolores Park, Bike Parking, Laundry On-Site, Walkable",
            0,
            AbbeyPhotos),

        // CA-33: SF Marina
        new(
            "1850-chestnut-st-san-francisco-ca",
            "Marina Gardens — 1 bd · 1 ba · Marina District",
            "1850 Chestnut St",
            "San Francisco, CA",
            1960,
            1,
            1,
            620,
            """
            Marina Gardens is a charming apartment community on Chestnut Street in San Francisco's Marina District. One-bedroom units with classic charm, updated interiors, and views of tree-lined streets.

            Walk to the Marina Green, Palace of Fine Arts, and Crissy Field waterfront. Surrounded by boutique shopping and dining on Chestnut and Union Streets. Near the 30 and 28 Muni bus lines.
            """.Trim(),
            "Near Marina Green, Updated Interiors, Walkable, Near Palace of Fine Arts, Quiet, Pet Friendly",
            0,
            KenmorePhotos),

        // CA-34: SF Hayes Valley
        new(
            "580-hayes-st-san-francisco-ca",
            "Hayes Valley Studios — Studio · 1 ba · Hayes Valley",
            "580 Hayes St",
            "San Francisco, CA",
            1925,
            0,
            1,
            500,
            """
            Hayes Valley Studios offers chic studio residences in one of San Francisco's trendiest neighborhoods. Modern finishes with open layouts, full kitchens, and stylish bathroom fixtures throughout.

            Steps from Patricia's Green park, Blue Bottle Coffee, and Hayes Street boutiques. Near Civic Center BART and the Van Ness Muni Metro. Bike storage and secured entry for residents.
            """.Trim(),
            "Trendy Location, Near BART, Bike Storage, Secured Entry, Modern Finishes, Near Parks",
            0,
            AbbeyPhotos),

        // CA-35: SF Nob Hill
        new(
            "1099-sutter-st-san-francisco-ca",
            "Sutter Place — Studio · 1 ba · Nob Hill",
            "1099 Sutter St",
            "San Francisco, CA",
            1820,
            0,
            1,
            450,
            """
            Sutter Place is a well-located building on Sutter Street near the top of Nob Hill. Studio apartments with efficient layouts, updated kitchens, and city views from upper floors.

            Walk to Union Square shopping, the cable car lines, and countless dining options. Near the California Street cable car and multiple Muni lines. Controlled access and on-site laundry.
            """.Trim(),
            "City Views, Near Cable Car, Walk to Union Square, Controlled Access, Laundry, Near Transit",
            0,
            KenmorePhotos),

        // CA-36: More Sacramento - Midtown
        new(
            "1801-l-st-sacramento-ca",
            "Capitol Towers — 1 bd · 1 ba · Midtown Sacramento",
            "1801 L St",
            "Sacramento, CA",
            1365,
            1,
            1,
            680,
            """
            Capitol Towers is a mid-rise in Midtown Sacramento offering one-bedroom residences with upscale finishes. Modern kitchens with quartz counters, stainless appliances, and designer cabinetry throughout.

            Walk to Sacramento's best restaurants, bars, and the State Capitol building. Near Golden 1 Center and the Sacramento River waterfront. Rooftop pool, fitness center, and co-working space.
            """.Trim(),
            "Rooftop Pool, Co-Working, Fitness Center, Walk Score 92, Near Capitol, Quartz Counters",
            0,
            SacramentoPhotos),

        // CA-37: Sacramento East
        new(
            "3640-folsom-blvd-sacramento-ca",
            "Folsom Terrace — 1 bd · 1 ba · East Sacramento",
            "3640 Folsom Blvd",
            "Sacramento, CA",
            1190,
            1,
            1,
            680,
            """
            Folsom Terrace is a tree-lined community in East Sacramento offering one-bedroom apartments with a neighborhood feel. Quiet units with updated kitchens, ceiling fans, and private balconies.

            Near Sacramento State campus, the University/65th Street light rail station, and East Sacramento shops. Easy access to Highway 50. Pool, courtyard, and responsive on-site maintenance.
            """.Trim(),
            "Near Light Rail, Pool, Private Balconies, Quiet Community, Near Sac State, Ceiling Fans",
            0,
            SacramentoPhotos),

        // CA-38: Sacramento Midtown Studio
        new(
            "2100-j-st-sacramento-ca",
            "Midtown Lofts — Studio · 1 ba · Midtown Sacramento",
            "2100 J St",
            "Sacramento, CA",
            1120,
            0,
            1,
            520,
            """
            Midtown Lofts provides efficient studio living in the heart of Sacramento's Midtown grid. Open layouts with high ceilings, modern kitchens, and large windows bringing in abundant natural light.

            Walk to Handle District restaurants, Sacramento Natural Foods Co-op, and Fremont Park. Near multiple Sacramento RT bus routes. On-site laundry, bike storage, and secured entry.
            """.Trim(),
            "High Ceilings, Walkable Midtown, Bike Storage, Secured Entry, On-Site Laundry, Near Parks",
            0,
            SacramentoPhotos),

        // CA-39: More SD - Hillcrest
        new(
            "3860-normal-st-san-diego-ca",
            "Park Terrace — 1 bd · 1 ba · Hillcrest",
            "3860 Normal St",
            "San Diego, CA",
            1435,
            1,
            1,
            670,
            """
            Park Terrace is a well-maintained community in the heart of Hillcrest, San Diego's walkable urban village. One-bedroom apartments with updated kitchens, good natural light, and generous closet space.

            Walk to restaurants, bars, and shops along University Avenue. Near Balboa Park hiking trails and the San Diego Zoo. Assigned parking, on-site laundry, and responsive management.
            """.Trim(),
            "Near Balboa Park, Walkable, Assigned Parking, On-Site Laundry, Updated Kitchen, Pet Friendly",
            0,
            SdNorthParkPhotos),

        // CA-40: More SD - Pacific Beach
        new(
            "1055-essex-st-san-diego-ca",
            "Essex Pacific Beach — 1 bd · 1 ba · Pacific Beach",
            "1055 Essex St",
            "San Diego, CA",
            1750,
            1,
            1,
            640,
            """
            Essex Pacific Beach puts you blocks from the ocean in San Diego's beloved PB neighborhood. Bright one-bedroom apartments with coastal vibes, updated finishes, and easy beach access year-round.

            Walk to the boardwalk, surf shops, and beachfront restaurants. Near Tourmaline Surf Park and Mission Bay. Pool, BBQ area, and bike storage. Perfect for the active coastal lifestyle.
            """.Trim(),
            "Near Beach, Pool, BBQ Area, Bike Storage, Coastal Vibes, Walk to Boardwalk",
            0,
            SdCoastalPhotos),

        // CA-41: More SD - Kearny Mesa
        new(
            "7870-convoy-ct-san-diego-ca",
            "Convoy Court — 2 bd · 2 ba · Kearny Mesa",
            "7870 Convoy Ct",
            "San Diego, CA",
            1540,
            2,
            2,
            950,
            """
            Convoy Court offers spacious two-bedroom apartments in Kearny Mesa's diverse Convoy District. Large layouts with separate dining areas, dual-sink bathrooms, and private balconies overlooking mature landscaping.

            Steps from San Diego's best Asian cuisine on Convoy Street. Central location with easy access to the 805, 163, and 52 freeways. Pool, fitness room, and covered parking.
            """.Trim(),
            "Spacious 2BD, Pool, Fitness Room, Covered Parking, Private Balconies, Central Location",
            0,
            SdMissionValleyPhotos),

        // CA-42: More LA - Leimert Park
        new(
            "4270-crenshaw-blvd-los-angeles-ca",
            "Crenshaw Manor — 2 bd · 1 ba · Leimert Park",
            "4270 Crenshaw Blvd",
            "Los Angeles, CA",
            1540,
            2,
            1,
            900,
            """
            Crenshaw Manor offers spacious two-bedroom apartments in the culturally rich Leimert Park neighborhood. Large layouts with separate dining areas, ample closets, and updated appliances throughout.

            Near the new Crenshaw/LAX Metro line, Baldwin Hills Scenic Overlook, and the vibrant local arts scene. Family-friendly community with on-site management, laundry, and secured parking.
            """.Trim(),
            "Spacious 2BD, Near New Metro, Secured Parking, Family Friendly, On-Site Management, Large Closets",
            0,
            AbbeyPhotos),

        // CA-43: More LA - Arts District
        new(
            "1850-industrial-st-los-angeles-ca",
            "Arts District Place — 1 bd · 1 ba · Arts District",
            "1850 Industrial St",
            "Los Angeles, CA",
            1890,
            1,
            1,
            780,
            """
            Arts District Place offers loft-style one-bedroom residences in LA's creative Arts District. Industrial-chic design with polished concrete floors, exposed ductwork, and oversized windows flooding units with light.

            Surrounded by galleries, breweries, and acclaimed restaurants like Bestia and Bavel. Walk to Little Tokyo and the LA River bike path. Courtyard, bike storage, and rooftop gathering space.
            """.Trim(),
            "Loft Style, Polished Concrete, Rooftop Space, Near Galleries, Bike Storage, Industrial Chic",
            0,
            KenmorePhotos),

        // CA-44: More LA - Hollywood
        new(
            "1800-grace-ave-los-angeles-ca",
            "Grace Avenue Apartments — 1 bd · 1 ba · Hollywood",
            "1800 Grace Ave",
            "Los Angeles, CA",
            1435,
            1,
            1,
            650,
            """
            Grace Avenue Apartments is a well-maintained community in a quiet Hollywood residential area. One-bedroom units with good layouts, updated flooring, and natural light from large windows.

            Near the Hollywood Farmers Market, Runyon Canyon hiking, and Franklin Village shops. Minutes from the 101 freeway and Hollywood/Western Metro station. On-site laundry and assigned parking.
            """.Trim(),
            "Near Runyon Canyon, Assigned Parking, On-Site Laundry, Quiet Street, Updated Flooring, Near Metro",
            0,
            AbbeyPhotos),

        // CA-45: More LA - West LA
        new(
            "10960-rochester-ave-los-angeles-ca",
            "Rochester West — 1 bd · 1 ba · West LA",
            "10960 Rochester Ave",
            "Los Angeles, CA",
            1820,
            1,
            1,
            750,
            """
            Rochester West offers premium one-bedroom living in West LA's Westwood-adjacent neighborhood. Bright units with open layouts, stainless steel appliances, and in-unit washer/dryer connections.

            Minutes from UCLA, the 405 freeway, and Century City. Walk to Westwood Village restaurants and shops. Community features include fitness area, controlled access, and underground parking.
            """.Trim(),
            "Near UCLA, Underground Parking, Fitness Area, W/D Connections, Controlled Access, Bright Units",
            0,
            KenmorePhotos),

        // CA-46: Sacramento - Carmichael
        new(
            "4800-madison-ave-sacramento-ca",
            "Madison Crossing — 1 bd · 1 ba · Carmichael",
            "4800 Madison Ave",
            "Sacramento, CA",
            1155,
            1,
            1,
            720,
            """
            Madison Crossing offers well-priced one-bedroom apartments in the Carmichael area of Sacramento. Updated units with new countertops, modern fixtures, and good storage space throughout.

            Near Manzanita Avenue shopping and the American River bike trail. Easy commute to downtown via Highway 50. Pool, laundry facilities, and covered parking for all residents.
            """.Trim(),
            "Pool, Covered Parking, Near Bike Trail, Updated Units, Laundry Facility, Near Highway 50",
            0,
            SacramentoPhotos),

        // CA-47: More LA - Koreatown 2BD
        new(
            "501-s-virgil-ave-los-angeles-ca",
            "Virgil Square — 2 bd · 1 ba · Koreatown",
            "501 S Virgil Ave",
            "Los Angeles, CA",
            1610,
            2,
            1,
            880,
            """
            Virgil Square provides spacious two-bedroom apartments at the border of Koreatown and Silver Lake. Updated units with new appliances, vinyl plank flooring, and modern bathroom fixtures throughout.

            Steps from Virgil Village cafes and boutiques, with Koreatown dining just blocks south. Near Vermont/Beverly Metro station for easy commutes. Gated community with on-site laundry and parking.
            """.Trim(),
            "Gated Community, New Appliances, Near Metro, On-Site Parking, Laundry, Spacious 2BD",
            0,
            AbbeyPhotos),

        // CA-48: More SD - Gaslamp adjacent
        new(
            "1150-j-st-san-diego-ca",
            "J Street Commons — Studio · 1 ba · East Village",
            "1150 J St",
            "San Diego, CA",
            1575,
            0,
            1,
            520,
            """
            J Street Commons offers modern studio residences in San Diego's East Village near the Gaslamp Quarter. Open-concept layouts with full kitchens, contemporary baths, and large windows with city light.

            Walk to Petco Park, Convention Center, and Gaslamp nightlife. On the trolley line for easy transit. Fitness center, rooftop terrace, and bike storage. Ideal for young professionals.
            """.Trim(),
            "Near Gaslamp, Rooftop Terrace, Fitness Center, Bike Storage, Near Trolley, Walk Score 95",
            0,
            SdLittleItalyPhotos),

        // CA-49: More LA - Culver City
        new(
            "3930-sepulveda-blvd-culver-city-ca",
            "Sepulveda Studios — 1 bd · 1 ba · Culver City",
            "3930 Sepulveda Blvd",
            "Culver City, CA",
            1645,
            1,
            1,
            690,
            """
            Sepulveda Studios provides modern one-bedroom apartments in the heart of Culver City's booming tech and entertainment hub. Contemporary finishes with quartz counters, stainless appliances, and in-unit laundry.

            Walk to Culver City Arts District, Platform shops, and the Expo Line for car-free commuting to DTLA and Santa Monica. Near Sony Studios, Amazon, and Apple TV+ offices.
            """.Trim(),
            "In-Unit Laundry, Near Expo Line, Quartz Counters, Near Studios, Walkable, Modern Design",
            0,
            KenmorePhotos),

        // CA-50: More Sacramento - Oak Park
        new(
            "3200-broadway-sacramento-ca",
            "Broadway Village — 1 bd · 1 ba · Oak Park",
            "3200 Broadway",
            "Sacramento, CA",
            1050,
            1,
            1,
            640,
            """
            Broadway Village offers affordable one-bedroom apartments in Sacramento's revitalizing Oak Park neighborhood. Clean units with updated kitchens, new flooring, and good natural light.

            Near UC Davis Medical Center, Sacramento City College, and Broadway's growing restaurant scene. Easy access to Highway 99 and Business 80. On-site laundry, parking, and gated entry.
            """.Trim(),
            "Affordable, Gated Entry, On-Site Laundry, Near UC Davis Medical, Parking, Updated Kitchen",
            0,
            SacramentoPhotos),

        // ═══════════════════════════════════════════════════════════════
        // HOUSTON / AUSTIN AREA (50 properties)
        // ═══════════════════════════════════════════════════════════════

        // TX-1: Hanover Montrose
        new(
            "3400-montrose-blvd-houston-tx",
            "Hanover Montrose — 2 bd · 2 ba · Montrose",
            "3400 Montrose Blvd",
            "Houston, TX",
            1919,
            2,
            2,
            1200,
            """
            Hanover Montrose offers luxury high-rise living in the heart of Houston's vibrant Montrose neighborhood. Two-bedroom residences with wood-style flooring, designer kitchens, and open-air loggia views of the downtown skyline.

            Resort-style pool deck with cabanas, 9th-floor loggia with dining areas overlooking downtown, state-of-the-art fitness center, dog park, and easy access to museums, restaurants, and nightlife.
            """.Trim(),
            "Resort Pool, Skyline Loggia, Fitness Center, Dog Park, Controlled Access, Concierge",
            0,
            HanoverPhotos),

        // TX-2: Aspire Post Oak
        new(
            "1616-post-oak-blvd-houston-tx",
            "Aspire Post Oak — 2 bd · 2 ba · Uptown Galleria",
            "1616 Post Oak Blvd",
            "Houston, TX",
            1890,
            2,
            2,
            1135,
            """
            High-rise luxury residences at the corner of Post Oak Blvd and San Felipe in Houston's iconic Uptown District. Aspire Post Oak delivers panoramic city views and world-class amenities in a premier setting.

            Floor-to-ceiling windows, chef-inspired kitchens, and spa-like bathrooms. Infinity-edge pool, rooftop sky lounge, private dining room, 24-hour concierge, and direct access to the Galleria.
            """.Trim(),
            "Infinity Pool, Sky Lounge, 24h Concierge, Private Dining, Fitness Center, Valet Parking",
            0,
            AspirePhotos),

        // TX-3: The Met Austin
        new(
            "10101-metropolitan-dr-austin-tx",
            "The Met — 2 bd · 2 ba · North Austin",
            "10101 Metropolitan Dr",
            "Austin, TX",
            1685,
            2,
            2,
            1020,
            """
            The Met is a contemporary apartment community in North Austin near The Domain. Modern interiors in two-bedroom floorplans with designer finishes, smart technology, and unparalleled views of the Austin skyline.

            Community amenities include coworking spaces, rooftop lounge, resort-style pool, dog park, fitness center, and controlled-access entry. Built in 2023 with 297 units. Pet-friendly with on-site management.
            """.Trim(),
            "Coworking, Rooftop Lounge, Resort Pool, Dog Park, Fitness Center, Smart Home Tech",
            0,
            MetAustinPhotos),

        // TX-4: Montrose at Buffalo Bayou
        new(
            "1320-montrose-blvd-houston-tx",
            "Montrose at Buffalo Bayou — Studio · 1 ba · Montrose",
            "1320 Montrose Blvd",
            "Houston, TX",
            1189,
            0,
            1,
            588,
            """
            Montrose at Buffalo Bayou is a premium community overlooking Houston's beloved Buffalo Bayou Park. Studio residences with modern finishes, full kitchens, and efficient open-concept layouts.

            Direct trail access for running and biking along Buffalo Bayou, minutes from downtown Houston. Pool, fitness center, and controlled-access parking. Walk to Montrose restaurants and shops.
            """.Trim(),
            "Park Views, Trail Access, Pool, Fitness Center, Controlled Access, Near Downtown",
            0,
            MontroseBayouPhotos),

        // TX-5: Midtown on the Rail
        new(
            "2310-main-st-houston-tx",
            "Midtown on the Rail — 1 bd · 1 ba · Midtown",
            "2310 Main St",
            "Houston, TX",
            1026,
            1,
            1,
            650,
            """
            Midtown on the Rail is a transit-oriented community steps from the METRORail in Houston's energetic Midtown district. One-bedroom apartments with modern finishes, full-size washer/dryer, and open layouts.

            Walk to Midtown bars, restaurants, and downtown Houston. Direct rail access to the Medical Center, Museum District, and NRG Stadium. Pool, fitness center, and rooftop lounge.
            """.Trim(),
            "Near METRORail, In-Unit W/D, Pool, Rooftop Lounge, Fitness Center, Walk to Downtown",
            0,
            MidtownRailPhotos),

        // TX-6: City Place Montrose
        new(
            "306-mcgowen-st-houston-tx",
            "City Place Montrose — 1 bd · 1 ba · Montrose",
            "306 McGowen St",
            "Houston, TX",
            1190,
            1,
            1,
            700,
            """
            City Place Montrose offers modern one-bedroom apartments at the border of Montrose and Midtown. Clean contemporary finishes with stainless appliances, wood-style flooring, and generous closets.

            Walk to the Menil Collection, Montrose restaurants, and Midtown nightlife. Near METRORail for easy downtown and Medical Center access. Pool, fitness center, and pet-friendly policies.
            """.Trim(),
            "Pool, Fitness Center, Pet Friendly, Near Menil, Near METRORail, Wood Floors",
            0,
            MontroseBayouPhotos),

        // TX-7: Lumen
        new(
            "3333-allen-pkwy-houston-tx",
            "Lumen — 1 bd · 1 ba · Montrose/Allen Parkway",
            "3333 Allen Pkwy",
            "Houston, TX",
            1260,
            1,
            1,
            720,
            """
            Lumen is a contemporary community on Allen Parkway with views of Buffalo Bayou Park and the downtown skyline. One-bedroom residences with floor-to-ceiling windows, modern kitchens, and open layouts.

            Adjacent to Buffalo Bayou running trails and the new Levy Park. Minutes from downtown, the Galleria, and River Oaks. Resort pool, sky lounge, fitness center, and controlled access.
            """.Trim(),
            "Skyline Views, Resort Pool, Sky Lounge, Fitness Center, Near Trails, Controlled Access",
            0,
            HoustonMidtownPhotos),

        // TX-8: Midtown Terrace Suites
        new(
            "3000-smith-st-houston-tx",
            "Midtown Terrace Suites — 1 bd · 1 ba · Midtown",
            "3000 Smith St",
            "Houston, TX",
            1120,
            1,
            1,
            650,
            """
            Midtown Terrace Suites offers well-priced one-bedroom apartments on Smith Street in Midtown Houston. Renovated interiors with updated kitchens, new flooring, and modern bathroom fixtures.

            On the METRORail line for car-free commuting to downtown and the Medical Center. Near Midtown Park, the Ensemble Theatre, and dozens of restaurants. Covered parking and on-site laundry.
            """.Trim(),
            "On METRORail, Renovated, Covered Parking, On-Site Laundry, Near Midtown Park, Updated Kitchen",
            0,
            HoustonMidtownPhotos),

        // TX-9: UNITI Montrose
        new(
            "1717-bissonnet-st-houston-tx",
            "UNITI Montrose — 1 bd · 1 ba · Montrose",
            "1717 Bissonnet St",
            "Houston, TX",
            1330,
            1,
            1,
            750,
            """
            UNITI Montrose is a contemporary community delivering modern one-bedroom residences in Houston's cultural core. Open floor plans with quartz countertops, soft-close cabinetry, and oversized windows.

            Walk to the Museum of Fine Arts, the Rothko Chapel, and Montrose's eclectic dining scene. Pool, fitness center, coworking lounge, and bike storage. Pet friendly with dog wash station.
            """.Trim(),
            "Quartz Counters, Pool, Coworking Lounge, Dog Wash, Fitness Center, Near Museums",
            0,
            HoustonMidtownPhotos),

        // TX-10: Montrose - Westheimer
        new(
            "1919-westheimer-rd-houston-tx",
            "Westheimer Flats — 1 bd · 1 ba · Montrose",
            "1919 Westheimer Rd",
            "Houston, TX",
            1470,
            1,
            1,
            720,
            """
            Westheimer Flats is a modern community on Houston's iconic Westheimer Road in Montrose. One-bedroom apartments with clean contemporary design, stainless appliances, and wood-style flooring.

            Walk to Montrose bars, restaurants, vintage shops, and the Menil Collection. Near the Museum District and Hermann Park. Pool, fitness center, and controlled-access parking for residents.
            """.Trim(),
            "Pool, Fitness Center, Controlled Access, Near Menil Collection, Walkable, Wood Floors",
            0,
            HanoverPhotos),

        // TX-11: Montrose - Richmond
        new(
            "1400-richmond-ave-houston-tx",
            "Richmond at Montrose — 1 bd · 1 ba · Montrose",
            "1400 Richmond Ave",
            "Houston, TX",
            1365,
            1,
            1,
            690,
            """
            Richmond at Montrose provides well-appointed one-bedroom apartments in the Montrose/River Oaks area. Updated interiors with granite counters, modern cabinetry, and crown molding details.

            Near River Oaks Shopping Center, the Menil Collection, and Buffalo Bayou trails. Easy access to US-59 for quick commutes. Pool, covered parking, and on-site laundry facilities.
            """.Trim(),
            "Granite Counters, Pool, Covered Parking, Near River Oaks, On-Site Laundry, Crown Molding",
            0,
            MontroseBayouPhotos),

        // TX-12: Montrose - Norfolk
        new(
            "2015-norfolk-st-houston-tx",
            "Norfolk Terrace — 1 bd · 1 ba · Montrose",
            "2015 Norfolk St",
            "Houston, TX",
            1260,
            1,
            1,
            660,
            """
            Norfolk Terrace is a boutique apartment community on a tree-lined Montrose street. Cozy one-bedroom units with updated kitchens, tile flooring, and private enclosed patios for outdoor living.

            Walk to Uchi Houston, Hugo's, and the best of Montrose dining. Near Montrose HEB and Buffalo Bayou Park. Quiet residential setting with gated entry and assigned parking.
            """.Trim(),
            "Private Patios, Gated Entry, Tree-Lined Street, Near Restaurants, Assigned Parking, Quiet",
            0,
            MontroseBayouPhotos),

        // TX-13: Montrose - Fairview
        new(
            "2311-fairview-st-houston-tx",
            "Fairview Montrose — 1 bd · 1 ba · Montrose",
            "2311 Fairview St",
            "Houston, TX",
            1295,
            1,
            1,
            680,
            """
            Fairview Montrose provides comfortable one-bedroom living in the eclectic Fairview corridor. Updated units with modern flooring, ample natural light, and good closet space throughout.

            Steps from Fairview Street bars and restaurants, near the Montrose HEB, and Buffalo Bayou trails. Gated parking, on-site laundry, and pet-friendly policies. Great value for inner-loop living.
            """.Trim(),
            "Gated Parking, Pet Friendly, On-Site Laundry, Near Buffalo Bayou, Updated Units, Inner Loop",
            0,
            HanoverPhotos),

        // TX-14: Montrose - Graustark
        new(
            "3700-graustark-st-houston-tx",
            "Graustark Villas — 2 bd · 2 ba · Montrose",
            "3700 Graustark St",
            "Houston, TX",
            1680,
            2,
            2,
            1050,
            """
            Graustark Villas offers spacious two-bedroom townhome-style residences in upper Montrose. Two-story layouts with private entries, attached garages, and fenced yards on select units.

            Near Montrose HEB, West Alabama Ice House, and the vibrant dining scene along Westheimer. Easy access to US-59, the Galleria, and downtown. Washer/dryer connections in every unit.
            """.Trim(),
            "Townhome Style, Attached Garages, Private Yards, W/D Connections, Near HEB, Two Stories",
            0,
            MontroseBayouPhotos),

        // TX-15: Montrose - Alabama
        new(
            "1225-w-alabama-st-houston-tx",
            "Alabama Court — Studio · 1 ba · Montrose",
            "1225 W Alabama St",
            "Houston, TX",
            1085,
            0,
            1,
            520,
            """
            Alabama Court offers affordable studio living in the heart of Montrose. Efficient layouts with full kitchens, updated bathrooms, and good closet space in a walkable location near everything.

            Steps from Montrose restaurants, coffee shops, and the Alabama Theatre. Near the METRO bus line for easy downtown commute. On-site laundry, parking included, and cat-friendly policies.
            """.Trim(),
            "Walkable Montrose, Parking Included, On-Site Laundry, Cat Friendly, Near METRO, Full Kitchen",
            0,
            HanoverPhotos),

        // TX-16: Heights - Yale
        new(
            "1100-yale-st-houston-tx",
            "Yale Street Flats — 1 bd · 1 ba · The Heights",
            "1100 Yale St",
            "Houston, TX",
            1505,
            1,
            1,
            740,
            """
            Yale Street Flats is a modern community in Houston's beloved Heights neighborhood. One-bedroom apartments with thoughtful design, premium finishes, and private balconies overlooking tree-lined streets.

            Walk to Heights Bike Trail, White Oak Music Hall, and the best brunch spots in Houston. Near I-10 and I-45 for easy commuting. Pool, fitness center, and dog-friendly community.
            """.Trim(),
            "Near Bike Trail, Pool, Fitness Center, Dog Friendly, Private Balconies, Tree-Lined Streets",
            0,
            AspirePhotos),

        // TX-17: Heights - 19th Street
        new(
            "325-w-19th-st-houston-tx",
            "19th Street Lofts — 1 bd · 1 ba · The Heights",
            "325 W 19th St",
            "Houston, TX",
            1610,
            1,
            1,
            770,
            """
            19th Street Lofts is a boutique community on the iconic 19th Street shopping corridor in the Heights. Loft-inspired one-bedroom residences with high ceilings, exposed beams, and industrial accents.

            Steps from antique shops, cafes, and craft cocktail bars along 19th Street. Near Heights Bike Trail and Donovan Park. Secured entry, on-site parking, and pet-friendly policies.
            """.Trim(),
            "High Ceilings, Exposed Beams, Near 19th Street Shops, Secured Entry, Pet Friendly, Boutique",
            0,
            AspirePhotos),

        // TX-18: Heights - Heights Blvd
        new(
            "910-heights-blvd-houston-tx",
            "Heights Boulevard Apartments — 1 bd · 1 ba · The Heights",
            "910 Heights Blvd",
            "Houston, TX",
            1365,
            1,
            1,
            700,
            """
            Heights Boulevard Apartments sits on Houston's scenic Heights Boulevard with its oak-lined esplanade. One-bedroom units with classic charm, updated kitchens, and ceiling fans throughout.

            Walk to Heights restaurants, Onion Creek Coffee, and the Heights Hike & Bike Trail. Near Donovan Park playground and community gardens. On-site laundry, parking, and courtyard.
            """.Trim(),
            "On Heights Blvd, Near Bike Trail, Courtyard, On-Site Laundry, Parking, Updated Kitchen",
            0,
            MidtownRailPhotos),

        // TX-19: Heights - Shepherd
        new(
            "1601-n-shepherd-dr-houston-tx",
            "Shepherd Park — 1 bd · 1 ba · The Heights",
            "1601 N Shepherd Dr",
            "Houston, TX",
            1260,
            1,
            1,
            670,
            """
            Shepherd Park provides affordable one-bedroom living on North Shepherd in the Heights area. Renovated units with new countertops, updated fixtures, and improved flooring throughout the apartment.

            Near Shepherd Park Plaza shopping, Heights restaurants, and I-10 for easy downtown commuting. Community pool, assigned parking, and on-site management. Friendly, pet-welcome environment.
            """.Trim(),
            "Renovated, Pool, Assigned Parking, Pet Welcome, On-Site Management, Near I-10",
            0,
            MidtownRailPhotos),

        // TX-20: Heights - Studemont
        new(
            "1450-studemont-st-houston-tx",
            "Studemont Place — 1 bd · 1 ba · The Heights",
            "1450 Studemont St",
            "Houston, TX",
            1470,
            1,
            1,
            730,
            """
            Studemont Place is a modern community on Studemont near the popular restaurant corridor. One-bedroom residences with sleek design, quartz counters, and stainless steel appliances.

            Walk to Coltivare, Eight Row Flint, and other Heights dining favorites. Near the I-10 feeder for quick downtown access. Pool, rooftop terrace, and pet-friendly policies with dog wash.
            """.Trim(),
            "Rooftop Terrace, Pool, Dog Wash, Quartz Counters, Near Restaurants, Near I-10",
            0,
            AspirePhotos),

        // TX-21: Heights - 11th Street
        new(
            "715-e-11th-st-houston-tx",
            "11th Street Station — 1 bd · 1 ba · The Heights",
            "715 E 11th St",
            "Houston, TX",
            1435,
            1,
            1,
            720,
            """
            11th Street Station is a sleek community in the eastern Heights with quick downtown access. One-bedroom apartments with modern kitchens, in-unit washer/dryer connections, and private patios available.

            Near Houston Farmers Market, White Oak Bayou trail, and Heights nightlife. Minutes from downtown via I-45 or I-10. Pool, fitness center, and controlled-access gated parking.
            """.Trim(),
            "W/D Connections, Pool, Fitness Center, Near Farmers Market, Gated Parking, Private Patios",
            0,
            HanoverPhotos),

        // TX-22: Heights - Ashland
        new(
            "2120-ashland-st-houston-tx",
            "Ashland Heights — 1 bd · 1 ba · The Heights",
            "2120 Ashland St",
            "Houston, TX",
            1330,
            1,
            1,
            690,
            """
            Ashland Heights is a quiet residential community in the heart of the Heights. One-bedroom apartments surrounded by mature trees with updated interiors, tile flooring, and good natural light.

            Near Heights Mercantile shops, local parks, and the Heights Hike & Bike Trail. Walk to Studewood restaurants and cafes. Gated community with on-site parking and laundry facilities.
            """.Trim(),
            "Gated Community, Mature Trees, Near Bike Trail, On-Site Parking, Laundry, Quiet Area",
            0,
            MidtownRailPhotos),

        // TX-23: Heights - TC Jester
        new(
            "1835-tc-jester-blvd-houston-tx",
            "Jester Park Flats — 2 bd · 2 ba · The Heights",
            "1835 TC Jester Blvd",
            "Houston, TX",
            1610,
            2,
            2,
            1020,
            """
            Jester Park Flats delivers spacious two-bedroom living near TC Jester Park in the Heights. Open layouts with island kitchens, dual-sink bathrooms, and generous walk-in closets.

            Adjacent to TC Jester Park jogging trails and near the Heights Bike Trail. Walk to Heights House Hotel restaurants and bars. Pool, grilling stations, fitness center, and dog park.
            """.Trim(),
            "Near Jogging Trails, Dog Park, Pool, Grilling Stations, Island Kitchen, Walk-In Closets",
            0,
            AspirePhotos),

        // TX-24: Heights - Center
        new(
            "4502-center-st-houston-tx",
            "Center Park Heights — 1 bd · 1 ba · The Heights",
            "4502 Center St",
            "Houston, TX",
            1190,
            1,
            1,
            650,
            """
            Center Park Heights offers value-priced one-bedroom apartments in the northern Heights area. Clean, functional units with updated kitchens and new flooring. Quiet, family-oriented neighborhood.

            Near Stude Park, White Oak Bayou Greenway, and Heights dining on North Main. Easy I-45 access for commuting. Pool, on-site laundry, and assigned parking. Cats and small dogs welcome.
            """.Trim(),
            "Value Priced, Pool, Near Greenway, Assigned Parking, On-Site Laundry, Pet Welcome",
            0,
            HanoverPhotos),

        // TX-25: Heights - Main
        new(
            "3402-n-main-st-houston-tx",
            "Main Street Heights — 2 bd · 1 ba · The Heights",
            "3402 N Main St",
            "Houston, TX",
            1540,
            2,
            1,
            950,
            """
            Main Street Heights offers spacious two-bedroom apartments near the Nicholson Street rail station in the Heights. Generous floor plans with separate living and dining, full-size kitchen, and ample storage.

            Walk to Heights restaurants, brewery scene, and METRORail. Near I-45 and I-10 interchange. Pool, on-site laundry, and covered parking. Family-friendly with nearby parks and playgrounds.
            """.Trim(),
            "Spacious 2BD, Near METRORail, Pool, Covered Parking, Family Friendly, Near Breweries",
            0,
            MidtownRailPhotos),

        // TX-26: Medical Center - Main St
        new(
            "6750-main-st-houston-tx",
            "Museum Park Residences — 1 bd · 1 ba · Museum District",
            "6750 Main St",
            "Houston, TX",
            1575,
            1,
            1,
            730,
            """
            Museum Park Residences offers upscale one-bedroom living in Houston's Museum District. Modern interiors with floor-to-ceiling windows, chef-inspired kitchens, and spa-like bathrooms.

            Walk to the Museum of Fine Arts, Hermann Park, and the Houston Zoo. On the METRORail line for direct Medical Center and downtown access. Pool, fitness center, and resident lounge.
            """.Trim(),
            "Near Museums, On METRORail, Pool, Fitness Center, Resident Lounge, Floor-to-Ceiling Windows",
            0,
            AspirePhotos),

        // TX-27: Medical Center - Holcombe
        new(
            "1900-holcombe-blvd-houston-tx",
            "Holcombe Medical Living — 1 bd · 1 ba · Medical Center",
            "1900 Holcombe Blvd",
            "Houston, TX",
            1400,
            1,
            1,
            700,
            """
            Holcombe Medical Living caters to Medical Center professionals with well-appointed one-bedroom apartments near TMC. Clean modern design with premium appliances and efficient layouts for busy schedules.

            Walk or bike to Texas Medical Center hospitals, MD Anderson, and Baylor. Near METRORail TMC station and Hermann Park. Pool, 24-hour fitness center, and controlled-access entry.
            """.Trim(),
            "Near TMC, 24hr Fitness, Pool, Controlled Access, Near METRORail, Bike Friendly",
            0,
            HoustonMidtownPhotos),

        // TX-28: Medical Center - Greenbriar
        new(
            "4100-greenbriar-dr-houston-tx",
            "Greenbriar Place — 1 bd · 1 ba · Museum District",
            "4100 Greenbriar Dr",
            "Houston, TX",
            1330,
            1,
            1,
            680,
            """
            Greenbriar Place is a well-maintained community near Rice University and the Museum District. One-bedroom apartments with updated kitchens, good layouts, and tree-shaded grounds providing a peaceful retreat.

            Walk to Rice Village shops and restaurants. Near Hermann Park, Miller Outdoor Theatre, and METRORail. On-site laundry, pool, and assigned parking. Quiet, scholarly neighborhood.
            """.Trim(),
            "Near Rice University, Pool, Assigned Parking, Tree-Shaded, On-Site Laundry, Near METRORail",
            0,
            MidtownRailPhotos),

        // TX-29: Medical Center - OST
        new(
            "2300-old-spanish-trail-houston-tx",
            "OST Medical Flats — 1 bd · 1 ba · Medical Center",
            "2300 Old Spanish Trail",
            "Houston, TX",
            1190,
            1,
            1,
            650,
            """
            OST Medical Flats provides affordable one-bedroom living near the Texas Medical Center and NRG Park. Practical layouts with full kitchens, updated flooring, and good storage for busy professionals.

            Near METRORail Stadium Park station and NRG Stadium. Easy access to Loop 610 and US-288. On-site laundry, gated parking, and responsive maintenance. Popular with TMC staff and students.
            """.Trim(),
            "Near TMC, Gated Parking, Near METRORail, On-Site Laundry, Affordable, Near NRG Stadium",
            0,
            HoustonMidtownPhotos),

        // TX-30: Medical Center - Almeda
        new(
            "5222-almeda-rd-houston-tx",
            "Almeda Museum Place — 1 bd · 1 ba · Museum District",
            "5222 Almeda Rd",
            "Houston, TX",
            1365,
            1,
            1,
            710,
            """
            Almeda Museum Place sits in the Museum District with easy access to Hermann Park and the Houston Zoo. One-bedroom apartments with contemporary finishes, stainless appliances, and private balconies.

            Near Brays Bayou trail for jogging and biking. Walk to museums and METRORail. Pool, fitness center, and gated entry. Pet-friendly community with nearby green space.
            """.Trim(),
            "Near Hermann Park, Pool, Fitness Center, Gated Entry, Pet Friendly, Near Trails",
            0,
            MontroseBayouPhotos),

        // TX-31: Medical Center - Bertner
        new(
            "7200-bertner-ave-houston-tx",
            "Bertner Medical Apartments — Studio · 1 ba · Medical Center",
            "7200 Bertner Ave",
            "Houston, TX",
            1085,
            0,
            1,
            500,
            """
            Bertner Medical Apartments offers compact studio living within walking distance of Texas Medical Center hospitals. Efficient layouts designed for medical professionals with 24-hour schedules.

            Steps from TMC shuttle routes, METRORail, and Medical Center dining options. Controlled access, on-site laundry, and covered parking. Quiet community focused on rest and convenience.
            """.Trim(),
            "Walk to TMC, Controlled Access, Covered Parking, On-Site Laundry, Quiet, 24hr Access",
            0,
            HoustonMidtownPhotos),

        // TX-32: Medical Center - Hermann
        new(
            "6100-hermann-dr-houston-tx",
            "Hermann Park View — 1 bd · 1 ba · Museum District",
            "6100 Hermann Dr",
            "Houston, TX",
            1680,
            1,
            1,
            780,
            """
            Hermann Park View delivers premium one-bedroom residences overlooking Houston's beloved Hermann Park. Upscale finishes with hardwood floors, granite counters, and park and city views from private balconies.

            Walk to the Houston Zoo, Japanese Garden, and Museum of Natural Science. Near METRORail Hermann Park station. Concierge, fitness center, pool, and 24-hour controlled access.
            """.Trim(),
            "Park Views, Concierge, Pool, Fitness Center, Hardwood Floors, Near Zoo, 24hr Access",
            0,
            AspirePhotos),

        // TX-33: Medical Center - Southmore
        new(
            "2425-southmore-blvd-houston-tx",
            "Southmore Commons — 2 bd · 1 ba · Third Ward",
            "2425 Southmore Blvd",
            "Houston, TX",
            1505,
            2,
            1,
            920,
            """
            Southmore Commons provides spacious two-bedroom apartments in the Third Ward adjacent to the Museum District. Generous layouts with separate dining, full kitchens, and ceiling fans throughout.

            Walk to the Ensemble Theatre, Project Row Houses, and Emancipation Park. Near the METRORail Wheeler station for easy commuting. Pool, on-site laundry, and assigned parking.
            """.Trim(),
            "Spacious 2BD, Near METRORail, Pool, Assigned Parking, Family Friendly, Near Arts District",
            0,
            MontroseBayouPhotos),

        // TX-34: Medical Center - Binz
        new(
            "1850-binz-st-houston-tx",
            "Binz at Museum Park — 1 bd · 1 ba · Museum District",
            "1850 Binz St",
            "Houston, TX",
            1435,
            1,
            1,
            720,
            """
            Binz at Museum Park offers modern one-bedroom living between the Museum District and Midtown. Contemporary finishes with quartz counters, wood-style flooring, and smart home features.

            Near the Children's Museum, Caroline Collective, and Hermann Park trails. On the METRORail line. Pool with sundeck, fitness center, bike storage, and package lockers for residents.
            """.Trim(),
            "Smart Home, Pool, Bike Storage, Package Lockers, Near METRORail, Quartz Counters",
            0,
            HoustonMidtownPhotos),

        // TX-35: Memorial - Memorial Dr
        new(
            "9400-memorial-dr-houston-tx",
            "Memorial Trails — 1 bd · 1 ba · Memorial",
            "9400 Memorial Dr",
            "Houston, TX",
            1470,
            1,
            1,
            750,
            """
            Memorial Trails is a serene community nestled along Memorial Drive near Memorial Park. One-bedroom apartments with updated interiors, private patios, and views of mature pine trees.

            Adjacent to Memorial Park's running trails, bike paths, and golf course. Minutes from the Energy Corridor and I-10. Resort pool, fitness center, and access to Buffalo Bayou trails.
            """.Trim(),
            "Near Memorial Park, Resort Pool, Fitness Center, Private Patios, Wooded Setting, Near Trails",
            0,
            HanoverPhotos),

        // TX-36: Memorial - West
        new(
            "12500-memorial-dr-houston-tx",
            "Memorial West Apartments — 2 bd · 2 ba · Memorial",
            "12500 Memorial Dr",
            "Houston, TX",
            1610,
            2,
            2,
            1100,
            """
            Memorial West Apartments offers spacious two-bedroom residences in a park-like setting along Memorial Drive. Generous layouts with split bedrooms, large closets, and full-size washer/dryer connections.

            Near Terry Hershey Park trails, Memorial City Mall, and top-rated Memorial schools. Easy I-10 and Beltway 8 access. Two pools, tennis court, fitness center, and playground.
            """.Trim(),
            "Two Pools, Tennis Court, Near Terry Hershey, W/D Connections, Playground, Split Bedrooms",
            0,
            AspirePhotos),

        // TX-37: Memorial - Dairy Ashford
        new(
            "1000-n-dairy-ashford-rd-houston-tx",
            "Dairy Ashford Gardens — 1 bd · 1 ba · Energy Corridor",
            "1000 N Dairy Ashford Rd",
            "Houston, TX",
            1190,
            1,
            1,
            720,
            """
            Dairy Ashford Gardens provides comfortable one-bedroom living in Houston's Energy Corridor. Updated units with new appliances, vinyl plank flooring, and good storage space for professionals.

            Near major energy company offices, Memorial City Mall, and George Bush Park. Easy I-10 and Beltway 8 access. Pool, fitness center, on-site laundry, and covered parking.
            """.Trim(),
            "Near Energy Corridor, Pool, Fitness Center, Covered Parking, Updated Units, Near I-10",
            0,
            HanoverPhotos),

        // TX-38: Memorial - Briar Forest
        new(
            "800-briar-forest-dr-houston-tx",
            "Briar Forest Pines — 1 bd · 1 ba · West Houston",
            "800 Briar Forest Dr",
            "Houston, TX",
            1120,
            1,
            1,
            680,
            """
            Briar Forest Pines is a well-maintained community in West Houston surrounded by tall pines and quiet residential streets. One-bedroom apartments with functional layouts and updated kitchens.

            Near Briar Forest shopping, international restaurants, and George Bush Park. Quick Beltway 8 access to the Galleria and Energy Corridor. Pool, laundry facility, and assigned parking.
            """.Trim(),
            "Pine Trees, Pool, Assigned Parking, Laundry Facility, Near Beltway 8, Quiet Streets",
            0,
            MidtownRailPhotos),

        // TX-39: Memorial - CityWest
        new(
            "2600-citywest-blvd-houston-tx",
            "CityWest Apartments — 1 bd · 1 ba · Westchase",
            "2600 CityWest Blvd",
            "Houston, TX",
            1225,
            1,
            1,
            710,
            """
            CityWest Apartments offers modern one-bedroom residences in the Westchase District near major employers. Clean layouts with stainless appliances, wood-style flooring, and ample counter space.

            Near the Westchase business district, shopping centers, and diverse international dining. Easy access to Beltway 8 and Westpark Tollway. Pool, fitness center, and business center.
            """.Trim(),
            "Near Business District, Pool, Fitness Center, Business Center, W/D Connections, Near Beltway",
            0,
            AspirePhotos),

        // TX-40: Memorial - Eldridge
        new(
            "7600-eldridge-pkwy-houston-tx",
            "Eldridge Crossing — 1 bd · 1 ba · West Houston",
            "7600 Eldridge Pkwy",
            "Houston, TX",
            1295,
            1,
            1,
            730,
            """
            Eldridge Crossing provides quality one-bedroom living near the intersection of Eldridge and Briar Forest in West Houston. Well-designed units with modern finishes, covered patios, and washer/dryer connections.

            Near West Houston shopping, restaurants, and major employers. Quick Beltway 8 and Westpark Tollway access. Pool, dog park, fitness center, and controlled-access gates.
            """.Trim(),
            "Dog Park, Pool, Fitness Center, W/D Connections, Covered Patios, Controlled Access",
            0,
            HanoverPhotos),

        // TX-41: Memorial - Town & Country
        new(
            "10700-town-and-country-way-houston-tx",
            "Town and Country Village — 1 bd · 1 ba · Memorial",
            "10700 Town and Country Way",
            "Houston, TX",
            1540,
            1,
            1,
            760,
            """
            Town and Country Village offers one-bedroom apartments in the upscale Town & Country area of west Memorial. Modern interiors with granite counters, stainless appliances, and wood-style flooring.

            Walk to Town & Country Village shops and restaurants. Near Memorial City Mall, CityCentre, and Memorial Park. Easy I-10 access to downtown and the Energy Corridor. Pool and fitness center.
            """.Trim(),
            "Near CityCentre, Pool, Fitness Center, Clubhouse, Granite Counters, Near I-10",
            0,
            AspirePhotos),

        // TX-42: Memorial - Pines Retreat
        new(
            "14520-memorial-dr-houston-tx",
            "Memorial Pines Retreat — 2 bd · 2 ba · Memorial",
            "14520 Memorial Dr",
            "Houston, TX",
            1750,
            2,
            2,
            1150,
            """
            Memorial Pines Retreat is a premium community in far west Memorial offering spacious two-bedroom apartments in a serene wooded setting. Large layouts with island kitchens, garden tubs, and private garages.

            Near Cullen Park, Terry Hershey trails, and Memorial schools. Minutes from the Energy Corridor via I-10. Two pools, clubhouse, fitness center, tennis courts, and nature trails on-site.
            """.Trim(),
            "Private Garages, Two Pools, Tennis Courts, Nature Trails, Island Kitchen, Near Parks",
            0,
            HanoverPhotos),

        // TX-43: Downtown - Main
        new(
            "1111-main-st-houston-tx",
            "Main Street Tower — Studio · 1 ba · Downtown",
            "1111 Main St",
            "Houston, TX",
            1365,
            0,
            1,
            550,
            """
            Main Street Tower offers studio living in the heart of downtown Houston on historic Main Street. Modern finishes with full kitchens, floor-to-ceiling windows, and dramatic city views from upper floors.

            Walk to Theater District, Discovery Green, and GreenStreet shopping. On the METRORail line with direct access everywhere. Rooftop pool, fitness center, and 24-hour concierge.
            """.Trim(),
            "Downtown Views, Rooftop Pool, Concierge, On METRORail, Fitness Center, Near Theater District",
            0,
            MidtownRailPhotos),

        // TX-44: Downtown - Travis
        new(
            "800-travis-st-houston-tx",
            "Travis Tower — 1 bd · 1 ba · Downtown",
            "800 Travis St",
            "Houston, TX",
            1575,
            1,
            1,
            740,
            """
            Travis Tower is a modern high-rise offering one-bedroom residences in downtown Houston's central business district. Premium finishes with hardwood floors, stainless appliances, and panoramic windows.

            Walk to Market Square Park, Buffalo Bayou, and countless restaurants. Near all METRORail stops for easy transit. Sky pool, fitness center, resident lounge, and valet parking available.
            """.Trim(),
            "Sky Pool, Valet Parking, Resident Lounge, Downtown Location, Hardwood Floors, Near Transit",
            0,
            AspirePhotos),

        // TX-45: Midtown - Brazos
        new(
            "2600-brazos-st-houston-tx",
            "Lumen Midtown — 1 bd · 1 ba · Midtown",
            "2600 Brazos St",
            "Houston, TX",
            1575,
            1,
            1,
            760,
            """
            Lumen Midtown is a contemporary community offering one-bedroom apartments in the heart of Houston's Midtown. Floor-to-ceiling windows, quartz countertops, and premium stainless steel appliances in every home.

            Steps from Houston's best nightlife, restaurants, and the METRORail. Skyline views from upper floors. Resort-style pool, fitness center, sky lounge, and controlled-access parking.
            """.Trim(),
            "Sky Lounge, Resort Pool, Fitness Center, Skyline Views, Floor-to-Ceiling Windows, Near Rail",
            0,
            HoustonMidtownPhotos),

        // TX-46: Midtown - Louisiana
        new(
            "2400-louisiana-st-houston-tx",
            "Louisiana Lofts — 1 bd · 1 ba · Midtown",
            "2400 Louisiana St",
            "Houston, TX",
            1435,
            1,
            1,
            720,
            """
            Louisiana Lofts occupies a converted building in Midtown offering loft-style one-bedroom residences. High ceilings, exposed ductwork, and oversized windows give these homes an industrial-chic character.

            Walk to Midtown bars, downtown Houston, and the Theater District. Near the METRORail McGowen station. Rooftop deck, bike storage, and controlled-access entry for residents.
            """.Trim(),
            "Loft Style, High Ceilings, Rooftop Deck, Bike Storage, Near METRORail, Controlled Access",
            0,
            MidtownRailPhotos),

        // TX-47: Midtown - Milam
        new(
            "2700-milam-st-houston-tx",
            "Milam Park Apartments — 1 bd · 1 ba · Midtown",
            "2700 Milam St",
            "Houston, TX",
            1295,
            1,
            1,
            680,
            """
            Milam Park Apartments offers solid one-bedroom living in Midtown Houston near the Ensemble/HCC METRORail stop. Updated units with new appliances, vinyl plank flooring, and ceiling fans.

            Walk to Midtown restaurants, bars, and coffee shops. Near Emancipation Park and easy downtown access. Pool, on-site laundry, and assigned parking. Responsive management team.
            """.Trim(),
            "Near METRORail, Pool, Assigned Parking, On-Site Laundry, Updated Units, Near Parks",
            0,
            HoustonMidtownPhotos),

        // TX-48: Midtown - Caroline
        new(
            "2900-caroline-st-houston-tx",
            "Caroline Midtown — 1 bd · 1 ba · Midtown",
            "2900 Caroline St",
            "Houston, TX",
            1540,
            1,
            1,
            750,
            """
            Caroline Midtown is a modern apartment community on Caroline Street in the heart of Midtown. One-bedroom residences with open kitchens, stainless appliances, and private balconies with city views.

            Steps from bars, restaurants, and Midtown Park. Near METRORail for Medical Center and downtown. Pool with sundeck, fitness center, and pet-friendly policies with on-site dog park.
            """.Trim(),
            "Dog Park, Pool, Fitness Center, Private Balconies, Near METRORail, City Views",
            0,
            MidtownRailPhotos),

        // TX-49: Downtown - Fannin
        new(
            "3100-fannin-st-houston-tx",
            "Fannin Square — 1 bd · 1 ba · Midtown",
            "3100 Fannin St",
            "Houston, TX",
            1225,
            1,
            1,
            650,
            """
            Fannin Square is a value-oriented community in upper Midtown near the Wheeler Transit Center. One-bedroom apartments with functional layouts, updated appliances, and good closet space.

            Walk to Midtown restaurants and bars with easy rail access to downtown, the Medical Center, and NRG Park. On-site laundry, covered parking, and gated entry for security.
            """.Trim(),
            "Near Transit Center, Gated Entry, Covered Parking, On-Site Laundry, Updated Appliances, Value",
            0,
            HoustonMidtownPhotos),

        // TX-50: Memorial - Gessner
        new(
            "1200-gessner-rd-houston-tx",
            "Gessner Park — 1 bd · 1 ba · West Houston",
            "1200 Gessner Rd",
            "Houston, TX",
            1155,
            1,
            1,
            700,
            """
            Gessner Park offers affordable one-bedroom living near the intersection of Gessner and I-10 in West Houston. Clean units with updated kitchens, good storage, and functional layouts for daily comfort.

            Near Memorial City Mall, Town & Country shops, and major employers along the Energy Corridor. Easy I-10 access. Pool, on-site laundry, assigned parking, and gated community entrance.
            """.Trim(),
            "Near Memorial City, Pool, Gated Entry, Assigned Parking, On-Site Laundry, Near I-10",
            0,
            MidtownRailPhotos),
    ];

    // ═══════════════════════════════════════════════════════════════
    // PHOTO ARRAYS — California
    // ═══════════════════════════════════════════════════════════════

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

    private static readonly string[] SdNorthParkPhotos =
    [
        "https://images1.apartments.com/i2/HTA_5DvqWjpxgUkfLY4xc0vdIrY0DxAzRIwXgki3yPU/117/parkline-north-park-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/7qyjf52rKJS5E6DtO6pBHCvjEnW1eYDrMrEmkM0nMGw/117/the-park-san-diego-ca-park-polk.jpg",
        "https://images1.apartments.com/i2/PYDbjovX49C840D0qOYgfkusZtJxmCfYK_uR9kYzjc8/117/niima-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] SdLittleItalyPhotos =
    [
        "https://images1.apartments.com/i2/rLPXcu7yyYNyFvPMB5qoF73v4tBIaYatw-mJgzaXIc4/117/stanza-little-italy-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/24Emb_ZQmhjdhyWTM2weRFFvF5GpN1p7cOrQExYhUEI/117/vici-luxury-rentals---little-italy-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/hiRneJst8wK9WRxhyFKycC1-tuboKPVVAWXQmR99BH4/117/the-helm-san-diego-ca-primary-photo.jpg",
    ];

    private static readonly string[] SdMissionValleyPhotos =
    [
        "https://images1.apartments.com/i2/-lwAHoIzoXe2HahZEai5DQWBdqJ9OX4uOq1JC4mSTm8/117/river-run-village-san-diego-ca-interior-photo.jpg",
        "https://images1.apartments.com/i2/U8aPV8Ojw-1XYfBf29YFiG0I3i73sPRWORK0ypsZk8o/117/imt-mission-valley-san-diego-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/3Z5vknDa5SRl7qoGkojUVxtj2yuNtiFhcbBuVcXvYpA/117/west-park-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] SdCoastalPhotos =
    [
        "https://images1.apartments.com/i2/65kDr75Yxivmm4ODzQCPHduAXXZ6Ithf1npF9w5Pgqc/111/loma-village-apartments-san-diego-ca-primary-photo.jpg",
        "https://images1.apartments.com/i2/dLKqoV34O3GkzE98X34bxzwfhhYvrQ3-xaMSHVnSjLo/117/pinnacle-on-the-park-san-diego-ca-interior-photo.jpg",
        "https://images1.apartments.com/i2/3Z5vknDa5SRl7qoGkojUVxtj2yuNtiFhcbBuVcXvYpA/117/west-park-san-diego-ca-building-photo.jpg",
    ];

    private static readonly string[] SacramentoPhotos =
    [
        "https://images1.apartments.com/i2/8WF6lrrf_2LtxLsvCr97f1wBihTL5qeA2tDIJxYgCTY/117/kinect-at-southport-sacramento-ca-building-photo.jpg",
        "https://images1.apartments.com/i2/PzKn44qWxXayk_lznoADAuLFxmGkeyv7zRJph2ASleg/117/sutter-green-apartments-sacramento-ca-building-photo.jpg",
    ];

    // ═══════════════════════════════════════════════════════════════
    // PHOTO ARRAYS — Houston / Austin
    // ═══════════════════════════════════════════════════════════════

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

    private static readonly string[] MetAustinPhotos =
    [
        "https://images1.apartments.com/i2/zq6ri1XKA1yfmFUSH8CtHWyzcbe5RLZIMrbsCjVFPgY/111/the-met-austin-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/PMp0vS-LqQFckIHZRFR4Vwsc1Cb5HJ6AmaTVVrN1_GI/117/the-met-austin-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/uqlRM3DB8QGUVQloPmaXp1GDUJ_3ZD_dtixa1hVbgw0/117/the-met-austin-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/jbXzyU2m_TVBbExSvt8P7v_a3HkUzNTleV96eAsCieI/117/the-met-austin-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/a-Ue9jZnAOYm5zh1NCy06g3ZdVIDSlcdC2nJCK-LafQ/117/the-met-austin-tx-building-photo.jpg",
    ];

    private static readonly string[] MontroseBayouPhotos =
    [
        "https://images1.apartments.com/i2/YyQOFR0_f4HSLZ_6GhzCcJOoQNWUGB_hG685IR0Ildk/111/montrose-at-buffalo-bayou-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/H2mjxvrJrDWsM4Jv4OI7Hnak9o1jBEKjp7JDn6QjYVg/117/montrose-at-buffalo-bayou-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/H9N21WZq3AfyNN7NnR-M9shNg5Y4LsWSy1NBKxNDeOY/117/montrose-at-buffalo-bayou-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/jN8obwFSMSImSeEA8jK-7YsnIlYaFmYO2pVYLiJxNK0/117/montrose-at-buffalo-bayou-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/JMMk-nptjQB-5VPnF0HFn2xW2ai33WiWthaxUjO4aNg/117/montrose-at-buffalo-bayou-houston-tx-building-photo.jpg",
    ];

    private static readonly string[] MidtownRailPhotos =
    [
        "https://images1.apartments.com/i2/Zn21UaG2ZLppMFzye1A40XCZiPZlkEyU6SkFFb-O1O8/111/midtown-on-the-rail-houston-tx-primary-photo.jpg",
        "https://images1.apartments.com/i2/V3vB2MEp2ADs3j21kwvWsKRdEHynJzjDo1kXH0LahMY/117/midtown-on-the-rail-houston-tx-rendering-photo.jpg",
        "https://images1.apartments.com/i2/X6x1xXZLEldDsYGCnGn8ZDRqBQtHtpiAuKUXZyrku3k/117/midtown-on-the-rail-houston-tx-interior-photo.jpg",
        "https://images1.apartments.com/i2/YsB9heUv_ljw0IjVmxpDCn8apyKJsZ_iVYku08aRAk0/117/midtown-on-the-rail-houston-tx-interior-photo.jpg",
        "https://images1.apartments.com/i2/Oi0c3L7CGezLPgUXFyAtYPpKCg9c6F9M6Z1TolTkhMM/117/midtown-on-the-rail-houston-tx-interior-photo.jpg",
    ];

    private static readonly string[] HoustonMidtownPhotos =
    [
        "https://images1.apartments.com/i2/CZf7NPHA63GTb9p6td2rA86hn5EDSe2X-Q_oF6MusOI/117/lumen-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/o3v1Gu5o9lWq6XvNeGTnLX4qXWevbUY4wr_UtWfhAQA/117/midtown-terrace-suites-houston-tx-building-photo.jpg",
        "https://images1.apartments.com/i2/IjJR4rXVooFM6sKiav5eaH25tfWM-0qgckX6Z1PuerQ/117/uniti-montrose-houston-tx-building-photo.jpg",
    ];
}
