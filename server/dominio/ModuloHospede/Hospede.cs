using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;

namespace ControleDeEstacionamento.Dominio.ModuloHospede;

public class Hospede : EntidadeBase<Hospede>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public  Veiculo Veiculo { get; set; }
    public Ticket Ticket { get; set; }
    public List<Checkin> Checkins { get; set; } = new List<Checkin>();
    public override void AtualizarRegistro(Hospede registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        Cpf = registroEditado.Cpf;
        Checkins = registroEditado.Checkins;
        Veiculo = registroEditado.Veiculo;
    }
}
