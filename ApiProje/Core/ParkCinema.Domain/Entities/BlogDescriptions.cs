using ParkCinema.Domain.Entities.Common;

namespace Boundmax.Domain.Entities;

public class BlogDescriptions:BaseEntity
{
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }

    //Relations
    public Blogs Blog { get; set; }
    public Guid BlogId { get; set; }
}
