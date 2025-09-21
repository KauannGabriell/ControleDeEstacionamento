namespace ControleDeEstacionamento.WebApi.Models.ModuloCheckin;

public record RealizarCheckinRequest(
        Guid veiculoId,
        Guid vagaId,
        Guid? hospedeId
);

public record RealizarCheckinResponse(Guid Id);
