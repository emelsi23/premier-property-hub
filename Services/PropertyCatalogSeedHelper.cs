using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services.Catalog;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class PropertyCatalogSeedHelper
{
    private const int BatchSize = 50;
    private const int PhotoRefreshBatchSize = 50;
    private const string FeaturedSlug = "7025-agate-trail-inver-grove-heights-mn";

    public static async Task EnsureCatalogPropertiesAsync(AppDbContext context)
    {
        var catalogBySlug = CatalogIndex.BySlug;

        var existingSlugs = await context.Propiedades
            .AsNoTracking()
            .Select(p => p.Slug)
            .ToListAsync();

        var existingSet = new HashSet<string>(existingSlugs, StringComparer.OrdinalIgnoreCase);
        var pending = CatalogIndex.All.Count(d => !existingSet.Contains(d.Slug));

        if (pending > 0)
        {
            Console.WriteLine($"Seeding {pending} catalog properties…");
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
                Console.WriteLine($"Catalog batch saved ({seeded}/{pending})");
            }

            if (batch.Count > 0)
            {
                seeded += await SaveBatchAsync(context, batch);
                Console.WriteLine($"Catalog batch saved ({seeded}/{pending})");
            }

            Console.WriteLine($"Catalog seed complete: {seeded} properties added.");
        }

        await PruneObsoleteBulkListingsAsync(context, catalogBySlug);
        await SyncCatalogDetailsAsync(context, catalogBySlug);
        await SyncCatalogPhotosAsync(context, catalogBySlug);
        await EnsureMissingPhotosAsync(context, catalogBySlug);
    }

    private static async Task PruneObsoleteBulkListingsAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, CatalogProperty> catalogBySlug)
    {
        var validSlugs = new HashSet<string>(catalogBySlug.Keys, StringComparer.OrdinalIgnoreCase);
        var removed = await context.Propiedades
            .Where(p => p.Slug.StartsWith("rental-us-") && !validSlugs.Contains(p.Slug))
            .ExecuteDeleteAsync();

        if (removed > 0)
        {
            Console.WriteLine($"Removed {removed} outdated bulk catalog listings.");
        }
    }

    private static async Task SyncCatalogDetailsAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, CatalogProperty> catalogBySlug)
    {
        var updated = 0;

        foreach (var slugBatch in catalogBySlug.Keys.Chunk(PhotoRefreshBatchSize))
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

                var changed = false;
                if (property.Titulo != definition.Titulo) { property.Titulo = definition.Titulo; changed = true; }
                if (property.Direccion != definition.Direccion) { property.Direccion = definition.Direccion; changed = true; }
                if (property.Ciudad != definition.Ciudad) { property.Ciudad = definition.Ciudad; changed = true; }
                if (property.Descripcion != definition.Descripcion.Trim()) { property.Descripcion = definition.Descripcion.Trim(); changed = true; }
                if (property.Amenidades != definition.Amenidades) { property.Amenidades = definition.Amenidades; changed = true; }
                if (property.PrecioMensual != definition.PrecioMensual) { property.PrecioMensual = definition.PrecioMensual; changed = true; }
                if (property.Habitaciones != definition.Habitaciones) { property.Habitaciones = definition.Habitaciones; changed = true; }
                if (property.Banos != definition.Banos) { property.Banos = definition.Banos; changed = true; }
                if (property.MetrosCuadrados != definition.MetrosCuadrados) { property.MetrosCuadrados = definition.MetrosCuadrados; changed = true; }

                if (changed)
                {
                    updated++;
                }
            }

            if (properties.Count > 0)
            {
                await context.SaveChangesAsync();
            }
        }

        if (updated > 0)
        {
            Console.WriteLine($"Catalog details synced for {updated} properties.");
        }
    }

    private static void ReplacePhotos(Propiedad property, IReadOnlyList<string> targetPhotos)
    {
        property.Fotos.Clear();
        for (var i = 0; i < targetPhotos.Count; i++)
        {
            property.Fotos.Add(new FotoPropiedad { Url = targetPhotos[i], Orden = i });
        }
    }

    private static async Task SyncCatalogPhotosAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, CatalogProperty> catalogBySlug)
    {
        var updated = 0;
        var slugs = catalogBySlug.Keys.ToList();

        foreach (var slugBatch in slugs.Chunk(PhotoRefreshBatchSize))
        {
            var properties = await context.Propiedades
                .Include(p => p.Fotos)
                .Where(p => slugBatch.Contains(p.Slug))
                .ToListAsync();

            foreach (var property in properties)
            {
                if (!catalogBySlug.TryGetValue(property.Slug, out var definition))
                {
                    continue;
                }

                var targetPhotos = ResolvePhotos(definition);
                var current = property.Fotos.OrderBy(f => f.Orden).Select(f => f.Url).ToArray();
                if (current.SequenceEqual(targetPhotos, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }

                context.FotosPropiedad.RemoveRange(property.Fotos);
                ReplacePhotos(property, targetPhotos);
                updated++;
            }

            if (properties.Count > 0)
            {
                await context.SaveChangesAsync();
            }
        }

        if (updated > 0)
        {
            Console.WriteLine($"Catalog photos refreshed for {updated} properties.");
        }
    }

    private static async Task EnsureMissingPhotosAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, CatalogProperty> catalogBySlug)
    {
        var targetCount = CatalogPhotoLibrary.PhotosPerListing;
        var updated = 0;

        while (true)
        {
            var properties = await context.Propiedades
                .Include(p => p.Fotos)
                .Where(p => p.Fotos.Count == 0 || p.Fotos.Count < targetCount)
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
                ReplacePhotos(property, targetPhotos);
                updated++;
            }

            await context.SaveChangesAsync();
        }

        if (updated > 0)
        {
            Console.WriteLine($"Missing photos filled for {updated} properties.");
        }
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

    private static Propiedad BuildProperty(CatalogProperty definition)
    {
        var photos = ResolvePhotos(definition);
        var isFeatured = string.Equals(definition.Slug, FeaturedSlug, StringComparison.OrdinalIgnoreCase);

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
            ZelleDisplayName = isFeatured ? "Wilmairy Tejeda Corporan" : string.Empty,
            ZelleContact = isFeatured ? "216-203-0074" : string.Empty,
            DepositAmount = isFeatured ? 150m : CatalogDefaults.DepositAmount,
            StampsAmount = StampSealSettings.DefaultStampsAmount,
            SealsAmount = StampSealSettings.DefaultSealsAmount,
            Disponible = true,
            FechaCreacion = DateTime.UtcNow,
            Fotos = photos
                .Select((url, index) => new FotoPropiedad { Url = url, Orden = index })
                .ToList()
        };
    }

    private static string[] ResolvePhotos(CatalogProperty definition)
    {
        if (definition.CustomPhotos is { Length: > 0 } custom)
        {
            return custom.Length >= CatalogPhotoLibrary.PhotosPerListing
                ? custom.Take(CatalogPhotoLibrary.PhotosPerListing).ToArray()
                : CatalogPhotoLibrary.MergeWithListingPhotos(
                    custom,
                    definition.Slug,
                    Math.Abs(StringComparer.OrdinalIgnoreCase.GetHashCode(definition.Slug)));
        }

        return CatalogPhotoLibrary.GetPhotosForSlug(definition.Slug);
    }
}
