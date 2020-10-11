using ConsultaH.Domain.Entities;

namespace ConsultaH.Domain.Interfaces
{
    public interface ITipoExameRepository : IRepositoryBase<TipoExame>
    {
        bool CanDelete(int tipoExameId);
    }
}
