using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await SeedContractAsync(context);

        if (await context.Propiedades.AnyAsync())
        {
            return;
        }

        try
        {
            var slug = await SlugHelper.EnsureUniqueAsync(context, SlugHelper.FromPropiedad("250 Reforma Ave, Juarez District", "Mexico City"));

            var propiedad = new Propiedad
            {
                Titulo = "Modern loft downtown",
                Slug = slug,
                Descripcion = "Bright apartment with panoramic views, fully equipped kitchen, and private balcony. Ideal for professionals.",
                Direccion = "250 Reforma Ave, Juarez District",
                Ciudad = "Mexico City",
                PrecioMensual = 18500,
                Habitaciones = 2,
                Banos = 2,
                MetrosCuadrados = 85,
            Amenidades = "Parking, Gym, 24h Security",
            ZelleDisplayName = "Premier Property Hub",
            ZelleContact = "payments@premierpropertyhub.com",
            DepositAmount = 250,
            Disponible = true,
                Fotos =
                [
                    new FotoPropiedad { Url = "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=800&q=80", Orden = 0 },
                    new FotoPropiedad { Url = "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=800&q=80", Orden = 1 },
                    new FotoPropiedad { Url = "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=800&q=80", Orden = 2 }
                ]
            };

            context.Propiedades.Add(propiedad);
            await context.SaveChangesAsync();
            Console.WriteLine("Sample property seeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Seed skipped: {ex.Message} | {ex.InnerException?.Message}");
        }
    }

    public static async Task SeedContractAsync(AppDbContext context)
    {
        if (await context.LeaseContracts.AnyAsync())
        {
            return;
        }

        try
        {
            context.LeaseContracts.Add(LeaseContractDefaults.Create());
            await context.SaveChangesAsync();
            Console.WriteLine("Default lease contract seeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Contract seed skipped: {ex.Message} | {ex.InnerException?.Message}");
        }
    }
}
