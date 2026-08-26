using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

/// <summary>Singleton-style settings for the generic reservation payment step.</summary>
public class ReservaPaymentSettings
{
    public int Id { get; set; } = 1;

    [Range(1, 999999)]
    public decimal DepositAmount { get; set; } = 150m;

    [Range(0, 999999)]
    public decimal NoShowFee { get; set; } = 10m;

    [StringLength(120)]
    public string ZelleDisplayName { get; set; } = "Premier Property Hub";

    [StringLength(120)]
    public string ZelleContact { get; set; } = string.Empty;

    [StringLength(500)]
    public string ZelleInstructions { get; set; } =
        "Envíe el depósito por Zelle e incluya su nombre completo en el mensaje.";

    public bool ZelleEnabled { get; set; } = true;

    public bool BarcodeEnabled { get; set; } = true;

    [StringLength(500)]
    public string BarcodeInstructions { get; set; } =
        "Pague en efectivo mostrando este código de barras y conserve su recibo.";

    public byte[]? BarcodeImageData { get; set; }

    [StringLength(100)]
    public string? BarcodeImageContentType { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public enum MetodoPagoReserva
{
    Ninguno = 0,
    Zelle = 1,
    CodigoBarras = 2
}
