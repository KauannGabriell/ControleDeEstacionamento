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

            builder.HasOne(f => f.Ticket)
                .WithOne();

            builder.Property(f => f.Placa)
                     .IsRequired();

            builder.Property(f => f.ValorMinuto)
                        .IsRequired();

            builder.Property(f => f.Cor)
                        .IsRequired();

            builder.Property(f => f.ValorTotal)
                        .IsRequired();

            builder.HasOne(f => f.Faturamento)
                .WithMany();

            builder.HasOne(f => f.Checkout)
               .WithOne();
        }
    }
}