using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Propiedades.AnyAsync())
        {
            return;
        }

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
    }
}
