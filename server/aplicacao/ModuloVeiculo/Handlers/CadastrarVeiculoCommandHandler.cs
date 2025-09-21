using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloVeiculo;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Cadastrar;

public class CadastrarVeiculoCommandHandler(
    IValidator<CadastrarVeiculoCommand> validator,  
    IMapper mapper,
    IRepositorioVeiculo repositorioVeiculo,
    ILogger<CadastrarVeiculoCommandHandler> logger,
    IUnitOfWork unitOfWork
) : IRequestHandler<CadastrarVeiculoCommand, Result<CadastrarVeiculoResult>>

{  
    public async Task<Result<CadastrarVeiculoResult>> Handle(CadastrarVeiculoCommand command, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await validator.ValidateAsync(command);

        if (!resultadoValidacao.IsValid)
        {
            var erros = resultadoValidacao.Errors.Select(e => e.ErrorMessage);
            var erroFormatado = ResultadosErro.RequisicaoInvalidaErro(erros);

            return Result.Fail(erroFormatado);
        }
        var registros = await repositorioVeiculo.SelecionarRegistrosAsync();

        try
        {
          
            var veiculo = mapper.Map<Veiculo>(command);

            await repositorioVeiculo.CadastrarAsync(veiculo);

            await unitOfWork.CommitAsync();

            var result = mapper.Map<CadastrarVeiculoResult>(veiculo);
            return Result.Ok(result);


        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();

            logger.LogError(ex, "Erro ao cadastrar veiculo {Modelo}", command.Modelo);

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
