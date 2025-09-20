using ControleDeEstacionamento.Core.Dominio.ModuloCheckout;
using ControleDeEstacionamento.Dominio.ModuloCheckout;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloCheckout;

public class RepositorioCheckoutEmOrm(AppDbContext contexto)
    : RepositorioBaseEmOrm<Checkout>(contexto), IRepositorioCheckout;