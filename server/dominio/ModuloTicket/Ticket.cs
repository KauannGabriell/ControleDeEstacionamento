using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;

namespace ControleDeEstacionamento.Dominio.ModuloTicket;

public class Ticket : EntidadeBase<Ticket>
{
    public Veiculo Veiculo { get; set; }
    public int IdentificadorUnicoSequencial { get; private set; }
    public Hospede? Hospede { get; set; }
    public DateTime DataEntrada { get; set; }
    public Vaga Vaga { get; set; }
    public StatusCheckin Status { get; set; }
    public Fatura? Fatura { get; set; }
    public override void AtualizarRegistro(Ticket registroEditado)
    {
        Fatura = registroEditado.Fatura;
        DataEntrada = registroEditado.DataEntrada;
        Veiculo = registroEditado.Veiculo;
        IdentificadorUnicoSequencial = registroEditado.IdentificadorUnicoSequencial;
        Hospede = registroEditado.Hospede;
        Status = registroEditado.Status;
        Vaga = registroEditado.Vaga;
    }

    private void GerarIdentificadorUnicoSequencial(int ultimoId)
    {
        IdentificadorUnicoSequencial = ultimoId + 1;
    }

    public static Ticket GerarTicket(
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
}
