using ControleDeEstacionamento.Core.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloCheckin;

public class RepositorioCheckinEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Checkin>(contexto), IRepositorioCheckin;