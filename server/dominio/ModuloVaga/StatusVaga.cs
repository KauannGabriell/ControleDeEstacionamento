

using System.ComponentModel.DataAnnotations;

namespace ControleDeEstacionamento.Dominio.ModuloVaga;

public enum StatusVaga
{
    [Display(Name = "Disponivel")]
    Disponivel,
    [Display(Name = "Ocupada")]
    Ocupada
}
