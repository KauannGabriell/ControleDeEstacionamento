using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloAutenticacao;
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
    public Veiculo() { }
    public Veiculo ( string placa, string modelo, string cor)
    {
        Id = Guid.NewGuid();
        Placa = placa;
        Modelo = modelo;
        Cor = cor;
    }
    public override void AtualizarRegistro(Veiculo registroEditado)
    {
        Placa = registroEditado.Placa;
        Modelo = registroEditado.Modelo;
        Cor = registroEditado.Cor;
    }
}
