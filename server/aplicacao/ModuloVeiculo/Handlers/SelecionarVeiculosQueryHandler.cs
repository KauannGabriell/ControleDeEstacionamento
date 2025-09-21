using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Core.Dominio.ModuloVeiculo;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Handlers;
public class SelecionarVeiculosQueryHandler(
    IMapper mapper,
    IRepositorioVeiculo repositorioVeiculo,
    ILogger<SelecionarVeiculosQueryHandler> logger
    ) : IRequestHandler<SelecionarVeiculosQuery, Result<SelecionarVeiculosResult>>
{
    

    public async Task<Result<SelecionarVeiculosResult>> Handle(SelecionarVeiculosQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var registros = query.Quantidade.HasValue  
                ? await repositorioVeiculo.SelecionarRegistrosAsync(query.Quantidade.Value)
                : await repositorioVeiculo.SelecionarRegistrosAsync();

            var result = mapper.Map<SelecionarVeiculosResult>(registros);
            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                "Ocorreu um erro durante a seleção de {@Registros}.",
                query
                );
            return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
        }
    }
}
