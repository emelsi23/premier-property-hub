using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public class LeaseContract
{
    public int Id { get; set; } = 1;

    [Required, StringLength(200)]
    public string Title { get; set; } = "Residential Lease Agreement";

    [Required, StringLength(200)]
    public string Subtitle { get; set; } = "Apartment rental · United States";

    [Required, StringLength(4000)]
    public string NoticeHtml { get; set; } = string.Empty;

    [Required]
    public string BodyHtml { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
