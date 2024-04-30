using FluentValidation;
using ParkCinema.Application.DTOs.Slider;

namespace ParkCinema.Application.Validators.SliderValidators;

public class SliderUpdateDtoValidator : AbstractValidator<SliderUpdateDTO>
{
    public SliderUpdateDtoValidator()
    {
        RuleFor(x => x.Image).NotEmpty().NotNull();
        RuleFor(x => x.Name).MaximumLength(40).NotEmpty().NotNull();
    }
}
