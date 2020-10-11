using ConsultaH.Domain.Entities;
using System.Collections.Generic;

namespace ConsultaH.Domain.Interfaces
{
    public interface IExameRepository : IRepositoryBase<Exame>
    {
        IEnumerable<Exame> GetExamesByTipoExameId(int tipoExameId);
        bool CanDelete(int exameId);
    }
}
