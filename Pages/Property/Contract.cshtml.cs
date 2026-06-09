using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Property;

public class ContractModel(
    AppDbContext context,
    SubmissionEmailService submissionEmailService) : PageModel
{
    private static readonly Regex DataUrlPattern = new(
        @"^data:(image/(?:png|jpeg|webp));base64,(.+)$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public Propiedad Propiedad { get; private set; } = null!;
    public string RenderedTitle { get; private set; } = string.Empty;
    public string RenderedSubtitle { get; private set; } = string.Empty;
    public string RenderedNoticeHtml { get; private set; } = string.Empty;
    public string RenderedBodyHtml { get; private set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        var propiedad = await LoadPropiedadAsync(slug);
        if (propiedad is null)
        {
            return NotFound();
        }

        ApplyRenderedContract(propiedad);
        return Page();
    }

    public async Task<IActionResult> OnPostSubmitAsync(string slug, [FromBody] ContractSubmitRequest request)
    {
        if (Request.Headers.XRequestedWith != "XMLHttpRequest")
        {
            return BadRequest();
        }

        var propiedad = await LoadPropiedadAsync(slug);
        if (propiedad is null)
        {
            return NotFound(new { success = false, message = "Property not found." });
        }

        if (string.IsNullOrWhiteSpace(request.TenantName))
        {
            return BadRequest(new { success = false, message = "Full name is required." });
        }

        if (string.IsNullOrWhiteSpace(request.TenantEmail) || !new EmailAddressAttribute().IsValid(request.TenantEmail))
        {
            return BadRequest(new { success = false, message = "Enter a valid email address." });
        }

        var action = request.Action?.Trim().ToLowerInvariant();
        if (action is not ("sign" or "changes"))
        {
            return BadRequest(new { success = false, message = "Choose to sign or submit changes." });
        }

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

        var submission = new ContractSubmission
        {
            PropiedadId = propiedad.Id,
            TenantName = request.TenantName.Trim(),
            TenantEmail = request.TenantEmail.Trim(),
            TenantPhone = string.IsNullOrWhiteSpace(request.TenantPhone) ? null : request.TenantPhone.Trim(),
            SubmissionType = action == "sign"
                ? ContractSubmissionType.Signature
                : ContractSubmissionType.ChangeRequest,
            SignatureImageData = signatureBytes,
            SignatureImageContentType = signatureContentType,
            ProposedChanges = proposedChanges,
            SubmittedAt = DateTime.UtcNow
        };

        context.ContractSubmissions.Add(submission);
        await context.SaveChangesAsync();
        await submissionEmailService.SendLeaseSubmissionAsync(submission, propiedad);

        return new JsonResult(new
        {
            success = true,
            submissionType = submission.SubmissionType.ToString(),
            message = submission.SubmissionType == ContractSubmissionType.Signature
                ? "Your signature has been submitted."
                : "Your proposed changes have been submitted."
        });
    }

    private void ApplyRenderedContract(Propiedad propiedad)
    {
        Propiedad = propiedad;
        var contract = propiedad.LeaseContract ?? LeaseContractDefaults.CreateForProperty(propiedad.Id);

        RenderedTitle = ContractTemplateRenderer.Render(contract.Title, propiedad);
        RenderedSubtitle = ContractTemplateRenderer.Render(contract.Subtitle, propiedad);
        RenderedNoticeHtml = ContractTemplateRenderer.Render(contract.NoticeHtml, propiedad);
        RenderedBodyHtml = ContractTemplateRenderer.Render(contract.BodyHtml, propiedad);
        ViewData["Title"] = RenderedTitle;
    }

    private Task<Propiedad?> LoadPropiedadAsync(string slug) =>
        context.Propiedades
            .Include(p => p.LeaseContract)
            .FirstOrDefaultAsync(p => p.Slug == slug && p.Disponible);
}

public class ContractSubmitRequest
{
    public string TenantName { get; set; } = string.Empty;
    public string TenantEmail { get; set; } = string.Empty;
    public string? TenantPhone { get; set; }
    public string? Action { get; set; }
    public string? SignatureDataUrl { get; set; }
    public string? ProposedChanges { get; set; }
}
