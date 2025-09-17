

using System.ComponentModel.DataAnnotations;

namespace ControleDeEstacionamento.Dominio.ModuloVaga;

public enum Status
{
    [Display(Name = "Disponivel")]
    Disponivel,
    [Display(Name = "Ocupada")]
    Ocupada
}
