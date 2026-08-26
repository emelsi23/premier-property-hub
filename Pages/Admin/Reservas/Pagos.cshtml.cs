using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ApartamentosRenta.Pages.Admin.Reservas;

public class PagosModel(AppDbContext context, IOptions<AdminAuthSettings> authSettings) : PageModel
{
    [BindProperty]
    public PaymentSettingsInput Input { get; set; } = new();

    public bool HasBarcodeImage { get; private set; }

    public string? StatusMessage { get; private set; }

    public string CurrentUsername { get; private set; } = string.Empty;

    public string PublicReservaUrl { get; private set; } = string.Empty;

    public async Task OnGetAsync()
    {
        CurrentUsername = AdminUsers.CurrentUsername(User);
        PublicReservaUrl = AdminUsers.BuildReservaUrl(
            Request.Scheme,
            Request.Host,
            AdminUsers.CurrentPublicSlug(User, authSettings.Value));
        var settings = await ReservaPaymentSettingsService.GetOrCreateAsync(context, CurrentUsername);
        MapFrom(settings);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        CurrentUsername = AdminUsers.CurrentUsername(User);
        PublicReservaUrl = AdminUsers.BuildReservaUrl(
            Request.Scheme,
            Request.Host,
            AdminUsers.CurrentPublicSlug(User, authSettings.Value));
        var settings = await ReservaPaymentSettingsService.GetOrCreateAsync(context, CurrentUsername);
        HasBarcodeImage = settings.BarcodeImageData is { Length: > 0 };

        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (!Input.ZelleEnabled && !Input.BarcodeEnabled)
        {
            ModelState.AddModelError(string.Empty, "Debe dejar al menos un método de pago activo (Zelle o código de barras).");
            return Page();
        }

        settings.DepositAmount = Input.DepositAmount;
        settings.NoShowFee = Input.NoShowFee;
        settings.ZelleEnabled = Input.ZelleEnabled;
        settings.ZelleDisplayName = Input.ZelleDisplayName.Trim();
        settings.ZelleContact = Input.ZelleContact.Trim();
        settings.ZelleInstructions = Input.ZelleInstructions.Trim();
        settings.BarcodeEnabled = Input.BarcodeEnabled;
        settings.BarcodeInstructions = Input.BarcodeInstructions.Trim();
        settings.UpdatedAt = DateTime.UtcNow;

        if (Input.RemoveBarcodeImage)
        {
            settings.BarcodeImageData = null;
            settings.BarcodeImageContentType = null;
        }
        else if (Input.BarcodeImage is { Length: > 0 })
        {
            if (Input.BarcodeImage.Length > 8 * 1024 * 1024)
            {
                ModelState.AddModelError(nameof(Input.BarcodeImage), "La imagen no puede superar 8 MB.");
                return Page();
            }

            await using var ms = new MemoryStream();
            await Input.BarcodeImage.CopyToAsync(ms);
            settings.BarcodeImageData = ms.ToArray();
            settings.BarcodeImageContentType = string.IsNullOrWhiteSpace(Input.BarcodeImage.ContentType)
                ? "image/png"
                : Input.BarcodeImage.ContentType;
        }

        await context.SaveChangesAsync();
        MapFrom(settings);
        StatusMessage = "Métodos de pago y montos actualizados (solo para su cuenta).";
        return Page();
    }

    public async Task<IActionResult> OnGetBarcodeAsync()
    {
        var me = AdminUsers.CurrentUsername(User);
        var settings = await ReservaPaymentSettingsService.GetOrCreateAsync(context, me);
        if (settings.BarcodeImageData is null || settings.BarcodeImageData.Length == 0)
        {
            return NotFound();
        }

        return File(settings.BarcodeImageData, settings.BarcodeImageContentType ?? "image/png");
    }

    private void MapFrom(ReservaPaymentSettings settings)
    {
        HasBarcodeImage = settings.BarcodeImageData is { Length: > 0 };
        Input = new PaymentSettingsInput
        {
            DepositAmount = settings.DepositAmount,
            NoShowFee = settings.NoShowFee,
            ZelleEnabled = settings.ZelleEnabled,
            ZelleDisplayName = settings.ZelleDisplayName,
            ZelleContact = settings.ZelleContact,
            ZelleInstructions = settings.ZelleInstructions,
            BarcodeEnabled = settings.BarcodeEnabled,
            BarcodeInstructions = settings.BarcodeInstructions
        };
    }
}

public class PaymentSettingsInput
{
    [Range(1, 999999), Display(Name = "Monto del depósito (USD)")]
    public decimal DepositAmount { get; set; } = 150m;

    [Range(0, 999999), Display(Name = "Cargo por no-show (USD)")]
    public decimal NoShowFee { get; set; } = 10m;

    [Display(Name = "Zelle activo")]
    public bool ZelleEnabled { get; set; } = true;

    [Required, StringLength(120), Display(Name = "Nombre Zelle")]
    public string ZelleDisplayName { get; set; } = "Premier Property Hub";

    [StringLength(120), Display(Name = "Correo / teléfono Zelle")]
    public string ZelleContact { get; set; } = string.Empty;

    [StringLength(500), Display(Name = "Instrucciones Zelle")]
    public string ZelleInstructions { get; set; } = string.Empty;

    [Display(Name = "Código de barras activo")]
    public bool BarcodeEnabled { get; set; } = true;

    [StringLength(500), Display(Name = "Instrucciones código de barras")]
    public string BarcodeInstructions { get; set; } = string.Empty;

    [Display(Name = "Imagen del código de barras")]
    public IFormFile? BarcodeImage { get; set; }

    [Display(Name = "Eliminar imagen actual")]
    public bool RemoveBarcodeImage { get; set; }
}
