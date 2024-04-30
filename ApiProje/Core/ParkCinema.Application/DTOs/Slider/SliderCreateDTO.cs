using Microsoft.AspNetCore.Http;

namespace ParkCinema.Application.DTOs.Slider;

public class SliderCreateDTO
{
    public IFormFile Image { get; set; }
    public string Name { get; set; }
}
