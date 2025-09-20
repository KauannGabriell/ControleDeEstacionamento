using ControleDeEstacionamento.Core.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloVaga;

public class RepositorioVagaEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Vaga>(contexto), IRepositorioVaga;