using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class StampSealContract
{
    public int Id { get; set; }

    public int PropiedadId { get; set; }

    public Propiedad Propiedad { get; set; } = null!;

    [Required, StringLength(200)]
    public string Title { get; set; } = "Stamps & Seals Purchase Agreement";

    [Required, StringLength(200)]
    public string Subtitle { get; set; } = "Official documentation · United States";

    [Required, StringLength(4000)]
    public string NoticeHtml { get; set; } = string.Empty;

    [Required]
    public string BodyHtml { get; set; } = string.Empty;

    [StringLength(200)]
    public string? TitleEs { get; set; }

    [StringLength(200)]
    public string? SubtitleEs { get; set; }

    [StringLength(4000)]
    public string? NoticeHtmlEs { get; set; }

    public string? BodyHtmlEs { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
