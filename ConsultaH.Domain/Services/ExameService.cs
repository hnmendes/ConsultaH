using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using ConsultaH.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ConsultaH.Domain.Services
{
    public class ExameService : ServiceBase<Exame>, IExameService
    {
        private readonly IExameRepository _repository;
        public ExameService(IExameRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Exame> GetExamesByTipoExameId(int tipoExameId)
        {
            return _repository.GetExamesByTipoExameId(tipoExameId);
        }

        public bool CanDelete(int exameId)
        {
            return _repository.CanDelete(exameId);
        }
    }
}
