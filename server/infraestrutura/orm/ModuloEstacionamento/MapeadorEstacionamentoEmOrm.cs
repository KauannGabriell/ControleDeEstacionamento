using ControleDeEstacionamento.Dominio.ModuloEstacionamento;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestutura.Orm.ModuloEstacionamento
{
    public class MapeadorEstacionamentoEmOrm : IEntityTypeConfiguration<Estacionamento>
    {
        public void Configure(EntityTypeBuilder<Estacionamento> builder)
        {

            builder.Property(f => f.Id)
                      .ValueGeneratedNever()
                      .IsRequired();

            builder.HasKey(f => f.Id);

            builder.HasMany(f => f.Vagas);
                   
        }
    }
}