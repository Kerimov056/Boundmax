using AutoMapper;
using Boundmax.Application.DTOs.BlogDescription;
using Boundmax.Application.DTOs.Reference;
using Boundmax.Domain.Entities;

namespace Boundmax.Persistance.MapperProfiles;

public class ReferencesProfile:Profile
{
    public ReferencesProfile()
    {
        CreateMap<References, CreateReferenceDto>().ReverseMap();
        CreateMap<References, GetReferenceDto>().ReverseMap();
    }
}
