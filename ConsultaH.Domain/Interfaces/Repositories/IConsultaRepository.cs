using ConsultaH.Domain.Entities;
using System;

namespace ConsultaH.Domain.Interfaces
{
    public interface IConsultaRepository : IRepositoryBase<Consulta>
    {
        bool DateExists(DateTime dateTime);
    }
}
