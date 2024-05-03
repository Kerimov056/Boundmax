namespace Boundmax.Application.DTOs.Blog;

public class MainGetBlogDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? SourceLanguage { get; set; }
    public string MainImageUrl { get; set; }
    public string? BlogAuthorName { get; set; }
    public DateTime CreatedDate { get; set; }
}
