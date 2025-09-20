
using FluentResults;
using MediatR;

namespace eAgenda.Core.Aplicacao.ModuloContato.Commands;

public record EditarContatoCommand(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string? Empresa,
    string? Cargo
    ): IRequest<Result<EditarContatoResult>>;

public record EditarContatoResult(
     string Nome,
     string Email,
     string Telefone,
     string? Empresa,
     string? Cargo
    );
