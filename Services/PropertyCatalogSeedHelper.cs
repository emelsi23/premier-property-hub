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
            .ToArray();

        foreach (var definition in catalog)
        {
            if (await context.Propiedades.AnyAsync(p => p.Slug == definition.Slug))
            {
                continue;
            }

            var photos = definition.CustomPhotos ?? CatalogDefaults.GetPhotos(definition.PhotoVariant);

            var propiedad = new Propiedad
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
                ZelleDisplayName = CatalogDefaults.ZelleDisplayName,
                ZelleContact = CatalogDefaults.ZelleContact,
                DepositAmount = CatalogDefaults.DepositAmount,
                StampsAmount = StampSealSettings.DefaultStampsAmount,
                SealsAmount = StampSealSettings.DefaultSealsAmount,
                Disponible = true,
                FechaCreacion = DateTime.UtcNow,
                Fotos = photos
                    .Select((url, index) => new FotoPropiedad { Url = url, Orden = index })
                    .ToList()
            };

            context.Propiedades.Add(propiedad);
            await context.SaveChangesAsync();

            context.LeaseContracts.Add(LeaseContractDefaults.CreateForProperty(propiedad.Id));
            context.StampSealContracts.Add(StampSealContractDefaults.CreateForProperty(propiedad.Id));
            await context.SaveChangesAsync();

            Console.WriteLine($"Catalog property seeded: {definition.Titulo} ({definition.Slug})");
        }
    }
}
