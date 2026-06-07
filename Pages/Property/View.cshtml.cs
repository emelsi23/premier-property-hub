using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Property;

public class ViewModel(AppDbContext context) : PageModel
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

    public PropertyApplicationStrings Strings { get; private set; } = null!;

    public PropertyContentLanguage ActiveLanguage { get; private set; }

    public bool ShowLanguageSwitcher { get; private set; }

    [BindProperty]
    public AppointmentInput Appointment { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string slug, string? lang)
    {
        var propiedad = await LoadPropiedadAsync(slug);
        if (propiedad is null)
        {
            return NotFound();
        }

        ApplyPageContext(propiedad, lang);
        return Page();
    }

    private void ApplyPageContext(Propiedad propiedad, string? lang)
    {
        Propiedad = propiedad;
        ActiveLanguage = PropertyPageLanguageHelper.Resolve(propiedad.IdiomaPublico, lang);
        ShowLanguageSwitcher = PropertyPageLanguageHelper.ShowLanguageSwitcher(propiedad.IdiomaPublico);
        Strings = PropertyApplicationStrings.Get(ActiveLanguage, VisitDepositSettings.Amount);
        ViewData["Title"] = propiedad.Titulo;
    }

    public async Task<IActionResult> OnPostAsync(string slug)
    {
        var propiedad = await LoadPropiedadAsync(slug);
        if (propiedad is null)
        {
            return NotFound();
        }

        Propiedad = propiedad;
        if (!propiedad.MostrarAplicacionPublica)
        {
            return BadRequest(new { success = false, message = "Application is not available for this property." });
        }

        ApplyPageContext(propiedad, Request.Query["lang"]);
        var isAjax = Request.Headers.XRequestedWith == "XMLHttpRequest";

        if (!ModelState.IsValid)
        {
            return isAjax ? AjaxValidationError() : Page();
        }

        if (DateTimeUtc.FromForm(Appointment.FechaHora) <= DateTime.UtcNow)
        {
            ModelState.AddModelError("Appointment.FechaCita", ActiveLanguage == PropertyContentLanguage.Spanish
                ? "Elija una fecha y hora futuras."
                : "Please choose a future date and time.");
            return isAjax ? AjaxValidationError() : Page();
        }

        if (DateTimeUtc.FromFormDate(Appointment.FechaNacimiento) >= DateTime.UtcNow.Date)
        {
            ModelState.AddModelError("Appointment.FechaNacimiento", ActiveLanguage == PropertyContentLanguage.Spanish
                ? "Ingrese una fecha de nacimiento válida."
                : "Please enter a valid date of birth.");
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
            SsnItin = Appointment.SsnItin.Trim(),
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

        return isAjax
            ? new JsonResult(new
            {
                success = true,
                token = publicToken,
                zelle = BuildZellePayload(propiedad)
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

        if (!AllowedImageTypes.Contains(paymentProof.ContentType))
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
        cita.PaymentProofContentType = paymentProof.ContentType;
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

    private static object BuildZellePayload(Propiedad propiedad) => new
    {
        displayName = string.IsNullOrWhiteSpace(propiedad.ZelleDisplayName)
            ? "Premier Property Hub"
            : propiedad.ZelleDisplayName,
        contact = propiedad.ZelleContact,
        depositAmount = VisitDepositSettings.Amount
    };

    private Task<Propiedad?> LoadPropiedadAsync(string slug) =>
        context.Propiedades
            .Include(p => p.Fotos.OrderBy(f => f.Orden))
            .FirstOrDefaultAsync(p => p.Slug == slug && p.Disponible);
}
