using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class FurnitureCategory
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(140)]
    public string Slug { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public bool IsActive { get; set; } = true;

    public List<FurnitureProduct> Products { get; set; } = [];
}
