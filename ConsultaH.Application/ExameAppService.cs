using ConsultaH.Application.Interface;
using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ConsultaH.Application
{
    public class ExameAppService : AppServiceBase<Exame>, IExameAppService
    {
        private readonly IExameService _exameService;

        public ExameAppService(IExameService exameService) : base(exameService)
        {
            _exameService = exameService;
        }

        public IEnumerable<Exame> GetExamesByTipoExameId(int tipoExameId)
        {
            return _exameService.GetExamesByTipoExameId(tipoExameId);
        }
        
        public bool CanDelete(int exameId)
        {
            return _exameService.CanDelete(exameId);
        }
    }
}
