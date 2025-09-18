using ControleDeEstacionamento.Dominio.ModuloCheckout;
using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloTicket
{
    public class MapeadorTicketEmOrm : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(t => t.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.HasOne(t => t.Veiculo)
                .WithMany();

            builder.Property(t => t.IdentificadorUnicoSequencial)
                .IsRequired();

            builder.HasOne(t => t.Hospede)
                 .WithMany()
                 .IsRequired(false);

            builder.Property(t => t.DataEntrada)
                 .IsRequired();

            builder.HasOne(t => t.Vaga)
                 .WithMany();
            
            builder.Property(t => t.Status)
                 .IsRequired();

            builder.Ignore(c => c.Checkin);
            builder.Ignore(c => c.Fatura);


        }
    }
}