using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services.Catalog;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class PropertyCatalogSeedHelper
{
    public static async Task EnsureCatalogPropertiesAsync(AppDbContext context)
    {
        var catalog = CaliforniaCatalog.Properties
            .Concat(MinnesotaCatalog.Properties)
            .Concat(BulkCatalogGenerator.GenerateAll())
            .GroupBy(p => p.Slug, StringComparer.OrdinalIgnoreCase)
            .Select(g => g.First())
            .ToArray();

        var catalogBySlug = catalog.ToDictionary(p => p.Slug, StringComparer.OrdinalIgnoreCase);

        var existingSlugs = await context.Propiedades
            .AsNoTracking()
            .Select(p => p.Slug)
            .ToListAsync();

        var existingSet = new HashSet<string>(existingSlugs, StringComparer.OrdinalIgnoreCase);
        var pending = catalog.Where(d => !existingSet.Contains(d.Slug)).ToList();

        if (pending.Count > 0)
        {
            Console.WriteLine($"Seeding {pending.Count} catalog properties…");

            const int batchSize = 50;
            var seeded = 0;

            foreach (var batch in pending.Chunk(batchSize))
            {
                var propiedades = new List<Propiedad>();

                foreach (var definition in batch)
                {
                    propiedades.Add(BuildProperty(definition));
                }

                context.Propiedades.AddRange(propiedades);
                await context.SaveChangesAsync();

                var leaseContracts = propiedades.Select(p => LeaseContractDefaults.CreateForProperty(p.Id)).ToList();
                var stampContracts = propiedades.Select(p => StampSealContractDefaults.CreateForProperty(p.Id)).ToList();
                context.LeaseContracts.AddRange(leaseContracts);
                context.StampSealContracts.AddRange(stampContracts);
                await context.SaveChangesAsync();

                seeded += propiedades.Count;
                Console.WriteLine($"Catalog batch saved ({seeded}/{pending.Count})");
            }

            Console.WriteLine($"Catalog seed complete: {seeded} properties added.");
        }

        await SyncCatalogPricesAsync(context, catalogBySlug);
        await RefreshCatalogPhotosAsync(context, catalogBySlug);
    }

    private static async Task SyncCatalogPricesAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, CatalogProperty> catalogBySlug)
    {
        var slugs = catalogBySlug.Keys.ToList();
        var properties = await context.Propiedades
            .Where(p => slugs.Contains(p.Slug))
            .ToListAsync();

        var updated = 0;

        foreach (var property in properties)
        {
            if (!catalogBySlug.TryGetValue(property.Slug, out var definition))
            {
                continue;
            }

            if (property.PrecioMensual == definition.PrecioMensual)
            {
                continue;
            }

            property.PrecioMensual = definition.PrecioMensual;
            updated++;
        }

        if (updated > 0)
        {
            await context.SaveChangesAsync();
            Console.WriteLine($"Catalog prices synced for {updated} properties.");
        }
    }

    private static async Task RefreshCatalogPhotosAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, CatalogProperty> catalogBySlug)
    {
        var slugs = catalogBySlug.Keys.ToList();
        var properties = await context.Propiedades
            .Include(p => p.Fotos)
            .Where(p => slugs.Contains(p.Slug))
            .ToListAsync();

        var updated = 0;

        foreach (var property in properties)
        {
            if (!catalogBySlug.TryGetValue(property.Slug, out var definition))
            {
                continue;
            }

            var targetPhotos = ResolvePhotos(definition);
            if (property.Fotos.Count >= targetPhotos.Length)
            {
                continue;
            }

            context.FotosPropiedad.RemoveRange(property.Fotos);
            property.Fotos.Clear();

            for (var i = 0; i < targetPhotos.Length; i++)
            {
                property.Fotos.Add(new FotoPropiedad
                {
                    Url = targetPhotos[i],
                    Orden = i
                });
            }

            updated++;
        }

        if (updated > 0)
        {
            await context.SaveChangesAsync();
            Console.WriteLine($"Catalog photos refreshed for {updated} properties.");
        }
    }

    private static Propiedad BuildProperty(CatalogProperty definition)
    {
        var photos = ResolvePhotos(definition);
        return new Propiedad
        {
            Titulo = definition.Titulo,
            Slug = definition.Slug,
            Descripcion = definition.Descripcion.Trim(),
            Direccion = definition.Direccion,
            Ciudad = definition.Ciudad,
            PrecioMensual = definition.PrecioMensual,
            Habitaciones = definition.Habitaciones,
            Banos = definition.Banos,
            MetrosCuadrados = definition.MetrosCuadrados,
            Amenidades = definition.Amenidades,
            ZelleDisplayName = string.Empty,
            ZelleContact = string.Empty,
            DepositAmount = CatalogDefaults.DepositAmount,
            StampsAmount = StampSealSettings.DefaultStampsAmount,
            SealsAmount = StampSealSettings.DefaultSealsAmount,
            Disponible = true,
            FechaCreacion = DateTime.UtcNow,
            Fotos = photos
                .Select((url, index) => new FotoPropiedad { Url = url, Orden = index })
                .ToList()
        };
    }

    private static string[] ResolvePhotos(CatalogProperty definition) =>
        definition.CustomPhotos
        ?? CatalogPhotoLibrary.GetPhotosForSlug(definition.Slug);
}
