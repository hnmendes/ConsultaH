using ConsultaH.Application.Interface;
using Ninject;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Consultah.MVC.ViewModels.ExtensionMethods;

namespace Consultah.MVC.ViewModels.Validations
{
    public class CpfExiste : ValidationAttribute
    {
        [Inject]
        public IPacienteAppService _pacienteApp {private get; set; }

        public override bool IsValid(object value)
        {
            if(value != null)
            {
                string cpf = value.ToString().RemoverCaractereCPF();

                var existe = !_pacienteApp.GetAll().Any(p => p.CPF == cpf);

                return existe;
            }

            return true;
        }
    }
}