using ConsultaH.Application.Interface;
using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ConsultaH.Application
{
    public class PacienteAppService : AppServiceBase<Paciente>, IPacienteAppService
    {
        private readonly IPacienteService _pacienteService;

        public PacienteAppService(IPacienteService pacienteService) : base(pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public IEnumerable<Paciente> GetPacienteByNameOrCpf(string cpfOuNome)
        {
            return _pacienteService.GetPacienteByNameOrCpf(cpfOuNome);
        }
    }
}
