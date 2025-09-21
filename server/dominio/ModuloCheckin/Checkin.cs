using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;

namespace ControleDeEstacionamento.Dominio.ModuloCheckin;
public class Checkin : EntidadeBase<Checkin>
{
    public DateTime DataEntrada 
    { 
        get
        {
            return DateTime.UtcNow;
        }

        set
        {
        }
    }
    public int UltimoIdTicket { get; set; }
    public Veiculo Veiculo { get; set; }
    public DateTime? DataSaida { get; set; }
    public StatusCheckin Status { get; set; }
    public Vaga Vaga { get; set; }
    public Hospede? Hospede { get; set; }
    public Ticket Ticket { get; set;}
    public Checkin () { }

    public Checkin(DateTime dataEntrada, int ultimoIdTicket, Veiculo veiculo, DateTime? dataSaida, StatusCheckin status, Vaga vaga, Hospede? hospede, Ticket ticket)
    {
        Id = Guid.NewGuid();
        DataEntrada = dataEntrada;
        UltimoIdTicket = ultimoIdTicket;
        Veiculo = veiculo;
        DataSaida = dataSaida;
        Status = status;
        Vaga = vaga;
        Hospede = hospede;
        Ticket = ticket;
    }
    public Ticket GerarTicket(
      Vaga vaga,
      DateTime dataEntrada,
      Hospede? hospede,
      Veiculo veiculo,
      int ultimoId)
    {
        var ticket = new Ticket
        {
            Vaga = vaga,
            DataEntrada = dataEntrada,
            Hospede = hospede,
            Veiculo = veiculo,
        };

        ticket.GerarIdentificadorUnicoSequencial(ultimoId);

        return ticket;
    }
    public override void AtualizarRegistro(Checkin registroEditado)
    {
        Veiculo = registroEditado.Veiculo;
        Hospede = registroEditado.Hospede;
        DataSaida = registroEditado.DataSaida;
        Status = registroEditado.Status;
        Ticket = registroEditado.Ticket;
        Vaga  = registroEditado.Vaga;
    }

    public void FinalizarTicket(Checkin checkin)
    {
        checkin.Status = StatusCheckin.Finalizado;
        checkin.DataSaida = DateTime.UtcNow;
    }
}

