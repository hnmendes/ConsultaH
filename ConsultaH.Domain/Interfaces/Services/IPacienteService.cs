using ConsultaH.Domain.Entities;
using System.Collections.Generic;

namespace ConsultaH.Domain.Interfaces.Services
{
    public interface IPacienteService : IServiceBase<Paciente>
    {
        IEnumerable<Paciente> GetPacienteByNameOrCpf(string cpfOuNome);

        bool CPFExists(string cpf);

        void Update(int idPaciente, string telefone = null, string nome = null, string email = null, Sexo? sexo = null);
    }
}
