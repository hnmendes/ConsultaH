using ConsultaH.Domain.Entities;
using ConsultaH.Domain.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ConsultaH.Infra.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {        
        public IEnumerable<Paciente> GetPacienteByNameOrCpf(string cpfOuNome)
        {
            return Db.Pacientes.Where(p => p.CPF.Contains(cpfOuNome) || p.Nome.Contains(cpfOuNome)).ToList();
        }

        public bool CPFExists(string cpf)
        {
            return Db.Pacientes.Any(p => p.CPF == cpf);
        } 

        public void Update(int idPaciente, string telefone = null, string nome = null, string email = null, Sexo? sexo = null)
        {
            var paciente = Db.Pacientes.Find(idPaciente);

            if (telefone != null)
            {
                paciente.Telefone = telefone;
            }

            if(nome != null)
            {
                paciente.Nome = nome;
            }

            if(email != null)
            {
                paciente.Email = email;
            }

            if(sexo != null)
            {
                paciente.Sexo = sexo.Value;
            }

            base.Update(paciente);
        }
    }
}
