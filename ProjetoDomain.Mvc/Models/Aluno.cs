using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDomain.Mvc
{
        public class Aluno
        {
            [Key]
            public Guid Id { get; set; }
            public string Matricula { get; set; }
            public string Nome { get; set; }
            public DateTime DataNascimento { get; set; }

        }
}
