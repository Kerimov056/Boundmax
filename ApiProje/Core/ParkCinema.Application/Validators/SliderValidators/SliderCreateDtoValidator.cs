using FluentValidation;
using ParkCinema.Application.DTOs.Slider;

namespace ParkCinema.Application.Validators.SliderValidators;

public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDTO>
{
    public SliderCreateDtoValidator()
    {
        RuleFor(x => x.Image).NotEmpty().NotNull();
        RuleFor(x => x.Name).MaximumLength(40).NotEmpty().NotNull();
    }
}
