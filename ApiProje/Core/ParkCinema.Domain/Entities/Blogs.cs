using ParkCinema.Domain.Entities.Common;

namespace Boundmax.Domain.Entities;

public class Blogs : BaseEntity
{
    public string Title { get; set; }
    public string? SourceLanguage { get; set; }
    public string MainImageUrl { get; set; }
    public string? BlogAuthorName { get; set; }
    public string Text { get; set; }

    //Relations
    public ICollection<Authors>? Authors { get; set; }
    public ICollection<References>? References { get; set; }
    //public ICollection<BlogDescriptions>? BlogDescriptions { get; set; }
}
