using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Reserva;

[IgnoreAntiforgeryToken]
public class IndexModel(AppDbContext context) : PageModel
{
    public const decimal DefaultDeposit = 150m;

    [BindProperty]
    public ReservaInput Input { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
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
            return new JsonResult(new { success = false, errors = new[] { "Debe confirmar que está de acuerdo en proceder con el pago del depósito de reserva." } });
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
            DepositAmount = DefaultDeposit,
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
        if (identityDoc is null || identityDoc.Length == 0)
        {
            return new JsonResult(new { success = false, error = "Debe subir una foto de su documento con selfie." });
        }

        if (identityDoc.Length > 8 * 1024 * 1024)
        {
            return new JsonResult(new { success = false, error = "El archivo no puede superar 8 MB." });
        }

        var contentType = identityDoc.ContentType?.ToLowerInvariant() ?? "";
        var ext = Path.GetExtension(identityDoc.FileName).ToLowerInvariant();
        var allowed = contentType is "image/jpeg" or "image/png" or "image/webp" or "image/gif"
            || ext is ".jpg" or ".jpeg" or ".png" or ".webp" or ".gif";
        if (!allowed)
        {
            return new JsonResult(new { success = false, error = "Solo se permiten imágenes (JPG, PNG, WEBP)." });
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

        using var ms = new MemoryStream();
        await identityDoc.CopyToAsync(ms);

        reserva.IdentidadData = ms.ToArray();
        reserva.IdentidadContentType = string.IsNullOrWhiteSpace(contentType) ? "image/jpeg" : contentType;
        reserva.IdentidadUploadedAt = DateTime.UtcNow;
        reserva.Estado = EstadoReservaGenerica.Completada;
        reserva.FechaCompletada = DateTime.UtcNow;

        await context.SaveChangesAsync();

        return new JsonResult(new
        {
            success = true,
            confirmationCode = reserva.CodigoConfirmacion,
            nombre = reserva.NombreCompleto,
            fechaVisita = reserva.FechaVisita.ToLocalTime().ToString("dddd, MMM d, yyyy · h:mm tt")
        });
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

            var code = $"PPH-{new string(chars)}";
            var exists = await context.ReservasGenericas.AnyAsync(r => r.CodigoConfirmacion == code);
            if (!exists)
            {
                return code;
            }
        }

        return $"PPH-{Guid.NewGuid().ToString("N")[..8].ToUpperInvariant()}";
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
