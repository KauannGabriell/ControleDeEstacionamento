using FluentResults;
using MediatR;

namespace eAgenda.Core.Aplicacao.ModuloContato.Commands;
public record ExcluirVeiculoCommand(Guid Id) : IRequest<Result<ExcluirContatoResult>>;

public record ExcluirContatoResult();
