using Boundmax.Application.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkCinema.Application.Abstraction.Services;
using ParkCinema.Application.DTOs.Auth;
using ParkCinema.Domain.Entities;
using ParkCinema.Domain.Enums;
using ParkCinema.Domain.Helpers;
using ParkCinema.Persistance.Context;
using ParkCinema.Persistance.Exceptions;
using System.Text;

namespace ParkCinema.Persistance.Implementations.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _siginManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ITokenHandler _tokenHandler;

    public AuthService(UserManager<AppUser> userManager,
                       SignInManager<AppUser> siginManager,
                       RoleManager<IdentityRole> roleManager,
                       AppDbContext context,
                       IConfiguration configuration,
                       ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _siginManager = siginManager;
        _roleManager = roleManager;
        _context = context;
        _configuration = configuration;
        _tokenHandler = tokenHandler;
    }

    public async Task<SignUpResponse> Create(CreateUserDto registerDTO)
    {
        // Check if the current user has the required role
        var currentUserRole = await GetUserRole(registerDTO.SuperAdminId);
        if (currentUserRole != Role.SuperAdmin.ToString())
        {
            throw new UnauthorizedAccessException("Only SuperAdmin and Admin can create users.");
        }

        if (!Enum.TryParse(registerDTO.UserRole, out Role role) || !Enum.IsDefined(typeof(Role), role))
        {
            throw new ArgumentException("Invalid user role specified.");
        }
        AppUser appUser = new AppUser()
        {
            Fullname = registerDTO.Fullname,
            UserName = registerDTO.Username,
            Email = registerDTO.Email,
            isActive = false,
        };
        IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerDTO.Password);
        if (!identityResult.Succeeded)
        {
            StringBuilder errorMessage = new();
            foreach (var error in identityResult.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new RegistrationException(errorMessage.ToString());
        }

        // Assign the role to the created user
        var result = await _userManager.AddToRoleAsync(appUser, role.ToString());
        if (!result.Succeeded)
        {
            return new SignUpResponse
            {
                StatusMessage = ExceptionResponseMessages.UserFailedMessage,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        // Return success response
        return new SignUpResponse
        {
            Errors = null,
            StatusMessage = ExceptionResponseMessages.UserSuccesMessage,
            UserEmail = appUser.Email
        };
    }

    public async Task<TokenResponseDTO> Login(LoginDTO loginDTO)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(loginDTO.UsernameOrEmail);
        if (appUser is null)
        {
            appUser = await _userManager.FindByNameAsync(loginDTO.UsernameOrEmail);
            if (appUser is null) throw new LogInFailerException("Invalid Login!");

        }

        SignInResult signInResult = await _siginManager.CheckPasswordSignInAsync(appUser, loginDTO.password, true);
        if (!signInResult.Succeeded)
        {
            throw new LogInFailerException("Invalid Login!");
        }
        //if (!appUser.isActive)
        //{
        //    throw new UserBlockedException("User Blocked");
        //}

        var tokenRespons = await _tokenHandler.CreateAccessToken(2,3,appUser);
        appUser.RefreshToken = tokenRespons.refreshToken;
        appUser.RefreshTokenExpration = tokenRespons.refreshTokenExpration;
        await _userManager.UpdateAsync(appUser);
        return tokenRespons;
    }

    public Task<TokenResponseDTO> LoginAdmin(LoginDTO loginDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<SignUpResponse> Register(RegisterDTO registerDTO)
    {
        AppUser appUser = new AppUser()
        {
            Fullname = registerDTO.Fullname,
            UserName = registerDTO.Username,
            Email = registerDTO.Email,
            BirthDate = registerDTO.BirthDate,
            isActive = false
        };

        IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerDTO.password);
        if (!identityResult.Succeeded)
        {
            StringBuilder errorMessage = new();
            foreach (var error in identityResult.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new RegistrationException(errorMessage.ToString());   
        }

        var result = await _userManager.AddToRoleAsync(appUser, Role.Member.ToString());
        if (!result.Succeeded)
        {
            return new SignUpResponse
            {
                StatusMessage = ExceptionResponseMessages.UserFailedMessage,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        return new SignUpResponse
        {
            Errors = null,
            StatusMessage = ExceptionResponseMessages.UserSuccesMessage,
            UserEmail = appUser.Email
        };
    }

    public async Task<TokenResponseDTO> ValidRefleshToken(string refreshToken)
    {
        if (refreshToken is null)
        {
            throw new ArgumentNullException("Refresh token does not exist");
        }
        var ByUser = await _context.Users.Where(a => a.RefreshToken == refreshToken).FirstOrDefaultAsync();
        if (ByUser is null)
        {
            throw new NotFoundException("User does Not Exist");
        }
        if (ByUser.RefreshTokenExpration < DateTime.UtcNow)
        {
            throw new ArgumentNullException("Refresh token does not exist");
        }

        var tokenResponse = await _tokenHandler.CreateAccessToken(2, 3, ByUser);
        ByUser.RefreshToken = tokenResponse.refreshToken;
        ByUser.RefreshTokenExpration = tokenResponse.refreshTokenExpration;
        await _userManager.UpdateAsync(ByUser);
        return tokenResponse;
    }

    private async Task<string> GetUserRole(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            throw new NotFoundException($"User with ID {userId} not found.");
        }
        var roles = await _userManager.GetRolesAsync(user);
        return roles.FirstOrDefault();
    }
}
