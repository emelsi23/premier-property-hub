using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Apartamentos;

public class IndexModel(AppDbContext context) : PageModel
{
    private const string DefaultWhatsAppUrl = "https://wa.me/19453846408?text=Hi%2C%20I%27d%20like%20help%20finding%20a%20rental%20on%20Premier%20Property%20Hub.";

    [BindProperty(SupportsGet = true)]
    public CatalogFilterInput Filters { get; set; } = new();

    public IList<CatalogListing> Listings { get; private set; } = [];
    public IList<CatalogStateOption> StateOptions { get; private set; } = [];
    public int TotalAvailable { get; private set; }
    public int TotalFiltered { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; } = PropertyCatalogHelper.DefaultPageSize;
    public decimal MinListingRent { get; private set; }
    public decimal MaxListingRent { get; private set; }
    public string WhatsAppUrl { get; } = DefaultWhatsAppUrl;

    public async Task OnGetAsync()
    {
        var availableQuery = context.Propiedades.AsNoTracking().Where(p => p.Disponible);
        TotalAvailable = await availableQuery.CountAsync();

        if (TotalAvailable > 0)
        {
            var rentBounds = await availableQuery
                .GroupBy(_ => 1)
                .Select(g => new { Min = g.Min(p => p.PrecioMensual), Max = g.Max(p => p.PrecioMensual) })
                .FirstAsync();
            MinListingRent = rentBounds.Min;
            MaxListingRent = rentBounds.Max;
        }

        var ciudades = await availableQuery.Select(p => p.Ciudad).ToListAsync();
        StateOptions = ciudades
            .Select(PropertyCatalogHelper.ParseStateCode)
            .Where(code => !string.IsNullOrWhiteSpace(code))
            .GroupBy(code => code!)
            .Select(g => new CatalogStateOption
            {
                Code = g.Key,
                Name = PropertyCatalogHelper.GetStateName(g.Key),
                Count = g.Count()
            })
            .OrderBy(s => s.Name)
            .ToList();

        var filteredQuery = PropertyCatalogHelper.ApplyFiltersToQuery(availableQuery, Filters);
        TotalFiltered = await filteredQuery.CountAsync();
        TotalPages = Math.Max(1, (int)Math.Ceiling(TotalFiltered / (double)PageSize));
        Filters.Page = Math.Clamp(Filters.Page, 1, TotalPages);

        var pageProperties = await PropertyCatalogHelper.ApplySort(filteredQuery, Filters.Sort)
            .Skip((Filters.Page - 1) * PageSize)
            .Take(PageSize)
            .Include(p => p.Fotos)
            .ToListAsync();

        Listings = pageProperties.Select(PropertyCatalogHelper.ToCatalogListing).ToList();
    }

    public string BuildPageUrl(int page)
    {
        var parts = new List<string> { $"Filters.Page={page}" };
        if (!string.IsNullOrWhiteSpace(Filters.Query))
        {
            parts.Add($"Filters.Query={Uri.EscapeDataString(Filters.Query)}");
        }

        if (!string.IsNullOrWhiteSpace(Filters.State))
        {
            parts.Add($"Filters.State={Uri.EscapeDataString(Filters.State)}");
        }

        if (Filters.Bedrooms is > 0)
        {
            parts.Add($"Filters.Bedrooms={Filters.Bedrooms}");
        }

        if (Filters.MinRent is > 0)
        {
            parts.Add($"Filters.MinRent={Filters.MinRent}");
        }

        if (Filters.MaxRent is > 0)
        {
            parts.Add($"Filters.MaxRent={Filters.MaxRent}");
        }

        if (!string.IsNullOrWhiteSpace(Filters.Sort) && Filters.Sort != "price-asc")
        {
            parts.Add($"Filters.Sort={Uri.EscapeDataString(Filters.Sort)}");
        }

        return $"/Apartamentos/Index?{string.Join("&", parts)}";
    }
}
