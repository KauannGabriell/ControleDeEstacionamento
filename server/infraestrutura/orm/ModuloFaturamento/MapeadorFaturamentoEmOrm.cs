using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestutura.Orm.ModuloFatura
{
    public class MapeadorFaturamentoEmOrm : IEntityTypeConfiguration<Faturamento>
    {
        public void Configure(EntityTypeBuilder<Faturamento> builder)
        {
            builder.Property(f => f.Id)
               .ValueGeneratedNever()
               .IsRequired();

            builder.HasMany(f => f.Faturas)
                .WithOne(fa => fa.Faturamento)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(f => f.ValorTotal)
                        .IsRequired();

        }
    }
}