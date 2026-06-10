using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApartamentosRenta.ViewComponents;

public class WhatsAppNavLinkViewComponent(SiteSettingsService siteSettings) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var display = await siteSettings.GetAgentWhatsAppDisplayAsync();
        var url = await siteSettings.GetAgentWhatsAppChatUrlAsync(
            "Hi, I'd like help finding a rental on Premier Property Hub.");

        return View(new WhatsAppNavLinkModel(display, url));
    }
}

public sealed record WhatsAppNavLinkModel(string Display, string Url);
