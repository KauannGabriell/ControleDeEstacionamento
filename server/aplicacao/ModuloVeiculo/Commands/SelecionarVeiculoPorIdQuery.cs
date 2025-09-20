
using FluentResults;
using MediatR;
using System.Collections.Immutable;

namespace eAgenda.Core.Aplicacao.ModuloContato.Commands;

public record SelecionarVeiculoPorIdQuery(Guid ContatoId) : IRequest<Result<SelecionarContatoPorIdResult>>; 


public record SelecionarContatoPorIdResult(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Empresa,
    string Cargo,
    ImmutableList<DetalhesCompromissoContatoDto> Compromissos
    );

public record DetalhesCompromissoContatoDto(
    string Assunto,
    DateTime Data,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino
    );