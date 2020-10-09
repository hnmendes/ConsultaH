using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using ConsultaH.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ConsultaH.Domain.Services
{
    public class PacienteService : ServiceBase<Paciente>, IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Paciente> GetPacienteByNameOrCpf(string cpfOuNome)
        {
            return _repository.GetPacienteByNameOrCpf(cpfOuNome);
        }
    }
}
