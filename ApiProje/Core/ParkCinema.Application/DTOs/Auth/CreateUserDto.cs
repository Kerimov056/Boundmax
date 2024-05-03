namespace Boundmax.Application.DTOs.Auth;

public record CreateUserDto(string? Fullname, string Username, string Email, string Password, string UserRole, Guid SuperAdminId);