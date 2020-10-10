using ConsultaH.Domain.Entities;
using System.Collections.Generic;

namespace ConsultaH.Domain.Interfaces
{
    public interface IPacienteRepository : IRepositoryBase<Paciente>
    {        
        IEnumerable<Paciente> GetPacienteByNameOrCpf(string cpfOuNome);
        bool CPFExists(string cpf);

    }
}
