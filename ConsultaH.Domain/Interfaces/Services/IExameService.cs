using ConsultaH.Domain.Entities;
using System.Collections.Generic;

namespace ConsultaH.Domain.Interfaces.Services
{
    public interface IExameService : IServiceBase<Exame>
    {
        IEnumerable<Exame> GetExamesByTipoExameId(int tipoExameId);
    }
}
