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

    public static string[] GetPhotos(int variant) =>
        CatalogPhotoLibrary.AssignExclusivePhotos(variant + 10_000, $"featured-{variant}");

    public static string BuildDescription(string name, string area, string detail) =>
        $"""
        {name} delivers upscale rental living in {area}, one of the most in-demand markets in the region. {detail}

        Residences feature contemporary finishes, open layouts, and premium appliances. Community amenities typically include fitness center, pool, coworking lounge, controlled access, and on-site management. Pet-friendly options may be available. Schedule your private tour today.
        """;
}
