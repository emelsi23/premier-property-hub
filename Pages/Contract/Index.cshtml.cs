using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartamentosRenta.Pages.Contract;

public class IndexModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Residential Lease Agreement";
    }
}
