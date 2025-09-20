using eAgenda.Core.Aplicacao.ModuloContato.Commands;
using System.Collections.Immutable;

namespace eAgenda_WebApi.Models.Modulo_Contato;

public record SelecionarVeiculosPorIdRequest(Guid Id);


public record SelecionarContatosPorIdResponse(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Empresa,
    string Cargo,
    ImmutableList<DetalhesCompromissoContatoDto> Compromissos
    );
