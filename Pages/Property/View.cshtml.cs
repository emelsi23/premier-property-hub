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
            ModelState.AddModelError("Appointment.FechaHora", "Please choose a future date and time.");
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
            Email = Appointment.Email.Trim(),
            Telefono = Appointment.Telefono.Trim(),
            FechaNacimiento = DateTimeUtc.FromFormDate(Appointment.FechaNacimiento),
            SsnItin = Appointment.SsnItin.Trim(),
            FechaHora = DateTimeUtc.FromForm(Appointment.FechaHora),
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

public class AppointmentInput
{
    [Required(ErrorMessage = "Full name is required"), StringLength(120)]
    [Display(Name = "Full name")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of birth is required")]
    [Display(Name = "Date of birth")]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; } = DateTime.Today.AddYears(-25);

    [Required(ErrorMessage = "Email is required"), StringLength(256)]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    [Display(Name = "Email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required"), StringLength(14)]
    [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Enter a valid number, e.g. (809) 690-9988")]
    [Display(Name = "Phone / WhatsApp")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "Visit date and time is required")]
    [Display(Name = "Preferred visit date & time")]
    public DateTime FechaHora { get; set; } = DateTime.Now.AddDays(1).Date.AddHours(10);

    [Required(ErrorMessage = "SSN or ITIN is required")]
    [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Enter a valid SSN, e.g. 121-22-1123")]
    [Display(Name = "SSN / ITIN")]
    public string SsnItin { get; set; } = string.Empty;
}
