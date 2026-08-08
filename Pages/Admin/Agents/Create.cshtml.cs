using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartamentosRenta.Pages.Admin.Agents;

public class CreateModel(AppDbContext context) : PageModel
{
    [BindProperty]
    public AgenteInput Input { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var slug = await AgenteHelper.BuildSlugAsync(context, Input.NombreCompleto, Input.Slug);

        var agente = new Models.Agente
        {
            Slug = slug,
            FechaCreacion = DateTime.UtcNow
        };

        AgenteHelper.ApplyInput(agente, Input);
        context.Agentes.Add(agente);
        await context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
