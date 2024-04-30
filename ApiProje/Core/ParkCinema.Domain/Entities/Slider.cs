using ParkCinema.Domain.Entities.Common;

namespace ParkCinema.Domain.Entities;

public class Slider: BaseEntity
{
    public byte[] ImagePath { get; set; }
    public string Name { get; set; }
}
