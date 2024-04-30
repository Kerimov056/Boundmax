using ParkCinema.Application.Abstraction.Repositories.IEntityRepository;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Context;

namespace ParkCinema.Persistance.Implementations.Repositories.IEntityRepository;

public class SliderReadRepository : ReadRepository<Slider>, ISliderReadRepository
{
    public SliderReadRepository(AppDbContext context) : base(context)
    {
    }
}
