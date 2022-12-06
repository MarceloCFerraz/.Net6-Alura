namespace DotNet6.Data.DTO.Filme;

public class ReadFilmeDTO
{
    public string Titulo { get; set; }

    public string Genero { get; set; }

    public int Duracao { get; set; }
    
    public DateTime QueryTime { get; set; } = DateTime.Now;
}