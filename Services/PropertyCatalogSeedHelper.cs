using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class PropertyCatalogSeedHelper
{
    public static async Task EnsureCatalogPropertiesAsync(AppDbContext context)
    {
        foreach (var definition in Catalog)
        {
            if (await context.Propiedades.AnyAsync(p => p.Slug == definition.Slug))
            {
                continue;
            }

            var propiedad = new Propiedad
            {
                Titulo = definition.Titulo,
                Slug = definition.Slug,
                Descripcion = definition.Descripcion,
                Direccion = definition.Direccion,
                Ciudad = definition.Ciudad,
                PrecioMensual = definition.PrecioMensual,
                Habitaciones = definition.Habitaciones,
                Banos = definition.Banos,
                MetrosCuadrados = definition.MetrosCuadrados,
                Amenidades = definition.Amenidades,
                ZelleDisplayName = definition.ZelleDisplayName,
                ZelleContact = definition.ZelleContact,
                DepositAmount = definition.DepositAmount,
                StampsAmount = StampSealSettings.DefaultStampsAmount,
                SealsAmount = StampSealSettings.DefaultSealsAmount,
                Disponible = true,
                FechaCreacion = DateTime.UtcNow,
                Fotos = definition.FotoUrls
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

    private static readonly CatalogProperty[] Catalog =
    [
        new(
            Slug: "7025-agate-trail-inver-grove-heights-mn",
            Titulo: "Ives of Inver Grove — Luxury 2 Bed Apartment",
            Direccion: "7025 Agate Trail",
            Ciudad: "Inver Grove Heights, MN",
            PrecioMensual: 1905,
            Habitaciones: 2,
            Banos: 2,
            MetrosCuadrados: 1120,
            Descripcion: """
                Tucked in a quiet pocket of Inver Grove Heights—just minutes from downtown St. Paul—Ives of Inver Grove brings understated elegance to everyday living. Soft-close cabinetry, built-in benches, and natural finishes throughout every home.

                This 2-bedroom, 2-bath residence offers boutique-inspired interiors with refined finishes, expansive windows, and thoughtfully designed living spaces. The community features a 24/7 fitness center, saltwater pool, remote work lounges, on-site speakeasy, rooftop terrace with grilling stations, golf simulator lounge, and controlled-access entry.

                Now pre-leasing for September 15th and onwards. Studio, alcove, 1-, 2-, and 3-bedroom floor plans also available. Penthouses include fireplace, private balcony, and exterior gas grill. Pet-friendly community with trails, parks, and Twin Cities conveniences nearby.
                """,
            Amenidades: """
                24/7 Fitness Center, Saltwater Pool, Speakeasy Lounge, Rooftop Deck, Golf Simulator, Remote Work Lounges, Controlled Access, Package Lockers, Pet Friendly, Soft-Close Cabinetry, In-Unit Washer/Dryer, Quartz Countertops
                """,
            ZelleDisplayName: "Wilmairy Tejeda Corporan",
            ZelleContact: "216-203-0074",
            DepositAmount: 150,
            FotoUrls:
            [
                "https://ivesinvergrove.com/application/files/5617/7920/5117/penthouse-living-room-kitchen..jpg",
                "https://ivesinvergrove.com/application/files/6817/7928/9201/ives-inver-grove-pool.jpg",
                "https://ivesinvergrove.com/application/files/3617/7915/8363/ives-inver-grove-apartments-exterior.jpg",
                "https://ivesinvergrove.com/application/files/1317/7915/8364/apartment-golf-simulator-lounge.jpg",
                "https://ivesinvergrove.com/application/files/3917/7915/8364/apartment-fitness-center-spin-bikes.jpg",
                "https://ivesinvergrove.com/application/files/2617/7915/8364/apartment-speakeasy-lounge.jpg",
                "https://ivesinvergrove.com/application/files/8917/7919/1596/apartment-rooftop-terrace.jpg"
            ])
    ];

    private sealed record CatalogProperty(
        string Slug,
        string Titulo,
        string Direccion,
        string Ciudad,
        decimal PrecioMensual,
        int Habitaciones,
        int Banos,
        decimal MetrosCuadrados,
        string Descripcion,
        string Amenidades,
        string ZelleDisplayName,
        string ZelleContact,
        decimal DepositAmount,
        string[] FotoUrls);
}
