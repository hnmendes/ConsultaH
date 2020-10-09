namespace ConsultaH.Infra.Migrations
{
    using ConsultaH.Domain.Entities;
    using System;
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

            var random = new Random();
            var sexo = random.Next(0, 2);
            var ddd = random.Next(11, 99);

            for (int i = 1; i <= 20; i++)
            {
                context.TipoExames.AddOrUpdate(new TipoExame() { Nome = "Tipo Exame" + i, Descricao = "Descrição Exame" + i, ID = i });
            }


            for (int i = 1; i <= 20; i++)
            {
                context.Exames.AddOrUpdate(new Exame() { ID = i, Nome = "Exame" + i, Observacoes = "Observação Exame" + i, TipoExameID = i });
            }

            for (int i = 1; i <= 20; i++)
            {
                if(i > 9)
                {
                    context.Pacientes.AddOrUpdate(new Paciente() { ID = i, CPF = "852961874" + i, DataNascimento = DateTime.Now, Email = "emailtest"+i+"@consultah.com", Nome="Teste " + i, Sexo = (Sexo)sexo, Telefone = ddd + "9" + "865227" + i });
                }
                else
                {
                    context.Pacientes.AddOrUpdate(new Paciente() { ID = i, CPF = "8529618747" + i, DataNascimento = DateTime.Now, Email = "emailtest" + i + "@consultah.com", Nome = "Teste " + i, Sexo = (Sexo)sexo, Telefone = ddd + "9" + "8652275" + i });
                }
            }

            for (int i = 1; i <= 20; i++)
            {
                context.Consultas.AddOrUpdate(new Consulta() { ID = i, PacienteID = i, ExameID = i, Horario = DateTime.Now.AddDays(i), TipoExameID = i });
            }
            
        }
    }
}
