using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Property;

public class StampsModel(AppDbContext context) : PageModel
{
    private static readonly Regex DataUrlPattern = new(
        @"^data:(image/(?:png|jpeg|webp));base64,(.+)$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public Propiedad Propiedad { get; private set; } = null!;
    public PropertyApplicationStrings Strings { get; private set; } = null!;
    public PropertyContractUiStrings Ui { get; private set; } = null!;
    public PropertyStampUiStrings StampUi { get; private set; } = null!;
    public PropertyContentLanguage ActiveLanguage { get; private set; }
    public bool ShowLanguageSwitcher { get; private set; }
    public string RenderedTitle { get; private set; } = string.Empty;
    public string RenderedSubtitle { get; private set; } = string.Empty;
    public string RenderedNoticeHtml { get; private set; } = string.Empty;
    public string RenderedBodyHtml { get; private set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string slug, string? lang)
    {
        var propiedad = await LoadPropiedadAsync(slug);
        if (propiedad is null || !propiedad.MostrarStampillasPublico)
        {
            return NotFound();
        }

        ApplyPageContext(propiedad, lang);
        return Page();
    }

    public async Task<IActionResult> OnPostSubmitAsync(string slug, [FromBody] StampSealSubmitRequest request)
    {
        if (Request.Headers.XRequestedWith != "XMLHttpRequest")
        {
            return BadRequest();
        }

        var propiedad = await LoadPropiedadAsync(slug);
        if (propiedad is null || !propiedad.MostrarStampillasPublico)
        {
            return NotFound(new { success = false, message = "Property not found." });
        }

        if (string.IsNullOrWhiteSpace(request.ClientName))
        {
            return BadRequest(new { success = false, message = "Full name is required." });
        }

        if (string.IsNullOrWhiteSpace(request.ClientEmail) || !new EmailAddressAttribute().IsValid(request.ClientEmail))
        {
            return BadRequest(new { success = false, message = "Enter a valid email address." });
        }

        var action = request.Action?.Trim().ToLowerInvariant();
        if (action is not ("sign" or "changes"))
        {
            return BadRequest(new { success = false, message = "Choose to sign or submit changes." });
        }

        if (!StampSealSettings.TryParseOption(request.PurchaseOption, out var purchaseOption))
        {
            return BadRequest(new { success = false, message = "Select stamps, seals, or both." });
        }

        var selectedAmount = StampSealSettings.GetAmount(purchaseOption);
        byte[]? signatureBytes = null;
        string? signatureContentType = null;
        var proposedChanges = string.IsNullOrWhiteSpace(request.ProposedChanges)
            ? null
            : request.ProposedChanges.Trim();

        if (action == "sign")
        {
            if (string.IsNullOrWhiteSpace(request.SignatureDataUrl))
            {
                return BadRequest(new { success = false, message = "Please draw your signature." });
            }

            var match = DataUrlPattern.Match(request.SignatureDataUrl);
            if (!match.Success)
            {
                return BadRequest(new { success = false, message = "Invalid signature image." });
            }

            signatureContentType = match.Groups[1].Value;
            try
            {
                signatureBytes = Convert.FromBase64String(match.Groups[2].Value);
            }
            catch
            {
                return BadRequest(new { success = false, message = "Invalid signature image." });
            }

            if (signatureBytes.Length > 512 * 1024)
            {
                return BadRequest(new { success = false, message = "Signature image is too large." });
            }
        }
        else if (string.IsNullOrWhiteSpace(proposedChanges))
        {
            return BadRequest(new { success = false, message = "Describe the changes you are requesting." });
        }

        context.StampSealSubmissions.Add(new StampSealSubmission
        {
            PropiedadId = propiedad.Id,
            ClientName = request.ClientName.Trim(),
            ClientEmail = request.ClientEmail.Trim(),
            ClientPhone = string.IsNullOrWhiteSpace(request.ClientPhone) ? null : request.ClientPhone.Trim(),
            SubmissionType = action == "sign"
                ? ContractSubmissionType.Signature
                : ContractSubmissionType.ChangeRequest,
            PurchaseOption = purchaseOption,
            SelectedAmount = selectedAmount,
            SignatureImageData = signatureBytes,
            SignatureImageContentType = signatureContentType,
            ProposedChanges = proposedChanges,
            SubmittedAt = DateTime.UtcNow
        });
        await context.SaveChangesAsync();

        return new JsonResult(new
        {
            success = true,
            message = action == "sign"
                ? "Your signature has been submitted."
                : "Your proposed changes have been submitted."
        });
    }

    private void ApplyPageContext(Propiedad propiedad, string? lang)
    {
        Propiedad = propiedad;
        ActiveLanguage = PropertyPageLanguageHelper.Resolve(propiedad.IdiomaPublico, lang);
        ShowLanguageSwitcher = PropertyPageLanguageHelper.ShowLanguageSwitcher(propiedad.IdiomaPublico);
        Strings = PropertyApplicationStrings.Get(ActiveLanguage, StampSealSettings.TotalAmount);
        Ui = PropertyContractUiStrings.Get(ActiveLanguage);
        StampUi = PropertyStampUiStrings.Get(ActiveLanguage);

        var contract = propiedad.StampSealContract ?? StampSealContractDefaults.CreateForProperty(propiedad.Id);
        var content = PropertyContractContentHelper.GetStampSealContent(contract, ActiveLanguage);

        RenderedTitle = StampSealTemplateRenderer.Render(content.Title, propiedad);
        RenderedSubtitle = StampSealTemplateRenderer.Render(content.Subtitle, propiedad);
        RenderedNoticeHtml = StampSealTemplateRenderer.Render(content.NoticeHtml, propiedad);
        RenderedBodyHtml = StampSealContractDynamicEnricher.Enrich(
            StampSealTemplateRenderer.Render(content.BodyHtml, propiedad));
        ViewData["Title"] = RenderedTitle;
    }

    private Task<Propiedad?> LoadPropiedadAsync(string slug) =>
        context.Propiedades
            .Include(p => p.StampSealContract)
            .FirstOrDefaultAsync(p => p.Slug == slug && p.Disponible);
}

public class StampSealSubmitRequest
{
    public string ClientName { get; set; } = string.Empty;
    public string ClientEmail { get; set; } = string.Empty;
    public string? ClientPhone { get; set; }
    public string? Action { get; set; }
    public string? PurchaseOption { get; set; }
    public string? SignatureDataUrl { get; set; }
    public string? ProposedChanges { get; set; }
}
