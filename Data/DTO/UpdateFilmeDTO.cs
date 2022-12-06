
using System.ComponentModel.DataAnnotations;

namespace DotNet6.Data.DTO.Filme;

public class UpdateFilmeDTO
{
    [Required(ErrorMessage = "Campo título é obrigatório")]
    [MaxLength(250, ErrorMessage = "Tamanho máximo do título do filme é 250 caracteres")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "Campo gênero é obrigatório")]
    [MaxLength(50, ErrorMessage = "Tamanho máximo do gênero do filme é 50 caracteres")]
    public string? Genero { get; set; }

    [Required(ErrorMessage = "Campo duração é obrigatório")]
    [Range(70, 600, ErrorMessage = "Filme só pode ter entre 70 e 600 minutos")]
    public int? Duracao { get; set; }

}