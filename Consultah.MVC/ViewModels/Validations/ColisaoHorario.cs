using ConsultaH.Application.Interface;
using Ninject;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Consultah.MVC.ViewModels.Validations
{
    public class ColisaoHorario : ValidationAttribute
    {
        [Inject]
        public IConsultaAppService _consultaApp { get; set; }

        public override bool IsValid(object value)
        {
            var horario = Convert.ToDateTime(value);

            var consultas = _consultaApp.GetAll().ToList();
            var horarioColide = false;

            consultas.ForEach(consulta => {

                var condition = (consulta.Horario.Day == horario.Day) &&
                                (consulta.Horario.Month == horario.Month) &&
                                (consulta.Horario.Year == horario.Year) &&
                                (consulta.Horario.Hour == horario.Hour) &&
                                (consulta.Horario.Minute == horario.Minute);

                horarioColide = (condition) ? true : false;
            });

            return horarioColide;
        }
    }
}