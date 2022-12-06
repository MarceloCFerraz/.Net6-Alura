using AutoMapper;
using DotNet6.Data;
using DotNet6.Data.DTO.Filme;
using Microsoft.AspNetCore.JsonPatch;

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

    public Models.Filme? UpdateFilme(int id, UpdateFilmeDTO updateDTO)
    {
        Models.Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        
        _mapper.Map(updateDTO, filme);
        _context.SaveChanges();

        return filme;
    }

    internal Boolean UpdateFilmePatch(int id, JsonPatchDocument<UpdateFilmeDTO> patch)
    {
        Boolean result = false;
        Models.Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);

        if (filme != null)
        {
            UpdateFilmeDTO updateDTO = _mapper.Map<UpdateFilmeDTO>(filme);

            patch.ApplyTo(updateDTO);

            _mapper.Map(updateDTO, filme);
            _context.SaveChanges();

            result = true;
        }

        return result;
    }
}