
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using System.Collections.Generic;

namespace ControleDeEstacionamento.Dominio.ModuloRastreamento;
public class Rastreamento : EntidadeBase<Rastreamento>
{
    //    Atributos:
    //Status de todas as vaga(livre, ocupado)
    // Lista de Vagas
    //Registrar veículo
    //Registrar Saída de veículo
    //Encerra Locação
    //Lista de Tickets
    //Listar todos os veículos(ocupados)

    public List<Vaga> Vagas { get; set; }
    public List<Vaga> VagasOCupadas { get; set; }
    public List<Veiculo> Veiculos { get; set; }


    public override void AtualizarRegistro(Rastreamento registroEditado)
    {
        throw new NotImplementedException();
    }
}
