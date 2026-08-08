using ApartamentosRenta.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Agents;

public class EditModel(AppDbContext context) : PageModel
{
    [BindProperty]
    public AgenteInput Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var agente = await context.Agentes.FindAsync(id);
        if (agente is null)
        {
            return NotFound();
        }

        Input = AgenteHelper.FromEntity(agente);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var agente = await context.Agentes.FindAsync(id);
        if (agente is null)
        {
            return NotFound();
        }

        agente.Slug = await AgenteHelper.BuildSlugAsync(context, Input.NombreCompleto, Input.Slug ?? agente.Slug, id);
        AgenteHelper.ApplyInput(agente, Input);
        await context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
