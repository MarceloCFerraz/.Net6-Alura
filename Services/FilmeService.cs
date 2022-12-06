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

    public ReadFilmeDTO? RecuperaFilmePorID(int id)
    {
        Models.Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);

        ReadFilmeDTO? filmeDTO = null;

        if (filme != null)
        {
            filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
        }

        return filmeDTO;
    }

    public IEnumerable<ReadFilmeDTO>? RecuperaFilmes(int skip, int take)
    {
        var filmes = _context.Filmes.Skip(skip).Take(take);

        List<ReadFilmeDTO> filmesDTO = _mapper.Map<List<ReadFilmeDTO>>(filmes);

        return filmesDTO;
    }

    public Models.Filme? UpdateFilme(int id, UpdateFilmeDTO updateDTO)
    {
        Models.Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        
        _mapper.Map(updateDTO, filme);
        _context.SaveChanges();

        return filme;
    }

    public bool UpdateFilmePatch(int id, JsonPatchDocument<UpdateFilmeDTO> patch)
    {
        bool result = false;
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

    public bool DeleteFilme(int id)
    {
        bool result = false;

        Models.Filme? filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);

        if (filme != null)
        {
            _context.Remove(filme);
            _context.SaveChanges();
            result = true;
        }

        return result;
    }
}