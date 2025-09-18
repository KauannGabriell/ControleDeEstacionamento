using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestutura.Orm.ModuloCheckin
{
    public class MapeadorCheckinEmOrm : IEntityTypeConfiguration<Checkin>
    {
        public void Configure(EntityTypeBuilder<Checkin> builder)
        {

            builder.Property(c => c.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(c => c.DataEntrada)
                        .IsRequired();

            builder.Property(c => c.UltimoIdTicket)
              .IsRequired();

            builder.HasOne(c => c.Veiculo)
            .WithOne();

            builder.Property(c => c.DataSaida)
                        .IsRequired(false);

            builder.Property(c => c.Status)
                        .IsRequired();

            builder.HasOne(c => c.Vaga)
                .WithMany();

            builder.HasOne(c => c.Hospede)
                .WithMany()
                .IsRequired(false);
        }
    }
}