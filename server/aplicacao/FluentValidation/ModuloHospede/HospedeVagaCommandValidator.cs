using ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;
using FluentValidation;

namespace ControleDeEstacionamento.Core.Aplicacao.FluentValidation;

public class CadastrarHospedeCommandValidator : AbstractValidator<CadastrarHospedeCommand>
{
    public CadastrarHospedeCommandValidator()
    {
    }
}