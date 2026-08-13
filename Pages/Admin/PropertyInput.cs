using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Http;

namespace ApartamentosRenta.Pages.Admin;

public class PropertyInput
{
    [Required, StringLength(120), Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required, StringLength(2000), Display(Name = "Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    [Required, StringLength(200), Display(Name = "Dirección")]
    public string Direccion { get; set; } = string.Empty;

    [Required, StringLength(80), Display(Name = "Ciudad")]
    public string Ciudad { get; set; } = string.Empty;

    [Range(1, 999999), Display(Name = "Alquiler mensual")]
    public decimal PrecioMensual { get; set; }

    [Range(0, 20), Display(Name = "Habitaciones")]
    public int Habitaciones { get; set; } = 1;

    [Range(1, 10), Display(Name = "Baños")]
    public int Banos { get; set; } = 1;

    [Range(10, 10000), Display(Name = "Metros cuadrados")]
    public decimal MetrosCuadrados { get; set; }

    [Display(Name = "Disponible")]
    public bool Disponible { get; set; } = true;

    [StringLength(500), Display(Name = "Amenidades")]
    public string Amenidades { get; set; } = string.Empty;

    [Display(Name = "URLs externas (opcional)")]
    public string FotosUrls { get; set; } = string.Empty;

    [StringLength(120), Display(Name = "Nombre para mostrar en Zelle")]
    public string ZelleDisplayName { get; set; } = string.Empty;

    [StringLength(120), Display(Name = "Email o teléfono Zelle")]
    public string ZelleContact { get; set; } = string.Empty;

    [StringLength(30), Display(Name = "Número de WhatsApp (clientes)")]
    public string WhatsAppNumber { get; set; } = string.Empty;

    [Range(1, 999999), Display(Name = "Depósito de visita Zelle (USD)")]
    public decimal DepositAmount { get; set; } = VisitDepositSettings.DefaultAmount;

    [Range(1, 999999), Display(Name = "Tarifa estampillas (USD)")]
    public decimal StampsAmount { get; set; } = StampSealSettings.DefaultStampsAmount;

    [Range(1, 999999), Display(Name = "Tarifa sellos (USD)")]
    public decimal SealsAmount { get; set; } = StampSealSettings.DefaultSealsAmount;

    [StringLength(200), Display(Name = "Título del contrato")]
    public string ContractTitle { get; set; } = "Contrato de arrendamiento residencial";

    [StringLength(200), Display(Name = "Subtítulo del contrato")]
    public string ContractSubtitle { get; set; } = "Alquiler de apartamento · Estados Unidos";

    [Display(Name = "Aviso del contrato (HTML)")]
    public string ContractNoticeHtml { get; set; } = LeaseContractDefaults.NoticeHtml;

    [Display(Name = "Contenido del contrato (HTML)")]
    public string ContractBodyHtml { get; set; } = LeaseContractDefaults.BodyHtml;

    [StringLength(200), Display(Name = "Título estampillas y sellos")]
    public string StampSealTitle { get; set; } = "Acuerdo de compra de estampillas y sellos";

    [StringLength(200), Display(Name = "Subtítulo estampillas y sellos")]
    public string StampSealSubtitle { get; set; } = "Documentación oficial · Estados Unidos";

    [Display(Name = "Aviso estampillas y sellos (HTML)")]
    public string StampSealNoticeHtml { get; set; } = StampSealContractDefaults.NoticeHtml;

    [Display(Name = "Contenido estampillas y sellos (HTML)")]
    public string StampSealBodyHtml { get; set; } = StampSealContractDefaults.BodyHtml;

    public IEnumerable<string> ParseFotoUrls() =>
        FotosUrls
            .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(url => !string.IsNullOrWhiteSpace(url));

    public static bool HasPhotoSources(IEnumerable<string> urls, IReadOnlyList<IFormFile>? uploads) =>
        urls.Any() || uploads?.Any(file => file.Length > 0) == true;

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
        WhatsAppNumber = entity.WhatsAppNumber,
        DepositAmount = entity.DepositAmount > 0 ? entity.DepositAmount : VisitDepositSettings.DefaultAmount,
        StampsAmount = entity.StampsAmount > 0 ? entity.StampsAmount : StampSealSettings.DefaultStampsAmount,
        SealsAmount = entity.SealsAmount > 0 ? entity.SealsAmount : StampSealSettings.DefaultSealsAmount,
        FotosUrls = string.Join(Environment.NewLine, entity.Fotos.OrderBy(f => f.Orden).Select(f => f.Url)),
        ContractTitle = entity.LeaseContract?.Title ?? "Contrato de arrendamiento residencial",
        ContractSubtitle = entity.LeaseContract?.Subtitle ?? "Alquiler de apartamento · Estados Unidos",
        ContractNoticeHtml = entity.LeaseContract?.NoticeHtml ?? LeaseContractDefaults.NoticeHtml,
        ContractBodyHtml = entity.LeaseContract?.BodyHtml ?? LeaseContractDefaults.BodyHtml,
        StampSealTitle = entity.StampSealContract?.Title ?? "Acuerdo de compra de estampillas y sellos",
        StampSealSubtitle = entity.StampSealContract?.Subtitle ?? "Documentación oficial · Estados Unidos",
        StampSealNoticeHtml = entity.StampSealContract?.NoticeHtml ?? StampSealContractDefaults.NoticeHtml,
        StampSealBodyHtml = entity.StampSealContract?.BodyHtml ?? StampSealContractDefaults.BodyHtml
    };
}
