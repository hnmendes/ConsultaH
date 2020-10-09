using ConsultaH.Domain.Entities;
using System.Collections.Generic;

namespace ConsultaH.Domain.Interfaces.Services
{
    public interface IPacienteService : IServiceBase<Paciente>
    {
        IEnumerable<Paciente> GetPacienteByNameOrCpf(string cpfOuNome);
    }
}
