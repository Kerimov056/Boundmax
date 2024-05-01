using ParkCinema.Domain.Entities.Common;

namespace Boundmax.Domain.Entities;

public class Authors:BaseEntity
{
    public string Fullname { get; set; }
    public string? ProfilImageUrl { get; set; }
    public string? Position { get; set; }
    public string? ContactLink { get; set; }

    //Relations
    public Blogs Blog { get; set; }
    public Guid BlogId { get; set; }
}
