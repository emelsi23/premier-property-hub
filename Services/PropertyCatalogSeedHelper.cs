using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services.Catalog;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class PropertyCatalogSeedHelper
{
    private const int BatchSize = 100;
    private const int PhotoRefreshBatchSize = 100;

    public static async Task EnsureCatalogPropertiesAsync(AppDbContext context)
    {
        var catalogBySlug = CatalogIndex.BySlug;

        var existingSlugs = await context.Propiedades
            .AsNoTracking()
            .Select(p => p.Slug)
            .ToListAsync();

        var existingSet = new HashSet<string>(existingSlugs, StringComparer.OrdinalIgnoreCase);
        var pendingCount = 0;

        foreach (var definition in CatalogIndex.All)
        {
            if (!existingSet.Contains(definition.Slug))
            {
                pendingCount++;
            }
        }

        if (pendingCount > 0)
        {
            Console.WriteLine($"Seeding {pendingCount} catalog properties…");
            var seeded = 0;
            var batch = new List<CatalogProperty>(BatchSize);

            foreach (var definition in CatalogIndex.All)
            {
                if (existingSet.Contains(definition.Slug))
                {
                    continue;
                }

                batch.Add(definition);
                if (batch.Count < BatchSize)
                {
                    continue;
                }

                seeded += await SaveBatchAsync(context, batch);
                batch.Clear();
                Console.WriteLine($"Catalog batch saved ({seeded}/{pendingCount})");
            }

            if (batch.Count > 0)
            {
                seeded += await SaveBatchAsync(context, batch);
                Console.WriteLine($"Catalog batch saved ({seeded}/{pendingCount})");
            }

            Console.WriteLine($"Catalog seed complete: {seeded} properties added.");
        }

        await SyncCatalogPricesAsync(context, catalogBySlug);
        await RefreshCatalogPhotosAsync(context, catalogBySlug);
    }

    private static async Task<int> SaveBatchAsync(AppDbContext context, IReadOnlyList<CatalogProperty> batch)
    {
        var propiedades = batch.Select(BuildProperty).ToList();
        context.Propiedades.AddRange(propiedades);
        await context.SaveChangesAsync();

        context.LeaseContracts.AddRange(propiedades.Select(p => LeaseContractDefaults.CreateForProperty(p.Id)));
        context.StampSealContracts.AddRange(propiedades.Select(p => StampSealContractDefaults.CreateForProperty(p.Id)));
        await context.SaveChangesAsync();

        return propiedades.Count;
    }

    private static async Task SyncCatalogPricesAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, CatalogProperty> catalogBySlug)
    {
        var updated = 0;

        foreach (var slugBatch in catalogBySlug.Keys.Chunk(BatchSize))
        {
            var properties = await context.Propiedades
                .Where(p => slugBatch.Contains(p.Slug))
                .ToListAsync();

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
        var targetCount = CatalogPhotoLibrary.PhotosPerListing;
        var updated = 0;

        while (true)
        {
            var properties = await context.Propiedades
                .Include(p => p.Fotos)
                .Where(p => p.Fotos.Count < targetCount)
                .OrderBy(p => p.Id)
                .Take(PhotoRefreshBatchSize)
                .ToListAsync();

            if (properties.Count == 0)
            {
                break;
            }

            foreach (var property in properties)
            {
                var targetPhotos = catalogBySlug.TryGetValue(property.Slug, out var definition)
                    ? ResolvePhotos(definition)
                    : CatalogPhotoLibrary.GetPhotosForSlug(property.Slug);

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

            await context.SaveChangesAsync();
        }

        if (updated > 0)
        {
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
