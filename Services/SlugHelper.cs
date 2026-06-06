using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using ApartamentosRenta.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Services;

public static partial class SlugHelper
{
    public static string FromText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return "propiedad";
        }

        var normalized = text.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        var slug = sb.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();
        slug = NonAlphanumeric().Replace(slug, "-");
        slug = MultiDash().Replace(slug, "-").Trim('-');

        return string.IsNullOrEmpty(slug) ? "propiedad" : slug[..Math.Min(slug.Length, 120)];
    }

    public static string FromPropiedad(string direccion, string ciudad) =>
        FromText($"{direccion} {ciudad}");

    public static async Task<string> EnsureUniqueAsync(AppDbContext context, string baseSlug, int? excludeId = null)
    {
        var slug = baseSlug;
        var counter = 1;

        while (await context.Propiedades.AnyAsync(p =>
                   p.Slug == slug && (excludeId == null || p.Id != excludeId)))
        {
            slug = $"{baseSlug}-{counter++}";
        }

        return slug;
    }

    [GeneratedRegex(@"[^a-z0-9]+")]
    private static partial Regex NonAlphanumeric();

    [GeneratedRegex(@"-{2,}")]
    private static partial Regex MultiDash();
}
