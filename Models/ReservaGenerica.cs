using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public enum EstadoReservaGenerica
{
    Borrador,
    EsperandoIdentidad,
    EsperandoPago,
    EsperandoConfirmacion,
    Completada,
    Cancelada
}

public class ReservaGenerica
{
    public int Id { get; set; }

    public Guid PublicToken { get; set; } = Guid.NewGuid();

    /// <summary>Human-readable confirmation code shown to the client, e.g. RMX-A7K29M.</summary>
    [Required, StringLength(20)]
    public string CodigoConfirmacion { get; set; } = string.Empty;

    [Required, StringLength(160)]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required, StringLength(14)]
    public string Telefono { get; set; } = string.Empty;

    [Required, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    public DateTime FechaVisita { get; set; }

    [Range(1, 20)]
    public int OcupantesTotales { get; set; } = 1;

    public bool PoseeHijos { get; set; }

    [Range(0, 10)]
    public int CantidadVehiculos { get; set; }

    public bool PoseeMascotas { get; set; }

    public bool AceptaTerminos { get; set; }

    public byte[]? FirmaData { get; set; }

    [StringLength(100)]
    public string? FirmaContentType { get; set; }

    public byte[]? IdentidadData { get; set; }

    [StringLength(100)]
    public string? IdentidadContentType { get; set; }

    public DateTime? IdentidadUploadedAt { get; set; }

    public MetodoPagoReserva MetodoPago { get; set; } = MetodoPagoReserva.Ninguno;

    public byte[]? PaymentProofData { get; set; }

    [StringLength(100)]
    public string? PaymentProofContentType { get; set; }

    public DateTime? PaymentProofUploadedAt { get; set; }

    public decimal DepositAmount { get; set; } = 150m;

    public EstadoReservaGenerica Estado { get; set; } = EstadoReservaGenerica.EsperandoIdentidad;

    public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;

    public DateTime? FechaCompletada { get; set; }
}
