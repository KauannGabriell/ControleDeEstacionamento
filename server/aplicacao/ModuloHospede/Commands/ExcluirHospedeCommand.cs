using FluentResults;
using MediatR;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;

public record ExcluirHospedeCommand(Guid Id) : IRequest<Result<ExcluirHospedeResult>>;

public record ExcluirHospedeResult();