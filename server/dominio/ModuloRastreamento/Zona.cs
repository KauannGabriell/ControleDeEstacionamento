using System.ComponentModel.DataAnnotations;

namespace ControleDeEstacionamento.Dominio.ModuloRastreamento;

public enum Zona
{
    [Display(Name = "Zona Azul")]
    ZonaAzul,

    [Display(Name = "Zona Verde")]
    ZonaVerde,

    [Display(Name = "Zona Amarela")]
    ZonaAmarela,

    [Display(Name = "Zona Laranja")]
    ZonaLaranja,

    [Display(Name = "Zona Roxa")]
    ZonaRoxa
}
