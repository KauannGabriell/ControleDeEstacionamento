using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;

namespace ControleDeEstacionamento.Dominio.ModuloCheckin;
public class Ticket : EntidadeBase<Ticket>
{
    public Veiculo Veiculo { get; set; }
    public int IdentificadorUnicoSequencial { get; set; }

   


    public override void AtualizarRegistro(Ticket registroEditado)
    {
    }
}
