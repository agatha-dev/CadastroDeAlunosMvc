using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeAlunosMvc.Models
{
    public class AlunoEdicaoModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        [MaxLength(4)]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo obrigatório")]
        public DateTime DataNascimento { get; set; }
    }
}
