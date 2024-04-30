using ParkCinema.Application.DTOs.Auth;
using ParkCinema.Domain.Entities;

namespace ParkCinema.Application.Abstraction.Services;

public interface ITokenHandler
{
    public Task<TokenResponseDTO> CreateAccessToken(int minutes, int refreshTokenMinutes, AppUser appUser);
}
