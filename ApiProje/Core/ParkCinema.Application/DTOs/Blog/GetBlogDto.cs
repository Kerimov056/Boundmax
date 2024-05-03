using Boundmax.Application.DTOs.Author;
using Boundmax.Application.DTOs.BlogDescription;
using Boundmax.Application.DTOs.Reference;

namespace Boundmax.Application.DTOs.Blog;

public class GetBlogDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Title { get; set; }
    public string? SourceLanguage { get; set; }
    public string MainImageUrl { get; set; }
    public string? BlogAuthorName { get; set; }
    public string Text { get; set; }
    public ICollection<GetAuthorDto>? GetAuthorDtos { get; set; }
    public ICollection<GetReferenceDto>? GetReferenceDtos { get; set; }
    //public ICollection<GetBlogDescriptionDto>? GetBlogDescriptionDtos { get; set; }
}
