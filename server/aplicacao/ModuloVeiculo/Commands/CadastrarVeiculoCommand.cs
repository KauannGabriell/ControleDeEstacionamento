using FluentResults;
using MediatR;


namespace ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;

public record CadastrarVeiculoCommand(
     string Placa,
     string Modelo,
     string Cor

) : IRequest<Result<CadastrarVeiculoResult>>;


public record CadastrarVeiculoResult(Guid Id);
