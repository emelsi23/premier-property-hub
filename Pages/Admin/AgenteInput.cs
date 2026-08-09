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

    [Required(ErrorMessage = "La URL de la foto es obligatoria.")]
    [StringLength(500)]
    [Display(Name = "URL de la foto")]
    public string FotoUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "El rol o título es obligatorio.")]
    [StringLength(120)]
    [Display(Name = "Título / rol")]
    public string RolTitulo { get; set; } = "Agente inmobiliario RE/MAX";

    [Range(0, 5, ErrorMessage = "La calificación debe estar entre 0 y 5.")]
    [Display(Name = "Calificación (0–5)")]
    public decimal Calificacion { get; set; } = 4.9m;

    [Range(0, 99999)]
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

    [Range(0, 60)]
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

    [Range(0, 9999)]
    [Display(Name = "Propiedades activas")]
    public int PropiedadesActivas { get; set; }

    [Range(0, 168)]
    [Display(Name = "Tiempo de respuesta (horas)")]
    public decimal TiempoRespuestaHoras { get; set; } = 2m;

    [Range(0, 100)]
    [Display(Name = "% de respuesta")]
    public int PorcentajeRespuesta { get; set; } = 98;

    [StringLength(24)]
    [Display(Name = "Código de verificación")]
    public string? CodigoVerificacion { get; set; }

    [Display(Name = "Perfil verificado")]
    public bool Verificado { get; set; } = true;

    [Display(Name = "Perfil activo (visible al público)")]
    public bool Activo { get; set; } = true;
}
