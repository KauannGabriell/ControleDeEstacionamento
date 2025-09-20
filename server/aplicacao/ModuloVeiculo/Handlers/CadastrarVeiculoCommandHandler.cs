using AutoMapper;
using eAgenda.Core.Aplicacao.Compartilhado;
using eAgenda.Core.Dominio.Compartilhado;
using eAgenda.Core.Dominio.ModuloContato;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace eAgenda.Core.Aplicacao.ModuloContato.Cadastrar;

public class CadastrarVeiculoCommandHandler(
    IValidator<CadastrarContatoCommand> validator,  
    IMapper mapper,
    IRepositorioContato repositorioContato,
    ILogger<CadastrarVeiculoCommandHandler> logger,
    IUnitOfWork unitOfWork
) : IRequestHandler<CadastrarContatoCommand, Result<CadastrarContatoResult>>

{  
    public async Task<Result<CadastrarContatoResult>> Handle(CadastrarContatoCommand command, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await validator.ValidateAsync(command);

        if (!resultadoValidacao.IsValid)
        {
            var erros = resultadoValidacao.Errors.Select(e => e.ErrorMessage);
            var erroFormatado = ResultadosErro.RequisicaoInvalidaErro(erros);

            return Result.Fail(erroFormatado);
        }
        var registros = await repositorioContato.SelecionarRegistrosAsync();

        if (registros.Any(x => x.Nome == command.Nome))
            return Result.Fail(ResultadosErro.RegistroDuplicadoErro("Já existe um contato com esse nome"));


        try
        {
          
            var contato = mapper.Map<Contato>(command);

            await repositorioContato.CadastrarAsync(contato);

            await unitOfWork.CommitAsync();

            var result = mapper.Map<CadastrarContatoResult>(contato);
            return Result.Ok(result);


        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();

            logger.LogError(ex, "Erro ao cadastrar contato {Nome}", command.Nome);

            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
