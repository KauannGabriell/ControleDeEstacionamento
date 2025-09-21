using FluentResults;
using MediatR;
using System.Collections.Immutable;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;

public record SelecionarHospedesQuery(int? Quantidade) : IRequest<Result<SelecionarHospedesResult>>;

public record SelecionarHospedesResult(ImmutableList<SelecionarHospedesDto> Veiculos);

public record SelecionarHospedesDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
    );
    

