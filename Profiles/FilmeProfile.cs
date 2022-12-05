using AutoMapper;
using DotNet6.Data.DTO;
using DotNet6.Models;

namespace DotNet6.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<NewFilmeDTO, Filme>();
    }
}