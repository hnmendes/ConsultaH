using ConsultaH.Application.Interface;
using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces.Services;

namespace ConsultaH.Application
{
    public class TipoExameAppService : AppServiceBase<TipoExame>, ITipoExameAppService
    {
        private readonly ITipoExameService _tipoExameService;

        public TipoExameAppService(ITipoExameService tipoExameService) : base (tipoExameService)
        {
            _tipoExameService = tipoExameService;
        }

        public bool CanDelete(int tipoExameId)
        {
            return _tipoExameService.CanDelete(tipoExameId);
        }
    }
}
