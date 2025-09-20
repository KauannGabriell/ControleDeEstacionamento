using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloVeiculo;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Handlers;

public class ExcluirContatoCommandHandler(
    IRepositorioVeiculo repositorioVeiculo,
    IUnitOfWork unitOfWork,
    ILogger<ExcluirContatoCommandHandler> logger
) : IRequestHandler<ExcluirVeiculoCommand, Result<ExcluirVeiculoResult>>
{
    public async Task<Result<ExcluirVeiculoResult>> Handle(ExcluirVeiculoCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await repositorioVeiculo.ExcluirAsync(command.Id);

            await unitOfWork.CommitAsync();

            var result = new ExcluirVeiculoResult();

            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();

            logger.LogError(
                ex,
                "Ocorreu um erro durante a exclusão de {@Registro}.",
                command
            );

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}