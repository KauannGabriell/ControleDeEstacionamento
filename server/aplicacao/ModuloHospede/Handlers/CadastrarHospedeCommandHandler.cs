using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Cadastrar;

public class CadastrarHospedeCommandHandler(
    IValidator<CadastrarHospedeCommand> validator,  
    IMapper mapper,
    IRepositorioHospede repositorioHospede,
    ILogger<CadastrarHospedeCommandHandler> logger,
    IUnitOfWork unitOfWork
) : IRequestHandler<CadastrarHospedeCommand, Result<CadastrarHospedeResult>>

{  
    public async Task<Result<CadastrarHospedeResult>> Handle(CadastrarHospedeCommand command, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await validator.ValidateAsync(command);

        if (!resultadoValidacao.IsValid)
        {
            var erros = resultadoValidacao.Errors.Select(e => e.ErrorMessage);
            var erroFormatado = ResultadosErro.RequisicaoInvalidaErro(erros);

            return Result.Fail(erroFormatado);
        }
        var registros = await repositorioHospede.SelecionarRegistrosAsync();

        try
        {
          
            var veiculo = mapper.Map<Hospede>(command);

            await repositorioHospede.CadastrarAsync(veiculo);

            await unitOfWork.CommitAsync();

            var result = mapper.Map<CadastrarHospedeResult>(veiculo);
            return Result.Ok(result);


        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();

            logger.LogError(ex, "Erro ao cadastrar hospede {Nome}", command.Nome);

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
