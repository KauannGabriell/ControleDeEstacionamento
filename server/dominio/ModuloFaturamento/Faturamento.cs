using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Dominio.ModuloCheckin;

namespace ControleDeEstacionamento.Dominio.ModuloFaturamento;
public class Faturamento : EntidadeBase<Faturamento>
{
    public List<Fatura> Faturas { get; set; }

    public float ValorTotal { get; set; }

    public Faturamento () { }

    public Faturamento(List<Fatura> faturas,  float valorTotal)
    {
        Id = new Guid();
        Faturas = faturas;
        ValorTotal = valorTotal;
    }
    public override void AtualizarRegistro(Faturamento registroEditado)
    {
        Faturas = registroEditado.Faturas;
    }

    public float ObterValorTotal(List<Fatura> Faturas)
    { 
        float valorTotal = 0;
        foreach (var fatura in Faturas)
        {
            valorTotal += fatura.ValorTotal;
        }
        return valorTotal;
    }
}
