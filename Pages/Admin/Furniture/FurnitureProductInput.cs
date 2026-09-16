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

    [Display(Name = "Fotos existentes (URLs)")]
    public string FotosUrls { get; set; } = string.Empty;

    public IEnumerable<string> ParseFotoUrls() =>
        (FotosUrls ?? string.Empty)
            .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(u => !string.IsNullOrWhiteSpace(u));

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
        FotosUrls = string.Join(Environment.NewLine, p.Photos.OrderBy(x => x.SortOrder).Select(x => x.Url))
    };
}
