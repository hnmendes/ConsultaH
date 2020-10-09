namespace ConsultaH.Domain.Entities
{
    public class Exame
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Observacoes { get; set; }

        public int TipoExameID { get; set; }

        public virtual TipoExame TipoExame { get; set; }
    }
}
