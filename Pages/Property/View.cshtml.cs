using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Property;

[IgnoreAntiforgeryToken]
public class ViewModel(
    AppDbContext context,
    IAntiforgery antiforgery,
    SiteSettingsService siteSettings) : PageModel
{
    private static readonly HashSet<string> AllowedImageTypes =
    [
        "image/jpeg",
        "image/png",
        "image/webp",
        "image/gif"
    ];

    private const long MaxPaymentProofBytes = 5 * 1024 * 1024;

    public Propiedad Propiedad { get; private set; } = null!;

    public string AgentWhatsAppUrl { get; private set; } = string.Empty;

    public string AgentWhatsAppDisplay { get; private set; } = string.Empty;

    [BindProperty]
    public AppointmentInput Appointment { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        var propiedad = await LoadPropiedadAsync(slug);
        if (propiedad is null)
        {
            return NotFound();
        }

        Propiedad = propiedad;
        await LoadAgentWhatsAppAsync(propiedad);
        ViewData["Title"] = propiedad.Titulo;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string slug)
    {
        var propiedad = await LoadPropiedadAsync(slug);
        if (propiedad is null)
        {
            return NotFound();
        }

        Propiedad = propiedad;
        var isAjax = Request.Headers.XRequestedWith == "XMLHttpRequest";

        if (!ModelState.IsValid)
        {
            return isAjax ? AjaxValidationError() : Page();
        }

        if (DateTimeUtc.FromForm(Appointment.FechaHora) <= DateTime.UtcNow)
        {
            ModelState.AddModelError("Appointment.FechaCita", "Please choose a future date and time.");
            return isAjax ? AjaxValidationError() : Page();
        }

        if (DateTimeUtc.FromFormDate(Appointment.FechaNacimiento) >= DateTime.UtcNow.Date)
        {
            ModelState.AddModelError("Appointment.FechaNacimiento", "Please enter a valid date of birth.");
            return isAjax ? AjaxValidationError() : Page();
        }

        var publicToken = Guid.NewGuid();
        context.Citas.Add(new Cita
        {
            PropiedadId = propiedad.Id,
            PublicToken = publicToken,
            NombreCliente = Appointment.NombreCliente.Trim(),
            ApellidoCliente = Appointment.ApellidoCliente.Trim(),
            Email = Appointment.Email.Trim(),
            Telefono = Appointment.Telefono.Trim(),
            FechaNacimiento = DateTimeUtc.FromFormDate(Appointment.FechaNacimiento),
            SsnItin = string.IsNullOrWhiteSpace(Appointment.SsnItin)
                ? null
                : Appointment.SsnItin.Trim(),
            FechaHora = DateTimeUtc.FromForm(Appointment.FechaHora),
            CodigoPostal = string.IsNullOrWhiteSpace(Appointment.CodigoPostal)
                ? null
                : Appointment.CodigoPostal.Trim(),
            EsCiudadanoAmericano = Appointment.EsCiudadanoAmericano!.Value,
            PersonasEnUnidad = Appointment.PersonasEnUnidad!.Value,
            DuracionContratoDeseada = Appointment.DuracionContratoDeseada.Trim(),
            FechaMudanzaTemprana = Appointment.FechaMudanzaTemprana.HasValue
                ? DateTimeUtc.FromFormDate(Appointment.FechaMudanzaTemprana.Value)
                : null,
            Fuma = Appointment.Fuma!.Value,
            EmpleadoActualmente = Appointment.EmpleadoActualmente!.Value,
            NombreCompania = string.IsNullOrWhiteSpace(Appointment.NombreCompania)
                ? null
                : Appointment.NombreCompania.Trim(),
            Salario = Appointment.Salario,
            DisponibleParaAsegurar = Appointment.DisponibleParaAsegurar,
            TieneMascotas = Appointment.TieneMascotas!.Value,
            AceptaDepositoReserva = Appointment.AceptaDepositoReserva!.Value,
            PagaraCitaCertificada = Appointment.PagaraCitaCertificada!.Value,
            MetodoPago = Appointment.MetodoPago,
            FechaSolicitud = DateTime.UtcNow,
            Estado = EstadoCita.EsperandoDeposito
        });

        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save appointment: {ex.Message} | {ex.InnerException?.Message}");
            if (isAjax)
            {
                return StatusCode(500, new
                {
                    success = false,
                    errors = new Dictionary<string, string>
                    {
                        ["_"] = "Could not save your request. Please try again in a moment."
                    }
                });
            }

            throw;
        }

        var antiforgeryTokens = isAjax ? antiforgery.GetAndStoreTokens(HttpContext) : null;

        return isAjax
            ? new JsonResult(new
            {
                success = true,
                token = publicToken,
                zelle = await BuildZellePayloadAsync(propiedad),
                antiforgeryToken = antiforgeryTokens?.RequestToken
            })
            : RedirectToPage("/Property/ThankYou", new { slug });
    }

    public async Task<IActionResult> OnPostUploadPaymentAsync(string slug, Guid token, IFormFile paymentProof)
    {
        var isAjax = Request.Headers.XRequestedWith == "XMLHttpRequest";
        if (!isAjax)
        {
            return BadRequest();
        }

        if (paymentProof is null || paymentProof.Length == 0)
        {
            return BadRequest(new { success = false, message = "Please select a payment screenshot." });
        }

        if (paymentProof.Length > MaxPaymentProofBytes)
        {
            return BadRequest(new { success = false, message = "Image must be 5 MB or smaller." });
        }

        if (!IsAllowedPaymentProof(paymentProof))
        {
            return BadRequest(new { success = false, message = "Upload a JPG, PNG, WEBP, or GIF image." });
        }

        var cita = await context.Citas
            .Include(c => c.Propiedad)
            .FirstOrDefaultAsync(c => c.PublicToken == token && c.Propiedad.Slug == slug);

        if (cita is null)
        {
            return NotFound(new { success = false, message = "Appointment not found." });
        }

        if (cita.Estado is EstadoCita.Cancelada or EstadoCita.Confirmada)
        {
            return BadRequest(new { success = false, message = "This appointment can no longer accept payments." });
        }

        await using var stream = new MemoryStream();
        await paymentProof.CopyToAsync(stream);

        cita.PaymentProofData = stream.ToArray();
        cita.PaymentProofContentType = ResolvePaymentProofContentType(paymentProof);
        cita.PaymentProofUploadedAt = DateTime.UtcNow;
        cita.Estado = EstadoCita.EsperandoConfirmacion;

        await context.SaveChangesAsync();

        return new JsonResult(new { success = true, status = nameof(EstadoCita.EsperandoConfirmacion) });
    }

    public async Task<IActionResult> OnGetStatusAsync(string slug, Guid token)
    {
        var cita = await context.Citas
            .AsNoTracking()
            .Include(c => c.Propiedad)
            .FirstOrDefaultAsync(c => c.PublicToken == token && c.Propiedad.Slug == slug);

        if (cita is null)
        {
            return NotFound(new { success = false });
        }

        return new JsonResult(new
        {
            success = true,
            status = cita.Estado.ToString(),
            confirmed = cita.Estado == EstadoCita.Confirmada
        });
    }

    private IActionResult AjaxValidationError()
    {
        var errors = ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .ToDictionary(
                x => x.Key,
                x => x.Value!.Errors.Select(e => e.ErrorMessage).First());

        return BadRequest(new { success = false, errors });
    }

    private static bool IsAllowedPaymentProof(IFormFile file)
    {
        if (AllowedImageTypes.Contains(file.ContentType))
        {
            return true;
        }

        if (!string.IsNullOrWhiteSpace(file.ContentType)
            && file.ContentType != "application/octet-stream")
        {
            return false;
        }

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return extension is ".jpg" or ".jpeg" or ".png" or ".webp" or ".gif";
    }

    private static string ResolvePaymentProofContentType(IFormFile file)
    {
        if (AllowedImageTypes.Contains(file.ContentType))
        {
            return file.ContentType;
        }

        return Path.GetExtension(file.FileName).ToLowerInvariant() switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".webp" => "image/webp",
            ".gif" => "image/gif",
            _ => "image/jpeg"
        };
    }

    private async Task LoadAgentWhatsAppAsync(Propiedad propiedad)
    {
        AgentWhatsAppDisplay = await siteSettings.GetAgentWhatsAppDisplayAsync();
        AgentWhatsAppUrl = await siteSettings.GetAgentWhatsAppChatUrlAsync(
            $"Hi, I'm interested in {propiedad.Titulo} on Premier Property Hub.");
    }

    private async Task<object> BuildZellePayloadAsync(Propiedad propiedad)
    {
        var hasPaymentMethod = WhatsAppLinkHelper.HasConfiguredPaymentMethod(propiedad.ZelleContact);
        var whatsappUrl = await siteSettings.GetAgentWhatsAppChatUrlAsync(
            $"Hi, I submitted a visit request for {propiedad.Titulo}. I'd like help completing my deposit.");

        return new
        {
            displayName = string.IsNullOrWhiteSpace(propiedad.ZelleDisplayName)
                ? "Premier Property Hub"
                : propiedad.ZelleDisplayName,
            contact = propiedad.ZelleContact,
            depositAmount = VisitDepositSettings.GetAmount(propiedad),
            hasPaymentMethod,
            whatsappUrl,
            whatsappDisplay = await siteSettings.GetAgentWhatsAppDisplayAsync()
        };
    }

    private Task<Propiedad?> LoadPropiedadAsync(string slug) =>
        context.Propiedades
            .Include(p => p.Fotos.OrderBy(f => f.Orden))
            .FirstOrDefaultAsync(p => p.Slug == slug && p.Disponible);
}
