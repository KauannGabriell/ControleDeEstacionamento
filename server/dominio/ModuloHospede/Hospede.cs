using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstacionamento.Dominio.ModuloHospede;

public class Hospede : EntidadeBase<Hospede>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }

    [NotMapped]
    public Veiculo Veiculo { get; set; }
    public override void AtualizarRegistro(Hospede registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        Cpf = registroEditado.Cpf;
        Veiculo = registroEditado.Veiculo;
    }
}
