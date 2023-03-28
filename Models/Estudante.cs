using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace VamosEstudar.Models
{
    public class Estudante
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [MaxLength(11)]
        public string Cpf { get; set; }
        [Required]
        public string Matricula { get; set; }
    }   
}
