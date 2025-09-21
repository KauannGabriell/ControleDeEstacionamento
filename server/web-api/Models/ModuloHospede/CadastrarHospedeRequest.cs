namespace ControleDeEstacionamento.WebApi.Models.ModuloHospede;

public record CadastrarHospedeRequest(
         string Nome,
         string Telefone,
         string Cpf
);

public record CadastrarHospedeResponse(Guid Id);
