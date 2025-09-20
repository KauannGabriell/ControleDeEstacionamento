namespace eAgenda_WebApi.Models.Modulo_Contato;

public record EditarVeiculoRequest(
    string Nome,
    string Email,
    string Telefone,
    string? Empresa,
    string? Cargo
    );


public record EditarContatoResponse (
    string Nome,
    string Email,
    string Telefone,
    string? Empresa,
    string? Cargo
    );



