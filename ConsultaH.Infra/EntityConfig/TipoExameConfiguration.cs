using ConsultaH.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ConsultaH.Infra.EntityConfig
{
    public class TipoExameConfiguration : EntityTypeConfiguration<TipoExame>
    {
        public TipoExameConfiguration()
        {
            HasKey(te => te.ID);

            Property(te => te.Nome)
                .IsRequired()
                .HasMaxLength(100);
            
            Property(te => te.Descricao)
                .HasMaxLength(256);
        }
    }
}
