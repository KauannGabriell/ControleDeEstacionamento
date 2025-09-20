using ControleDeEstacionamento.Core.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloFaturamento;

public class RepositorioFaturamentoEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Faturamento>(contexto), IRepositorioFaturamento;