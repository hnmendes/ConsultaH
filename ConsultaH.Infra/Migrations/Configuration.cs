namespace ConsultaH.Infra.Migrations
{
    using ConsultaH.Domain.Entities;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.AppConsultahContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.AppConsultahContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            for (int i = 1; i <= 20; i++)
            {
                context.TipoExames.AddOrUpdate(new TipoExame() { Nome = "Tipo Exame" + i, Descricao = "Descrição Exame" + i, ID = i });
            }


            for (int i = 1; i <= 20; i++)
            {
                context.Exames.AddOrUpdate(new Exame() { ID = i, Nome = "Exame" + i, Observacoes = "Observação Exame" + i, TipoExameID = i });
            }

            
        }
    }
}
