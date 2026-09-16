using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class FurnitureSeedHelper
{
    public static async Task EnsureCatalogAsync(AppDbContext context)
    {
        await EnsureCategoriesAsync(context);

        if (await context.FurnitureProducts.AnyAsync())
        {
            return;
        }

        var categories = await context.FurnitureCategories.ToDictionaryAsync(c => c.Slug, c => c.Id);
        var now = DateTime.UtcNow;
        var products = BuildSampleProducts(categories, now);

        context.FurnitureProducts.AddRange(products);
        await context.SaveChangesAsync();
        Console.WriteLine($"Furniture catalog seeded: {products.Count} products.");
    }

    private static async Task EnsureCategoriesAsync(AppDbContext context)
    {
        var definitions = new (string Name, string Slug, int Sort)[]
        {
            ("Living Room", "living-room", 1),
            ("Bedroom", "bedroom", 2),
            ("Dining", "dining", 3),
            ("Home Office", "home-office", 4),
            ("Outdoor", "outdoor", 5),
            ("Mattresses", "mattresses", 6),
            ("Sale", "sale", 7)
        };

        var existing = await context.FurnitureCategories.Select(c => c.Slug).ToListAsync();
        foreach (var (name, slug, sort) in definitions)
        {
            if (existing.Contains(slug, StringComparer.OrdinalIgnoreCase))
            {
                continue;
            }

            context.FurnitureCategories.Add(new FurnitureCategory
            {
                Name = name,
                Slug = slug,
                SortOrder = sort,
                IsActive = true
            });
        }

        await context.SaveChangesAsync();
    }

    private static List<FurnitureProduct> BuildSampleProducts(Dictionary<string, int> categories, DateTime now)
    {
        // Royalty-free Unsplash furniture photos — original Ironwood sample catalog.
        var samples = new List<(string Cat, string Title, string Sku, decimal Price, decimal? Compare, string Short, string Desc, bool Featured, string[] Photos)>
        {
            ("living-room", "Harbor Linen Sofa", "IW-LR-1001", 899m, 1099m,
                "Sofa de 3 plazas en lino natural con patas de madera.",
                "Sofá Harbor con asientos profundos, cojines removibles y estructura reforzada. Ideal para salas contemporáneas. Tapizado en lino beige lavable.",
                true,
                ["https://images.unsplash.com/photo-1555041469-a586c61ea9bc?w=1200&q=80",
                 "https://images.unsplash.com/photo-1493663284031-b7e3aefcae8e?w=1200&q=80"]),

            ("living-room", "Cascade Sectional Chaise", "IW-LR-1002", 1499m, null,
                "Seccional modular con chaise reversible.",
                "Seccional Cascade con chaise reversible, tela performance y soporte de espuma de alta densidad. Perfecto para espacios abiertos.",
                true,
                ["https://images.unsplash.com/photo-1586023492125-27b2c045efd7?w=1200&q=80"]),

            ("living-room", "Oakvale Coffee Table", "IW-LR-1003", 349m, 429m,
                "Mesa de centro en roble macizo con acabado mate.",
                "Mesa Oakvale en roble natural, borde vivo suave y patas cónicas. Combina con salas modernas o rústicas.",
                false,
                ["https://images.unsplash.com/photo-1532372320572-cda25681a5d5?w=1200&q=80"]),

            ("living-room", "Nordic Accent Chair", "IW-LR-1004", 429m, null,
                "Sillón acento con respaldo alto y tela bouclé.",
                "Sillón Nordic con diseño escandinavo, bouclé crema y base en madera teñida nogal.",
                true,
                ["https://images.unsplash.com/photo-1567538096630-e0c55bd6374c?w=1200&q=80"]),

            ("living-room", "Ember Media Console", "IW-LR-1005", 699m, null,
                "Consola TV con puertas ranuradas y cableado oculto.",
                "Consola Ember de 70\" con puertas ranuradas, estantes ajustables y ventilación posterior para equipos.",
                false,
                ["https://images.unsplash.com/photo-1595428774223-ef52624120d2?w=1200&q=80"]),

            ("living-room", "Lumen Floor Lamp", "IW-LR-1006", 189m, 229m,
                "Lámpara de pie con pantalla de lino y base de metal.",
                "Lámpara Lumen con base en bronce envejecido y pantalla cilíndrica de lino. Luz cálida para lectura.",
                false,
                ["https://images.unsplash.com/photo-1507473885765-e6ed057f782c?w=1200&q=80"]),

            ("bedroom", "Solstice Platform Bed Queen", "IW-BR-2001", 799m, 949m,
                "Cama platform queen con cabecera tapizada.",
                "Cama Solstice queen con cabecera acolchada, listones de soporte y no requiere box spring.",
                true,
                ["https://images.unsplash.com/photo-1505693416388-ac5ce068fe85?w=1200&q=80",
                 "https://images.unsplash.com/photo-1616594039964-ae9021a400a0?w=1200&q=80"]),

            ("bedroom", "Cedar Nightstand Pair", "IW-BR-2002", 459m, null,
                "Par de mesas de noche con cajón suave.",
                "Par de nightstands Cedar en chapa de nogal, cajón con cierre suave y nicho abierto inferior.",
                false,
                ["https://images.unsplash.com/photo-1555041469-a586c61ea9bc?w=800&q=80"]),

            ("bedroom", "Atlas 6-Drawer Dresser", "IW-BR-2003", 899m, 1049m,
                "Cómoda de 6 cajones con tiradores metalizados.",
                "Cómoda Atlas amplia, 6 cajones de deslizamiento suave y acabado carbón mate.",
                true,
                ["https://images.unsplash.com/photo-1595428774223-ef52624120d2?w=1000&q=80"]),

            ("bedroom", "Cloud Soft Bench", "IW-BR-2004", 279m, null,
                "Banco de pie de cama con tapizado bouclé.",
                "Banco Cloud con espuma densa y tapizado bouclé ivory. Ideal al pie de la cama o en vestíbulo.",
                false,
                ["https://images.unsplash.com/photo-1555041469-a586c61ea9bc?w=900&q=80"]),

            ("dining", "Harvest Extendable Table", "IW-DN-3001", 1099m, null,
                "Mesa extensible para 6–8 personas.",
                "Mesa Harvest en roble, extensible con hoja central. Asientos cómodos para 6 y hasta 8 extendida.",
                true,
                ["https://images.unsplash.com/photo-1617806118233-18e1de247200?w=1200&q=80"]),

            ("dining", "Ridge Dining Chair Set of 4", "IW-DN-3002", 519m, 599m,
                "Set de 4 sillas con asiento tapizado.",
                "Sillas Ridge con estructura de madera, asiento en tela performance y respaldo ergonómico.",
                false,
                ["https://images.unsplash.com/photo-1503602642458-232111445657?w=1200&q=80"]),

            ("dining", "Barley Counter Stool", "IW-DN-3003", 189m, null,
                "Taburete de barra con respaldo bajo.",
                "Taburete Barley altura counter, asiento acolchado y reposapiés en metal negro mate.",
                false,
                ["https://images.unsplash.com/photo-1506439773649-6e0eb8cfb237?w=1200&q=80"]),

            ("dining", "Granary Sideboard", "IW-DN-3004", 849m, 999m,
                "Aparador con estantes internos y puertas.",
                "Sideboard Granary con 3 puertas, estantes ajustables y acabado nogal. Ideal para vajilla y servicio.",
                true,
                ["https://images.unsplash.com/photo-1595428774223-ef52624120d2?w=1100&q=80"]),

            ("home-office", "Focus Standing Desk", "IW-HO-4001", 649m, null,
                "Escritorio sit-stand eléctrico 48\".",
                "Escritorio Focus con motor silencioso, memoria de altura y superficie resistente a rayones.",
                true,
                ["https://images.unsplash.com/photo-1518455027359-f3f8164ba9c7?w=1200&q=80"]),

            ("home-office", "Aero Mesh Task Chair", "IW-HO-4002", 329m, 399m,
                "Silla ergonómica con respaldo mesh.",
                "Silla Aero con lumbar ajustable, reposabrazos 3D y ruedas silenciosas para piso duro.",
                true,
                ["https://images.unsplash.com/photo-1580480055273-228ff5388ef8?w=1200&q=80"]),

            ("home-office", "Linea Bookcase Tall", "IW-HO-4003", 449m, null,
                "Librero alto de 5 niveles.",
                "Librero Linea en acabado roble claro, 5 estantes abiertos y anclaje anti-vuelco incluido.",
                false,
                ["https://images.unsplash.com/photo-1594026112284-02bb6f3352bb?w=1200&q=80"]),

            ("outdoor", "Terrace Teak Lounge Set", "IW-OD-5001", 1299m, 1499m,
                "Set exterior sofá + 2 sillones + mesa.",
                "Set Terrace en ratán sintético con cojines weatherproof y mesa de centro en teak.",
                true,
                ["https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?w=1200&q=80"]),

            ("outdoor", "Ember Fire Pit Table", "IW-OD-5002", 799m, null,
                "Mesa fire pit a gas propano.",
                "Fire pit Ember con tapa de mesa conversora, quemador de acero inoxidable y control de llama.",
                false,
                ["https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=1200&q=80"]),

            ("outdoor", "Coastal Adirondack Pair", "IW-OD-5003", 349m, 399m,
                "Par de Adirondack en poly lumber.",
                "Par de sillas Adirondack Coastal, poly lumber resistente a UV, no requieren pintura.",
                false,
                ["https://images.unsplash.com/photo-1600566753190-17f0baa2a6c3?w=1200&q=80"]),

            ("mattresses", "Summit Hybrid Mattress Queen", "IW-MT-6001", 899m, 1099m,
                "Colchón híbrido queen con resortes pocket.",
                "Colchón Summit hybrid: foam de alivio de presión + pocket coils. Funda lavable y prueba en casa 100 noches.",
                true,
                ["https://images.unsplash.com/photo-1631049307264-da0ec9d70304?w=1200&q=80"]),

            ("mattresses", "Drift Memory Foam Twin", "IW-MT-6002", 449m, null,
                "Colchón memory foam twin.",
                "Drift memory foam twin con capas de gel cooling y base de soporte. Empaque compacto.",
                false,
                ["https://images.unsplash.com/photo-1505693416388-ac5ce068fe85?w=1000&q=80"]),

            ("sale", "Clearance Bouclé Loveseat", "IW-SL-7001", 549m, 799m,
                "Loveseat bouclé — liquidación limitada.",
                "Loveseat en bouclé arena, stock limitado de liquidación. Garantía de estructura 1 año.",
                true,
                ["https://images.unsplash.com/photo-1555041469-a586c61ea9bc?w=1100&q=80"]),

            ("sale", "Warehouse Oak Desk", "IW-SL-7002", 299m, 449m,
                "Escritorio de exhibición con descuento.",
                "Escritorio de exhibición en roble, ligeras marcas de showroom. Funcional y con garantía limitada.",
                false,
                ["https://images.unsplash.com/photo-1518455027359-f3f8164ba9c7?w=1000&q=80"])
        };

        var list = new List<FurnitureProduct>();
        foreach (var s in samples)
        {
            if (!categories.TryGetValue(s.Cat, out var categoryId))
            {
                continue;
            }

            var slug = SlugHelper.FromText(s.Title);
            var product = new FurnitureProduct
            {
                Title = s.Title,
                Slug = slug,
                Sku = s.Sku,
                ShortDescription = s.Short,
                Description = s.Desc,
                Price = s.Price,
                CompareAtPrice = s.Compare,
                CategoryId = categoryId,
                IsActive = true,
                IsFeatured = s.Featured,
                CreatedAt = now,
                UpdatedAt = now,
                Photos = s.Photos.Select((url, i) => new FurniturePhoto
                {
                    Url = url,
                    SortOrder = i,
                    IsPrimary = i == 0
                }).ToList()
            };
            list.Add(product);
        }

        return list;
    }
}
