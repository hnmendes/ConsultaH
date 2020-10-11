using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using System;
using System.Linq;

namespace ConsultaH.Infra.Repositories
{
    public class ConsultaRepository : RepositoryBase<Consulta>, IConsultaRepository
    {
        public bool DateExists(DateTime dateTime)
        {
            var consultas = Db.Consultas.ToList();
            var exists = false;

            consultas.ForEach(consulta => {
                
                var condition = (consulta.Horario.Day == dateTime.Day) &&
                                (consulta.Horario.Month == dateTime.Month) &&
                                (consulta.Horario.Year == dateTime.Year) &&
                                (consulta.Horario.Hour == dateTime.Hour) &&
                                (consulta.Horario.Minute == dateTime.Minute);

                if (condition)
                {
                    exists = true;
                }
            });

            return exists;
        }
    }
}
