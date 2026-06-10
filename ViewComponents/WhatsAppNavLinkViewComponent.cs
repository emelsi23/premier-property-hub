using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApartamentosRenta.ViewComponents;

public class WhatsAppNavLinkViewComponent(SiteSettingsService siteSettings) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(bool compact = false)
    {
        var display = await siteSettings.GetAgentWhatsAppDisplayAsync();
        var url = await siteSettings.GetAgentWhatsAppChatUrlAsync(
            "Hi, I'd like help finding a rental on Premier Property Hub.");

        return View(new WhatsAppNavLinkModel(display, url, compact));
    }
}

public sealed record WhatsAppNavLinkModel(string Display, string Url, bool Compact);
