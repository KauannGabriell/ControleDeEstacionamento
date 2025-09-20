using System.Collections.Immutable;

namespace ControleDeEstacionamento.Models.ModuloVeiculo;
public record SelecionarVeiculosRequest(int? Quantidade);

public record SelecionarVeiculosResponse(
    int Quantidade, 
    ImmutableList<SelecionarVeiculosDto> Veiculos);
