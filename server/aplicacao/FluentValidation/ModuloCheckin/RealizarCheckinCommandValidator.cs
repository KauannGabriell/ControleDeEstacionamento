using ControleDeEstacionamento.Core.Aplicacao.ModuloCheckin.Commands;
using FluentValidation;

namespace ControleDeEstacionamento.Core.Aplicacao.FluentValidation;

public class RealizarCheckinCommandValidator : AbstractValidator<RealizarCheckinCommand>
{
    public RealizarCheckinCommandValidator()
    {
    }
}