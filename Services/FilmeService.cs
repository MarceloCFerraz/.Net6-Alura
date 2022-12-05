using AutoMapper;
using DotNet6.Data;
using DotNet6.Data.DTO;
using DotNet6.Models;

namespace DotNet6.Services.Filme;

public class FilmeService 
{
    private IMapper _mapper;
    private FilmeContext _context;

    public FilmeService(IMapper mapper, FilmeContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Models.Filme AdicionaFilme(NewFilmeDTO filmeDTO)
    {
        Models.Filme filme = _mapper.Map<Models.Filme>(filmeDTO);
        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return filme;
    }

    public Models.Filme? RecuperaFilmePorID(int id)
    {
        Models.Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);

        return filme;
    }

    public IEnumerable<Models.Filme>? RecuperaFilmes(int skip, int take)
    {
        return _context.Filmes
                .Skip(skip)
                .Take(take);
    }
}