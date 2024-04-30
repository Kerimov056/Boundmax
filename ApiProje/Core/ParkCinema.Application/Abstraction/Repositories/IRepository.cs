using Microsoft.EntityFrameworkCore;
using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Application.Abstraction.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
    public DbSet<T> Table { get; }
}
