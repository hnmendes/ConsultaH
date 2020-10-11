using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaH.MVC.ViewModels
{
    public class ExameViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nome do exame é necessário")]
        [MaxLength(100, ErrorMessage = "Não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(1000, ErrorMessage = "Não pode ter mais de 1000 caracteres.")]
        public string Observacoes { get; set; }

        [Required]
        [Display(Name = "Tipo de Exame")]
        public int TipoExameID { get; set; }
        
        [ForeignKey("TipoExameID")]
        public virtual TipoExameViewModel TipoExame { get; set; }
    }
}