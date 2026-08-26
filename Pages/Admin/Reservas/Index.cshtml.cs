using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin.Reservas;

public class IndexModel(AppDbContext context) : PageModel
{
    public IList<ReservaGenerica> Reservas { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Reservas = await context.ReservasGenericas
            .OrderByDescending(r => r.FechaSolicitud)
            .ToListAsync();
    }

    public async Task<IActionResult> OnGetFirmaAsync(int id)
    {
        var r = await context.ReservasGenericas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (r?.FirmaData is null || r.FirmaData.Length == 0)
        {
            return NotFound();
        }

        return File(r.FirmaData, r.FirmaContentType ?? "image/png");
    }

    public async Task<IActionResult> OnGetIdentidadAsync(int id)
    {
        var r = await context.ReservasGenericas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (r?.IdentidadData is null || r.IdentidadData.Length == 0)
        {
            return NotFound();
        }

        return File(r.IdentidadData, r.IdentidadContentType ?? "image/jpeg");
    }

    public async Task<IActionResult> OnGetComprobanteAsync(int id)
    {
        var r = await context.ReservasGenericas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (r?.PaymentProofData is null || r.PaymentProofData.Length == 0)
        {
            return NotFound();
        }

        return File(r.PaymentProofData, r.PaymentProofContentType ?? "image/jpeg");
    }

    public async Task<IActionResult> OnGetPdfAsync(int id)
    {
        var r = await context.ReservasGenericas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (r is null)
        {
            return NotFound();
        }

        var pdf = ReservaGenericaPdfDocument.Generate(r);
        var safeName = string.Concat(r.NombreCompleto.Where(ch => char.IsLetterOrDigit(ch) || ch is ' ' or '-' or '_'))
            .Trim()
            .Replace(' ', '_');
        if (string.IsNullOrWhiteSpace(safeName))
        {
            safeName = $"reserva-{r.Id}";
        }

        var fileName = $"Protocolo-Reserva-{safeName}-{r.Id}.pdf";
        return File(pdf, "application/pdf", fileName);
    }

    public async Task<IActionResult> OnPostConfirmAsync(int id)
    {
        var r = await context.ReservasGenericas.FindAsync(id);
        if (r is null)
        {
            return NotFound();
        }

        if (r.Estado == EstadoReservaGenerica.EsperandoConfirmacion)
        {
            r.Estado = EstadoReservaGenerica.Completada;
            r.FechaCompletada = DateTime.UtcNow;
            await context.SaveChangesAsync();
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCancelAsync(int id)
    {
        var r = await context.ReservasGenericas.FindAsync(id);
        if (r is null)
        {
            return NotFound();
        }

        if (r.Estado != EstadoReservaGenerica.Cancelada)
        {
            r.Estado = EstadoReservaGenerica.Cancelada;
            await context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}
