using AutoMapper;
using DotNet6.Data.DTO.Filme;
using DotNet6.Models;

namespace DotNet6.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<NewFilmeDTO, Filme>();
        CreateMap<UpdateFilmeDTO, Filme>();
        CreateMap<Filme, UpdateFilmeDTO>();
    }
}