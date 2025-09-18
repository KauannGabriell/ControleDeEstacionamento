using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloVaga
{
    public class MapeadorVeiculoEmOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.Property(t => t.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(v => v.Placa)
                    .IsRequired();

            builder.Property(v => v.Modelo)
                   .IsRequired();

            builder.Property(v => v.Cor)
              .IsRequired();

            builder.HasOne(c => c.Hospede);
        }
    }
}