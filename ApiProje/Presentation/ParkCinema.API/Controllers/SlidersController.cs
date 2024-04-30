using Microsoft.AspNetCore.Mvc;
using ParkCinema.Application.Abstraction.Services;
using ParkCinema.Application.DTOs.Slider;
using System.Net;

namespace ParkCinema.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SlidersController : ControllerBase
{
    public readonly ISliderServices _sliderService;

    public SlidersController(ISliderServices sliderService) =>  _sliderService = sliderService;

    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //    var slider = await _sliderService.GetAllAsync();
    //    return Ok(slider);
    //}

    //[HttpGet("{id:Guid}")]
    //public async Task<IActionResult> GetById(Guid id)
    //{
    //    var bySlider = await _sliderService.GetByIdAsync(id);   
    //    return Ok(bySlider);
    //}

    //[HttpPost]
    //public async Task<IActionResult> CreateSlider([FromForm] SliderCreateDTO sliderCreateDTO)
    //{
    //    await _sliderService.CreateAsync(sliderCreateDTO);
    //    return StatusCode((int)HttpStatusCode.Created);
    //}

    //[HttpPut]
    //public async Task<IActionResult> UpdateSlider(Guid Id, [FromForm] SliderUpdateDTO sliderUpdateDTO)
    //{
    //    await _sliderService.UpdateAsync(Id,sliderUpdateDTO);
    //    return Ok();    
    //}

    //[HttpDelete("{id:Guid}")]
    //public async Task<IActionResult> Remove(Guid id)
    //{
    //    await _sliderService.RemoveAsync(id);
    //    return Ok();
    //}

}
