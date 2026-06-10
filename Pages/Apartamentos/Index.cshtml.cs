using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Apartamentos;

public class IndexModel(AppDbContext context, SiteSettingsService siteSettings) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public CatalogFilterInput Filters { get; set; } = new();

    public IList<CatalogListing> Listings { get; private set; } = [];
    public IList<CatalogStateOption> StateOptions { get; private set; } = [];
    public int TotalAvailable { get; private set; }
    public decimal MinListingRent { get; private set; }
    public decimal MaxListingRent { get; private set; }
    public string WhatsAppUrl { get; private set; } = string.Empty;
    public string WhatsAppDisplay { get; private set; } = string.Empty;

    public async Task OnGetAsync()
    {
        var propiedades = await context.Propiedades
            .AsNoTracking()
            .Include(p => p.Fotos)
            .Where(p => p.Disponible)
            .OrderByDescending(p => p.FechaCreacion)
            .ToListAsync();

        TotalAvailable = propiedades.Count;
        var allListings = PropertyCatalogHelper.ToCatalogListings(propiedades).ToList();

        if (allListings.Count > 0)
        {
            MinListingRent = allListings.Min(p => p.PrecioMensual);
            MaxListingRent = allListings.Max(p => p.PrecioMensual);
        }

        StateOptions = allListings
            .Where(p => !string.IsNullOrWhiteSpace(p.StateCode))
            .GroupBy(p => p.StateCode!)
            .Select(g => new CatalogStateOption
            {
                Code = g.Key,
                Name = PropertyCatalogHelper.GetStateName(g.Key),
                Count = g.Count()
            })
            .OrderBy(s => s.Name)
            .ToList();

        Listings = PropertyCatalogHelper.ApplyFilters(allListings, Filters).ToList();

        WhatsAppDisplay = await siteSettings.GetAgentWhatsAppDisplayAsync();
        WhatsAppUrl = await siteSettings.GetAgentWhatsAppChatUrlAsync(
            "Hi, I'd like help finding a rental on Premier Property Hub.");
    }
}
