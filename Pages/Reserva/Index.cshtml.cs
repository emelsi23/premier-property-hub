using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ApartamentosRenta.Pages.Reserva;

[IgnoreAntiforgeryToken]
public class IndexModel(AppDbContext context, IOptions<AdminAuthSettings> authSettings) : PageModel
{
    [BindProperty]
    public ReservaInput Input { get; set; } = new();

    public ReservaPaymentSettings PaymentSettings { get; private set; } = new();

    public string AgentUsername { get; private set; } = string.Empty;

    public string AgentDisplayName { get; private set; } = string.Empty;

    public bool AgentNotFound { get; private set; }

    public async Task<IActionResult> OnGetAsync(string? agent)
    {
        if (!TryResolveAgent(agent, out var account))
        {
            AgentNotFound = true;
            return Page();
        }

        AgentUsername = account.Username;
        AgentDisplayName = account.EffectiveDisplayName;
        PaymentSettings = await ReservaPaymentSettingsService.GetOrCreateAsync(context, account.Username);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string? agent)
    {
        if (!TryResolveAgent(agent, out var account))
        {
            return new JsonResult(new { success = false, errors = new[] { "Enlace de reserva inválido." } });
        }

        var settings = await ReservaPaymentSettingsService.GetOrCreateAsync(context, account.Username);

        if (!ModelState.IsValid)
        {
            return new JsonResult(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });
        }

        if (string.IsNullOrWhiteSpace(Input.FirmaDataUrl) || !Input.FirmaDataUrl.StartsWith("data:image/", StringComparison.OrdinalIgnoreCase))
        {
            return new JsonResult(new { success = false, errors = new[] { "La firma digital es obligatoria." } });
        }

        var firmaBytes = DecodeDataUrl(Input.FirmaDataUrl);
        if (firmaBytes is null || firmaBytes.Length == 0)
        {
            return new JsonResult(new { success = false, errors = new[] { "No se pudo procesar la firma. Intente de nuevo." } });
        }

        DateTime visita;
        try
        {
            visita = DateTimeUtc.FromForm(Input.FechaVisita.Date.Add(Input.HoraVisita));
        }
        catch
        {
            return new JsonResult(new { success = false, errors = new[] { "Fecha u hora de visita inválida." } });
        }

        if (!Input.AceptaPagoReserva)
        {
            return new JsonResult(new { success = false, errors = new[] { "Debe confirmar que está de acuerdo en proceder con el depósito de reserva." } });
        }

        if (visita <= DateTime.UtcNow)
        {
            return new JsonResult(new { success = false, errors = new[] { "La fecha de visita debe ser en el futuro." } });
        }

        var codigo = await GenerateUniqueCodeAsync();
        var token = Guid.NewGuid();

        var reserva = new ReservaGenerica
        {
            PublicToken = token,
            CodigoConfirmacion = codigo,
            NombreCompleto = Input.NombreCompleto.Trim(),
            Telefono = Input.Telefono.Trim(),
            Email = Input.Email.Trim(),
            FechaVisita = visita,
            OcupantesTotales = Input.OcupantesTotales,
            PoseeHijos = Input.PoseeHijos,
            CantidadVehiculos = Input.CantidadVehiculos,
            PoseeMascotas = Input.PoseeMascotas,
            AceptaTerminos = true,
            FirmaData = firmaBytes,
            FirmaContentType = "image/png",
            DepositAmount = settings.DepositAmount,
            AdminUsername = account.Username,
            Estado = EstadoReservaGenerica.EsperandoIdentidad,
            FechaSolicitud = DateTime.UtcNow
        };

        context.ReservasGenericas.Add(reserva);
        await context.SaveChangesAsync();

