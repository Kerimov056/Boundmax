using FluentValidation;
using ParkCinema.Application.DTOs.Slider;

namespace ParkCinema.Application.Validators.SliderValidators;

public class SliderGetDtoValidator : AbstractValidator<SliderGetDTO>
{
    public SliderGetDtoValidator()
    {
        RuleFor(x => x.imagePath).NotNull().NotEmpty().MaximumLength(12000);
    }
}
