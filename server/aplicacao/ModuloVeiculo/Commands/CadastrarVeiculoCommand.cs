using eAgenda.Core.Aplicacao.ModuloContato.Cadastrar;
using FluentResults;
using MediatR;
using StackExchange.Redis;


namespace ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;

public record CadastrarVeiculoCommand(
 
) : IRequest<Result<CadastrarContatoResult>>;


public record CadastrarContatoResult(Guid Id);
