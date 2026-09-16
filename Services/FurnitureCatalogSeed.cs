namespace ApartamentosRenta.Services;

/// <summary>
/// Original Ironwood catalog. Photos assigned uniquely from FurniturePhotoLibrary (Pexels).
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
        var list = new List<SeedItem>();
        Add(list, "living-room", "Harbor Linen Sofa", "IW-LR-1001", 899m, 1099m, true,
            "Sof├í de 3 plazas en lino natural con patas de madera.",
            "Sof├í Harbor con asientos profundos, cojines removibles y estructura reforzada. Ideal para salas contempor├íneas. Tapizado en lino beige lavable.");

        Add(list, "living-room", "Cascade Sectional Chaise", "IW-LR-1002", 1499m, null, true,
            "Seccional modular con chaise reversible.",
            "Seccional Cascade con chaise reversible, tela performance y soporte de espuma de alta densidad. Perfecto para espacios abiertos.");

        Add(list, "living-room", "Oakvale Coffee Table", "IW-LR-1003", 349m, 429m, false,
            "Mesa de centro en roble macizo con acabado mate.",
            "Mesa Oakvale en roble natural, borde vivo suave y patas c├│nicas. Combina con salas modernas o r├║sticas.");

        Add(list, "living-room", "Nordic Accent Chair", "IW-LR-1004", 429m, null, true,
            "Sill├│n acento con respaldo alto y tela boucl├®.",
            "Sill├│n Nordic con dise├▒o escandinavo, boucl├® crema y base en madera te├▒ida nogal.");

        Add(list, "living-room", "Ember Media Console", "IW-LR-1005", 699m, null, false,
            "Consola TV con puertas ranuradas y cableado oculto.",
            "Consola Ember de 70\" con puertas ranuradas, estantes ajustables y ventilaci├│n posterior para equipos.");

        Add(list, "living-room", "Lumen Floor Lamp", "IW-LR-1006", 189m, 229m, false,
            "L├ímpara de pie con pantalla de lino y base de metal.",
            "L├ímpara Lumen con base en bronce envejecido y pantalla cil├¡ndrica de lino. Luz c├ílida para lectura.");

        Add(list, "living-room", "Riviera Track Arm Sofa", "IW-LR-1007", 1099m, 1299m, true,
            "Sof├í track-arm de 88\" en tela performance.",
            "Sof├í Riviera con brazos rectos, asiento firme de espuma densificada y patas en roble te├▒ido. Disponible en tono piedra.");

        Add(list, "living-room", "Brookside Loveseat", "IW-LR-1008", 749m, null, false,
            "Loveseat compacto para espacios peque├▒os.",
            "Loveseat Brookside de 62\", cojines sueltos y tela resistente a manchas. Ideal para apartamentos.");

        Add(list, "living-room", "Marlowe Power Recliner", "IW-LR-1009", 899m, 1049m, true,
            "Reclinable el├®ctrico con USB y reposacabezas.",
            "Reclinable Marlowe con motor silencioso, puertos USB duales y soporte lumbar. Tapizado microfibra charcoal.");

        Add(list, "living-room", "Glider Recliner Ashford", "IW-LR-1010", 549m, null, false,
            "Glider reclinable manual para sala o nursery.",
            "Ashford combina balanceo suave y reclinado manual. Base s├│lida y tela f├ícil de limpiar.");

        Add(list, "living-room", "Pebble 4-Piece Sectional", "IW-LR-1011", 1799m, 2099m, true,
            "Seccional convertible de 4 piezas con chaise.",
            "Seccional Pebble modular: sof├í, corner, chaise y otomana. Cojines extra firmes y tela boucl├® arena.");

        Add(list, "living-room", "Summit Convertible Sectional", "IW-LR-1012", 1299m, null, false,
            "Seccional en L con almohadas decorativas.",
            "Summit se configura izquierda o derecha. Incluye 2 throw pillows y patas negras mate.");

        Add(list, "living-room", "Lift-Top Cocktail Table Knox", "IW-LR-1013", 449m, 529m, false,
            "Mesa lift-top con almacenamiento oculto.",
            "Knox eleva la tapa para laptop o comida. Compartimento interno y acabado roble oscuro.");

        Add(list, "living-room", "Arch Storage Cabinet Mira", "IW-LR-1014", 399m, 499m, false,
            "Gabinete con puertas arqueadas y estantes.",
            "Gabinete Mira con puertas de arco, acabado roble claro y estantes ajustables para vajilla o libros.");

        Add(list, "living-room", "Stone Accent Cabinet", "IW-LR-1015", 849m, null, true,
            "Cabinet de acento con puertas en relieve.",
            "Cabinet Stone de 2 puertas, acabado piedra/negro, ideal como pieza focal junto al sof├í.");

        Add(list, "living-room", "Slate Track Sofa", "IW-LR-1016", 649m, 749m, false,
            "Sof├í contempor├íneo en tono slate.",
            "Sof├í Slate de 3 plazas, brazos anchos y asiento profundo. Tela performance gris pizarra.");

        Add(list, "living-room", "Alloy Modern Sofa", "IW-LR-1017", 679m, null, false,
            "Sof├í moderno en tejido alloy metalizado suave.",
            "Alloy aporta un look urbano con costuras limpia y patas c├│nicas. Perfecto para loft.");

        Add(list, "living-room", "Nutmeg Classic Sofa", "IW-LR-1018", 599m, 699m, false,
            "Sof├í cl├ísico en tono nuez c├ílido.",
            "Sof├í Nutmeg con brazos enrollados suaves, cojines plush y patas en madera natural.");

        Add(list, "living-room", "Quartz Box Sofa", "IW-LR-1019", 729m, null, true,
            "Sof├í boxy en tela quartz clara.",
            "Dise├▒o Quartz de l├¡neas limpias, asientos anchos y respaldo firme. Incluye cojines lumbar.");

        Add(list, "living-room", "Manual Reclining Sofa Drift", "IW-LR-1020", 899m, 999m, false,
            "Sof├í reclinable manual de 3 posiciones.",
            "Drift reclinable para dos plazas laterales. Mec├ínica confiable y tela negra resistente.");

        Add(list, "living-room", "Vale Modular Sectional", "IW-LR-1021", 999m, 1199m, true,
            "Seccional de 4 piezas modular.",
            "Vale se arma en U o L. Piezas con conectores ocultos y cojines removibles.");

        Add(list, "living-room", "Zephyr Soft Sectional", "IW-LR-1022", 1049m, null, false,
            "Seccional acolchado con chaise ancha.",
            "Zephyr ofrece asiento profundo tipo cloud y chaise generosa. Tela chenille suave.");

        Add(list, "living-room", "Aviemore Sofa & Loveseat Set", "IW-LR-1023", 1199m, 1399m, true,
            "Set sof├í + loveseat a juego.",
            "Set Aviemore en tejido piedra: sof├í 84\" y loveseat 62\". Mismo acabado de patas y costura.");

        Add(list, "living-room", "Beacon Convertible Sofa Bed", "IW-LR-1024", 899m, null, false,
            "Sof├í convertible con 2 almohadas.",
            "Beacon se transforma en cama de visita. Incluye 2 accent pillows y mecanismo easy-pull.");

        Add(list, "living-room", "Power Glider with Audio Ridge", "IW-LR-1025", 1299m, 1499m, true,
            "Glider power con sistema de audio Bluetooth.",
            "Ridge combina glider, reclinado el├®ctrico y parlantes integrados. Ideal home theater.");

        Add(list, "living-room", "Power Reclining Sofa Mercer", "IW-LR-1026", 1349m, null, false,
            "Sof├í power reclining en cuero sint├®tico.",
            "Mercer en dark brown, cabezal ajustable y consolas laterales con carga USB.");

        Add(list, "living-room", "District Convertible Sectional", "IW-LR-1027", 1249m, 1449m, false,
            "Seccional 4 piezas convertible.",
            "District incluye chaise y ottoman. Tela performance y patas negras.");

        Add(list, "living-room", "Heartland Sofa & Loveseat", "IW-LR-1028", 1399m, null, true,
            "Conjunto sof├í + loveseat en tela quartz.",
            "Heartland ofrece look tradicional actualizado. Cojines sueltos y brazos acolchados.");

        Add(list, "living-room", "Boyd Power Recliner Black", "IW-LR-1029", 1099m, 1299m, false,
            "Power recliner con cabezal ajustable negro.",
            "Boyd en cuero sint├®tico negro, motor dual y reposapi├®s extendido.");

        Add(list, "living-room", "Boyd Power Recliner Gray", "IW-LR-1030", 1099m, 1299m, false,
            "Power recliner con cabezal ajustable gris.",
            "Misma construcci├│n Boyd en gris carb├│n. Ideal para salas modernas.");

        Add(list, "living-room", "Kora 3-Piece Sectional Chaise", "IW-LR-1031", 1699m, 1899m, true,
            "Seccional 3 piezas con chaise esquina.",
            "Kora en tono stone: sof├í, corner y chaise RAF. Espuma de alta resiliencia.");

        Add(list, "living-room", "Midnight 4-Piece Sectional", "IW-LR-1032", 2199m, 2499m, true,
            "Seccional grande 4 piezas en onyx.",
            "Midnight para salas amplias. Chaise LAF, deep seats y tela performance oscura.");

        Add(list, "living-room", "Linden Fog Sectional", "IW-LR-1033", 2299m, null, true,
            "Seccional premium 4 piezas tono fog.",
            "Linden con chaise RAF, cojines overstuffed y patas ocultas para look flotante.");

        Add(list, "living-room", "Daybed Kosmo Frame", "IW-LR-1034", 449m, 549m, false,
            "Daybed vers├ítil para sala o guest room.",
            "Kosmo daybed con base s├│lida y listones. A├▒ade tu colch├│n twin favorito.");

        Add(list, "living-room", "Side Table Pair Holm", "IW-LR-1035", 259m, null, false,
            "Par de mesas auxiliares redondas.",
            "Holm en roble claro, di├ímetro 18\". Perfectas junto al sof├í o en pasillo.");

        Add(list, "living-room", "Ottoman Storage Cube", "IW-LR-1036", 199m, 249m, false,
            "Otomana cubo con tapa abatible.",
            "Almacenamiento oculto para mantas. Tela durable y patas ocultas.");

        Add(list, "living-room", "Wall Gallery Console", "IW-LR-1037", 549m, null, false,
            "Consola estrecha para TV o entrada.",
            "Consola de 60\" con 2 cajones y estante inferior abierto. Acabado nogal.");

        Add(list, "living-room", "Arc Floor Lamp Brass", "IW-LR-1038", 229m, null, false,
            "L├ímpara arco en lat├│n mate.",
            "Arco ajustable sobre sof├í o sill├│n. Pantalla de lino blanco.");

        Add(list, "living-room", "Boucl├® Swivel Chair", "IW-LR-1039", 499m, 599m, true,
            "Sill├│n giratorio en boucl├® ivory.",
            "Base giratoria 360┬░, asiento ancho y respaldo curvo. Pieza statement.");

        Add(list, "living-room", "Leather Look Club Chair", "IW-LR-1040", 579m, null, false,
            "Club chair en vinilo premium.",
            "Estilo club cl├ísico, costuras reforzadas y patas en caoba oscura.");

        Add(list, "bedroom", "Solstice Platform Bed Queen", "IW-BR-2001", 799m, 949m, true,
            "Cama platform queen con cabecera tapizada.",
            "Cama Solstice queen con cabecera acolchada, listones de soporte y no requiere box spring.");

        Add(list, "bedroom", "Cedar Nightstand Pair", "IW-BR-2002", 459m, null, false,
            "Par de mesas de noche con caj├│n suave.",
            "Par de nightstands Cedar en chapa de nogal, caj├│n con cierre suave y nicho abierto inferior.");

        Add(list, "bedroom", "Atlas 6-Drawer Dresser", "IW-BR-2003", 899m, 1049m, true,
            "C├│moda de 6 cajones con tiradores metalizados.",
            "C├│moda Atlas amplia, 6 cajones de deslizamiento suave y acabado carb├│n mate.");

        Add(list, "bedroom", "Cloud Soft Bench", "IW-BR-2004", 279m, null, false,
            "Banco de pie de cama con tapizado boucl├®.",
            "Banco Cloud con espuma densa y tapizado boucl├® ivory. Ideal al pie de la cama o en vest├¡bulo.");

        Add(list, "bedroom", "Pinecrest Queen 4-Piece Set", "IW-BR-2005", 899m, 1099m, true,
            "Set queen: cama, c├│moda, espejo y nightstand.",
            "Set Pinecrest en pino natural. Cabecera panel, c├│moda 6 cajones, espejo y 1 mesa de noche.");

        Add(list, "bedroom", "Sherwood Dresser Wide", "IW-BR-2006", 749m, null, false,
            "C├│moda ancha de 6 cajones.",
            "Sherwood con frente ranurado, tiradores negros y acabado roble medio.");

        Add(list, "bedroom", "Carlton Queen 4-Piece Set", "IW-BR-2007", 949m, null, true,
            "Set queen completo estilo contempor├íneo.",
            "Incluye platform bed, dresser, mirror y nightstand. Acabado gris c├ílido.");

        Add(list, "bedroom", "Sierra Queen Bedroom Set", "IW-BR-2008", 799m, 999m, false,
            "Set 4 piezas en oferta de temporada.",
            "Sierra incluye cama, c├│moda, espejo y nightstand. Acabado aqua-gris suave.");

        Add(list, "bedroom", "Ashlyn Storage Panel Bed", "IW-BR-2009", 899m, null, true,
            "Cama queen con almacenamiento bajo.",
            "Ashlyn panel bed blanca/natural con cajones laterales ocultos. Sin box spring.");

        Add(list, "bedroom", "Crowley Tall Dresser", "IW-BR-2010", 849m, 949m, false,
            "C├│moda alta de 5 cajones.",
            "Crowley en gris moderno, perfil delgado para closets estrechos.");

        Add(list, "bedroom", "Kendall White Queen Set", "IW-BR-2011", 999m, null, true,
            "Set 4 piezas blanco brillante.",
            "Kendall: cama, dresser, mirror y nightstand. Ideal habitaciones luminosas.");

        Add(list, "bedroom", "Watson Gray Oak Set", "IW-BR-2012", 999m, 1149m, false,
            "Set queen en gray oak.",
            "Watson con vetas naturales visibles y herrajes brushed nickel.");

        Add(list, "bedroom", "Lysa Armoire Wardrobe", "IW-BR-2013", 1099m, null, false,
            "Armario con barra y estantes.",
            "Lysa armoire con puertas dobles, barra de colgar y 2 cajones inferiores.");

        Add(list, "bedroom", "Kona Queen 4-Piece Set", "IW-BR-2014", 1099m, 1249m, true,
            "Set queen gris moderno completo.",
            "Kona incluye bed, dresser, mirror y nightstand. Acabado gray wash.");

        Add(list, "bedroom", "Aphra Vanity Desk", "IW-BR-2015", 649m, 749m, false,
            "Vanity con espejo y cajones.",
            "Aphra vanity blanca con toques rosa suave, espejo oval y taburete opcional no incluido.");

        Add(list, "bedroom", "Kai King 5-Piece Set Gray", "IW-BR-2016", 1299m, null, true,
            "Set king 5 piezas en gris.",
            "Kai western king: cama, dresser, mirror y 2 nightstands. Acabado gris contempor├íneo.");

        Add(list, "bedroom", "Oster Black Dresser", "IW-BR-2017", 899m, null, false,
            "C├│moda negra mate de 6 cajones.",
            "Oster con frente liso y tiradores ocultos. Look minimalista.");

        Add(list, "bedroom", "Millie Warm Gray 5-Piece", "IW-BR-2018", 1199m, 1349m, true,
            "Set queen 5 piezas warm gray.",
            "Millie incluye bed, dresser, mirror, chest y nightstand.");

        Add(list, "bedroom", "Marcela White Queen Set", "IW-BR-2019", 1049m, null, false,
            "Set 4 piezas blanco cl├ísico.",
            "Marcela con molduras suaves y acabado lacado f├ícil de limpiar.");

        Add(list, "bedroom", "Lucia Beige & White Set", "IW-BR-2020", 1099m, 1249m, false,
            "Set queen beige y blanco.",
            "Lucia combina cabecera tapizada beige con casegoods blancos.");

        Add(list, "bedroom", "Caraway Black Queen Set", "IW-BR-2021", 1149m, null, true,
            "Set 4 piezas negro dram├ítico.",
            "Caraway para habitaciones modernas. Contraste fuerte con ropa de cama clara.");

        Add(list, "bedroom", "Kai Queen 5-Piece Black", "IW-BR-2022", 1199m, 1399m, false,
            "Set queen 5 piezas negro.",
            "Incluye bed, dresser, mirror, chest y nightstand en negro satinado.");

        Add(list, "bedroom", "Cavelle Black Queen Set", "IW-BR-2023", 1099m, null, false,
            "Set 4 piezas negro contempor├íneo.",
            "Cavelle con l├¡neas rectas y patas c├│nicas. F├ícil de combinar.");

        Add(list, "bedroom", "Willow Queen 6-Piece Set", "IW-BR-2024", 1299m, 1499m, true,
            "Set queen amplio 6 piezas.",
            "Willow incluye bed, dresser, mirror, 2 nightstands y chest. Acabado washed white.");

        Add(list, "bedroom", "Brant Oak Queen 5-Piece", "IW-BR-2025", 1249m, null, true,
            "Set queen 5 piezas barrel oak.",
            "Brant en roble barrel con herrajes bronce. Estilo transitional.");

        Add(list, "bedroom", "Brant Coastal White 5-Piece", "IW-BR-2026", 1249m, 1399m, false,
            "Set queen 5 piezas coastal white.",
            "Misma colecci├│n Brant en blanco costero. Look fresco y luminoso.");

        Add(list, "bedroom", "Upholstered Headboard Only", "IW-BR-2027", 329m, 399m, false,
            "Cabecera queen tapizada standalone.",
            "Se fija a la pared o al frame existente. Espuma densa y tela linen-look.");

        Add(list, "bedroom", "Mirror Floor Leaner", "IW-BR-2028", 249m, null, false,
            "Espejo de piso 66\" con marco roble.",
            "Leaner mirror para vestidor o dormitorio. Cristal biselado.");

        Add(list, "dining", "Harvest Extendable Table", "IW-DN-3001", 1099m, null, true,
            "Mesa extensible para 6ÔÇô8 personas.",
            "Mesa Harvest en roble, extensible con hoja central. Asientos c├│modos para 6 y hasta 8 extendida.");

        Add(list, "dining", "Ridge Dining Chair Set of 4", "IW-DN-3002", 519m, 599m, false,
            "Set de 4 sillas con asiento tapizado.",
            "Sillas Ridge con estructura de madera, asiento en tela performance y respaldo ergon├│mico.");

        Add(list, "dining", "Barley Counter Stool", "IW-DN-3003", 189m, null, false,
            "Taburete de barra con respaldo bajo.",
            "Taburete Barley altura counter, asiento acolchado y reposapi├®s en metal negro mate.");

        Add(list, "dining", "Granary Sideboard", "IW-DN-3004", 849m, 999m, true,
            "Aparador con estantes internos y puertas.",
            "Sideboard Granary con 3 puertas, estantes ajustables y acabado nogal. Ideal para vajilla y servicio.");

        Add(list, "dining", "Arlo Wine Cabinet", "IW-DN-3005", 349m, null, false,
            "Cabinet para vino con puertas corredizas.",
            "Arlo en rustic oak, porta botellas y estante para copas. Compacto para apartamentos.");

        Add(list, "dining", "Hazel Espresso Wine Rack", "IW-DN-3006", 299m, 349m, false,
            "Wine cabinet espresso 35\".",
            "Hazel con racks inclinados y puerta de vidrio templado.");

        Add(list, "dining", "Rowan Side Chair Pair", "IW-DN-3007", 279m, null, false,
            "Par de sillas side upholstered.",
            "Rowan en gris/negro, asiento acolchado y patas c├│nicas. Venta por par.");

        Add(list, "dining", "Burke Swivel Barstool Pair", "IW-DN-3008", 399m, 449m, true,
            "Par de barstools swivel beige.",
            "Burke altura bar, asiento giratorio y base dark brown. Set de 2.");

        Add(list, "dining", "Anchor 5-Piece Counter Set", "IW-DN-3009", 599m, null, false,
            "Set counter: mesa + 4 sillas.",
            "Anchor en acabado natural. Mesa square y 4 counter chairs.");

        Add(list, "dining", "Circle 6-Piece Dining Set", "IW-DN-3010", 699m, 799m, true,
            "Set 6 piezas mesa redonda + sillas.",
            "Circle con mesa redonda y 5 sillas. Ideal conversaci├│n familiar.");

        Add(list, "dining", "Edina Server Oak Black", "IW-DN-3011", 649m, null, false,
            "Server / buffet oak y negro.",
            "Edina con puertas y cajones. Acabado oak & sandy black.");

        Add(list, "dining", "Morocco 7-Piece Dining Set", "IW-DN-3012", 749m, 899m, true,
            "Mesa rectangular + 6 sillas natural.",
            "Morocco en madera natural clara. Capacidad 6 c├│moda.");

        Add(list, "dining", "Nate Maple Server", "IW-DN-3013", 599m, null, false,
            "Server maple con estantes abiertos.",
            "Nate maple, estilo transitional. Perfecto bajo TV o en dining.");

        Add(list, "dining", "Bard 5-Piece Counter Set", "IW-DN-3014", 899m, 999m, false,
            "Set counter wheat/charcoal 5 piezas.",
            "Bard: mesa counter + 4 stools. Contraste wheat y charcoal.");

        Add(list, "dining", "Lazy Susan Counter 7-Piece", "IW-DN-3015", 999m, null, true,
            "Set counter 7 piezas con lazy susan.",
            "Mesa square alta, lazy susan central y 6 stools.");

        Add(list, "dining", "Harbor 7-Piece Dining Set", "IW-DN-3016", 999m, 1149m, true,
            "Set comedor 7 piezas completo.",
            "Mesa rectangular + 6 sillas tapizadas. Acabado roble medio.");

        Add(list, "dining", "Bard 6-Piece Counter Set", "IW-DN-3017", 1099m, null, false,
            "Set counter 6 piezas wheat/charcoal.",
            "Mesa m├ís larga + 5 stools de la colecci├│n Bard.");

        Add(list, "dining", "Arini Extension Dining Set", "IW-DN-3018", 1599m, 1799m, true,
            "Set 5 piezas con hoja de extensi├│n.",
            "Arini sand wash: mesa extensible + 4 sillas. Crece de 6 a 8 puestos.");

        Add(list, "dining", "Burke 7-Piece Formal Set", "IW-DN-3019", 1799m, 1999m, true,
            "Set formal con hoja de 18\".",
            "Mesa Burke + 6 sillas. Hoja incluida. Acabado dark brown elegante.");

        Add(list, "dining", "Escape Dining Bar Trio", "IW-DN-3020", 1899m, null, false,
            "Bar dining + 2 swivel stools.",
            "Escape en glazed oak con trim negro. Ideal loft o kitchen island look.");

        Add(list, "dining", "Simple Side Chair Single", "IW-DN-3021", 89m, null, false,
            "Silla comedor individual econ├│mica.",
            "Estructura madera, asiento s├│lido. Compra varias para sets custom.");

        Add(list, "dining", "Counter Height Chair Single", "IW-DN-3022", 99m, 119m, false,
            "Silla counter individual.",
            "Altura counter est├índar. Metal y madera mixta.");

        Add(list, "dining", "Black Metal Barstool", "IW-DN-3023", 79m, null, false,
            "Barstool negro industrial.",
            "Acero negro mate, asiento redondo. Stackable en almac├®n.");

        Add(list, "dining", "Upholstered Counter Stool", "IW-DN-3024", 129m, 149m, false,
            "Stool counter tapizado gris.",
            "Asiento cushion, reposapi├®s cromado y patas negras.");

        Add(list, "home-office", "Focus Standing Desk", "IW-HO-4001", 649m, null, true,
            "Escritorio sit-stand el├®ctrico 48\".",
            "Escritorio Focus con motor silencioso, memoria de altura y superficie resistente a rayones.");

        Add(list, "home-office", "Aero Mesh Task Chair", "IW-HO-4002", 329m, 399m, true,
            "Silla ergon├│mica con respaldo mesh.",
            "Silla Aero con lumbar ajustable, reposabrazos 3D y ruedas silenciosas para piso duro.");

        Add(list, "home-office", "Linea Bookcase Tall", "IW-HO-4003", 449m, null, false,
            "Librero alto de 5 niveles.",
            "Librero Linea en acabado roble claro, 5 estantes abiertos y anclaje anti-vuelco incluido.");

        Add(list, "home-office", "Studio Compact Desk 42\"", "IW-HO-4004", 349m, 399m, false,
            "Escritorio compacto para home office.",
            "Studio 42\" con caj├│n y bandeja para teclado. Acabado blanco/roble.");

        Add(list, "home-office", "Executive L-Desk Oak", "IW-HO-4005", 899m, null, true,
            "Escritorio en L con retorno.",
            "L-desk Executive en roble, 2 cajones y grommets para cables.");

        Add(list, "home-office", "File Credenza Low", "IW-HO-4006", 499m, 579m, false,
            "Credenza baja para archivos.",
            "Dos cajones letter/legal y superficie para impresora.");

        Add(list, "home-office", "Ergo Kneeling Chair", "IW-HO-4007", 219m, null, false,
            "Silla ergon├│mica de rodillas.",
            "Alternativa activa al task chair. Espuma firme y base estable.");

        Add(list, "home-office", "Wall Shelf Set of 3", "IW-HO-4008", 129m, 159m, false,
            "Set de 3 estantes flotantes.",
            "Roble claro, instalaci├│n oculta. Para libros y decoraci├│n.");

        Add(list, "home-office", "Monitor Riser with Drawer", "IW-HO-4009", 79m, null, false,
            "Elevador de monitor con caj├│n.",
            "Bamb├║, altura ergon├│mica y almacenamiento para accesorios.");

        Add(list, "home-office", "Guest Office Chair Pair", "IW-HO-4010", 399m, 449m, false,
            "Par de sillas de visita.",
            "Sin ruedas, asiento tapizado y estructura metal negro.");

        Add(list, "outdoor", "Terrace Teak Lounge Set", "IW-OD-5001", 1299m, 1499m, true,
            "Set exterior sof├í + 2 sillones + mesa.",
            "Set Terrace en rat├ín sint├®tico con cojines weatherproof y mesa de centro en teak.");

        Add(list, "outdoor", "Ember Fire Pit Table", "IW-OD-5002", 799m, null, false,
            "Mesa fire pit a gas propano.",
            "Fire pit Ember con tapa de mesa conversora, quemador de acero inoxidable y control de llama.");

        Add(list, "outdoor", "Coastal Adirondack Pair", "IW-OD-5003", 349m, 399m, false,
            "Par de Adirondack en poly lumber.",
            "Par de sillas Adirondack Coastal, poly lumber resistente a UV, no requieren pintura.");

        Add(list, "outdoor", "Patio Dining 7-Piece", "IW-OD-5004", 1099m, 1299m, true,
            "Mesa outdoor + 6 sillas.",
            "Aluminio powder-coat y textilene. Parasol no incluido.");

        Add(list, "outdoor", "Chaise Lounge Pair", "IW-OD-5005", 599m, null, false,
            "Par de camastros ajustables.",
            "5 posiciones, ruedas traseras y cojines removibles.");

        Add(list, "outdoor", "Bistro Set for Two", "IW-OD-5006", 279m, 329m, false,
            "Set bistr├│ mesa + 2 sillas.",
            "Hierro forjado look, compacto para balc├│n.");

        Add(list, "outdoor", "Outdoor Sectional Modular", "IW-OD-5007", 1599m, 1799m, true,
            "Seccional outdoor modular.",
            "Piezas con cojines solution-dyed. Resiste sol y lluvia ligera.");

        Add(list, "outdoor", "Planter Box Pair Tall", "IW-OD-5008", 189m, null, false,
            "Par de jardineras altas.",
            "Madera tratada, drenaje inferior. 24\" alto.");

        Add(list, "mattresses", "Summit Hybrid Mattress Queen", "IW-MT-6001", 899m, 1099m, true,
            "Colch├│n h├¡brido queen con resortes pocket.",
            "Colch├│n Summit hybrid: foam de alivio de presi├│n + pocket coils. Funda lavable y prueba en casa 100 noches.");

        Add(list, "mattresses", "Drift Memory Foam Twin", "IW-MT-6002", 449m, null, false,
            "Colch├│n memory foam twin.",
            "Drift memory foam twin con capas de gel cooling y base de soporte. Empaque compacto.");

        Add(list, "mattresses", "Summit Hybrid King", "IW-MT-6003", 1199m, 1399m, true,
            "Colch├│n h├¡brido king.",
            "Misma construcci├│n Summit en king. Edge support reforzado.");

        Add(list, "mattresses", "Cloud Soft Foam Queen", "IW-MT-6004", 699m, 849m, false,
            "Memory foam queen plush.",
            "Sensaci├│n cloud, gel cooling y funda zip-off.");

        Add(list, "mattresses", "Firm Support Twin XL", "IW-MT-6005", 399m, null, false,
            "Colch├│n firme twin XL.",
            "Ideal dormitorios juveniles o guest. N├║cleo de soporte denso.");

        Add(list, "mattresses", "Pillow Top Hybrid Full", "IW-MT-6006", 749m, 899m, false,
            "H├¡brido full con pillow top.",
            "Capa superior plush + coils. Buen balance firmeza/confort.");

        Add(list, "mattresses", "Adjustable Base Queen", "IW-MT-6007", 899m, null, true,
            "Base ajustable el├®ctrica queen.",
            "Cabeza y pies motorizados, control remoto y USB. Compatible con h├¡bridos.");

        Add(list, "mattresses", "Mattress Protector Queen", "IW-MT-6008", 49m, 69m, false,
            "Protector impermeable queen.",
            "Bamb├║, silencioso y con el├ísticos de esquina.");

        Add(list, "sale", "Clearance Boucl├® Loveseat", "IW-SL-7001", 549m, 799m, true,
            "Loveseat boucl├® ÔÇö liquidaci├│n limitada.",
            "Loveseat en boucl├® arena, stock limitado de liquidaci├│n. Garant├¡a de estructura 1 a├▒o.");

        Add(list, "sale", "Warehouse Oak Desk", "IW-SL-7002", 299m, 449m, false,
            "Escritorio de exhibici├│n con descuento.",
            "Escritorio de exhibici├│n en roble, ligeras marcas de showroom. Funcional y con garant├¡a limitada.");

        Add(list, "sale", "Floor Model Recliner", "IW-SL-7003", 399m, 699m, true,
            "Reclinable de piso ÔÇö ├║nico.",
            "Modelo de exhibici├│n en excelente estado. Color charcoal. Sin caja original.");

        Add(list, "sale", "Open Box Nightstand", "IW-SL-7004", 129m, 229m, false,
            "Nightstand open-box.",
            "Empaque abierto, producto nuevo. Acabado gray oak.");

        Add(list, "sale", "Last Chance Dining Chairs ├ù2", "IW-SL-7005", 149m, 279m, false,
            "Par de sillas ├║ltima unidad.",
            "Set de 2 sillas remanentes de colecci├│n anterior. Tela taupe.");

        Add(list, "sale", "Scratch & Dent Media Console", "IW-SL-7006", 349m, 699m, true,
            "Consola con leve marca de showroom.",
            "Marca superficial en un lateral. Funciona perfecto. 65\" width.");

        Add(list, "sale", "Demo Mattress Queen", "IW-SL-7007", 399m, 899m, false,
            "Colch├│n demo queen higienizado.",
            "Usado solo en showroom, funda nueva incluida. H├¡brido medium.");

        Add(list, "sale", "Patio Set Clearance", "IW-SL-7008", 499m, 899m, true,
            "Set patio 4 piezas liquidaci├│n.",
            "Sof├í + 2 chairs + mesa. Cojines nuevos. Estructura year-end clearance.");


        for (var i = 0; i < list.Count; i++)
        {
            list[i] = list[i] with { Photos = FurniturePhotoLibrary.PairFor(i) };
        }

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
        string desc)
    {
        list.Add(new SeedItem(cat, title, sku, price, compare, shortDesc, desc, featured, []));
    }
}