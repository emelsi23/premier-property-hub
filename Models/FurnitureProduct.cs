using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class FurnitureProduct
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(220)]
    public string Slug { get; set; } = string.Empty;

    [StringLength(80)]
    public string Sku { get; set; } = string.Empty;

    [StringLength(300)]
    public string ShortDescription { get; set; } = string.Empty;

    [StringLength(8000)]
    public string Description { get; set; } = string.Empty;

    [Range(0, 9999999)]
    public decimal Price { get; set; }

    [Range(0, 9999999)]
    public decimal? CompareAtPrice { get; set; }

    public int CategoryId { get; set; }

    public FurnitureCategory? Category { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsFeatured { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public List<FurniturePhoto> Photos { get; set; } = [];
}
