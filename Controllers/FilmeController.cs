using DotNet6.Data.DTO;
using DotNet6.Models;
using DotNet6.Services.Filme;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeService _service;

    public FilmeController(FilmeService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] NewFilmeDTO filmeDTO)
    {
        Filme filme = _service.AdicionaFilme(filmeDTO);
        
        return CreatedAtAction(
            nameof(RecuperaFilmePorID),
            new { id = filme.id },
            filme
        );
    }

    [HttpGet]
    public IEnumerable<Filme>? RecuperaFilmes(
        [FromQuery] int skip=0,
        [FromQuery] int take=50
    )
    {
        return this._service.RecuperaFilmes(skip, take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorID(/* [FromQuery] */ int id)
    {        
        IActionResult result = NotFound();

        Filme? filme = this._service.RecuperaFilmePorID(id);

        if (filme != null) 
        {
            Ok(filme);
        }
        
        return result;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id)
    {
        IActionResult result = NotFound();



        return result;
    }
}
        