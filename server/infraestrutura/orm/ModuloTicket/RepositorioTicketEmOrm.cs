using ControleDeEstacionamento.Core.Dominio.ModuloTicket;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloTicket;

public class RepositorioTicketEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Ticket>(contexto), IRepositorioTicket;