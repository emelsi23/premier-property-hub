using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class FurniturePhoto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public FurnitureProduct? Product { get; set; }

    [Required, StringLength(1000)]
    public string Url { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public bool IsPrimary { get; set; }
}
