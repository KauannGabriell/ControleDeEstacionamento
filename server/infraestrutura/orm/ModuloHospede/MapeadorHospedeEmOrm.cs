using ControleDeEstacionamento.Dominio.ModuloFaturamento;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloHospede
{
    public class MapeadorHospedeEmOrm : IEntityTypeConfiguration<Hospede>
    {
        public void Configure(EntityTypeBuilder<Hospede> builder)
        {
            builder.Property(c => c.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(c => c.Nome)
                     .IsRequired()
                     .HasMaxLength(100);

            builder.Property(c => c.Telefone)
                        .IsRequired()
                        .HasMaxLength(20);

            builder.Property(c => c.Cpf)
                        .IsRequired()
                        .HasMaxLength(14);

            builder.Ignore(c => c.Veiculo);
        }
    }
}