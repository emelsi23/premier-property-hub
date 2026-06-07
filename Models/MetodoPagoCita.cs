namespace ApartamentosRenta.Models;

public enum MetodoPagoCita
{
    Zelle,

    [System.ComponentModel.DataAnnotations.Display(Name = "Apple Pay")]
    ApplePay,

    [System.ComponentModel.DataAnnotations.Display(Name = "Cash")]
    Efectivo
}
