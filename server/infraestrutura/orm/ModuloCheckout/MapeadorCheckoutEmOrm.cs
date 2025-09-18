using ControleDeEstacionamento.Dominio.ModuloCheckout;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloCheckout
{
    public class MapeadorCheckoutEmOrm : IEntityTypeConfiguration<Checkout>
    {
        public void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder.Property(c => c.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(c => c.DataSaida)
                   .IsRequired();

            builder.HasOne(c => c.Fatura)
                .WithOne();
        }
    }
}