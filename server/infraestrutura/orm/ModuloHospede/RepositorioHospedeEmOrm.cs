using ControleDeEstacionamento.Core.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloHospede;

public class RepositorioHospedeEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Hospede>(contexto), IRepositorioHospede;