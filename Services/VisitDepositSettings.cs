using ApartamentosRenta.Models;

namespace ApartamentosRenta.Services;

public static class VisitDepositSettings
{
    public const decimal DefaultAmount = 150m;

    public static decimal GetAmount(Propiedad propiedad) =>
        propiedad.DepositAmount > 0 ? propiedad.DepositAmount : DefaultAmount;
}
