using ApartamentosRenta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static class PropertyCatalogHelper
{
    public const int DefaultPageSize = 24;
    private static readonly Dictionary<string, string> StateNames = new(StringComparer.OrdinalIgnoreCase)
    {
        ["AL"] = "Alabama", ["AK"] = "Alaska", ["AZ"] = "Arizona", ["AR"] = "Arkansas",
        ["CA"] = "California", ["CO"] = "Colorado", ["CT"] = "Connecticut", ["DE"] = "Delaware",
        ["FL"] = "Florida", ["GA"] = "Georgia", ["HI"] = "Hawaii", ["ID"] = "Idaho",
        ["IL"] = "Illinois", ["IN"] = "Indiana", ["IA"] = "Iowa", ["KS"] = "Kansas",
        ["KY"] = "Kentucky", ["LA"] = "Louisiana", ["ME"] = "Maine", ["MD"] = "Maryland",
        ["MA"] = "Massachusetts", ["MI"] = "Michigan", ["MN"] = "Minnesota", ["MS"] = "Mississippi",
        ["MO"] = "Missouri", ["MT"] = "Montana", ["NE"] = "Nebraska", ["NV"] = "Nevada",
        ["NH"] = "New Hampshire", ["NJ"] = "New Jersey", ["NM"] = "New Mexico", ["NY"] = "New York",
        ["NC"] = "North Carolina", ["ND"] = "North Dakota", ["OH"] = "Ohio", ["OK"] = "Oklahoma",
        ["OR"] = "Oregon", ["PA"] = "Pennsylvania", ["RI"] = "Rhode Island", ["SC"] = "South Carolina",
        ["SD"] = "South Dakota", ["TN"] = "Tennessee", ["TX"] = "Texas", ["UT"] = "Utah",
        ["VT"] = "Vermont", ["VA"] = "Virginia", ["WA"] = "Washington", ["WV"] = "West Virginia",
        ["WI"] = "Wisconsin", ["WY"] = "Wyoming", ["DC"] = "District of Columbia"
    };

    public static string? ParseStateCode(string ciudad)
    {
        if (string.IsNullOrWhiteSpace(ciudad))
        {
            return null;
        }

        var parts = ciudad.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2)
        {
            return null;
        }

        var code = parts[^1].Trim();
        return code.Length == 2 ? code.ToUpperInvariant() : null;
    }

    public static string GetStateName(string? stateCode) =>
        stateCode is not null && StateNames.TryGetValue(stateCode, out var name)
            ? name
            : stateCode ?? "Other";

    public static string GetCityLabel(string ciudad)
    {
        if (string.IsNullOrWhiteSpace(ciudad))
        {
            return string.Empty;
        }

        var parts = ciudad.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return parts.Length >= 2
            ? string.Join(", ", parts[..^1])
            : ciudad.Trim();
    }

    public static string BuildScheduleUrl(string slug) => $"/property/{slug}#schedule";

    public static IEnumerable<CatalogListing> ToCatalogListings(IEnumerable<Propiedad> propiedades) =>
        propiedades.Select(ToCatalogListing);

    public static CatalogListing ToCatalogListing(Propiedad p)
    {
        var stateCode = ParseStateCode(p.Ciudad);
        return new CatalogListing
        {
            Id = p.Id,
            Slug = p.Slug,
            Titulo = p.Titulo,
            Direccion = p.Direccion,
            Ciudad = p.Ciudad,
            CityLabel = GetCityLabel(p.Ciudad),
            StateCode = stateCode,
            StateName = GetStateName(stateCode),
            PrecioMensual = p.PrecioMensual,
            Habitaciones = p.Habitaciones,
            Banos = p.Banos,
            MetrosCuadrados = p.MetrosCuadrados,
            Amenidades = p.Amenidades,
            Descripcion = p.Descripcion,
            PhotoUrl = p.Fotos.OrderBy(f => f.Orden).FirstOrDefault()?.Url,
            DepositAmount = VisitDepositSettings.GetAmount(p),
            ScheduleUrl = BuildScheduleUrl(p.Slug)
        };
    }

    public static IQueryable<Propiedad> ApplyFiltersToQuery(IQueryable<Propiedad> query, CatalogFilterInput filters)
    {
        if (!string.IsNullOrWhiteSpace(filters.State))
        {
            var state = filters.State.Trim().ToUpperInvariant();
            query = query.Where(p => p.Ciudad.EndsWith(", " + state));
        }

        if (!string.IsNullOrWhiteSpace(filters.Query))
        {
            var term = filters.Query.Trim();
            query = query.Where(p =>
                EF.Functions.Like(p.Titulo, $"%{term}%")
                || EF.Functions.Like(p.Ciudad, $"%{term}%")
                || EF.Functions.Like(p.Direccion, $"%{term}%")
                || EF.Functions.Like(p.Amenidades, $"%{term}%")
                || EF.Functions.Like(p.Descripcion, $"%{term}%"));
        }

        if (filters.Bedrooms is > 0)
        {
            query = query.Where(p => p.Habitaciones >= filters.Bedrooms.Value);
        }

        if (filters.MinRent is > 0)
        {
            query = query.Where(p => p.PrecioMensual >= filters.MinRent.Value);
        }

        if (filters.MaxRent is > 0)
        {
            query = query.Where(p => p.PrecioMensual <= filters.MaxRent.Value);
        }

        return query;
    }

    public static IQueryable<Propiedad> ApplySort(IQueryable<Propiedad> query, string? sort) =>
        sort switch
        {
            "price-desc" => query.OrderByDescending(p => p.PrecioMensual).ThenBy(p => p.Id),
            "beds-desc" => query.OrderByDescending(p => p.Habitaciones).ThenBy(p => p.PrecioMensual),
            "newest" => query.OrderByDescending(p => p.FechaCreacion).ThenByDescending(p => p.Id),
            _ => query.OrderBy(p => p.PrecioMensual).ThenBy(p => p.Id)
        };

    public static IEnumerable<CatalogListing> ApplyFilters(
        IEnumerable<CatalogListing> listings,
        CatalogFilterInput filters)
    {
        var query = listings;

        if (!string.IsNullOrWhiteSpace(filters.State))
        {
            query = query.Where(p =>
                string.Equals(p.StateCode, filters.State.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(filters.Query))
        {
            var term = filters.Query.Trim();
            query = query.Where(p =>
                p.Titulo.Contains(term, StringComparison.OrdinalIgnoreCase)
                || p.Ciudad.Contains(term, StringComparison.OrdinalIgnoreCase)
                || p.Direccion.Contains(term, StringComparison.OrdinalIgnoreCase)
                || p.Amenidades.Contains(term, StringComparison.OrdinalIgnoreCase)
                || p.Descripcion.Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        if (filters.Bedrooms is > 0)
        {
            query = query.Where(p => p.Habitaciones >= filters.Bedrooms.Value);
        }

        if (filters.MinRent is > 0)
        {
            query = query.Where(p => p.PrecioMensual >= filters.MinRent.Value);
        }

        if (filters.MaxRent is > 0)
        {
            query = query.Where(p => p.PrecioMensual <= filters.MaxRent.Value);
        }

        return filters.Sort switch
        {
            "price-desc" => query.OrderByDescending(p => p.PrecioMensual),
            "beds-desc" => query.OrderByDescending(p => p.Habitaciones).ThenBy(p => p.PrecioMensual),
            "newest" => query.OrderByDescending(p => p.Id),
            _ => query.OrderBy(p => p.PrecioMensual)
        };
    }
}

public sealed class CatalogListing
{
    public int Id { get; init; }
    public string Slug { get; init; } = string.Empty;
    public string Titulo { get; init; } = string.Empty;
    public string Direccion { get; init; } = string.Empty;
    public string Ciudad { get; init; } = string.Empty;
    public string CityLabel { get; init; } = string.Empty;
    public string? StateCode { get; init; }
    public string StateName { get; init; } = string.Empty;
    public decimal PrecioMensual { get; init; }
    public int Habitaciones { get; init; }
    public int Banos { get; init; }
    public decimal MetrosCuadrados { get; init; }
    public string Amenidades { get; init; } = string.Empty;
    public string Descripcion { get; init; } = string.Empty;
    public string? PhotoUrl { get; init; }
    public decimal DepositAmount { get; init; }
    public string ScheduleUrl { get; init; } = string.Empty;

    public IEnumerable<string> AmenityTags =>
        Amenidades.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Take(3);
}

public sealed class CatalogFilterInput
{
    public string? Query { get; set; }
    public string? State { get; set; }
    public int? Bedrooms { get; set; }
    public decimal? MinRent { get; set; }
    public decimal? MaxRent { get; set; }
    public string Sort { get; set; } = "price-asc";
    public int Page { get; set; } = 1;
}

public sealed class CatalogStateOption
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public int Count { get; init; }
}
