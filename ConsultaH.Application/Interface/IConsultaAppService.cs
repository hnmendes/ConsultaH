using ConsultaH.Domain.Entities;
using System;

namespace ConsultaH.Application.Interface
{
    public interface IConsultaAppService : IAppServiceBase<Consulta>
    {
        bool DateExists(DateTime dateTime);        

    }
}
