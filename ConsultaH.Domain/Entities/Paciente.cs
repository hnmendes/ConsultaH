using System;

namespace ConsultaH.Domain.Entities
{
    public enum Sexo
    {
        Feminino, Masculino
    }

    public class Paciente
    {
        public int ID { get; set; }
        
        public string Nome { get; set; }

        public string CPF { get; set; }
        
        public DateTime DataNascimento { get; set; }

        public Sexo Sexo { get; set; }
        
        public string Telefone { get; set; }
        
        public string Email { get; set; }
    }
}
