using ControleDeEstacionamento.Dominio.ModuloVaga;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeEstacionamento.Infraestrutura.Orm.ModuloVaga
{
    public class MapeadorVagaEmOrm : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.Property(t => t.Id)
                   .ValueGeneratedNever()
                   .IsRequired();
           
            builder.Property(v => v.IdentificadorVaga)
                    .IsRequired();

            builder.Property(v => v.Zona)
                    .IsRequired();

            builder.Property(v => v.Status)
                     .IsRequired();

            builder.HasMany(v => v.Hospedes);

            builder.HasOne(v => v.Veiculo)
                          .WithMany()                    
                          .IsRequired(false);
        }
    }
}