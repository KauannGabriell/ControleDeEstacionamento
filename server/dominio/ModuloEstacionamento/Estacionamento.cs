
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstacionamento.Dominio.ModuloRastreamento;
public class Estacionamento : EntidadeBase<Estacionamento>
{
    public List<Vaga> Vagas { get; set; }

    [NotMapped]
    public List<Vaga> VagasOCupadas { get; set; }
    public List<Vaga> ObtendoVagasPorZona(int numeroVagasZona, char zona)
    {

        Vagas = new List<Vaga>();
        for (int i = 0; i < numeroVagasZona; i++)
        {
            Vagas.Add(new Vaga
            {
                Zona = zona,
                Status = StatusVaga.Disponivel,
                IdentificadorVaga = GeradorIdentificadorVaga.CriarGuidString()
            });
        }
        return Vagas;
    }

    public override void AtualizarRegistro(Estacionamento registroEditado)
    {
        
        Vagas = registroEditado.Vagas;
        VagasOCupadas = registroEditado.VagasOCupadas;
    }
}
