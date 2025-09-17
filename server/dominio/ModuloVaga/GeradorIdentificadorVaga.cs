namespace ControleDeEstacionamento.Dominio.ModuloVaga;

public static class GeradorIdentificadorVaga
{
    public static string CriarGuidString()
    {
        return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
    }
}
