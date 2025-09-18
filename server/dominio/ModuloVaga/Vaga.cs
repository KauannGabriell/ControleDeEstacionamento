using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloRastreamento;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;

namespace ControleDeEstacionamento.Dominio.ModuloVaga;

public class Vaga : EntidadeBase<Vaga>
{
    public string IdentificadorVaga { get; set; } = GeradorIdentificadorVaga.CriarGuidString();
    public char Zona { get; set; }
    public StatusVaga Status { get; set; }
    public List<Hospede> Hospedes { get; set; } = new List<Hospede>();
    public Veiculo Veiculo { get; set; }
    public Estacionamento Estacionamento { get; set; }
    public override void AtualizarRegistro(Vaga registroEditado)
    {
        IdentificadorVaga = registroEditado.IdentificadorVaga;
        Zona = registroEditado.Zona;
        Status = registroEditado.Status;
        Veiculo = registroEditado.Veiculo;
        Hospedes = registroEditado.Hospedes;
        Estacionamento = registroEditado.Estacionamento;
    }

    public StatusVaga VerificarStatusVaga(Vaga vaga)
    {
        if(vaga.Veiculo == null)
            return StatusVaga.Disponivel;

        else
            return StatusVaga.Ocupada;
    }
}
