using Boundmax.Application.DTOs.Author;
using Boundmax.Application.DTOs.BlogDescription;
using Boundmax.Application.DTOs.Reference;
using Boundmax.Domain.Entities;

namespace Boundmax.Application.DTOs.Blog;

public class CreateBlogDto
{
    public string AdminId { get; set; }
    public string Title { get; set; }
    public string? SourceLanguage { get; set; }
    public string MainImageUrl { get; set; }
    public string Text { get; set; }
    public ICollection<CreateAuthorDto>? CreateAuthorDtos { get; set; }
    public ICollection<CreateReferenceDto>? CreateReferenceDtos { get; set; }
    //public ICollection<CreateBlogDescriptionDto>? CreateBlogDescriptionDtos { get; set; }
}
