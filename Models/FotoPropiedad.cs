using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class FotoPropiedad
{
    public int Id { get; set; }

    public int PropiedadId { get; set; }

    public Propiedad Propiedad { get; set; } = null!;

    [Required, Url, StringLength(500)]
    public string Url { get; set; } = string.Empty;

    public int Orden { get; set; }
}
