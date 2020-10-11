using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using System.Linq;

namespace ConsultaH.Infra.Repositories
{
    public class TipoExameRepository : RepositoryBase<TipoExame>, ITipoExameRepository
    {
        public bool CanDelete(int tipoExameId)
        {
            var isInExames = Db.Exames.Any(e => e.TipoExameID == tipoExameId);
            var isInConsultas = Db.Consultas.Any(c => c.TipoExameID == tipoExameId);

            return !isInConsultas && !isInConsultas;
        }
    }
}
