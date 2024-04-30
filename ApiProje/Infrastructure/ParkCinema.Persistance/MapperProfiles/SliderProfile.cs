using AutoMapper;
using ParkCinema.Application.DTOs.Slider;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Persistance.MapperProfiles;

public class SliderProfile : Profile
{
    public SliderProfile()
    {
        CreateMap<Slider, SliderCreateDTO>().ReverseMap();
        CreateMap<Slider, SliderUpdateDTO>().ReverseMap();
        CreateMap<Slider, SliderGetDTO>().ReverseMap();
    }
}
