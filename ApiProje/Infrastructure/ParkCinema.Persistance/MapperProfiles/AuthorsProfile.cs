using AutoMapper;
using Boundmax.Application.DTOs.Author;
using Boundmax.Domain.Entities;

namespace Boundmax.Persistance.MapperProfiles;

public class AuthorsProfile:Profile
{
    public AuthorsProfile()
    {
        CreateMap<Authors, CreateAuthorDto>().ReverseMap();
        CreateMap<Authors, GetAuthorDto>().ReverseMap();
    }
}
