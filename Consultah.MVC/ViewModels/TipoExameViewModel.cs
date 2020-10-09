using System.ComponentModel.DataAnnotations;

namespace ConsultaH.MVC.ViewModels
{
    public class TipoExameViewModel
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100, ErrorMessage = "Não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(256, ErrorMessage = "Não pode ter mais de 256 caracteres.")]
        public string Descricao { get; set; }
    }
}