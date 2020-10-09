using Consultah.MVC.ViewModels.ExtensionMethods;
using Consultah.MVC.ViewModels.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsultaH.MVC.ViewModels
{
    public enum Sexo
    {
        Feminino, Masculino
    }

    public class PacienteViewModel
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100, ErrorMessage = "Não pode ter mais que 100 caracteres.")]
        [Required]
        [Display(Name = "Nome do Paciente")]
        public string Nome { get; set; }
        
        [CpfExiste(ErrorMessage = "CPF já cadastrado.")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessage = "CPF Inválido.")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public Sexo Sexo { get; set; }        

        [RegularExpression(@"^1\d\d(\d\d)?$|^0800 ?\d{3} ?\d{4}$|^(\(0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d\) ?|0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d[ .-]?)?(9|9[ .-])?[2-9]\d{3}[ .-]?\d{4}$", ErrorMessage = "Telefone Inválido.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Email Inválido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
    
}