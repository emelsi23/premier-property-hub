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
        {name} ofrece alquiler de alto nivel en {area}, uno de los mercados más demandados de la región. {detail}

        Las residencias cuentan con acabados contemporáneos, planos abiertos y electrodomésticos premium. Las amenidades del complejo suelen incluir gimnasio, piscina, sala coworking, acceso controlado y administración en el sitio. Pueden estar disponibles opciones que admiten mascotas. Agenda tu visita privada hoy.
        """;
}
