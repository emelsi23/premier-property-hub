using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartamentosRenta.Pages.Admin.Agents;

public class CreateModel(AppDbContext context, AgentPhotoUploadService photoUpload) : PageModel
{
    [BindProperty]
    public AgenteInput Input { get; set; } = new();

    [BindProperty]
    public IFormFile? FotoUpload { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var uploadError = photoUpload.ValidateFile(FotoUpload);
        if (uploadError is not null)
        {
            ModelState.AddModelError("FotoUpload", uploadError);
        }

        if (string.IsNullOrWhiteSpace(Input.FotoUrl) && (FotoUpload is null || FotoUpload.Length == 0))
        {
            ModelState.AddModelError("FotoUpload", "Sube una foto o pega una URL.");
        }

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
        if (string.IsNullOrWhiteSpace(agente.FotoUrl))
        {
            agente.FotoUrl = "/images/agents/maria-angelica.png";
        }

        context.Agentes.Add(agente);
        await context.SaveChangesAsync();

        var uploaded = await photoUpload.SaveAsync(agente.Id, FotoUpload);
        if (!string.IsNullOrWhiteSpace(uploaded))
        {
            agente.FotoUrl = uploaded;
            await context.SaveChangesAsync();
        }

        return RedirectToPage("Index");
    }
}
