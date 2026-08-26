using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Appointments;

public class IndexModel(AppDbContext context) : PageModel
{
    public IList<Cita> Appointments { get; private set; } = [];

    public string CurrentUsername { get; private set; } = string.Empty;

    public async Task OnGetAsync()
    {
        CurrentUsername = AdminUsers.CurrentUsername(User);
        Appointments = await context.Citas
            .Include(c => c.Propiedad)
            .Where(c => c.AdminUsername == "" || c.AdminUsername == CurrentUsername)
            .OrderByDescending(c => c.FechaSolicitud)
            .ToListAsync();
    }

    public async Task<IActionResult> OnGetPaymentProofAsync(int id)
    {
        var cita = await FindVisibleAsync(id, tracking: false);
        if (cita?.PaymentProofData is null || cita.PaymentProofData.Length == 0)
        {
            return NotFound();
        }

        return File(cita.PaymentProofData, cita.PaymentProofContentType ?? "image/jpeg");
    }

    public async Task<IActionResult> OnPostConfirmAsync(int id)
    {
        var cita = await FindVisibleAsync(id, tracking: true);
        if (cita is null) return NotFound();

        if (cita.Estado != EstadoCita.EsperandoConfirmacion)
        {
            return RedirectToPage();
        }

        var me = AdminUsers.CurrentUsername(User);
        if (string.IsNullOrEmpty(cita.AdminUsername))
        {
            cita.AdminUsername = me;
        }

        cita.Estado = EstadoCita.Confirmada;
        await context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCancelAsync(int id)
    {
        var cita = await FindVisibleAsync(id, tracking: true);
        if (cita is null) return NotFound();

        var me = AdminUsers.CurrentUsername(User);
        if (string.IsNullOrEmpty(cita.AdminUsername))
        {
            cita.AdminUsername = me;
        }

        cita.Estado = EstadoCita.Cancelada;
        await context.SaveChangesAsync();
        return RedirectToPage();
    }

    private async Task<Cita?> FindVisibleAsync(int id, bool tracking)
    {
        var me = AdminUsers.CurrentUsername(User);
        var query = tracking ? context.Citas.AsQueryable() : context.Citas.AsNoTracking();
        return await query.FirstOrDefaultAsync(c =>
            c.Id == id && (c.AdminUsername == "" || c.AdminUsername == me));
    }
}
