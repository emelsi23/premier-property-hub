using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Contract;

public class EditModel(AppDbContext context) : PageModel
{
    [BindProperty]
    public ContractInput Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        var contract = await GetOrCreateContractAsync();
        Input = ContractInput.FromEntity(contract);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var contract = await GetOrCreateContractAsync();
        contract.Title = Input.Title.Trim();
        contract.Subtitle = Input.Subtitle.Trim();
        contract.NoticeHtml = Input.NoticeHtml.Trim();
        contract.BodyHtml = Input.BodyHtml.Trim();
        contract.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
        TempData["Success"] = "Contract updated successfully.";
        return RedirectToPage();
    }

    private async Task<LeaseContract> GetOrCreateContractAsync()
    {
        var contract = await context.LeaseContracts.FirstOrDefaultAsync(c => c.Id == 1);
        if (contract is not null)
        {
            return contract;
        }

        contract = LeaseContractDefaults.Create();
        context.LeaseContracts.Add(contract);
        await context.SaveChangesAsync();
        return contract;
    }
}

public class ContractInput
{
    [Required, StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string Subtitle { get; set; } = string.Empty;

    [Required, StringLength(4000)]
    public string NoticeHtml { get; set; } = string.Empty;

    [Required]
    public string BodyHtml { get; set; } = string.Empty;

    public static ContractInput FromEntity(LeaseContract entity) => new()
    {
        Title = entity.Title,
        Subtitle = entity.Subtitle,
        NoticeHtml = entity.NoticeHtml,
        BodyHtml = entity.BodyHtml
    };
}
