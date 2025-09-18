using ControleDeEstacionamento.Core.Aplicacao;
using ControleDeEstacionamento.WebApi.AutoMapper;
using ControleDeEstacionamento.WebApi.Orm;
using ControleDeEstacionamento.WebApi.Swagger;
using eAgenda.WebApi.Identity;
using ControleDeEstacionamento.Infraestutura.Orm;
using System.Text.Json.Serialization;

namespace Gestao_de_Estacionamentos.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                    .AddCamadaAplicacao(builder.Logging, builder.Configuration);

                    builder.Services.AddCamadaInfraestruturaOrm(builder.Configuration);

            builder.Services.AddAutoMapperProfiles(builder.Configuration);

            builder.Services.AddIdentityProviderConfig(builder.Configuration);

            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            builder.Services.AddSwaggerConfig();

            builder.Services.AddSwaggerGen(c =>
            {
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.ApplyMigrations();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}