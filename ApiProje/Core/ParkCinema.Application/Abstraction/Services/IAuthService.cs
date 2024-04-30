using ParkCinema.Application.DTOs.Auth;
using ParkCinema.Domain.Helpers;

namespace ParkCinema.Application.Abstraction.Services;

public interface IAuthService
{
    Task<SignUpResponse> Register(RegisterDTO registerDTO);
    Task<TokenResponseDTO> Login(LoginDTO loginDTO);
    Task<TokenResponseDTO> LoginAdmin(LoginDTO loginDTO);
    Task<TokenResponseDTO> ValidRefleshToken(string refreshToken);

    //Yazilacaqlar:
    //Task PasswordResetAsnyc(string email);
    //Task<bool> ResetPassword(ResetPassword resetPassword);
    //Task<string> ByAdmin();
}
