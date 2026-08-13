using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace ApartamentosRenta.Services;

public static class SiteCulture
{
    public const string CookieName = ".Premier.Culture";
    public const string Spanish = "es";
    public const string English = "en";

    public static readonly string[] Supported = [Spanish, English];

    public static bool IsEnglish =>
        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
            .Equals(English, StringComparison.OrdinalIgnoreCase);

    public static string Current => IsEnglish ? English : Spanish;

    public static string ToggleCulture => IsEnglish ? Spanish : English;

    public static string Normalize(string? culture) =>
        string.Equals(culture, English, StringComparison.OrdinalIgnoreCase) ? English : Spanish;

    public static void Configure(IServiceCollection services)
    {
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var cultures = Supported.Select(c => new CultureInfo(c)).ToList();
            options.DefaultRequestCulture = new RequestCulture(Spanish);
            options.SupportedCultures = cultures;
            options.SupportedUICultures = cultures;
            options.RequestCultureProviders =
            [
                new CookieRequestCultureProvider { CookieName = CookieName },
                new QueryStringRequestCultureProvider(),
                new AcceptLanguageHeaderRequestCultureProvider()
            ];
        });
    }
}
