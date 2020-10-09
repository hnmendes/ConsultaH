using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ConsultaH.Infra.Repositories
{
    public class ExameRepository : RepositoryBase<Exame>, IExameRepository
    {
        public IEnumerable<Exame> GetExamesByTipoExameId(int tipoExameId)
        {
            return Db.Exames.Where(e => e.TipoExameID == tipoExameId).ToList();
        }
    }
}
