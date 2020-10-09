using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using ConsultaH.Domain.Interfaces.Services;

namespace ConsultaH.Domain.Services
{
    public class TipoExameService : ServiceBase<TipoExame>, ITipoExameService
    {
        private readonly ITipoExameRepository _repository;
        public TipoExameService(ITipoExameRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
