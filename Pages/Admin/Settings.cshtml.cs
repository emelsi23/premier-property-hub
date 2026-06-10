using System.ComponentModel.DataAnnotations;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartamentosRenta.Pages.Admin;

public class SettingsModel(SiteSettingsService siteSettings) : PageModel
{
    [BindProperty]
    public SettingsInput Input { get; set; } = new();

    public string? StatusMessage { get; private set; }
    public string PreviewUrl { get; private set; } = string.Empty;
    public string PreviewDisplay { get; private set; } = string.Empty;

    public async Task OnGetAsync(string? saved)
    {
        if (saved == "1")
        {
            StatusMessage = "Settings saved.";
        }

        await LoadAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadPreviewAsync(Input.AgentWhatsApp);
            return Page();
        }

        await siteSettings.UpdateAgentWhatsAppAsync(Input.AgentWhatsApp);
        return RedirectToPage(new { saved = "1" });
    }

    private async Task LoadAsync()
    {
        var phone = await siteSettings.GetAgentWhatsAppAsync();
        Input.AgentWhatsApp = WhatsAppLinkHelper.FormatDisplay(phone);
        await LoadPreviewAsync(phone);
    }

    private Task LoadPreviewAsync(string phone)
    {
        PreviewDisplay = WhatsAppLinkHelper.FormatDisplay(phone);
        PreviewUrl = WhatsAppLinkHelper.BuildChatUrl(
            phone,
            "Hi, I'd like help with a rental on Premier Property Hub.");
        return Task.CompletedTask;
    }

    public sealed class SettingsInput
    {
        [Required(ErrorMessage = "Enter a WhatsApp number.")]
        [StringLength(30, ErrorMessage = "Use at most 30 characters.")]
        [Display(Name = "Agent WhatsApp number")]
        public string AgentWhatsApp { get; set; } = string.Empty;
    }
}
