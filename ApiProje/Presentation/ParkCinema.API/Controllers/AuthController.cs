using Microsoft.AspNetCore.Mvc;
using ParkCinema.Application.Abstraction.Services;
using ParkCinema.Application.DTOs.Auth;
using ParkCinema.Domain.Helpers;

namespace ParkCinema.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var responseToken = await _authService.Login(loginDTO);
        return Ok(responseToken);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {
        ArgumentNullException.ThrowIfNull(registerDTO, ExceptionResponseMessages.ParametrNotFoundMessage);

        SignUpResponse response = await _authService.Register(registerDTO)
                ?? throw new SystemException(ExceptionResponseMessages.NotFoundMessage);

        if (response.Errors != null)
        {
            if (response.Errors.Count > 0)
            {
                return BadRequest(response.Errors);
            }
        }
        else
        {
            //string subject = "Register Confirmation";
            //string html = string.Empty;
            //string password = registerDTO.password;

            //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates", "verify.html");
            //html = System.IO.File.ReadAllText(filePath);

            //html = html.Replace("{{password}}", password);

            //_emailService.Send(registerDTO.Email, subject, html);

        }
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken([FromQuery] string ReRefreshtoken)
    {
        var response = await _authService.ValidRefleshToken(ReRefreshtoken);
        return Ok(response);
    }
}
