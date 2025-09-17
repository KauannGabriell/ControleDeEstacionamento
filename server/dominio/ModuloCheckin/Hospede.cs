using ControleDeEstacionamento.Core.Dominio.Compartilhado;

namespace ControleDeEstacionamento.Dominio.ModuloCheckin;

public class Hospede : EntidadeBase<Hospede>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }

    public override void AtualizarRegistro(Hospede registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        Cpf = registroEditado.Cpf;
    }
}
