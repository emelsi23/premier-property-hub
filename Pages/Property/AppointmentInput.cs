using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Models;

namespace ApartamentosRenta.Pages.Property;

public class AppointmentInput : IValidatableObject
{
    [Required(ErrorMessage = "First name is required"), StringLength(80)]
    [Display(Name = "First name")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required"), StringLength(80)]
    [Display(Name = "Last name")]
    public string ApellidoCliente { get; set; } = string.Empty;

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

    [Required(ErrorMessage = "Visit date is required")]
    [Display(Name = "Visit date")]
    [DataType(DataType.Date)]
    public DateTime FechaCita { get; set; } = DateTime.Today.AddDays(1);

    [Required(ErrorMessage = "Visit time is required")]
    [Display(Name = "Visit time")]
    [DataType(DataType.Time)]
    public TimeSpan HoraCita { get; set; } = new(10, 0, 0);

    [StringLength(10)]
    [Display(Name = "Zip code")]
    public string? CodigoPostal { get; set; }

    [Required(ErrorMessage = "Please indicate if you are a U.S. citizen")]
    [Display(Name = "Are you a U.S. citizen?")]
    public bool? EsCiudadanoAmericano { get; set; }

    [Required(ErrorMessage = "Number of occupants is required")]
    [Range(1, 20, ErrorMessage = "Enter between 1 and 20 people")]
    [Display(Name = "How many people will live in the unit?")]
    public int? PersonasEnUnidad { get; set; } = 1;

    [Required(ErrorMessage = "Desired lease length is required"), StringLength(80)]
    [Display(Name = "How long do you want the lease?")]
    public string DuracionContratoDeseada { get; set; } = string.Empty;

    [Required(ErrorMessage = "Earliest move-in date is required")]
    [Display(Name = "Earliest move-in date")]
    [DataType(DataType.Date)]
    public DateTime? FechaMudanzaTemprana { get; set; } = DateTime.Today.AddDays(7);

    [Required(ErrorMessage = "Please indicate if anyone smokes")]
    [Display(Name = "Do you or anyone living in the unit smoke?")]
    public bool? Fuma { get; set; }

    [Required(ErrorMessage = "Please indicate your employment status")]
    [Display(Name = "Are you currently employed?")]
    public bool? EmpleadoActualmente { get; set; }

    [StringLength(120)]
    [Display(Name = "Employer / company name")]
    public string? NombreCompania { get; set; }

    [Display(Name = "Monthly or weekly income (USD)")]
    public decimal? Salario { get; set; }

    [Required(ErrorMessage = "Available funds amount is required")]
    [Range(0, 9999999, ErrorMessage = "Enter a valid amount")]
    [Display(Name = "How much do you have available now to secure the property? (USD)")]
    public decimal? DisponibleParaAsegurar { get; set; }

    [Required(ErrorMessage = "Please indicate if you have pets")]
    [Display(Name = "Do you have pets?")]
    public bool? TieneMascotas { get; set; }

    [Required(ErrorMessage = "Please confirm if you accept the reservation deposit")]
    [Display(Name = "Do you accept paying a reservation deposit if approved?")]
    public bool? AceptaDepositoReserva { get; set; }

    [Required(ErrorMessage = "Please indicate if you will pay for the certified visit")]
    [Display(Name = "Will you pay the certified visit fee ($150 USD)?")]
    public bool? PagaraCitaCertificada { get; set; }

    [Display(Name = "Payment method")]
    public MetodoPagoCita? MetodoPago { get; set; }

    [Required(ErrorMessage = "SSN or ITIN is required")]
    [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Enter a valid SSN, e.g. 121-22-1123")]
    [Display(Name = "SSN / ITIN")]
    public string SsnItin { get; set; } = string.Empty;

    [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and policies")]
    [Display(Name = "I agree to the terms and policies")]
    public bool AceptaTerminos { get; set; }

    public DateTime FechaHora =>
        FechaCita.Date.Add(HoraCita);

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EmpleadoActualmente == true)
        {
            if (string.IsNullOrWhiteSpace(NombreCompania))
            {
                yield return new ValidationResult(
                    "Employer name is required when employed.",
                    [nameof(NombreCompania)]);
            }

            if (Salario is null or <= 0)
            {
                yield return new ValidationResult(
                    "Enter your income when employed.",
                    [nameof(Salario)]);
            }
        }

        if (PagaraCitaCertificada == true && MetodoPago is null)
        {
            yield return new ValidationResult(
                "Select a payment method.",
                [nameof(MetodoPago)]);
        }

        if (PagaraCitaCertificada == false)
        {
            yield return new ValidationResult(
                "The certified visit requires the visit deposit to schedule a tour.",
                [nameof(PagaraCitaCertificada)]);
        }
    }
}
