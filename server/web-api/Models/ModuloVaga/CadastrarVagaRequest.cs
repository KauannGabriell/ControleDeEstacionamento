namespace ControleDeEstacionamento.WebApi.Models.ModuloVaga;

public record CadastrarVagaRequest(
   int quantidade,
   char zona
);

public record CadastrarVagaResponse(
    List<Guid> idsVagas
    );
