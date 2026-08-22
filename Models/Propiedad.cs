using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class Propiedad
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Titulo { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string Slug { get; set; } = string.Empty;

    [Required, StringLength(2000)]
    public string Descripcion { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string Direccion { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string Ciudad { get; set; } = string.Empty;

    [Range(0, 999999999)]
    public decimal PrecioMensual { get; set; }

    public int Habitaciones { get; set; }

    public int Banos { get; set; }

    public decimal MetrosCuadrados { get; set; }

    [StringLength(500)]
    public string Amenidades { get; set; } = string.Empty;

    public bool Disponible { get; set; } = true;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    [StringLength(120)]
    public string ZelleDisplayName { get; set; } = string.Empty;

    [StringLength(120)]
    public string ZelleContact { get; set; } = string.Empty;

    [StringLength(30)]
    public string WhatsAppNumber { get; set; } = string.Empty;

    [Range(0, 999999)]
    public decimal DepositAmount { get; set; } = 150m;

    [Range(0, 999999)]
    public decimal StampsAmount { get; set; } = 245m;

    [Range(0, 999999)]
    public decimal SealsAmount { get; set; } = 245m;

    public ICollection<FotoPropiedad> Fotos { get; set; } = [];

    public ICollection<Cita> Citas { get; set; } = [];

    public LeaseContract? LeaseContract { get; set; }

    public StampSealContract? StampSealContract { get; set; }
}
