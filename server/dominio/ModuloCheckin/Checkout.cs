using ControleDeEstacionamento.Core.Dominio.Compartilhado;

namespace ControleDeEstacionamento.Dominio.ModuloCheckin;
public class Checkout 
{
    public DateTime DataSaida
    {
        get
        {
            return DateTime.Now;
        }
    }
    public Checkin Checkin { get; set; }

    public void FinalizarCheckin(Checkin checkin)
    {
        checkin.FinalizarTicket(checkin);
    }

}
