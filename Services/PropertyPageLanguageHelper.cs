using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class PropertyPageLanguageHelper
{
    public static PropertyContentLanguage Resolve(PropertyPublicLanguage setting, string? langQuery) =>
        setting switch
        {
            PropertyPublicLanguage.Spanish => PropertyContentLanguage.Spanish,
            PropertyPublicLanguage.English => PropertyContentLanguage.English,
            _ => string.Equals(langQuery, "es", StringComparison.OrdinalIgnoreCase)
                ? PropertyContentLanguage.Spanish
                : PropertyContentLanguage.English
        };

    public static bool ShowLanguageSwitcher(PropertyPublicLanguage setting) =>
        setting == PropertyPublicLanguage.Bilingual;

    public static string LangQuery(PropertyContentLanguage language) =>
        language == PropertyContentLanguage.Spanish ? "es" : "en";

    public static string AppendLang(string url, PropertyContentLanguage language)
    {
        var lang = LangQuery(language);
        return url.Contains('?') ? $"{url}&lang={lang}" : $"{url}?lang={lang}";
    }
}
