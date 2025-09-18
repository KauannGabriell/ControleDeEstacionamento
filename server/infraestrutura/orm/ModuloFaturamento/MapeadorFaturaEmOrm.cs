using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestutura.Orm.ModuloFatura
{
    public class MapeadorFaturaEmOrm : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {

            builder.Property(f => f.Id)
                      .ValueGeneratedNever()
                      .IsRequired();

            builder.HasOne(f => f.Ticket);

            builder.HasOne(f => f.Checkout);

            builder.Property(f => f.ValorMinuto)
                        .IsRequired();


            builder.HasOne(f => f.Hospede)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.Veiculo)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(f => f.Faturamento)
                        .WithMany(fa => fa.Faturas)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.Property(f => f.ValorTotal)
                        .IsRequired();
        }
    }
}