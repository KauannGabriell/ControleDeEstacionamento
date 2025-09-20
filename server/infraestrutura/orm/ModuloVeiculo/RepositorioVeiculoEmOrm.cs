using ControleDeEstacionamento.Core.Dominio.ModuloVeiculo;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloVeiculo;

public class RepositorioVeiculoEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Veiculo>(contexto), IRepositorioVeiculo;