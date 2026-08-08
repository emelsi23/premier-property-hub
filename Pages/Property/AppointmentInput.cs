using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Models;

namespace ApartamentosRenta.Pages.Property;

public class AppointmentInput : IValidatableObject
{
    [Required(ErrorMessage = "El nombre es obligatorio."), StringLength(80)]
    [Display(Name = "Nombre")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio."), StringLength(80)]
    [Display(Name = "Apellido")]
    public string ApellidoCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [Display(Name = "Fecha de nacimiento")]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; } = DateTime.Today.AddYears(-25);

    [Required(ErrorMessage = "El correo electrónico es obligatorio."), StringLength(256)]
    [EmailAddress(ErrorMessage = "Ingresa un correo electrónico válido.")]
    [Display(Name = "Correo electrónico")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio."), StringLength(14)]
    [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Ingresa un número válido, ej. (809) 690-9988")]
    [Display(Name = "Teléfono / WhatsApp")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de visita es obligatoria.")]
    [Display(Name = "Fecha de visita")]
    [DataType(DataType.Date)]
    public DateTime FechaCita { get; set; } = DateTime.Today.AddDays(1);

    [Required(ErrorMessage = "La hora de visita es obligatoria.")]
    [Display(Name = "Hora de visita")]
    [DataType(DataType.Time)]
    public TimeSpan HoraCita { get; set; } = new(10, 0, 0);

    [StringLength(10)]
    [Display(Name = "Código postal")]
    public string? CodigoPostal { get; set; }

    [Required(ErrorMessage = "Indica si eres ciudadano de EE. UU.")]
    [Display(Name = "¿Eres ciudadano de EE. UU.?")]
    public bool? EsCiudadanoAmericano { get; set; }

    [Required(ErrorMessage = "Indica cuántas personas vivirán en la unidad.")]
    [Range(1, 20, ErrorMessage = "Ingresa entre 1 y 20 personas.")]
    [Display(Name = "¿Cuántas personas vivirán en la unidad?")]
    public int? PersonasEnUnidad { get; set; } = 1;

    [Required(ErrorMessage = "Indica la duración del contrato deseada."), StringLength(80)]
    [Display(Name = "¿Cuánto tiempo quieres el contrato?")]
    public string DuracionContratoDeseada { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de mudanza es obligatoria.")]
    [Display(Name = "Fecha de mudanza más temprana")]
    [DataType(DataType.Date)]
    public DateTime? FechaMudanzaTemprana { get; set; } = DateTime.Today.AddDays(7);

    [Required(ErrorMessage = "Indica si alguien fuma en la unidad.")]
    [Display(Name = "¿Tú o alguien en la unidad fuma?")]
    public bool? Fuma { get; set; }

    [Required(ErrorMessage = "Indica si estás empleado actualmente.")]
    [Display(Name = "¿Estás empleado actualmente?")]
    public bool? EmpleadoActualmente { get; set; }

    [StringLength(120)]
    [Display(Name = "Nombre del empleador / empresa")]
    public string? NombreCompania { get; set; }

    [Display(Name = "Ingreso mensual o semanal (USD)")]
    public decimal? Salario { get; set; }

    [Required(ErrorMessage = "Indica cuánto tienes disponible para asegurar la propiedad.")]
    [Range(0, 9999999, ErrorMessage = "Ingresa un monto válido.")]
    [Display(Name = "¿Cuánto tienes disponible ahora para asegurar la propiedad? (USD)")]
    public decimal? DisponibleParaAsegurar { get; set; }

    [Required(ErrorMessage = "Indica si tienes mascotas.")]
    [Display(Name = "¿Tienes mascotas?")]
    public bool? TieneMascotas { get; set; }

    [Required(ErrorMessage = "Confirma si aceptas el depósito de reserva.")]
    [Display(Name = "¿Aceptas pagar un depósito de reserva si eres aprobado?")]
    public bool? AceptaDepositoReserva { get; set; }

    [Required(ErrorMessage = "Indica si pagarás la visita certificada.")]
    [Display(Name = "¿Pagarás la tarifa de visita certificada?")]
    public bool? PagaraCitaCertificada { get; set; }

    [Display(Name = "Método de pago")]
    public MetodoPagoCita? MetodoPago { get; set; }

    [StringLength(11)]
    [RegularExpression(@"^(\d{3}-\d{2}-\d{4})?$", ErrorMessage = "Ingresa un SSN válido, ej. 121-22-1123")]
    [Display(Name = "SSN / ITIN (opcional)")]
    public string? SsnItin { get; set; }

    [Range(typeof(bool), "true", "true", ErrorMessage = "Debes aceptar los términos y políticas.")]
    [Display(Name = "Acepto los términos y políticas")]
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
                    "El nombre del empleador es obligatorio si estás empleado.",
                    [nameof(NombreCompania)]);
            }

            if (Salario is null or <= 0)
            {
                yield return new ValidationResult(
                    "Ingresa tu ingreso si estás empleado.",
                    [nameof(Salario)]);
            }
        }

        if (PagaraCitaCertificada == false)
        {
            yield return new ValidationResult(
                "La visita certificada requiere el depósito de visita para agendar el tour.",
                [nameof(PagaraCitaCertificada)]);
        }
    }
}
