using ConsultaH.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ConsultaH.Infra.EntityConfig
{
    public class ExameConfiguration : EntityTypeConfiguration<Exame>
    {
        public ExameConfiguration()
        {
            HasKey(e => e.ID);

            Property(e => e.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(e => e.Observacoes)
                .HasMaxLength(1000);

            HasRequired(e => e.TipoExame)
                .WithMany()
                .HasForeignKey(e => e.TipoExameID);
        }
    }
}
