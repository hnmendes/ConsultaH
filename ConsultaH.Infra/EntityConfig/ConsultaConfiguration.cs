using ConsultaH.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ConsultaH.Infra.EntityConfig
{
    public class ConsultaConfiguration : EntityTypeConfiguration<Consulta>
    {
        public ConsultaConfiguration()
        {
            HasKey(c => c.ID);

            Property(c => c.Horario)
                .IsRequired();

            Property(c => c.NumeroProtocolo)
                .IsRequired()
                .HasMaxLength(20);

            HasRequired(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteID);

            HasRequired(c => c.TipoExame)
                .WithMany()
                .HasForeignKey(c => c.TipoExameID);

            HasRequired(c => c.Exame)
                .WithMany()
                .HasForeignKey(c => c.ExameID);
            
        }
    }
}
