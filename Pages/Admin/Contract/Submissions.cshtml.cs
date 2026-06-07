using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Contract;

public class SubmissionsModel(AppDbContext context) : PageModel
{
    public IList<ContractSubmission> Submissions { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Submissions = await context.ContractSubmissions
            .OrderByDescending(s => s.SubmittedAt)
            .ToListAsync();
    }

    public async Task<IActionResult> OnGetSignatureAsync(int id)
    {
        var submission = await context.ContractSubmissions.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        if (submission?.SignatureImageData is null || submission.SignatureImageData.Length == 0)
        {
            return NotFound();
        }

        return File(submission.SignatureImageData, submission.SignatureImageContentType ?? "image/png");
    }
}
