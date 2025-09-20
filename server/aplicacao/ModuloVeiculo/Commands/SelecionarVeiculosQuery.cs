using FluentResults;
using MediatR;
using System.Collections.Immutable;

namespace eAgenda.Core.Aplicacao.ModuloContato.Commands;

public record SelecionarVeiculosQuery(int? Quantidade) : IRequest<Result<SelecionarContatosResult>>;

public record SelecionarContatosResult(ImmutableList<SelecionarContatosDto> Contatos);

public record SelecionarContatosDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Empresa,
    string Cargo);
