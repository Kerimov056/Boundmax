using Boundmax.Application.Abstraction.Repositories.IEntityRepository;
using Boundmax.Domain.Entities;
using ParkCinema.Persistance.Context;
using ParkCinema.Persistance.Implementations.Repositories;

namespace Boundmax.Persistance.Implementations.Repositories.IEntityRepository;

public class BlogReadRepository : ReadRepository<Blogs>, IBlogReadRepository
{
    public BlogReadRepository(AppDbContext context) : base(context)
    {
    }
}
