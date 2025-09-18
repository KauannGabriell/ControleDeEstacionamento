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
            return DateTime.Now;
        }
    }
    public int UltimoIdTicket { get; set; }
    public Veiculo Veiculo { get; set; }
    public DateTime? DataSaida { get; set; }
    public StatusCheckin Status { get; set; }
    public Vaga Vaga { get; set; }
    public Hospede? Hospede { get; set; }
    public Ticket Ticket
    {
        get
        {
            return Ticket.GerarTicket(Vaga, DataEntrada, Hospede, Veiculo, UltimoIdTicket);
        }
    }


    public override void AtualizarRegistro(Checkin registroEditado)
    {
        Veiculo = registroEditado.Veiculo;
        Hospede = registroEditado.Hospede;
        DataSaida = registroEditado.DataSaida;
    }

    public void FinalizarTicket(Checkin checkin)
    {
        checkin.Status = StatusCheckin.Finalizado;
        checkin.DataSaida = DateTime.Now;
    }
}

