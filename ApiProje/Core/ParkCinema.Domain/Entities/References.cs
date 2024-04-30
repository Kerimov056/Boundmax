using ParkCinema.Domain.Entities.Common;

namespace Boundmax.Domain.Entities;

public class References:BaseEntity
{
    public string ReferenceLink { get; set; }

    //Relations
    public Blogs Blog { get; set; }
    public Guid BlogId { get; set; }
}
