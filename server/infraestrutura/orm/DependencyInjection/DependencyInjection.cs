using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Core.Dominio.ModuloHospede;
using ControleDeEstacionamento.Core.Dominio.ModuloTicket;
using ControleDeEstacionamento.Core.Dominio.ModuloVaga;
using ControleDeEstacionamento.Core.Dominio.ModuloVeiculo;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;
using ControleDeEstacionamento.Infraestrutura.Orm.ModuloCheckin;
using ControleDeEstacionamento.Infraestrutura.Orm.ModuloHospede;
using ControleDeEstacionamento.Infraestrutura.Orm.ModuloTicket;
using ControleDeEstacionamento.Infraestrutura.Orm.ModuloVaga;
using ControleDeEstacionamento.Infraestrutura.Orm.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleDeEstacionamento.Infraestutura.Orm;
public static class DependencyInjection
{
    public static IServiceCollection AddCamadaInfraestruturaOrm(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRepositorioVeiculo, RepositorioVeiculoEmOrm>();
        services.AddScoped<IRepositorioVaga, RepositorioVagaEmOrm>();
        services.AddScoped<IRepositorioHospede, RepositorioHospedeEmOrm>();
        services.AddScoped<IRepositorioCheckin, RepositorioCheckinEmOrm>();
        services.AddScoped<IRepositorioTicket, RepositorioTicketEmOrm>();

        services.AddEntityFrameworkConfig(configuration);

        return services;
    }

    private static void AddEntityFrameworkConfig(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration["SQL_CONNECTION_STRING"];

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new Exception("A variável SQL_CONNECTION_STRING não foi fornecida.");

        services.AddDbContext<IUnitOfWork, AppDbContext>(options =>
            options.UseNpgsql(connectionString, (opt) => opt.EnableRetryOnFailure(3)));
    }
}