using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using FluentValidation;

namespace ControleDeEstacionamento.Core.Aplicacao.FluentValidation;

public class CadastrarVeiculoCommandValidator : AbstractValidator<CadastrarVeiculoCommand>
{
    public CadastrarVeiculoCommandValidator()
    {
    }
}