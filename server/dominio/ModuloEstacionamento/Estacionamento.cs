
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstacionamento.Dominio.ModuloEstacionamento;
public class Estacionamento : EntidadeBase<Estacionamento>
{
    public List<Vaga> Vagas { get; set; }

    [NotMapped]
    public List<Vaga> VagasOCupadas { get; set; }


    public Estacionamento() { }

    public Estacionamento(List<Vaga> vagas, List<Vaga> vagasOCupadas)
    {
        Id = Guid.NewGuid();
        Vagas = vagas;
        VagasOCupadas = vagasOCupadas;
    }

    public override void AtualizarRegistro(Estacionamento registroEditado)
    {
        
        Vagas = registroEditado.Vagas;
        VagasOCupadas = registroEditado.VagasOCupadas;
    }
}
