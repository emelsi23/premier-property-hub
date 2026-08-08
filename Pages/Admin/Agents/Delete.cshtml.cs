using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Agents;

public class DeleteModel(AppDbContext context) : PageModel
{
    [BindProperty]
    public Models.Agente Agente { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var agente = await context.Agentes.FirstOrDefaultAsync(a => a.Id == id);
        if (agente is null)
        {
            return NotFound();
        }

        Agente = agente;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var agente = await context.Agentes.FindAsync(id);
        if (agente is null)
        {
            return NotFound();
        }

        context.Agentes.Remove(agente);
        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
