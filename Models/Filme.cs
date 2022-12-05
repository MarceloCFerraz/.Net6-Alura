

using System.ComponentModel.DataAnnotations;

namespace DotNet6.Models
{
    public class Filme{
        [Key]
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero do filme é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O genero só pode ter no máximo 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A duração do filme é obrigatória!")]
        [Range(70, 600, ErrorMessage = "A duração do filme só pode ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
        
    }
}