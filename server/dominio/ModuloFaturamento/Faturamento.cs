using ControleDeEstacionamento.Core.Dominio.Compartilhado;

namespace ControleDeEstacionamento.Dominio.ModuloFaturamento;
public class Faturamento : EntidadeBase<Faturamento>
{
    public DateTime Placa { get; set; }
    public string ValorDiaria { get; set; }
    public string Cor { get; set; }

    public override void AtualizarRegistro()
    {
    }
}
