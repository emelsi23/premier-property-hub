using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public enum EstadoCita
{
    Pendiente,
    Confirmada,
    Cancelada
}

public class Cita
{
    public int Id { get; set; }

    public int PropiedadId { get; set; }

    public Propiedad Propiedad { get; set; } = null!;

    [Required, StringLength(120)]
    public string NombreCliente { get; set; } = string.Empty;

    [Required, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(14)]
    public string Telefono { get; set; } = string.Empty;

    public DateTime FechaNacimiento { get; set; }

    [Required, StringLength(11)]
    public string SsnItin { get; set; } = string.Empty;

    public DateTime FechaHora { get; set; }

    [StringLength(500)]
    public string? Notas { get; set; }

    public EstadoCita Estado { get; set; } = EstadoCita.Pendiente;

    public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;
}
