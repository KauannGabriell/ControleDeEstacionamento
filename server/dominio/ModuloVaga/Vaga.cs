using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloRastreamento;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;

namespace ControleDeEstacionamento.Dominio.ModuloVaga;

public class Vaga : EntidadeBase<Vaga>
{
    public string IdentificadorVaga { get; private set; } = GeradorIdentificadorVaga.CriarGuidString();
    public Zona Zona { get; set; }
    public Status Status { get; set; }
    public Veiculo Veiculo { get; set; }

    public override void AtualizarRegistro(Vaga registroEditado)
    {
        IdentificadorVaga = registroEditado.IdentificadorVaga;
        Zona = registroEditado.Zona;
        Status = registroEditado.Status;
        Veiculo = registroEditado.Veiculo;
    }

    public Status VerificarStatusVaga(Vaga vaga)
    {
        if(vaga.Veiculo == null)
            return Status.Disponivel;

        else
            return Status.Ocupada;
    }
}
