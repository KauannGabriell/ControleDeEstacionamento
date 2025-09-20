using FluentResults;
using MediatR;


namespace ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;

public record CadastrarVagaCommand(
     int quantidade,
     char zona
) : IRequest<Result<CadastrarVagaResult>>;


public record CadastrarVagaResult(
    List<Guid> idsVagas
    );
