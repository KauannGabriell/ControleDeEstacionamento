using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstacionamento.Dominio.ModuloVeiculo;
public class Veiculo : EntidadeBase<Veiculo>
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }

    [NotMapped]
    public Checkin Checkin { get; set; }
    public Hospede? Hospede { get; set; }
    public List<Vaga> Vagas { get; set; } = new List<Vaga>();
    public Ticket Ticket { get; set; }
    public override void AtualizarRegistro(Veiculo registroEditado)
    {
        Placa = registroEditado.Placa;
        Modelo = registroEditado.Modelo;
        Cor = registroEditado.Cor;
        Checkin = registroEditado.Checkin;
        Hospede = registroEditado.Hospede;
        Ticket = registroEditado.Ticket;
        Vagas = registroEditado.Vagas;
    }
}
