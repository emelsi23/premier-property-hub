namespace ApartamentosRenta.Services;

public static class CatalogHeroCarousel
{
    private const string Hd = "w=1920&h=1080&fit=crop&q=92&auto=format";

    public static IReadOnlyList<CatalogHeroSlide> Slides { get; } = new CatalogHeroSlide[]
    {
        new("https://images.unsplash.com/photo-1600585154084-4e5fe7c39198?" + Hd, "Apartamento con sala luminosa y diseño moderno"),
        new("https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?" + Hd, "Cocina y área social de apartamento premium"),
        new("https://images.unsplash.com/photo-1600607687920-4e2a09cf159d?" + Hd, "Interior elegante con acabados de alta calidad"),
        new("https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?" + Hd, "Sala de estar amplia con decoración contemporánea"),
        new("https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?" + Hd, "Habitación principal con luz natural"),
        new("https://images.unsplash.com/photo-1600566753190-17f0baa2a6c3?" + Hd, "Espacio abierto de apartamento de lujo")
    };
}

public sealed record CatalogHeroSlide(string Url, string Alt);
