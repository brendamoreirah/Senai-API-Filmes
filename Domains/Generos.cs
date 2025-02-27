using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_filmes_senai.Domains
{
    [Table("Generos")]
    public class Generos
    {

        [Key]
        public Guid IdGenero { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Nome do Genêro é obrigatório!")]
        public string? Nome { get; set; }
    }
}
