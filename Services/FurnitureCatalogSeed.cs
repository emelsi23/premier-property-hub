namespace ApartamentosRenta.Services;

/// <summary>
/// Original Ironwood catalog (names, copy, SKUs, prices). Photos are royalty-free Unsplash URLs.
/// Not a copy of any third-party store catalog.
/// </summary>
public static class FurnitureCatalogSeed
{
    public static IReadOnlyList<SeedItem> All { get; } = Build();

    public sealed record SeedItem(
        string CategorySlug,
        string Title,
        string Sku,
        decimal Price,
        decimal? CompareAt,
        string Short,
        string Description,
        bool Featured,
        string[] Photos);

    private static IReadOnlyList<SeedItem> Build()
    {
        // Shared Unsplash furniture photo pool (royalty-free).
        string[] sofa =
        [
            "https://images.unsplash.com/photo-1555041469-a586c61ea9bc?w=1200&q=80",
            "https://images.unsplash.com/photo-1493663284031-b7e3aefcae8e?w=1200&q=80",
            "https://images.unsplash.com/photo-1586023492125-27b2c045efd7?w=1200&q=80",
            "https://images.unsplash.com/photo-1567538096630-e0c55bd6374c?w=1200&q=80",
            "https://images.unsplash.com/photo-1556228453-efd6c1ff04f6?w=1200&q=80",
            "https://images.unsplash.com/photo-1618220179428-22790b461013?w=1200&q=80"
        ];
        string[] table =
        [
            "https://images.unsplash.com/photo-1532372320572-cda25681a5d5?w=1200&q=80",
            "https://images.unsplash.com/photo-1617806118233-18e1de247200?w=1200&q=80",
            "https://images.unsplash.com/photo-1594026112284-02bb6f3352bb?w=1200&q=80",
            "https://images.unsplash.com/photo-1595428774223-ef52624120d2?w=1200&q=80"
        ];
        string[] bed =
        [
            "https://images.unsplash.com/photo-1505693416388-ac5ce068fe85?w=1200&q=80",
            "https://images.unsplash.com/photo-1616594039964-ae9021a400a0?w=1200&q=80",
            "https://images.unsplash.com/photo-1631049307264-da0ec9d70304?w=1200&q=80",
            "https://images.unsplash.com/photo-1522771739844-6a9f6d5f14af?w=1200&q=80"
        ];
        string[] chair =
        [
            "https://images.unsplash.com/photo-1503602642458-232111445657?w=1200&q=80",
            "https://images.unsplash.com/photo-1580480055273-228ff5388ef8?w=1200&q=80",
            "https://images.unsplash.com/photo-1506439773649-6e0eb8cfb237?w=1200&q=80",
            "https://images.unsplash.com/photo-1592078615290-033ee584e267?w=1200&q=80"
        ];
        string[] office =
        [
            "https://images.unsplash.com/photo-1518455027359-f3f8164ba9c7?w=1200&q=80",
            "https://images.unsplash.com/photo-1593062096033-9a2b4c4c4b1a?w=1200&q=80",
            "https://images.unsplash.com/photo-1497366216548-37526070297c?w=1200&q=80"
        ];
        string[] outdoor =
        [
            "https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?w=1200&q=80",
            "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=1200&q=80",
            "https://images.unsplash.com/photo-1600566753190-17f0baa2a6c3?w=1200&q=80",
            "https://images.unsplash.com/photo-1600047509807-ba8f99d2cdbc?w=1200&q=80"
        ];
        string[] lamp =
        [
            "https://images.unsplash.com/photo-1507473885765-e6ed057f782c?w=1200&q=80",
            "https://images.unsplash.com/photo-1513506003901-1e6a229e2d15?w=1200&q=80"
        ];

        var list = new List<SeedItem>();

        // ——— Living Room ———
        Add(list, "living-room", "Harbor Linen Sofa", "IW-LR-1001", 899m, 1099m, true,
            "Sofá de 3 plazas en lino natural con patas de madera.",
            "Sofá Harbor con asientos profundos, cojines removibles y estructura reforzada. Ideal para salas contemporáneas. Tapizado en lino beige lavable.",
            sofa[0], sofa[1]);
        Add(list, "living-room", "Cascade Sectional Chaise", "IW-LR-1002", 1499m, null, true,
            "Seccional modular con chaise reversible.",
            "Seccional Cascade con chaise reversible, tela performance y soporte de espuma de alta densidad. Perfecto para espacios abiertos.",
            sofa[2]);
        Add(list, "living-room", "Oakvale Coffee Table", "IW-LR-1003", 349m, 429m, false,
            "Mesa de centro en roble macizo con acabado mate.",
            "Mesa Oakvale en roble natural, borde vivo suave y patas cónicas. Combina con salas modernas o rústicas.",
            table[0]);
        Add(list, "living-room", "Nordic Accent Chair", "IW-LR-1004", 429m, null, true,
            "Sillón acento con respaldo alto y tela bouclé.",
            "Sillón Nordic con diseño escandinavo, bouclé crema y base en madera teñida nogal.",
            sofa[3]);
        Add(list, "living-room", "Ember Media Console", "IW-LR-1005", 699m, null, false,
            "Consola TV con puertas ranuradas y cableado oculto.",
            "Consola Ember de 70\" con puertas ranuradas, estantes ajustables y ventilación posterior para equipos.",
            table[3]);
        Add(list, "living-room", "Lumen Floor Lamp", "IW-LR-1006", 189m, 229m, false,
            "Lámpara de pie con pantalla de lino y base de metal.",
            "Lámpara Lumen con base en bronce envejecido y pantalla cilíndrica de lino. Luz cálida para lectura.",
            lamp[0]);
        Add(list, "living-room", "Riviera Track Arm Sofa", "IW-LR-1007", 1099m, 1299m, true,
            "Sofá track-arm de 88\" en tela performance.",
            "Sofá Riviera con brazos rectos, asiento firme de espuma densificada y patas en roble teñido. Disponible en tono piedra.",
            sofa[4], sofa[0]);
        Add(list, "living-room", "Brookside Loveseat", "IW-LR-1008", 749m, null, false,
            "Loveseat compacto para espacios pequeños.",
            "Loveseat Brookside de 62\", cojines sueltos y tela resistente a manchas. Ideal para apartamentos.",
            sofa[1]);
        Add(list, "living-room", "Marlowe Power Recliner", "IW-LR-1009", 899m, 1049m, true,
            "Reclinable eléctrico con USB y reposacabezas.",
            "Reclinable Marlowe con motor silencioso, puertos USB duales y soporte lumbar. Tapizado microfibra charcoal.",
            sofa[5]);
        Add(list, "living-room", "Glider Recliner Ashford", "IW-LR-1010", 549m, null, false,
            "Glider reclinable manual para sala o nursery.",
            "Ashford combina balanceo suave y reclinado manual. Base sólida y tela fácil de limpiar.",
            sofa[3]);
        Add(list, "living-room", "Pebble 4-Piece Sectional", "IW-LR-1011", 1799m, 2099m, true,
            "Seccional convertible de 4 piezas con chaise.",
            "Seccional Pebble modular: sofá, corner, chaise y otomana. Cojines extra firmes y tela bouclé arena.",
            sofa[2], sofa[4]);
        Add(list, "living-room", "Summit Convertible Sectional", "IW-LR-1012", 1299m, null, false,
            "Seccional en L con almohadas decorativas.",
            "Summit se configura izquierda o derecha. Incluye 2 throw pillows y patas negras mate.",
            sofa[0], sofa[2]);
        Add(list, "living-room", "Lift-Top Cocktail Table Knox", "IW-LR-1013", 449m, 529m, false,
            "Mesa lift-top con almacenamiento oculto.",
            "Knox eleva la tapa para laptop o comida. Compartimento interno y acabado roble oscuro.",
            table[0], table[1]);
        Add(list, "living-room", "Arch Storage Cabinet Mira", "IW-LR-1014", 399m, 499m, false,
            "Gabinete con puertas arqueadas y estantes.",
            "Gabinete Mira con puertas de arco, acabado roble claro y estantes ajustables para vajilla o libros.",
            table[3]);
        Add(list, "living-room", "Stone Accent Cabinet", "IW-LR-1015", 849m, null, true,
            "Cabinet de acento con puertas en relieve.",
            "Cabinet Stone de 2 puertas, acabado piedra/negro, ideal como pieza focal junto al sofá.",
            table[2]);
        Add(list, "living-room", "Slate Track Sofa", "IW-LR-1016", 649m, 749m, false,
            "Sofá contemporáneo en tono slate.",
            "Sofá Slate de 3 plazas, brazos anchos y asiento profundo. Tela performance gris pizarra.",
            sofa[5]);
        Add(list, "living-room", "Alloy Modern Sofa", "IW-LR-1017", 679m, null, false,
            "Sofá moderno en tejido alloy metalizado suave.",
            "Alloy aporta un look urbano con costuras limpia y patas cónicas. Perfecto para loft.",
            sofa[4]);
        Add(list, "living-room", "Nutmeg Classic Sofa", "IW-LR-1018", 599m, 699m, false,
            "Sofá clásico en tono nuez cálido.",
            "Sofá Nutmeg con brazos enrollados suaves, cojines plush y patas en madera natural.",
            sofa[1]);
        Add(list, "living-room", "Quartz Box Sofa", "IW-LR-1019", 729m, null, true,
            "Sofá boxy en tela quartz clara.",
            "Diseño Quartz de líneas limpias, asientos anchos y respaldo firme. Incluye cojines lumbar.",
            sofa[0]);
        Add(list, "living-room", "Manual Reclining Sofa Drift", "IW-LR-1020", 899m, 999m, false,
            "Sofá reclinable manual de 3 posiciones.",
            "Drift reclinable para dos plazas laterales. Mecánica confiable y tela negra resistente.",
            sofa[5]);
        Add(list, "living-room", "Vale Modular Sectional", "IW-LR-1021", 999m, 1199m, true,
            "Seccional de 4 piezas modular.",
            "Vale se arma en U o L. Piezas con conectores ocultos y cojines removibles.",
            sofa[2]);
        Add(list, "living-room", "Zephyr Soft Sectional", "IW-LR-1022", 1049m, null, false,
            "Seccional acolchado con chaise ancha.",
            "Zephyr ofrece asiento profundo tipo cloud y chaise generosa. Tela chenille suave.",
            sofa[4], sofa[1]);
        Add(list, "living-room", "Aviemore Sofa & Loveseat Set", "IW-LR-1023", 1199m, 1399m, true,
            "Set sofá + loveseat a juego.",
            "Set Aviemore en tejido piedra: sofá 84\" y loveseat 62\". Mismo acabado de patas y costura.",
            sofa[0], sofa[1]);
        Add(list, "living-room", "Beacon Convertible Sofa Bed", "IW-LR-1024", 899m, null, false,
            "Sofá convertible con 2 almohadas.",
            "Beacon se transforma en cama de visita. Incluye 2 accent pillows y mecanismo easy-pull.",
            sofa[2]);
        Add(list, "living-room", "Power Glider with Audio Ridge", "IW-LR-1025", 1299m, 1499m, true,
            "Glider power con sistema de audio Bluetooth.",
            "Ridge combina glider, reclinado eléctrico y parlantes integrados. Ideal home theater.",
            sofa[5]);
        Add(list, "living-room", "Power Reclining Sofa Mercer", "IW-LR-1026", 1349m, null, false,
            "Sofá power reclining en cuero sintético.",
            "Mercer en dark brown, cabezal ajustable y consolas laterales con carga USB.",
            sofa[5], sofa[3]);
        Add(list, "living-room", "District Convertible Sectional", "IW-LR-1027", 1249m, 1449m, false,
            "Seccional 4 piezas convertible.",
            "District incluye chaise y ottoman. Tela performance y patas negras.",
            sofa[2]);
        Add(list, "living-room", "Heartland Sofa & Loveseat", "IW-LR-1028", 1399m, null, true,
            "Conjunto sofá + loveseat en tela quartz.",
            "Heartland ofrece look tradicional actualizado. Cojines sueltos y brazos acolchados.",
            sofa[1], sofa[0]);
        Add(list, "living-room", "Boyd Power Recliner Black", "IW-LR-1029", 1099m, 1299m, false,
            "Power recliner con cabezal ajustable negro.",
            "Boyd en cuero sintético negro, motor dual y reposapiés extendido.",
            sofa[5]);
        Add(list, "living-room", "Boyd Power Recliner Gray", "IW-LR-1030", 1099m, 1299m, false,
            "Power recliner con cabezal ajustable gris.",
            "Misma construcción Boyd en gris carbón. Ideal para salas modernas.",
            sofa[4]);
        Add(list, "living-room", "Kora 3-Piece Sectional Chaise", "IW-LR-1031", 1699m, 1899m, true,
            "Seccional 3 piezas con chaise esquina.",
            "Kora en tono stone: sofá, corner y chaise RAF. Espuma de alta resiliencia.",
            sofa[2], sofa[0]);
        Add(list, "living-room", "Midnight 4-Piece Sectional", "IW-LR-1032", 2199m, 2499m, true,
            "Seccional grande 4 piezas en onyx.",
            "Midnight para salas amplias. Chaise LAF, deep seats y tela performance oscura.",
            sofa[5], sofa[4]);
        Add(list, "living-room", "Linden Fog Sectional", "IW-LR-1033", 2299m, null, true,
            "Seccional premium 4 piezas tono fog.",
            "Linden con chaise RAF, cojines overstuffed y patas ocultas para look flotante.",
            sofa[1], sofa[2]);
        Add(list, "living-room", "Daybed Kosmo Frame", "IW-LR-1034", 449m, 549m, false,
            "Daybed versátil para sala o guest room.",
            "Kosmo daybed con base sólida y listones. Añade tu colchón twin favorito.",
            bed[0]);
        Add(list, "living-room", "Side Table Pair Holm", "IW-LR-1035", 259m, null, false,
            "Par de mesas auxiliares redondas.",
            "Holm en roble claro, diámetro 18\". Perfectas junto al sofá o en pasillo.",
            table[0]);
        Add(list, "living-room", "Ottoman Storage Cube", "IW-LR-1036", 199m, 249m, false,
            "Otomana cubo con tapa abatible.",
            "Almacenamiento oculto para mantas. Tela durable y patas ocultas.",
            sofa[3]);
        Add(list, "living-room", "Wall Gallery Console", "IW-LR-1037", 549m, null, false,
            "Consola estrecha para TV o entrada.",
            "Consola de 60\" con 2 cajones y estante inferior abierto. Acabado nogal.",
            table[3]);
        Add(list, "living-room", "Arc Floor Lamp Brass", "IW-LR-1038", 229m, null, false,
            "Lámpara arco en latón mate.",
            "Arco ajustable sobre sofá o sillón. Pantalla de lino blanco.",
            lamp[1]);
        Add(list, "living-room", "Bouclé Swivel Chair", "IW-LR-1039", 499m, 599m, true,
            "Sillón giratorio en bouclé ivory.",
            "Base giratoria 360°, asiento ancho y respaldo curvo. Pieza statement.",
            sofa[3]);
        Add(list, "living-room", "Leather Look Club Chair", "IW-LR-1040", 579m, null, false,
            "Club chair en vinilo premium.",
            "Estilo club clásico, costuras reforzadas y patas en caoba oscura.",
            sofa[5]);

        // ——— Bedroom ———
        Add(list, "bedroom", "Solstice Platform Bed Queen", "IW-BR-2001", 799m, 949m, true,
            "Cama platform queen con cabecera tapizada.",
            "Cama Solstice queen con cabecera acolchada, listones de soporte y no requiere box spring.",
            bed[0], bed[1]);
        Add(list, "bedroom", "Cedar Nightstand Pair", "IW-BR-2002", 459m, null, false,
            "Par de mesas de noche con cajón suave.",
            "Par de nightstands Cedar en chapa de nogal, cajón con cierre suave y nicho abierto inferior.",
            table[3]);
        Add(list, "bedroom", "Atlas 6-Drawer Dresser", "IW-BR-2003", 899m, 1049m, true,
            "Cómoda de 6 cajones con tiradores metalizados.",
            "Cómoda Atlas amplia, 6 cajones de deslizamiento suave y acabado carbón mate.",
            table[2]);
        Add(list, "bedroom", "Cloud Soft Bench", "IW-BR-2004", 279m, null, false,
            "Banco de pie de cama con tapizado bouclé.",
            "Banco Cloud con espuma densa y tapizado bouclé ivory. Ideal al pie de la cama o en vestíbulo.",
            sofa[3]);
        Add(list, "bedroom", "Pinecrest Queen 4-Piece Set", "IW-BR-2005", 899m, 1099m, true,
            "Set queen: cama, cómoda, espejo y nightstand.",
            "Set Pinecrest en pino natural. Cabecera panel, cómoda 6 cajones, espejo y 1 mesa de noche.",
            bed[1], table[3]);
        Add(list, "bedroom", "Sherwood Dresser Wide", "IW-BR-2006", 749m, null, false,
            "Cómoda ancha de 6 cajones.",
            "Sherwood con frente ranurado, tiradores negros y acabado roble medio.",
            table[2]);
        Add(list, "bedroom", "Carlton Queen 4-Piece Set", "IW-BR-2007", 949m, null, true,
            "Set queen completo estilo contemporáneo.",
            "Incluye platform bed, dresser, mirror y nightstand. Acabado gris cálido.",
            bed[0], bed[2]);
        Add(list, "bedroom", "Sierra Queen Bedroom Set", "IW-BR-2008", 799m, 999m, false,
            "Set 4 piezas en oferta de temporada.",
            "Sierra incluye cama, cómoda, espejo y nightstand. Acabado aqua-gris suave.",
            bed[3], table[3]);
        Add(list, "bedroom", "Ashlyn Storage Panel Bed", "IW-BR-2009", 899m, null, true,
            "Cama queen con almacenamiento bajo.",
            "Ashlyn panel bed blanca/natural con cajones laterales ocultos. Sin box spring.",
            bed[1]);
        Add(list, "bedroom", "Crowley Tall Dresser", "IW-BR-2010", 849m, 949m, false,
            "Cómoda alta de 5 cajones.",
            "Crowley en gris moderno, perfil delgado para closets estrechos.",
            table[2]);
        Add(list, "bedroom", "Kendall White Queen Set", "IW-BR-2011", 999m, null, true,
            "Set 4 piezas blanco brillante.",
            "Kendall: cama, dresser, mirror y nightstand. Ideal habitaciones luminosas.",
            bed[0], table[3]);
        Add(list, "bedroom", "Watson Gray Oak Set", "IW-BR-2012", 999m, 1149m, false,
            "Set queen en gray oak.",
            "Watson con vetas naturales visibles y herrajes brushed nickel.",
            bed[2], table[2]);
        Add(list, "bedroom", "Lysa Armoire Wardrobe", "IW-BR-2013", 1099m, null, false,
            "Armario con barra y estantes.",
            "Lysa armoire con puertas dobles, barra de colgar y 2 cajones inferiores.",
            table[3]);
        Add(list, "bedroom", "Kona Queen 4-Piece Set", "IW-BR-2014", 1099m, 1249m, true,
            "Set queen gris moderno completo.",
            "Kona incluye bed, dresser, mirror y nightstand. Acabado gray wash.",
            bed[1], bed[3]);
        Add(list, "bedroom", "Aphra Vanity Desk", "IW-BR-2015", 649m, 749m, false,
            "Vanity con espejo y cajones.",
            "Aphra vanity blanca con toques rosa suave, espejo oval y taburete opcional no incluido.",
            table[1]);
        Add(list, "bedroom", "Kai King 5-Piece Set Gray", "IW-BR-2016", 1299m, null, true,
            "Set king 5 piezas en gris.",
            "Kai western king: cama, dresser, mirror y 2 nightstands. Acabado gris contemporáneo.",
            bed[0], bed[2]);
        Add(list, "bedroom", "Oster Black Dresser", "IW-BR-2017", 899m, null, false,
            "Cómoda negra mate de 6 cajones.",
            "Oster con frente liso y tiradores ocultos. Look minimalista.",
            table[2]);
        Add(list, "bedroom", "Millie Warm Gray 5-Piece", "IW-BR-2018", 1199m, 1349m, true,
            "Set queen 5 piezas warm gray.",
            "Millie incluye bed, dresser, mirror, chest y nightstand.",
            bed[3], table[3]);
        Add(list, "bedroom", "Marcela White Queen Set", "IW-BR-2019", 1049m, null, false,
            "Set 4 piezas blanco clásico.",
            "Marcela con molduras suaves y acabado lacado fácil de limpiar.",
            bed[0]);
        Add(list, "bedroom", "Lucia Beige & White Set", "IW-BR-2020", 1099m, 1249m, false,
            "Set queen beige y blanco.",
            "Lucia combina cabecera tapizada beige con casegoods blancos.",
            bed[1], sofa[1]);
        Add(list, "bedroom", "Caraway Black Queen Set", "IW-BR-2021", 1149m, null, true,
            "Set 4 piezas negro dramático.",
            "Caraway para habitaciones modernas. Contraste fuerte con ropa de cama clara.",
            bed[2], table[2]);
        Add(list, "bedroom", "Kai Queen 5-Piece Black", "IW-BR-2022", 1199m, 1399m, false,
            "Set queen 5 piezas negro.",
            "Incluye bed, dresser, mirror, chest y nightstand en negro satinado.",
            bed[0], table[3]);
        Add(list, "bedroom", "Cavelle Black Queen Set", "IW-BR-2023", 1099m, null, false,
            "Set 4 piezas negro contemporáneo.",
            "Cavelle con líneas rectas y patas cónicas. Fácil de combinar.",
            bed[3]);
        Add(list, "bedroom", "Willow Queen 6-Piece Set", "IW-BR-2024", 1299m, 1499m, true,
            "Set queen amplio 6 piezas.",
            "Willow incluye bed, dresser, mirror, 2 nightstands y chest. Acabado washed white.",
            bed[1], bed[0]);
        Add(list, "bedroom", "Brant Oak Queen 5-Piece", "IW-BR-2025", 1249m, null, true,
            "Set queen 5 piezas barrel oak.",
            "Brant en roble barrel con herrajes bronce. Estilo transitional.",
            bed[2], table[0]);
        Add(list, "bedroom", "Brant Coastal White 5-Piece", "IW-BR-2026", 1249m, 1399m, false,
            "Set queen 5 piezas coastal white.",
            "Misma colección Brant en blanco costero. Look fresco y luminoso.",
            bed[0], table[3]);
        Add(list, "bedroom", "Upholstered Headboard Only", "IW-BR-2027", 329m, 399m, false,
            "Cabecera queen tapizada standalone.",
            "Se fija a la pared o al frame existente. Espuma densa y tela linen-look.",
            bed[1]);
        Add(list, "bedroom", "Mirror Floor Leaner", "IW-BR-2028", 249m, null, false,
            "Espejo de piso 66\" con marco roble.",
            "Leaner mirror para vestidor o dormitorio. Cristal biselado.",
            table[1]);

        // ——— Dining ———
        Add(list, "dining", "Harvest Extendable Table", "IW-DN-3001", 1099m, null, true,
            "Mesa extensible para 6–8 personas.",
            "Mesa Harvest en roble, extensible con hoja central. Asientos cómodos para 6 y hasta 8 extendida.",
            table[1]);
        Add(list, "dining", "Ridge Dining Chair Set of 4", "IW-DN-3002", 519m, 599m, false,
            "Set de 4 sillas con asiento tapizado.",
            "Sillas Ridge con estructura de madera, asiento en tela performance y respaldo ergonómico.",
            chair[0]);
        Add(list, "dining", "Barley Counter Stool", "IW-DN-3003", 189m, null, false,
            "Taburete de barra con respaldo bajo.",
            "Taburete Barley altura counter, asiento acolchado y reposapiés en metal negro mate.",
            chair[2]);
        Add(list, "dining", "Granary Sideboard", "IW-DN-3004", 849m, 999m, true,
            "Aparador con estantes internos y puertas.",
            "Sideboard Granary con 3 puertas, estantes ajustables y acabado nogal. Ideal para vajilla y servicio.",
            table[3]);
        Add(list, "dining", "Arlo Wine Cabinet", "IW-DN-3005", 349m, null, false,
            "Cabinet para vino con puertas corredizas.",
            "Arlo en rustic oak, porta botellas y estante para copas. Compacto para apartamentos.",
            table[2]);
        Add(list, "dining", "Hazel Espresso Wine Rack", "IW-DN-3006", 299m, 349m, false,
            "Wine cabinet espresso 35\".",
            "Hazel con racks inclinados y puerta de vidrio templado.",
            table[3]);
        Add(list, "dining", "Rowan Side Chair Pair", "IW-DN-3007", 279m, null, false,
            "Par de sillas side upholstered.",
            "Rowan en gris/negro, asiento acolchado y patas cónicas. Venta por par.",
            chair[0], chair[3]);
        Add(list, "dining", "Burke Swivel Barstool Pair", "IW-DN-3008", 399m, 449m, true,
            "Par de barstools swivel beige.",
            "Burke altura bar, asiento giratorio y base dark brown. Set de 2.",
            chair[2]);
        Add(list, "dining", "Anchor 5-Piece Counter Set", "IW-DN-3009", 599m, null, false,
            "Set counter: mesa + 4 sillas.",
            "Anchor en acabado natural. Mesa square y 4 counter chairs.",
            table[1], chair[0]);
        Add(list, "dining", "Circle 6-Piece Dining Set", "IW-DN-3010", 699m, 799m, true,
            "Set 6 piezas mesa redonda + sillas.",
            "Circle con mesa redonda y 5 sillas. Ideal conversación familiar.",
            table[0], chair[1]);
        Add(list, "dining", "Edina Server Oak Black", "IW-DN-3011", 649m, null, false,
            "Server / buffet oak y negro.",
            "Edina con puertas y cajones. Acabado oak & sandy black.",
            table[3]);
        Add(list, "dining", "Morocco 7-Piece Dining Set", "IW-DN-3012", 749m, 899m, true,
            "Mesa rectangular + 6 sillas natural.",
            "Morocco en madera natural clara. Capacidad 6 cómoda.",
            table[1], chair[0]);
        Add(list, "dining", "Nate Maple Server", "IW-DN-3013", 599m, null, false,
            "Server maple con estantes abiertos.",
            "Nate maple, estilo transitional. Perfecto bajo TV o en dining.",
            table[2]);
        Add(list, "dining", "Bard 5-Piece Counter Set", "IW-DN-3014", 899m, 999m, false,
            "Set counter wheat/charcoal 5 piezas.",
            "Bard: mesa counter + 4 stools. Contraste wheat y charcoal.",
            table[1], chair[2]);
        Add(list, "dining", "Lazy Susan Counter 7-Piece", "IW-DN-3015", 999m, null, true,
            "Set counter 7 piezas con lazy susan.",
            "Mesa square alta, lazy susan central y 6 stools.",
            table[0], chair[2]);
        Add(list, "dining", "Harbor 7-Piece Dining Set", "IW-DN-3016", 999m, 1149m, true,
            "Set comedor 7 piezas completo.",
            "Mesa rectangular + 6 sillas tapizadas. Acabado roble medio.",
            table[1], chair[3]);
        Add(list, "dining", "Bard 6-Piece Counter Set", "IW-DN-3017", 1099m, null, false,
            "Set counter 6 piezas wheat/charcoal.",
            "Mesa más larga + 5 stools de la colección Bard.",
            table[1], chair[2]);
        Add(list, "dining", "Arini Extension Dining Set", "IW-DN-3018", 1599m, 1799m, true,
            "Set 5 piezas con hoja de extensión.",
            "Arini sand wash: mesa extensible + 4 sillas. Crece de 6 a 8 puestos.",
            table[0], chair[0]);
        Add(list, "dining", "Burke 7-Piece Formal Set", "IW-DN-3019", 1799m, 1999m, true,
            "Set formal con hoja de 18\".",
            "Mesa Burke + 6 sillas. Hoja incluida. Acabado dark brown elegante.",
            table[1], chair[3]);
        Add(list, "dining", "Escape Dining Bar Trio", "IW-DN-3020", 1899m, null, false,
            "Bar dining + 2 swivel stools.",
            "Escape en glazed oak con trim negro. Ideal loft o kitchen island look.",
            table[3], chair[2]);
        Add(list, "dining", "Simple Side Chair Single", "IW-DN-3021", 89m, null, false,
            "Silla comedor individual económica.",
            "Estructura madera, asiento sólido. Compra varias para sets custom.",
            chair[0]);
        Add(list, "dining", "Counter Height Chair Single", "IW-DN-3022", 99m, 119m, false,
            "Silla counter individual.",
            "Altura counter estándar. Metal y madera mixta.",
            chair[2]);
        Add(list, "dining", "Black Metal Barstool", "IW-DN-3023", 79m, null, false,
            "Barstool negro industrial.",
            "Acero negro mate, asiento redondo. Stackable en almacén.",
            chair[1]);
        Add(list, "dining", "Upholstered Counter Stool", "IW-DN-3024", 129m, 149m, false,
            "Stool counter tapizado gris.",
            "Asiento cushion, reposapiés cromado y patas negras.",
            chair[2]);

        // ——— Home Office ———
        Add(list, "home-office", "Focus Standing Desk", "IW-HO-4001", 649m, null, true,
            "Escritorio sit-stand eléctrico 48\".",
            "Escritorio Focus con motor silencioso, memoria de altura y superficie resistente a rayones.",
            office[0]);
        Add(list, "home-office", "Aero Mesh Task Chair", "IW-HO-4002", 329m, 399m, true,
            "Silla ergonómica con respaldo mesh.",
            "Silla Aero con lumbar ajustable, reposabrazos 3D y ruedas silenciosas para piso duro.",
            chair[1]);
        Add(list, "home-office", "Linea Bookcase Tall", "IW-HO-4003", 449m, null, false,
            "Librero alto de 5 niveles.",
            "Librero Linea en acabado roble claro, 5 estantes abiertos y anclaje anti-vuelco incluido.",
            table[2]);
        Add(list, "home-office", "Studio Compact Desk 42\"", "IW-HO-4004", 349m, 399m, false,
            "Escritorio compacto para home office.",
            "Studio 42\" con cajón y bandeja para teclado. Acabado blanco/roble.",
            office[0]);
        Add(list, "home-office", "Executive L-Desk Oak", "IW-HO-4005", 899m, null, true,
            "Escritorio en L con retorno.",
            "L-desk Executive en roble, 2 cajones y grommets para cables.",
            office[2], office[0]);
        Add(list, "home-office", "File Credenza Low", "IW-HO-4006", 499m, 579m, false,
            "Credenza baja para archivos.",
            "Dos cajones letter/legal y superficie para impresora.",
            table[3]);
        Add(list, "home-office", "Ergo Kneeling Chair", "IW-HO-4007", 219m, null, false,
            "Silla ergonómica de rodillas.",
            "Alternativa activa al task chair. Espuma firme y base estable.",
            chair[1]);
        Add(list, "home-office", "Wall Shelf Set of 3", "IW-HO-4008", 129m, 159m, false,
            "Set de 3 estantes flotantes.",
            "Roble claro, instalación oculta. Para libros y decoración.",
            table[0]);
        Add(list, "home-office", "Monitor Riser with Drawer", "IW-HO-4009", 79m, null, false,
            "Elevador de monitor con cajón.",
            "Bambú, altura ergonómica y almacenamiento para accesorios.",
            office[0]);
        Add(list, "home-office", "Guest Office Chair Pair", "IW-HO-4010", 399m, 449m, false,
            "Par de sillas de visita.",
            "Sin ruedas, asiento tapizado y estructura metal negro.",
            chair[3]);

        // ——— Outdoor ———
        Add(list, "outdoor", "Terrace Teak Lounge Set", "IW-OD-5001", 1299m, 1499m, true,
            "Set exterior sofá + 2 sillones + mesa.",
            "Set Terrace en ratán sintético con cojines weatherproof y mesa de centro en teak.",
            outdoor[0]);
        Add(list, "outdoor", "Ember Fire Pit Table", "IW-OD-5002", 799m, null, false,
            "Mesa fire pit a gas propano.",
            "Fire pit Ember con tapa de mesa conversora, quemador de acero inoxidable y control de llama.",
            outdoor[1]);
        Add(list, "outdoor", "Coastal Adirondack Pair", "IW-OD-5003", 349m, 399m, false,
            "Par de Adirondack en poly lumber.",
            "Par de sillas Adirondack Coastal, poly lumber resistente a UV, no requieren pintura.",
            outdoor[2]);
        Add(list, "outdoor", "Patio Dining 7-Piece", "IW-OD-5004", 1099m, 1299m, true,
            "Mesa outdoor + 6 sillas.",
            "Aluminio powder-coat y textilene. Parasol no incluido.",
            outdoor[0], outdoor[3]);
        Add(list, "outdoor", "Chaise Lounge Pair", "IW-OD-5005", 599m, null, false,
            "Par de camastros ajustables.",
            "5 posiciones, ruedas traseras y cojines removibles.",
            outdoor[2]);
        Add(list, "outdoor", "Bistro Set for Two", "IW-OD-5006", 279m, 329m, false,
            "Set bistró mesa + 2 sillas.",
            "Hierro forjado look, compacto para balcón.",
            outdoor[3]);
        Add(list, "outdoor", "Outdoor Sectional Modular", "IW-OD-5007", 1599m, 1799m, true,
            "Seccional outdoor modular.",
            "Piezas con cojines solution-dyed. Resiste sol y lluvia ligera.",
            outdoor[0], outdoor[1]);
        Add(list, "outdoor", "Planter Box Pair Tall", "IW-OD-5008", 189m, null, false,
            "Par de jardineras altas.",
            "Madera tratada, drenaje inferior. 24\" alto.",
            outdoor[3]);

        // ——— Mattresses ———
        Add(list, "mattresses", "Summit Hybrid Mattress Queen", "IW-MT-6001", 899m, 1099m, true,
            "Colchón híbrido queen con resortes pocket.",
            "Colchón Summit hybrid: foam de alivio de presión + pocket coils. Funda lavable y prueba en casa 100 noches.",
            bed[2]);
        Add(list, "mattresses", "Drift Memory Foam Twin", "IW-MT-6002", 449m, null, false,
            "Colchón memory foam twin.",
            "Drift memory foam twin con capas de gel cooling y base de soporte. Empaque compacto.",
            bed[0]);
        Add(list, "mattresses", "Summit Hybrid King", "IW-MT-6003", 1199m, 1399m, true,
            "Colchón híbrido king.",
            "Misma construcción Summit en king. Edge support reforzado.",
            bed[2], bed[3]);
        Add(list, "mattresses", "Cloud Soft Foam Queen", "IW-MT-6004", 699m, 849m, false,
            "Memory foam queen plush.",
            "Sensación cloud, gel cooling y funda zip-off.",
            bed[1]);
        Add(list, "mattresses", "Firm Support Twin XL", "IW-MT-6005", 399m, null, false,
            "Colchón firme twin XL.",
            "Ideal dormitorios juveniles o guest. Núcleo de soporte denso.",
            bed[0]);
        Add(list, "mattresses", "Pillow Top Hybrid Full", "IW-MT-6006", 749m, 899m, false,
            "Híbrido full con pillow top.",
            "Capa superior plush + coils. Buen balance firmeza/confort.",
            bed[2]);
        Add(list, "mattresses", "Adjustable Base Queen", "IW-MT-6007", 899m, null, true,
            "Base ajustable eléctrica queen.",
            "Cabeza y pies motorizados, control remoto y USB. Compatible con híbridos.",
            bed[3]);
        Add(list, "mattresses", "Mattress Protector Queen", "IW-MT-6008", 49m, 69m, false,
            "Protector impermeable queen.",
            "Bambú, silencioso y con elásticos de esquina.",
            bed[1]);

        // ——— Sale ———
        Add(list, "sale", "Clearance Bouclé Loveseat", "IW-SL-7001", 549m, 799m, true,
            "Loveseat bouclé — liquidación limitada.",
            "Loveseat en bouclé arena, stock limitado de liquidación. Garantía de estructura 1 año.",
            sofa[0]);
        Add(list, "sale", "Warehouse Oak Desk", "IW-SL-7002", 299m, 449m, false,
            "Escritorio de exhibición con descuento.",
            "Escritorio de exhibición en roble, ligeras marcas de showroom. Funcional y con garantía limitada.",
            office[0]);
        Add(list, "sale", "Floor Model Recliner", "IW-SL-7003", 399m, 699m, true,
            "Reclinable de piso — único.",
            "Modelo de exhibición en excelente estado. Color charcoal. Sin caja original.",
            sofa[5]);
        Add(list, "sale", "Open Box Nightstand", "IW-SL-7004", 129m, 229m, false,
            "Nightstand open-box.",
            "Empaque abierto, producto nuevo. Acabado gray oak.",
            table[3]);
        Add(list, "sale", "Last Chance Dining Chairs ×2", "IW-SL-7005", 149m, 279m, false,
            "Par de sillas última unidad.",
            "Set de 2 sillas remanentes de colección anterior. Tela taupe.",
            chair[0]);
        Add(list, "sale", "Scratch & Dent Media Console", "IW-SL-7006", 349m, 699m, true,
            "Consola con leve marca de showroom.",
            "Marca superficial en un lateral. Funciona perfecto. 65\" width.",
            table[3]);
        Add(list, "sale", "Demo Mattress Queen", "IW-SL-7007", 399m, 899m, false,
            "Colchón demo queen higienizado.",
            "Usado solo en showroom, funda nueva incluida. Híbrido medium.",
            bed[2]);
        Add(list, "sale", "Patio Set Clearance", "IW-SL-7008", 499m, 899m, true,
            "Set patio 4 piezas liquidación.",
            "Sofá + 2 chairs + mesa. Cojines nuevos. Estructura year-end clearance.",
            outdoor[0]);

        return list;
    }

    private static void Add(
        List<SeedItem> list,
        string cat,
        string title,
        string sku,
        decimal price,
        decimal? compare,
        bool featured,
        string shortDesc,
        string desc,
        params string[] photos)
    {
        list.Add(new SeedItem(cat, title, sku, price, compare, shortDesc, desc, featured, photos));
    }
}
