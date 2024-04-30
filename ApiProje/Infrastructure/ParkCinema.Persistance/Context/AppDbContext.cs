using Boundmax.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkCinema.Domain.Entities;
using ParkCinema.Persistance.Configurations;

namespace ParkCinema.Persistance.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SliderConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Blogs> Blogs { get; set; }
    public DbSet<Authors> Authors { get; set; }
    public DbSet<References> References { get; set; }
    public DbSet<BlogDescriptions> BlogDescriptions { get; set; }
}
