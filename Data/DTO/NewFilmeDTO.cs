using System.ComponentModel.DataAnnotations;

namespace DotNet6.Data.DTO;

public class NewFilmeDTO
{
    [Required(ErrorMessage = "Campo Título é obrigatório")]
    [StringLength(250, ErrorMessage = "O título do filme só pode conter 250 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Campo Gênero é obrigatório")]
    [StringLength(50, ErrorMessage = "O gênero do filme só pode conter 50 caracteres")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Campo Duração é obrigatório")]
    [Range(70, 600, ErrorMessage = "A duração do filme só pode ter entre 70 e 600 minutos")]
    public int Duration { get; set; }

    
}