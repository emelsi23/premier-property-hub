namespace ApartamentosRenta.Services.Catalog;

internal sealed record CatalogProperty(
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
    int PhotoVariant = 0,
    string[]? CustomPhotos = null);

internal static class CatalogDefaults
{
    public const decimal DepositAmount = 150m;

    private static readonly string[][] PhotoSets =
    [
        [
            "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=900&q=80",
            "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=900&q=80",
            "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=900&q=80"
        ],
        [
            "https://images.unsplash.com/photo-1484154210962-1977b2b13f98?w=900&q=80",
            "https://images.unsplash.com/photo-1564013799919-ab600027ffc6?w=900&q=80",
            "https://images.unsplash.com/photo-1493809842364-78817add7ffb?w=900&q=80"
        ],
        [
            "https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=900&q=80",
            "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?w=900&q=80",
            "https://images.unsplash.com/photo-1600607687939-ce8a6c25118c?w=900&q=80"
        ],
        [
            "https://images.unsplash.com/photo-1600566753190-17f0baa2a6c3?w=900&q=80",
            "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=900&q=80",
            "https://images.unsplash.com/photo-1600047509807-ba8f88d28fcc?w=900&q=80"
        ],
        [
            "https://images.unsplash.com/photo-1600210492486-724fe5c67fb0?w=900&q=80",
            "https://images.unsplash.com/photo-1605276374102-4c046148abbf?w=900&q=80",
            "https://images.unsplash.com/photo-1613490493576-7fde63acd811?w=900&q=80"
        ]
    ];

    public static string[] GetPhotos(int variant) => PhotoSets[Math.Abs(variant) % PhotoSets.Length];

    public static string BuildDescription(string name, string area, string detail) =>
        $"""
        {name} delivers upscale rental living in {area}, one of the most in-demand markets in the region. {detail}

        Residences feature contemporary finishes, open layouts, and premium appliances. Community amenities typically include fitness center, pool, coworking lounge, controlled access, and on-site management. Pet-friendly options may be available. Schedule your private tour today.
        """;
}
