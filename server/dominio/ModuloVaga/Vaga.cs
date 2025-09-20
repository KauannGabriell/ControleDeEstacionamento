using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloEstacionamento;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace ControleDeEstacionamento.Dominio.ModuloVaga;

public class Vaga : EntidadeBase<Vaga>
{
    public string IdentificadorVaga { get; set; }
    public char Zona { get; set; }
    public StatusVaga Status { get; set; }
    public List<Hospede>? Hospedes { get; set; } = new List<Hospede>();
    public Estacionamento? Estacionamento { get; set; }
    public Veiculo? Veiculo { get; set; }

    public Vaga() { }

    public List<Vaga> ObtendoVagasPorZona(int numeroVagasZona, char zona)
    {

        var Vagas = new List<Vaga>();
        for (int i = 0; i < numeroVagasZona; i++)
        {
            Vagas.Add(new Vaga
            {
                Id = Guid.NewGuid(),
                Zona = zona,
                Status = StatusVaga.Disponivel,
                IdentificadorVaga = GeradorIdentificadorVaga.CriarGuidString()
            });
        }
        return Vagas;
    }
    public Vaga(char zona, StatusVaga statusVaga, List<Hospede> hospedes, Estacionamento estacionamento)
    {
        Id = Guid.NewGuid();
        IdentificadorVaga = GeradorIdentificadorVaga.CriarGuidString();
        Zona = zona;
        Status = statusVaga;
        Hospedes = hospedes;
        Estacionamento = estacionamento;
    }
    public override void AtualizarRegistro(Vaga registroEditado)
    {
        IdentificadorVaga = registroEditado.IdentificadorVaga;
        Zona = registroEditado.Zona;
        Status = registroEditado.Status;
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
