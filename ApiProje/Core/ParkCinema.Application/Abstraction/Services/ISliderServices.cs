using ParkCinema.Application.DTOs.Slider;

namespace ParkCinema.Application.Abstraction.Services;

public interface ISliderServices
{
    Task<List<SliderGetDTO>> GetAllAsync();
    Task CreateAsync(SliderCreateDTO sliderCreateDTO);
    Task<SliderGetDTO> GetByIdAsync(Guid Id);
    Task UpdateAsync(Guid Id, SliderUpdateDTO sliderUpdateDTO);
    Task RemoveAsync(Guid Id);
}
