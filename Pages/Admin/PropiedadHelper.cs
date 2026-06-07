using ApartamentosRenta.Data;
using ApartamentosRenta.Models;
using ApartamentosRenta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartamentosRenta.Pages.Admin;

public static class PropiedadHelper
{
    public static void ApplyInput(Propiedad propiedad, PropertyInput input)
    {
        propiedad.Titulo = input.Titulo.Trim();
        propiedad.Descripcion = input.Descripcion.Trim();
        propiedad.Direccion = input.Direccion.Trim();
        propiedad.Ciudad = input.Ciudad.Trim();
        propiedad.PrecioMensual = input.PrecioMensual;
        propiedad.Habitaciones = input.Habitaciones;
        propiedad.Banos = input.Banos;
        propiedad.MetrosCuadrados = input.MetrosCuadrados;
        propiedad.Disponible = input.Disponible;
        propiedad.Amenidades = input.Amenidades.Trim();
        propiedad.ZelleDisplayName = input.ZelleDisplayName.Trim();
        propiedad.ZelleContact = input.ZelleContact.Trim();
        propiedad.DepositAmount = VisitDepositSettings.Amount;
    }

    public static LeaseContract ApplyContractInput(Propiedad propiedad, PropertyInput input)
    {
        var contract = propiedad.LeaseContract ?? new LeaseContract { PropiedadId = propiedad.Id };
        contract.Title = input.ContractTitle.Trim();
        contract.Subtitle = input.ContractSubtitle.Trim();
        contract.NoticeHtml = input.ContractNoticeHtml.Trim();
        contract.BodyHtml = input.ContractBodyHtml.Trim();
        contract.UpdatedAt = DateTime.UtcNow;
        contract.PropiedadId = propiedad.Id;
        return contract;
    }

    public static StampSealContract ApplyStampSealInput(Propiedad propiedad, PropertyInput input)
    {
        var contract = propiedad.StampSealContract ?? new StampSealContract { PropiedadId = propiedad.Id };
        contract.Title = input.StampSealTitle.Trim();
        contract.Subtitle = input.StampSealSubtitle.Trim();
        contract.NoticeHtml = input.StampSealNoticeHtml.Trim();
        contract.BodyHtml = input.StampSealBodyHtml.Trim();
        contract.UpdatedAt = DateTime.UtcNow;
        contract.PropiedadId = propiedad.Id;
        return contract;
    }

    public static async Task EnsureContractsForAllPropertiesAsync(AppDbContext context)
    {
        await LeaseContractSeedHelper.EnsureForAllPropertiesAsync(context);
        await StampSealSeedHelper.EnsureForAllPropertiesAsync(context);
    }

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
