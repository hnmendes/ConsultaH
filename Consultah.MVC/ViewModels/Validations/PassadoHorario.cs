using System;
using System.ComponentModel.DataAnnotations;

namespace Consultah.MVC.ViewModels.Validations
{
    public class PassadoHorario : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var horarioAtual = DateTime.Now;
            var horarioDesejado = Convert.ToDateTime(value);

            if (horarioAtual > horarioDesejado)
            {
                return false;
            }

            return true;
        }
    }
}