using FluentResults;
using MediatR;


namespace ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;

public record CadastrarHospedeCommand(
         string Nome,
         string Telefone,
         string Cpf

) : IRequest<Result<CadastrarHospedeResult>>;


public record CadastrarHospedeResult(Guid Id);
