using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartamentosRenta.Pages;

[IgnoreAntiforgeryToken]
public class LanguageModel : PageModel
{
    public IActionResult OnGet(string culture, string? returnUrl = null)
    {
        culture = SiteCulture.Normalize(culture);
        Response.Cookies.Append(
            SiteCulture.CookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,
                HttpOnly = false,
                Secure = Request.IsHttps,
                SameSite = SameSiteMode.Lax,
                Path = "/"
            });

        if (string.IsNullOrWhiteSpace(returnUrl) || !Url.IsLocalUrl(returnUrl))
        {
            returnUrl = "/Apartamentos/Index";
        }

        return LocalRedirect(returnUrl);
    }
}
