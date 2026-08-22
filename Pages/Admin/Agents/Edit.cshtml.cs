using ApartamentosRenta.Data;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartamentosRenta.Pages.Admin.Agents;

public class EditModel(AppDbContext context, AgentPhotoUploadService photoUpload) : PageModel
{
    [BindProperty]
    public AgenteInput Input { get; set; } = new();

    [BindProperty]
    public IFormFile? FotoUpload { get; set; }

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
        var uploadError = photoUpload.ValidateFile(FotoUpload);
        if (uploadError is not null)
        {
            ModelState.AddModelError("FotoUpload", uploadError);
        }

        var agente = await context.Agentes.FindAsync(id);
        if (agente is null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(Input.FotoUrl)
            && (FotoUpload is null || FotoUpload.Length == 0)
            && string.IsNullOrWhiteSpace(agente.FotoUrl))
        {
            ModelState.AddModelError("FotoUpload", "Sube una foto o pega una URL.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        agente.Slug = await AgenteHelper.BuildSlugAsync(context, Input.NombreCompleto, Input.Slug ?? agente.Slug, id);
        AgenteHelper.ApplyInput(agente, Input);

        var uploaded = await photoUpload.SaveAsync(agente.Id, FotoUpload);
        if (!string.IsNullOrWhiteSpace(uploaded))
        {
            agente.FotoUrl = uploaded;
        }

        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
