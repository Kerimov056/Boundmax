using Boundmax.Application.DTOs.BlogDescription;
using Boundmax.Application.DTOs.Reference;

namespace Boundmax.Application.DTOs.Author;

public class GetAuthorDto
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string? ProfilImageUrl { get; set; }
    public string? Position { get; set; }
    public string? ContactLink { get; set; }
}
