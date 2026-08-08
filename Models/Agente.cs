using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class Agente
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Slug { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string FotoUrl { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string RolTitulo { get; set; } = "Agente inmobiliario RE/MAX";

    [Range(0, 5)]
    public decimal Calificacion { get; set; } = 5m;

    [Range(0, 99999)]
    public int TotalResenas { get; set; }

    [Required, StringLength(80)]
    public string NumeroLicencia { get; set; } = string.Empty;

    [Required, StringLength(40)]
    public string EstadoLicencia { get; set; } = string.Empty;

    [Range(0, 60)]
    public int AnosExperiencia { get; set; }

    [Required, StringLength(2000)]
    public string Biografia { get; set; } = string.Empty;

    [StringLength(30)]
    public string WhatsAppNumber { get; set; } = string.Empty;

    [StringLength(120)]
    public string Email { get; set; } = string.Empty;

    [StringLength(30)]
    public string Telefono { get; set; } = string.Empty;

    [StringLength(300)]
    public string AreasServicio { get; set; } = string.Empty;

    [StringLength(200)]
    public string Idiomas { get; set; } = "Español, Inglés";

    [Range(0, 9999)]
    public int PropiedadesActivas { get; set; }

    [Range(0, 168)]
    public decimal TiempoRespuestaHoras { get; set; } = 2m;

    [Range(0, 100)]
    public int PorcentajeRespuesta { get; set; } = 98;

    [Required, StringLength(24)]
    public string CodigoVerificacion { get; set; } = string.Empty;

    public bool Verificado { get; set; } = true;

    public bool Activo { get; set; } = true;

    public DateTime? FechaVerificacion { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
}
