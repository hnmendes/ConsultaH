using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ConsultaH.Infra.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public IEnumerable<Paciente> GetPacienteByNameOrCpf(string cpfOuNome)
        {
            return Db.Pacientes.Where(p => p.CPF.Contains(cpfOuNome) || p.Nome.Contains(cpfOuNome)).ToList();
        }
    }
}
