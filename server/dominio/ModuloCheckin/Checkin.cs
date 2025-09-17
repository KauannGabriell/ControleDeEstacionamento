using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstacionamento.Dominio.ModuloCheckin;
public class Checkin : EntidadeBase<Checkin>
{
    public DateTime DataEntrada { 
        get
        {
            return DateTime.Now;
        }
                                }
    public override void AtualizarRegistro(Checkin registroEditado)
    {
        throw new NotImplementedException();
    }
}

