using FluentResults;
using MediatR;
using System.Collections.Immutable;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloContato.Commands;

public record SelecionarVeiculosQuery(int? Quantidade) : IRequest<Result<SelecionarVeiculosResult>>;

public record SelecionarVeiculosResult(ImmutableList<SelecionarVeiculosDto> Veiculos);

public record SelecionarVeiculosDto(
    Guid Id,
    string Placa,
    string Modelo,
    string Cor
    );
    

