using MyPortfolio.Application.DTOs;
using System.Security.Claims;

namespace MyPortfolio.Application.Services;

public interface IUserService
{
    Task<UserDto> GetUserInfo(ClaimsPrincipal userPrincipal);
    Task<string?> UpdateUserInfoAsync(UserDto user);
    Task<string?> UpdateUserPasswordAsync(string id, string currentPassword, string newPassword, string newPasswordConfirm);
}