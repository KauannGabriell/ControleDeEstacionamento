using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloAutenticacao;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloCheckout;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloRastreamento;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<Usuario, Cargo, Guid>(options), IUnitOfWork
{
    public DbSet<Vaga> Vagas { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Checkin> Checkins { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Fatura> Faturas { get; set; }
    public DbSet<Faturamento> Faturamentos { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Hospede> Hospedes { get; set; }

    public DbSet<Estacionamento> Estacionamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(AppDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task CommitAsync()
    {
        await SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Unchanged;
                    break;

                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }
        }

        await Task.CompletedTask;
    }
}