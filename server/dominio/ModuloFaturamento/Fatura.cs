using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloCheckout;
using ControleDeEstacionamento.Dominio.ModuloTicket;

namespace ControleDeEstacionamento.Dominio.ModuloFaturamento;
public class Fatura : EntidadeBase<Fatura>
{
    public Ticket Ticket { get; set; }

    public Checkout Checkout { get; set; }
    public DateTime Placa { get; set; }
    public float ValorMinuto
    {
        get
        {
            return 0.10f;
        }

        set { }
    }
    public string Cor { get; set; }
    public float ValorTotal { get; set; }
    public Faturamento Faturamento { get; set; }

    public override void AtualizarRegistro(Fatura registroEditado)
    {
        Ticket = registroEditado.Ticket;
        Placa = registroEditado.Placa;
        ValorMinuto = registroEditado.ValorMinuto;
        Cor = registroEditado.Cor;
    }

    public void ObterValorTotal(Checkin checkin, Checkout checkout)
    {
        var totalMinutos = ObterTempoDeDuracaoCheckin(checkin, checkout).Minutes;
        ValorTotal = totalMinutos * ValorMinuto;
    }

    public TimeSpan ObterTempoDeDuracaoCheckin(Checkin checkin, Checkout checkout)
    {
        TimeSpan ts = checkout.DataSaida - checkin.DataEntrada;
        return ts;
    }
}
