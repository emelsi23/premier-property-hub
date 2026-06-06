using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin;

public static class PropiedadHelper
{
    public static async Task ApplyFotosAsync(AppDbContext context, Propiedad propiedad, IEnumerable<string> urls)
    {
        var urlList = urls.ToList();
        if (urlList.Count == 0)
        {
            throw new InvalidOperationException("Se requiere al menos una foto.");
        }

        context.FotosPropiedad.RemoveRange(propiedad.Fotos);
        propiedad.Fotos.Clear();

        for (var i = 0; i < urlList.Count; i++)
        {
            propiedad.Fotos.Add(new FotoPropiedad
            {
                Url = urlList[i],
                Orden = i
            });
        }
    }

    public static async Task<string> BuildSlugAsync(AppDbContext context, string direccion, string ciudad, int? excludeId = null)
    {
        var baseSlug = SlugHelper.FromPropiedad(direccion, ciudad);
        return await SlugHelper.EnsureUniqueAsync(context, baseSlug, excludeId);
    }
}
