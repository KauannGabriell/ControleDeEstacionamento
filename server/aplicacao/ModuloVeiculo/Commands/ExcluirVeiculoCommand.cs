using FluentResults;
using MediatR;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;

public record ExcluirVeiculoCommand(Guid Id) : IRequest<Result<ExcluirVeiculoResult>>;

public record ExcluirVeiculoResult();