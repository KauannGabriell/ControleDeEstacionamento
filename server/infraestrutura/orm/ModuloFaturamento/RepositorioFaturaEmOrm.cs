using ControleDeEstacionamento.Core.Dominio.ModuloFatura;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloFatura;

public class RepositorioFaturaEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Fatura>(contexto), IRepositorioFatura;