using Microsoft.AspNetCore.Identity;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Services;
using MyPortfolio.Core.Entities;
using System.Security.Claims;

namespace MyPortfolio.Infrastructure.Services;

public class UserService : IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly SignInManager<AppUser> _signInManager;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<UserDto> GetUserInfo(ClaimsPrincipal userPrincipal)
    {
        var user = await _userManager.GetUserAsync(userPrincipal);

        if (user == null)
            return new();

        return new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };
    }

    public async Task<string?> UpdateUserInfoAsync(UserDto userDto)
    {
        var user = await _userManager.FindByIdAsync(userDto.Id);

        if (user == null)
            return null;

        user.UserName = userDto.UserName;
        user.Email = userDto.Email;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.PhoneNumber = userDto.PhoneNumber;

       var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            return string.Join("\n", result.Errors.Select(e => e.Description));

        await _signInManager.RefreshSignInAsync(user);
        return string.Empty;
    }

    public async Task<string?> UpdateUserPasswordAsync(string id, string currentPassword, string newPassword, string newPasswordConfirm)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return null;

        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

        if (newPassword != newPasswordConfirm)
            return "Yeni sifreler ayni degil";

        if (!result.Succeeded)
            return string.Join("\n", result.Errors.Select(e => e.Description));

        await _signInManager.RefreshSignInAsync(user);
        return string.Empty;
    }
}