using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using ControleDeEstacionamento.Dominio.ModuloVaga;

namespace ControleDeEstacionamento.Dominio.ModuloCheckout;
public class Checkout  : EntidadeBase<Checkout>
{
    public DateTime DataSaida
    {
        get
        {
            return DateTime.Now;
        }
        set
        {
        }
    }
    public Fatura Fatura { get; set; }

    public void FinalizarCheckin(Ticket ticket, Checkin checkin)
    {
        checkin.Status = StatusCheckin.Finalizado;
        checkin.DataSaida = DateTime.Now;

        ticket.Status = StatusCheckin.Finalizado;
        ticket.Vaga.Status = StatusVaga.Disponivel; 
    }
    public override void AtualizarRegistro(Checkout registroEditado)
    {
        DataSaida = registroEditado.DataSaida;
        Fatura = registroEditado.Fatura;
    }

}
