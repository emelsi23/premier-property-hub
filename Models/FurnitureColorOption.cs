using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class FurnitureColorOption
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public FurnitureProduct? Product { get; set; }

    [Required, StringLength(80)]
    public string Name { get; set; } = string.Empty;

    /// <summary>CSS hex, e.g. #C4A574</summary>
    [Required, StringLength(16)]
    public string HexColor { get; set; } = "#C4A574";

    public int SortOrder { get; set; }

    public bool IsDefault { get; set; }

    public List<FurniturePhoto> Photos { get; set; } = [];
}
