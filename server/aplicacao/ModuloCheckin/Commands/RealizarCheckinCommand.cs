using FluentResults;
using MediatR;


namespace ControleDeEstacionamento.Core.Aplicacao.ModuloCheckin.Commands;

public record RealizarCheckinCommand(
      Guid veiculoId,
      Guid vagaId,
      Guid? hospedeId
) : IRequest<Result<RealizarCheckinResult>>;


public record RealizarCheckinResult(Guid Id);
