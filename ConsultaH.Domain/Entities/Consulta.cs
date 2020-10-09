using System;

namespace ConsultaH.Domain.Entities
{
    public class Consulta
    {
        public int ID { get; set; }
        
        public int PacienteID { get; set; }
        
        public virtual Paciente Paciente { get; set; }
        
        public int TipoExameID { get; set; }
        
        public virtual TipoExame TipoExame { get; set; }
        
        public int ExameID { get; set; }
        
        public virtual Exame Exame { get; set; }
        
        public DateTime Horario { get; set; }

        public string NumeroProtocolo { get; set; }
    }
}
