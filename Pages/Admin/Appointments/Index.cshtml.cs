using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Appointments;

public class IndexModel(AppDbContext context) : PageModel
{
    public IList<Cita> Appointments { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Appointments = await context.Citas
            .Include(c => c.Propiedad)
            .OrderByDescending(c => c.FechaSolicitud)
            .ToListAsync();
    }

    public async Task<IActionResult> OnGetPaymentProofAsync(int id)
    {
        var cita = await context.Citas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        if (cita?.PaymentProofData is null || cita.PaymentProofData.Length == 0)
        {
            return NotFound();
        }

        return File(cita.PaymentProofData, cita.PaymentProofContentType ?? "image/jpeg");
    }

    public async Task<IActionResult> OnPostConfirmAsync(int id)
    {
        var cita = await context.Citas.FindAsync(id);
        if (cita is null) return NotFound();

        if (cita.Estado != EstadoCita.EsperandoConfirmacion)
        {
            return RedirectToPage();
        }

        cita.Estado = EstadoCita.Confirmada;
        await context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCancelAsync(int id)
    {
        var cita = await context.Citas.FindAsync(id);
        if (cita is null) return NotFound();
        cita.Estado = EstadoCita.Cancelada;
        await context.SaveChangesAsync();
        return RedirectToPage();
    }
}
