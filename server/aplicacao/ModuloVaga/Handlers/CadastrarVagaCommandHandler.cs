using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Cadastrar;

public class CadastrarVagaCommandHandler(
    IValidator<CadastrarVagaCommand> validator,  
    IMapper mapper,
    IRepositorioVaga repositorioVaga,
    ILogger<CadastrarVagaCommandHandler> logger,
    IUnitOfWork unitOfWork
) : IRequestHandler<CadastrarVagaCommand, Result<CadastrarVagaResult>>

{  
    public async Task<Result<CadastrarVagaResult>> Handle(CadastrarVagaCommand command, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await validator.ValidateAsync(command);

        if (!resultadoValidacao.IsValid)
        {
            var erros = resultadoValidacao.Errors.Select(e => e.ErrorMessage);
            var erroFormatado = ResultadosErro.RequisicaoInvalidaErro(erros);

            return Result.Fail(erroFormatado);
        }
        var registros = await repositorioVaga.SelecionarRegistrosAsync();

        try
        {
          
            var vaga = mapper.Map<Vaga>(command);

            var vagas = vaga.ObtendoVagasPorZona(command.quantidade, command.zona);

            await repositorioVaga.CadastrarEntidadesAsync(vagas);

            await unitOfWork.CommitAsync();

            var result = new CadastrarVagaResult(idsVagas: vagas.Select(v => v.Id).ToList());

            return Result.Ok(result);


        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();

            logger.LogError(ex, "Erro ao cadastrar vaga {Vaga}", command.zona);

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
