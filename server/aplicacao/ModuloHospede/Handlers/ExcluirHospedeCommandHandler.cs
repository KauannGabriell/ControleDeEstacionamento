using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloHospede;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Handlers;

public class ExcluirHospedeCommandHandler(
    IRepositorioHospede repositorioHospede,
    IUnitOfWork unitOfWork,
    ILogger<ExcluirHospedeCommandHandler> logger
) : IRequestHandler<ExcluirHospedeCommand, Result<ExcluirHospedeResult>>
{
    public async Task<Result<ExcluirHospedeResult>> Handle(ExcluirHospedeCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await repositorioHospede.ExcluirAsync(command.Id);

            await unitOfWork.CommitAsync();

            var result = new ExcluirHospedeResult();

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