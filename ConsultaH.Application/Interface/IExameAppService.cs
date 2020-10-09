using ConsultaH.Domain.Entities;
using System.Collections.Generic;

namespace ConsultaH.Application.Interface
{
    public interface IExameAppService : IAppServiceBase<Exame>
    {
        IEnumerable<Exame> GetExamesByTipoExameId(int tipoExameId);
    }
}
