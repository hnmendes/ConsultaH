using ConsultaH.Domain.Entities;
using System.Collections.Generic;

namespace ConsultaH.Application.Interface
{
    public interface IPacienteAppService : IAppServiceBase<Paciente>
    {
        IEnumerable<Paciente> GetPacienteByNameOrCpf(string cpfOuNome);
    }
}
