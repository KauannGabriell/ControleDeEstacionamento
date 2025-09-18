using ControleDeEstacionamento.Core.Dominio.ModuloAutenticacao;
using ControleDeEstacionamento.Infraestrutura.Orm.Compartilhado;
using ControleDeEstacionamento.WebApi.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eAgenda.WebApi.Identity;

public static class IdentityConfig
{
    public static void AddIdentityProviderConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITenantProvider, IdentityTenantProvider>();

        services.AddIdentity<Usuario, Cargo>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.AddJwtAuthentication(configuration);
    }

    private static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
    }
}