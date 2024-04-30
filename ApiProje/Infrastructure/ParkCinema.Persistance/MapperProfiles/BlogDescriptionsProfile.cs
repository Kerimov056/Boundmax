using AutoMapper;
using Boundmax.Application.DTOs.Blog;
using Boundmax.Application.DTOs.BlogDescription;
using Boundmax.Domain.Entities;

namespace Boundmax.Persistance.MapperProfiles;

public class BlogDescriptionsProfile:Profile
{
    public BlogDescriptionsProfile()
    {
        CreateMap<BlogDescriptions, CreateBlogDescriptionDto>().ReverseMap();
        CreateMap<BlogDescriptions, GetBlogDescriptionDto>().ReverseMap();
    }
}
