using ConsultaH.Domain.Entities;
using ConsultaH.Infra.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConsultaH.Infra.Context
{
    public class AppConsultahContext : DbContext
    {
        public AppConsultahContext() : base("consultahConnectionString")
        {

        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoExame> TipoExames { get; set; }
        public DbSet<Exame> Exames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(200));

            modelBuilder.Configurations.Add(new PacienteConfiguration());
            modelBuilder.Configurations.Add(new ExameConfiguration());
            modelBuilder.Configurations.Add(new ConsultaConfiguration());
            modelBuilder.Configurations.Add(new TipoExameConfiguration());

            base.OnModelCreating(modelBuilder);

        }

        public override int SaveChanges()
        {
            foreach (var entrada in ChangeTracker.Entries<Consulta>())
            {
                var consulta = entrada.Entity;                

                if (entrada.State == EntityState.Added)
                {                    
                    entrada.Property("NumeroProtocolo").CurrentValue = consulta.Horario.ToString("yyMMddHHmmssffffff");
                }

                if (entrada.State == EntityState.Modified)
                {
                    entrada.Property("NumeroProtocolo").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
