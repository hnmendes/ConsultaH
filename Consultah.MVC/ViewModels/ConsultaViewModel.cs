using Consultah.MVC.ViewModels.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaH.MVC.ViewModels
{
    public class ConsultaViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nome do Paciente")]
        [Required(ErrorMessage = "Você precisa selecionar um Paciente.")]
        public int PacienteID { get; set; }

        [ForeignKey("PacienteID")]
        public virtual PacienteViewModel Paciente { get; set; }

        [Display(Name = "Tipo do Exame")]
        [Required(ErrorMessage = "Você precisa selecionar um Tipo de Exame.")]
        public int TipoExameID { get; set; }

        [ForeignKey("TipoExameID")]
        public virtual TipoExameViewModel TipoExame { get; set; }

        [Display(Name = "Nome do Exame")]
        [Required(ErrorMessage = "Você precisa selecionar um Exame.")]
        public int ExameID { get; set; }
        
        public virtual ExameViewModel Exame { get; set; }
        
        [Display(Name = "Horário da Consulta")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddThh:mm}", ApplyFormatInEditMode = true)]
        [ColisaoHorario(ErrorMessage = "Não pode ter marcação de consulta neste horário, pois está colidindo com outro consulta previamente cadastrada.")]
        [PassadoHorario(ErrorMessage = "Horário não pode ser escolhido para um dia que já passou.")]
        public DateTime Horario { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Número de Protocolo")]
        public string NumeroProtocolo { get; set; }
    }
}