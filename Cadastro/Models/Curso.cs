using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Models
{
    public class Curso
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do curso")]
        public string Nome { get; set; }
        [Display(Name = "Quantidade de aulas")]
        public int QuantidadeAulas { get; set; }
        [Display(Name = "Preço")]
        public int Preco { get; set; }
        [Display(Name = "Data da criação")]
        public DateTime DataCriacao { get; set; }
    }
}