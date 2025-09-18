using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloRastreamento;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;

namespace ControleDeEstacionamento.Dominio.ModuloVaga;

public class Vaga : EntidadeBase<Vaga>
{
    public string IdentificadorVaga { get; private set; } = GeradorIdentificadorVaga.CriarGuidString();
    public  char Zona { get; set; }
    public StatusVaga Status { get; set; }
    public Veiculo Veiculo { get; set; }
    public List<Checkin> Checkins { get; set; } = new List<Checkin>();
    public override void AtualizarRegistro(Vaga registroEditado)
    {
        IdentificadorVaga = registroEditado.IdentificadorVaga;
        Zona = registroEditado.Zona;
        Status = registroEditado.Status;
        Veiculo = registroEditado.Veiculo;
        Checkins = registroEditado.Checkins;
    }

    public StatusVaga VerificarStatusVaga(Vaga vaga)
    {
        if(vaga.Veiculo == null)
            return StatusVaga.Disponivel;

        else
            return StatusVaga.Ocupada;
    }
}
