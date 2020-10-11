using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using ConsultaH.Domain.Interfaces.Services;
using System;

namespace ConsultaH.Domain.Services
{
    public class ConsultaService : ServiceBase<Consulta>, IConsultaService
    {
        private readonly IConsultaRepository _repository;

        public ConsultaService(IConsultaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public bool DateExists(DateTime dateTime)
        {
            return _repository.DateExists(dateTime);
        }

    }
}
