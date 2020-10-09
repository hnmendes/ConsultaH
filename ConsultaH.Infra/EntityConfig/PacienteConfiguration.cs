using ConsultaH.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ConsultaH.Infra.EntityConfig
{
    public class PacienteConfiguration : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfiguration()
        {
            
            HasKey(p => p.ID);

            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Sexo)
                .IsOptional();

            Property(p => p.Telefone)
                .IsRequired();

            Property(p => p.CPF)                
                .HasMaxLength(20)
                .IsRequired();

            Property(p => p.DataNascimento)
                .IsRequired();

            Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}
