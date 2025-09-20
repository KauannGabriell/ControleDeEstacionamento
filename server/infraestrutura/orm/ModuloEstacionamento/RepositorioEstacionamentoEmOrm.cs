using ControleDeEstacionamento.Core.Dominio.ModuloEstacionamento;
using ControleDeEstacionamento.Dominio.ModuloEstacionamento;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloEstacionamento;

public class RepositorioEstacionamentoEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Estacionamento>(contexto), IRepositorioEstacionamento;