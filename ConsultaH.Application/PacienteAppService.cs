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

        public bool CPFExists(string cpf)
        {
            return _pacienteService.CPFExists(cpf);
        }

        public void Update(int idPaciente, string telefone = null, string nome = null, string email = null, Sexo? sexo = null)
        {
            _pacienteService.Update(idPaciente, telefone, nome, email, sexo);
        }
    }
}
