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

        await EnsureAllPropertiesHavePhotosAsync(context, catalogBySlug);
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

    private static async Task EnsureAllPropertiesHavePhotosAsync(
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

                if (targetPhotos.Length == 0)
                {
                    targetPhotos = CatalogPhotoLibrary.GetPhotosForSlug(property.Slug);
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

            await context.SaveChangesAsync();
        }

        if (updated > 0)
        {
            Console.WriteLine($"Catalog photos ensured for {updated} properties.");
        }
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
        var photos = definition.CustomPhotos is { Length: > 0 } custom
            ? CatalogPhotoLibrary.MergeWithListingPhotos(custom, definition.Slug)
            : CatalogPhotoLibrary.GetPhotosForSlug(definition.Slug);

        return photos.Length > 0
            ? photos
            : CatalogPhotoLibrary.GetPhotosForListing(definition.PhotoVariant);
    }
}
