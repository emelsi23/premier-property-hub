using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;

namespace ApartamentosRenta.Pages.Admin;

public class PropertyInput
{
    [Required, StringLength(120), Display(Name = "Title")]
    public string Titulo { get; set; } = string.Empty;

    [Required, StringLength(2000), Display(Name = "Description")]
    public string Descripcion { get; set; } = string.Empty;

    [Required, StringLength(200), Display(Name = "Address")]
    public string Direccion { get; set; } = string.Empty;

    [Required, StringLength(80), Display(Name = "City")]
    public string Ciudad { get; set; } = string.Empty;

    [Range(1, 999999), Display(Name = "Monthly rent")]
    public decimal PrecioMensual { get; set; }

    [Range(0, 20), Display(Name = "Bedrooms")]
    public int Habitaciones { get; set; } = 1;

    [Range(1, 10), Display(Name = "Bathrooms")]
    public int Banos { get; set; } = 1;

    [Range(10, 10000), Display(Name = "Square feet")]
    public decimal MetrosCuadrados { get; set; }

    [Display(Name = "Available")]
    public bool Disponible { get; set; } = true;

    [StringLength(500), Display(Name = "Amenities")]
    public string Amenidades { get; set; } = string.Empty;

    [Required(ErrorMessage = "Add at least one photo URL")]
    [Display(Name = "Photos (one URL per line)")]
    public string FotosUrls { get; set; } = string.Empty;

    [StringLength(120), Display(Name = "Zelle display name")]
    public string ZelleDisplayName { get; set; } = string.Empty;

    [StringLength(120), Display(Name = "Zelle email or phone")]
    public string ZelleContact { get; set; } = string.Empty;

    [Range(1, 999999), Display(Name = "Zelle visit deposit (USD)")]
    public decimal DepositAmount { get; set; } = VisitDepositSettings.DefaultAmount;

    [Range(1, 999999), Display(Name = "Stamps fee (USD)")]
    public decimal StampsAmount { get; set; } = StampSealSettings.DefaultStampsAmount;

    [Range(1, 999999), Display(Name = "Seals fee (USD)")]
    public decimal SealsAmount { get; set; } = StampSealSettings.DefaultSealsAmount;

    [StringLength(200), Display(Name = "Contract title")]
    public string ContractTitle { get; set; } = "Residential Lease Agreement";

    [StringLength(200), Display(Name = "Contract subtitle")]
    public string ContractSubtitle { get; set; } = "Apartment rental · United States";

    [Display(Name = "Contract notice (HTML)")]
    public string ContractNoticeHtml { get; set; } = LeaseContractDefaults.NoticeHtml;

    [Display(Name = "Contract body (HTML)")]
    public string ContractBodyHtml { get; set; } = LeaseContractDefaults.BodyHtml;

    [StringLength(200), Display(Name = "Stamps & seals title")]
    public string StampSealTitle { get; set; } = "Stamps & Seals Purchase Agreement";

    [StringLength(200), Display(Name = "Stamps & seals subtitle")]
    public string StampSealSubtitle { get; set; } = "Official documentation · United States";

    [Display(Name = "Stamps & seals notice (HTML)")]
    public string StampSealNoticeHtml { get; set; } = StampSealContractDefaults.NoticeHtml;

    [Display(Name = "Stamps & seals body (HTML)")]
    public string StampSealBodyHtml { get; set; } = StampSealContractDefaults.BodyHtml;

    public IEnumerable<string> ParseFotoUrls() =>
        FotosUrls
            .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(url => !string.IsNullOrWhiteSpace(url));

    public static PropertyInput FromEntity(Propiedad entity) => new()
    {
        Titulo = entity.Titulo,
        Descripcion = entity.Descripcion,
        Direccion = entity.Direccion,
        Ciudad = entity.Ciudad,
        PrecioMensual = entity.PrecioMensual,
        Habitaciones = entity.Habitaciones,
        Banos = entity.Banos,
        MetrosCuadrados = entity.MetrosCuadrados,
        Disponible = entity.Disponible,
        Amenidades = entity.Amenidades,
        ZelleDisplayName = entity.ZelleDisplayName,
        ZelleContact = entity.ZelleContact,
        DepositAmount = entity.DepositAmount > 0 ? entity.DepositAmount : VisitDepositSettings.DefaultAmount,
        StampsAmount = entity.StampsAmount > 0 ? entity.StampsAmount : StampSealSettings.DefaultStampsAmount,
        SealsAmount = entity.SealsAmount > 0 ? entity.SealsAmount : StampSealSettings.DefaultSealsAmount,
        FotosUrls = string.Join(Environment.NewLine, entity.Fotos.OrderBy(f => f.Orden).Select(f => f.Url)),
        ContractTitle = entity.LeaseContract?.Title ?? "Residential Lease Agreement",
        ContractSubtitle = entity.LeaseContract?.Subtitle ?? "Apartment rental · United States",
        ContractNoticeHtml = entity.LeaseContract?.NoticeHtml ?? LeaseContractDefaults.NoticeHtml,
        ContractBodyHtml = entity.LeaseContract?.BodyHtml ?? LeaseContractDefaults.BodyHtml,
        StampSealTitle = entity.StampSealContract?.Title ?? "Stamps & Seals Purchase Agreement",
        StampSealSubtitle = entity.StampSealContract?.Subtitle ?? "Official documentation · United States",
        StampSealNoticeHtml = entity.StampSealContract?.NoticeHtml ?? StampSealContractDefaults.NoticeHtml,
        StampSealBodyHtml = entity.StampSealContract?.BodyHtml ?? StampSealContractDefaults.BodyHtml
    };
}
