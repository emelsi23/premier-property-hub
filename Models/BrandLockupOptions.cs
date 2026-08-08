namespace ApartamentosRenta.Models;

public sealed class BrandLockupOptions
{
    public string Variant { get; init; } = "";

    public bool LinkToCatalog { get; init; } = true;

    public static BrandLockupOptions For(string variant, bool linkToCatalog = true) =>
        new() { Variant = variant, LinkToCatalog = linkToCatalog };
}
