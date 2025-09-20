using ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using FluentValidation;

namespace ControleDeEstacionamento.Core.Aplicacao.FluentValidation;

public class CadastrarVagaCommandValidator : AbstractValidator<CadastrarVagaCommand>
{
    public CadastrarVagaCommandValidator()
    {
    }
}