using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloTicket;

namespace ControleDeEstacionamento.Dominio.ModuloVeiculo;
public class Veiculo : EntidadeBase<Veiculo>
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public Checkin Checkin { get; set; }
    public Hospede? Hospede { get; set; }

    public Ticket Ticket { get; set; }
    public override void AtualizarRegistro(Veiculo registroEditado)
    {
        Placa = registroEditado.Placa;
        Modelo = registroEditado.Modelo;
        Cor = registroEditado.Cor;
        Checkin = registroEditado.Checkin;
        Hospede = registroEditado.Hospede;
        Ticket = registroEditado.Ticket;
    }
}
