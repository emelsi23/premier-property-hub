using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin;

public class DeleteModel(AppDbContext context) : PageModel
{
    [BindProperty]
    public Propiedad Propiedad { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var propiedad = await context.Propiedades.FirstOrDefaultAsync(p => p.Id == id);
        if (propiedad is null)
        {
            return NotFound();
        }

        Propiedad = propiedad;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var propiedad = await context.Propiedades.FindAsync(id);
        if (propiedad is null)
        {
            return NotFound();
        }

        context.Propiedades.Remove(propiedad);
        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
