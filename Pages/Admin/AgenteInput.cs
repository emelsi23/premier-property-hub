using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Pages.Admin;

public class AgenteInput
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(120)]
    [Display(Name = "Nombre completo")]
    public string NombreCompleto { get; set; } = string.Empty;

    [StringLength(120)]
    [Display(Name = "Slug de URL (opcional)")]
    public string? Slug { get; set; }

    [StringLength(500)]
    [Display(Name = "URL de la foto (opcional si subes archivo)")]
    public string FotoUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "El rol o título es obligatorio.")]
    [StringLength(120)]
    [Display(Name = "Título / rol")]
    public string RolTitulo { get; set; } = "Agente inmobiliario RE/MAX";

    [Display(Name = "Calificación")]
    public decimal Calificacion { get; set; } = 4.9m;

    [Display(Name = "Total de reseñas")]
    public int TotalResenas { get; set; }

    [Required(ErrorMessage = "El número de licencia es obligatorio.")]
    [StringLength(80)]
    [Display(Name = "Número de licencia")]
    public string NumeroLicencia { get; set; } = string.Empty;

    [Required(ErrorMessage = "El estado de la licencia es obligatorio.")]
    [StringLength(40)]
    [Display(Name = "Estado de la licencia")]
    public string EstadoLicencia { get; set; } = string.Empty;

    [Display(Name = "Años de experiencia")]
    public int AnosExperiencia { get; set; }

    [Required(ErrorMessage = "La biografía es obligatoria.")]
    [StringLength(2000)]
    [Display(Name = "Biografía")]
    public string Biografia { get; set; } = string.Empty;

    [Required(ErrorMessage = "El WhatsApp personal del agente es obligatorio.")]
    [StringLength(30)]
    [Display(Name = "WhatsApp personal")]
    public string WhatsAppNumber { get; set; } = string.Empty;

    [StringLength(120)]
    [EmailAddress(ErrorMessage = "Email no válido.")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [StringLength(30)]
    [Display(Name = "Teléfono")]
    public string Telefono { get; set; } = string.Empty;

    [StringLength(300)]
    [Display(Name = "Áreas de servicio")]
    public string AreasServicio { get; set; } = string.Empty;

    [StringLength(200)]
    [Display(Name = "Idiomas")]
    public string Idiomas { get; set; } = "Español, Inglés";

    [Display(Name = "Propiedades activas")]
    public int PropiedadesActivas { get; set; }

    [Display(Name = "Tiempo de respuesta (horas)")]
    public decimal TiempoRespuestaHoras { get; set; } = 2m;

    [Display(Name = "% de respuesta")]
    public int PorcentajeRespuesta { get; set; } = 98;

    [StringLength(24)]
    [Display(Name = "Código de verificación")]
    public string? CodigoVerificacion { get; set; }

    [Display(Name = "Fecha de verificación")]
    [DataType(DataType.Date)]
    public DateTime? FechaVerificacion { get; set; }

    [Display(Name = "Perfil verificado")]
    public bool Verificado { get; set; } = true;

    [Display(Name = "Perfil activo (visible al público)")]
    public bool Activo { get; set; } = true;
}