        return new JsonResult(new
        {
            success = true,
            token = token.ToString(),
            needsIdentity = true
        });
    }

    public async Task<IActionResult> OnPostUploadIdentityAsync(Guid token, IFormFile identityDoc)
    {
        var (ok, error, bytes, contentType) = await ReadImageAsync(identityDoc, "Debe subir una foto de su documento con selfie.");
        if (!ok)
        {
            return new JsonResult(new { success = false, error });
        }

        var reserva = await context.ReservasGenericas.FirstOrDefaultAsync(r => r.PublicToken == token);
        if (reserva is null)
        {
            return new JsonResult(new { success = false, error = "Reserva no encontrada." });
        }

        if (reserva.Estado is EstadoReservaGenerica.Completada or EstadoReservaGenerica.Cancelada)
        {
            return new JsonResult(new { success = false, error = "Esta reserva ya fue procesada." });
        }

        reserva.IdentidadData = bytes;
        reserva.IdentidadContentType = contentType;
        reserva.IdentidadUploadedAt = DateTime.UtcNow;
        reserva.Estado = EstadoReservaGenerica.EsperandoPago;
        await context.SaveChangesAsync();

        var settings = await ReservaPaymentSettingsService.GetOrCreateAsync(context, reserva.AdminUsername);
        return new JsonResult(new
        {
            success = true,
            next = "payment",
            payment = BuildPaymentPayload(settings, reserva.DepositAmount)
        });
    }

    public async Task<IActionResult> OnGetPaymentOptionsAsync(Guid token)
    {
        var reserva = await context.ReservasGenericas.AsNoTracking().FirstOrDefaultAsync(r => r.PublicToken == token);
        if (reserva is null)
        {
            return new JsonResult(new { success = false, error = "Reserva no encontrada." });
        }

        var settings = await ReservaPaymentSettingsService.GetOrCreateAsync(context, reserva.AdminUsername);
        return new JsonResult(new
        {
            success = true,
            payment = BuildPaymentPayload(settings, reserva.DepositAmount > 0 ? reserva.DepositAmount : settings.DepositAmount)
        });
    }

    public async Task<IActionResult> OnGetBarcodeImageAsync(string? agent)
    {
        if (!TryResolveAgent(agent, out var account))
        {
            return NotFound();
        }

        var settings = await ReservaPaymentSettingsService.GetOrCreateAsync(context, account.Username);
        if (settings.BarcodeImageData is null || settings.BarcodeImageData.Length == 0)
        {
            return NotFound();
        }

        return File(settings.BarcodeImageData, settings.BarcodeImageContentType ?? "image/png");
    }

    public async Task<IActionResult> OnPostUploadPaymentAsync(Guid token, string metodoPago, IFormFile paymentProof)
    {
        if (!Enum.TryParse<MetodoPagoReserva>(metodoPago, ignoreCase: true, out var metodo)
            || metodo is MetodoPagoReserva.Ninguno)
        {
            return new JsonResult(new { success = false, error = "Seleccione un método de pago válido." });
        }

        var (ok, error, bytes, contentType) = await ReadImageAsync(paymentProof, "Debe subir el comprobante de pago.");
        if (!ok)
        {
            return new JsonResult(new { success = false, error });
        }

        var reserva = await context.ReservasGenericas.FirstOrDefaultAsync(r => r.PublicToken == token);
        if (reserva is null)
        {
            return new JsonResult(new { success = false, error = "Reserva no encontrada." });
        }

        if (reserva.Estado is EstadoReservaGenerica.Completada or EstadoReservaGenerica.Cancelada)
        {
            return new JsonResult(new { success = false, error = "Esta reserva ya fue procesada." });
        }

        if (reserva.Estado is not (EstadoReservaGenerica.EsperandoPago or EstadoReservaGenerica.EsperandoConfirmacion))
        {
            return new JsonResult(new { success = false, error = "Complete primero la verificación de identidad." });
        }

        reserva.MetodoPago = metodo;
        reserva.PaymentProofData = bytes;
        reserva.PaymentProofContentType = contentType;
        reserva.PaymentProofUploadedAt = DateTime.UtcNow;
        reserva.Estado = EstadoReservaGenerica.EsperandoConfirmacion;
        await context.SaveChangesAsync();

        return new JsonResult(new
        {
            success = true,
            next = "waiting",
            status = nameof(EstadoReservaGenerica.EsperandoConfirmacion)
        });
    }

    public async Task<IActionResult> OnGetStatusAsync(Guid token)
    {
        var reserva = await context.ReservasGenericas.AsNoTracking().FirstOrDefaultAsync(r => r.PublicToken == token);
        if (reserva is null)
        {
            return new JsonResult(new { success = false });
        }

        var confirmed = reserva.Estado == EstadoReservaGenerica.Completada;
        var cancelled = reserva.Estado == EstadoReservaGenerica.Cancelada;

        return new JsonResult(new
        {
            success = true,
            status = reserva.Estado.ToString(),
            confirmed,
            cancelled,
            confirmationCode = confirmed ? reserva.CodigoConfirmacion : null,
            nombre = confirmed ? reserva.NombreCompleto : null,
            fechaVisita = confirmed
                ? reserva.FechaVisita.ToLocalTime().ToString("dddd, MMM d, yyyy · h:mm tt")
                : null,
            monto = confirmed ? reserva.DepositAmount.ToString("N2") : null,
            metodo = confirmed
                ? reserva.MetodoPago switch
                {
                    MetodoPagoReserva.Zelle => "Zelle",
                    MetodoPagoReserva.CodigoBarras => "Código de barras",
                    _ => null
                }
                : null
        });
    }

    private bool TryResolveAgent(string? agent, out AdminUserAccount account)
    {
        var found = AdminUsers.FindByPublicAgent(authSettings.Value, agent);
        if (found is null)
        {
            account = new AdminUserAccount();
            return false;
        }

        account = found;
        return true;
    }

    private static object BuildPaymentPayload(ReservaPaymentSettings settings, decimal amount)
    {
        var refund = Math.Max(0, amount - settings.NoShowFee);
        return new
        {
            amount = amount,
            amountFormatted = amount.ToString("N2"),
            noShowFee = settings.NoShowFee.ToString("N2"),
            refundFormatted = refund.ToString("N2"),
            zelleEnabled = settings.ZelleEnabled,
            zelleDisplayName = settings.ZelleDisplayName,
            zelleContact = settings.ZelleContact,
            zelleInstructions = settings.ZelleInstructions,
            barcodeEnabled = settings.BarcodeEnabled,
            barcodeInstructions = settings.BarcodeInstructions,
            barcodeHasImage = settings.BarcodeImageData is { Length: > 0 }
        };
    }

    private static async Task<(bool Ok, string? Error, byte[]? Bytes, string ContentType)> ReadImageAsync(IFormFile? file, string missingMessage)
    {
        if (file is null || file.Length == 0)
        {
            return (false, missingMessage, null, "");
        }

        if (file.Length > 8 * 1024 * 1024)
        {
            return (false, "El archivo no puede superar 8 MB.", null, "");
        }

        var contentType = file.ContentType?.ToLowerInvariant() ?? "";
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        var allowed = contentType is "image/jpeg" or "image/png" or "image/webp" or "image/gif"
            || ext is ".jpg" or ".jpeg" or ".png" or ".webp" or ".gif";
        if (!allowed)
        {
            return (false, "Solo se permiten imágenes (JPG, PNG, WEBP).", null, "");
        }

        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        return (true, null, ms.ToArray(), string.IsNullOrWhiteSpace(contentType) ? "image/jpeg" : contentType);
    }

    private async Task<string> GenerateUniqueCodeAsync()
    {
        const string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        for (var attempt = 0; attempt < 20; attempt++)
        {
            var chars = new char[6];
            for (var i = 0; i < chars.Length; i++)
            {
                chars[i] = alphabet[Random.Shared.Next(alphabet.Length)];
            }

            var code = $"RMX-{new string(chars)}";
            var exists = await context.ReservasGenericas.AnyAsync(r => r.CodigoConfirmacion == code);
            if (!exists)
            {
                return code;
            }
        }

        return $"RMX-{Guid.NewGuid().ToString("N")[..8].ToUpperInvariant()}";
    }

    private static byte[]? DecodeDataUrl(string dataUrl)
    {
        var comma = dataUrl.IndexOf(',');
        if (comma < 0)
        {
            return null;
        }

        try
        {
            return Convert.FromBase64String(dataUrl[(comma + 1)..]);
        }
        catch
        {
            return null;
        }
    }
}

public class ReservaInput
{
    [Required(ErrorMessage = "El nombre completo es obligatorio."), StringLength(160)]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio."), StringLength(14)]
    [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Formato: (###) ###-####")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio."), EmailAddress, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de visita es obligatoria."), DataType(DataType.Date)]
    public DateTime FechaVisita { get; set; } = DateTime.Today.AddDays(1);

    [Required(ErrorMessage = "La hora de visita es obligatoria.")]
    public TimeSpan HoraVisita { get; set; } = new(10, 0, 0);

    [Range(1, 20, ErrorMessage = "Indique entre 1 y 20 ocupantes.")]
    public int OcupantesTotales { get; set; } = 1;

    public bool PoseeHijos { get; set; }

    [Range(0, 10)]
    public int CantidadVehiculos { get; set; }

    public bool PoseeMascotas { get; set; }

    public bool AceptaPagoReserva { get; set; }

    [Required]
    public string FirmaDataUrl { get; set; } = string.Empty;

    public bool AceptaTerminos { get; set; }
}
