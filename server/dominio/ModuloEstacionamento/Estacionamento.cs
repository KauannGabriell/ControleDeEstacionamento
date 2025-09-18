
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using System.Collections.Generic;

namespace ControleDeEstacionamento.Dominio.ModuloRastreamento;
public class Estacionamento : EntidadeBase<Estacionamento>
{
    public List<Vaga> Vagas { get; set; }
    public List<Vaga> VagasOCupadas { get; set; }
    public List<Veiculo> Veiculos { get; set; }

    public List<Vaga> ObtendoVagasPorZona(int numeroVagasZona, char zona)
    {

        Vagas = new List<Vaga>();
        for (int i = 0; i < numeroVagasZona; i++)
        {
            Vagas.Add(new Vaga
            {
                Zona = zona,
                Status = StatusVaga.Disponivel
            });
        }
        return Vagas;
    }

    public override void AtualizarRegistro(Estacionamento registroEditado)
    {
        
        Vagas = registroEditado.Vagas;
        Veiculos = registroEditado.Veiculos;
        VagasOCupadas = registroEditado.VagasOCupadas;
    }
}
