using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Models;

namespace ApartamentosRenta.Pages.Admin.Furniture;

public class FurnitureProductInput
{
    [Required, StringLength(200), Display(Name = "Título")]
    public string Title { get; set; } = string.Empty;

    [StringLength(220), Display(Name = "Slug (URL)")]
    public string? Slug { get; set; }

    [StringLength(80), Display(Name = "SKU")]
    public string Sku { get; set; } = string.Empty;

    [StringLength(300), Display(Name = "Descripción corta")]
    public string ShortDescription { get; set; } = string.Empty;

    [StringLength(8000), Display(Name = "Descripción")]
    public string Description { get; set; } = string.Empty;

    [Range(0, 9999999), Display(Name = "Precio (USD)")]
    public decimal Price { get; set; }

    [Range(0, 9999999), Display(Name = "Precio anterior (oferta)")]
    public decimal? CompareAtPrice { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecciona una categoría."), Display(Name = "Categoría")]
    public int CategoryId { get; set; }

    [Display(Name = "Activo")]
    public bool IsActive { get; set; } = true;

    [Display(Name = "Destacado")]
    public bool IsFeatured { get; set; }

    [Display(Name = "Permitir preview de color en la tienda")]
    public bool AllowColorPreview { get; set; } = true;

    /// <summary>One color per line: Name|#RRGGBB</summary>
    [Display(Name = "Colores / acabados")]
    public string ColorsText { get; set; } = string.Empty;

    /// <summary>One photo per line: url  OR  url|ColorName</summary>
    [Display(Name = "Fotos existentes (URLs)")]
    public string FotosUrls { get; set; } = string.Empty;

    [Display(Name = "Color para fotos nuevas")]
    public string? UploadColorName { get; set; }

    public IReadOnlyList<(string Url, string? ColorName)> ParseFotoLines()
    {
        var list = new List<(string Url, string? ColorName)>();
        foreach (var raw in (FotosUrls ?? string.Empty)
                     .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                continue;
            }

            var parts = raw.Split('|', 2, StringSplitOptions.TrimEntries);
            var url = parts[0];
            var color = parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]) ? parts[1] : null;
            if (!string.IsNullOrWhiteSpace(url))
            {
                list.Add((url, color));
            }
        }

        return list;
    }

    public IEnumerable<string> ParseFotoUrls() =>
        ParseFotoLines().Select(x => x.Url);

    public IReadOnlyList<(string Name, string Hex)> ParseColors()
    {
        var list = new List<(string Name, string Hex)>();
        foreach (var raw in (ColorsText ?? string.Empty)
                     .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            var parts = raw.Split('|', 2, StringSplitOptions.TrimEntries);
            var name = parts[0];
            var hex = parts.Length > 1 ? parts[1] : "#C4A574";
            if (!hex.StartsWith('#'))
            {
                hex = "#" + hex;
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                list.Add((name, hex.ToUpperInvariant()));
            }
        }

        return list;
    }

    public static FurnitureProductInput FromEntity(FurnitureProduct p) => new()
    {
        Title = p.Title,
        Slug = p.Slug,
        Sku = p.Sku,
        ShortDescription = p.ShortDescription,
        Description = p.Description,
        Price = p.Price,
        CompareAtPrice = p.CompareAtPrice,
        CategoryId = p.CategoryId,
        IsActive = p.IsActive,
        IsFeatured = p.IsFeatured,
        AllowColorPreview = p.AllowColorPreview,
        ColorsText = string.Join(Environment.NewLine,
            p.ColorOptions.OrderBy(c => c.SortOrder)
                .Select(c => $"{c.Name}|{c.HexColor}")),
        FotosUrls = string.Join(Environment.NewLine,
            p.Photos.OrderBy(x => x.SortOrder).Select(x =>
                x.ColorOption is null
                    ? x.Url
                    : $"{x.Url}|{x.ColorOption.Name}"))
    };
}
