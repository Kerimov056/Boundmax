using AutoMapper;
using Boundmax.Application.DTOs.Blog;
using Boundmax.Domain.Entities;

namespace Boundmax.Persistance.MapperProfiles;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<Blogs, CreateBlogDto>().ReverseMap();
        CreateMap<Blogs, MainGetBlogDto>().ReverseMap();
        CreateMap<Blogs, GetBlogDto>()
             .ForMember(dest => dest.GetAuthorDtos, opt => opt.MapFrom(src => src.Authors))
             .ForMember(dest => dest.GetReferenceDtos, opt => opt.MapFrom(src => src.References))
             //.ForMember(dest => dest.GetBlogDescriptionDtos, opt => opt.MapFrom(src => src.BlogDescriptions))
                .ReverseMap();

    }
}
