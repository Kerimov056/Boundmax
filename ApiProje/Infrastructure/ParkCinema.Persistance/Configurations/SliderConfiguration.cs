using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.Configurations;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(x=>x.Name).IsRequired().HasMaxLength(40);
    }
}
