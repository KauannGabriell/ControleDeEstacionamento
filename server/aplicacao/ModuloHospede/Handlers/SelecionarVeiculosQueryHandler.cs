using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;
using ControleDeEstacionamento.Core.Dominio.ModuloHospede;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Handlers;
public class SelecionarHospedesQueryHandler(
    IMapper mapper,
    IRepositorioHospede repositorioHospede,
    ILogger<SelecionarHospedesQueryHandler> logger
    ) : IRequestHandler<SelecionarHospedesQuery, Result<SelecionarHospedesResult>>
{
    

    public async Task<Result<SelecionarHospedesResult>> Handle(SelecionarHospedesQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var registros = query.Quantidade.HasValue  
                ? await repositorioHospede.SelecionarRegistrosAsync(query.Quantidade.Value)
                : await repositorioHospede.SelecionarRegistrosAsync();

            var result = mapper.Map<SelecionarHospedesResult>(registros);
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
