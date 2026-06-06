using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Property;

public class ViewModel(AppDbContext context) : PageModel
{
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

        if (Appointment.FechaHora <= DateTime.Now)
        {
            ModelState.AddModelError("Appointment.FechaHora", "Please choose a future date and time.");
            return isAjax ? AjaxValidationError() : Page();
        }

        if (Appointment.FechaNacimiento.Date >= DateTime.Today)
        {
            ModelState.AddModelError("Appointment.FechaNacimiento", "Please enter a valid date of birth.");
            return isAjax ? AjaxValidationError() : Page();
        }

        context.Citas.Add(new Cita
        {
            PropiedadId = propiedad.Id,
            NombreCliente = Appointment.NombreCliente.Trim(),
            Email = Appointment.Email.Trim(),
            Telefono = Appointment.Telefono.Trim(),
            FechaNacimiento = Appointment.FechaNacimiento.Date,
            SsnItin = Appointment.SsnItin.Trim(),
            FechaHora = Appointment.FechaHora
        });

        await context.SaveChangesAsync();

        return isAjax
            ? new JsonResult(new { success = true })
            : RedirectToPage("/Property/ThankYou", new { slug });
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
