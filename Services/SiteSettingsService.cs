using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public class SiteSettingsService(AppDbContext context)
{
    public async Task<string> GetAgentWhatsAppAsync()
    {
        var settings = await context.SiteSettings
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == 1);

        return WhatsAppLinkHelper.NormalizePhone(settings?.AgentWhatsApp);
    }

    public async Task<string> GetAgentWhatsAppDisplayAsync() =>
        WhatsAppLinkHelper.FormatDisplay(await GetAgentWhatsAppAsync());

    public async Task<string> GetAgentWhatsAppChatUrlAsync(string? message = null)
    {
        var phone = await GetAgentWhatsAppAsync();
        return WhatsAppLinkHelper.BuildChatUrl(phone, message);
    }

    public async Task UpdateAgentWhatsAppAsync(string phone)
    {
        var normalized = WhatsAppLinkHelper.NormalizePhone(phone);
        var settings = await context.SiteSettings.FirstOrDefaultAsync(s => s.Id == 1);
        if (settings is null)
        {
            context.SiteSettings.Add(new SiteSettings
            {
                Id = 1,
                AgentWhatsApp = normalized
            });
        }
        else
        {
            settings.AgentWhatsApp = normalized;
        }

        await context.SaveChangesAsync();
    }

    public async Task EnsureSeededAsync()
    {
        if (await context.SiteSettings.AnyAsync(s => s.Id == 1))
        {
            return;
        }

        context.SiteSettings.Add(new SiteSettings
        {
            Id = 1,
            AgentWhatsApp = WhatsAppLinkHelper.DefaultAgentPhone
        });

        await context.SaveChangesAsync();
    }
}
