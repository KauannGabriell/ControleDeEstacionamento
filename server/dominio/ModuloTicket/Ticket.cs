using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;

namespace ControleDeEstacionamento.Dominio.ModuloTicket;
public class Ticket : EntidadeBase<Ticket>
{
    public Veiculo Veiculo { get; set; }
    public int IdentificadorUnicoSequencial  { get; set; }
    public Hospede? Hospede { get; set; }

    public override void AtualizarRegistro(Ticket registroEditado)
    {
        Veiculo = registroEditado.Veiculo;
        IdentificadorUnicoSequencial = registroEditado.IdentificadorUnicoSequencial;
        Hospede = registroEditado.Hospede;
    }

    public void GerarIdentificadorUnicoSequencial(int ultimoId)
    {
        IdentificadorUnicoSequencial = ultimoId++;
    }

    public static Ticket GerarTicket(Hospede? hospede, DateTime horaEntrada, Veiculo veiculo, int ultimoId)
    {
        var ticket = new Ticket();
        ticket.Veiculo = veiculo;
        ticket.Hospede = hospede;
        ticket.GerarIdentificadorUnicoSequencial(ultimoId);
        return ticket;
    }
}
