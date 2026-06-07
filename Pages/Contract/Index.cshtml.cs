using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Contract;

public class IndexModel(AppDbContext context) : PageModel
{
    private static readonly Regex DataUrlPattern = new(
        @"^data:(image/(?:png|jpeg|webp));base64,(.+)$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public LeaseContract Contract { get; private set; } = null!;

    public async Task<IActionResult> OnGetAsync()
    {
        Contract = await LoadContractAsync();
        ViewData["Title"] = Contract.Title;
        return Page();
    }

    public async Task<IActionResult> OnPostSubmitAsync([FromBody] ContractSubmitRequest request)
    {
        if (Request.Headers.XRequestedWith != "XMLHttpRequest")
        {
            return BadRequest();
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

        return new JsonResult(new
        {
            success = true,
            submissionType = submission.SubmissionType.ToString(),
            message = submission.SubmissionType == ContractSubmissionType.Signature
                ? "Your signature has been submitted."
                : "Your proposed changes have been submitted."
        });
    }

    private async Task<LeaseContract> LoadContractAsync()
    {
        var contract = await context.LeaseContracts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == 1);
        return contract ?? LeaseContractDefaults.Create();
    }
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
