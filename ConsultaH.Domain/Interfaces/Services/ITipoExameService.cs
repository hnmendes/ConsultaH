using ConsultaH.Domain.Entities;

namespace ConsultaH.Domain.Interfaces.Services
{
    public interface ITipoExameService : IServiceBase<TipoExame>
    {
        bool CanDelete(int tipoExameId);
    }
}
