using ConsultaH.Domain.Entities;
using System;

namespace ConsultaH.Domain.Interfaces.Services
{
    public interface IConsultaService : IServiceBase<Consulta>
    {
        bool DateExists(DateTime dateTime);
    }
}
