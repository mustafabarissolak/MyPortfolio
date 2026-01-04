using Microsoft.AspNetCore.Identity;
using MyPortfolio.Application.Services;
using MyPortfolio.Core.Entities;
using MyPortfolio.Infrastructure.SmtpServices;

namespace MyPortfolio.Infrastructure.Services;


public class AuthService : IAuthService
{
    readonly SignInManager<AppUser> _signInManager;
    readonly UserManager<AppUser> _userManager;
    readonly IMailTemplateService _mailService;
    public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMailTemplateService mailService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _mailService = mailService;
    }


    public async Task<string?> Login(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return "Kullanıcı adı veya şifre yanlış.";

        var isLockedOut = await _userManager.IsLockedOutAsync(user);
        if (isLockedOut)
        {
            var lockoutEnd = await _userManager.GetLockoutEndDateAsync(user);
            if (lockoutEnd.HasValue && lockoutEnd.Value > DateTimeOffset.Now)
            {
                string formatted = lockoutEnd.Value.ToLocalTime().ToString("dd-MM-yyyy HH:mm:ss");
                return $"Hesabınız kilitli. Lütfen {formatted} tarihinde tekrar deneyin.";
            }
            else
                await _userManager.SetLockoutEndDateAsync(user, null);
        }

        var result = await _signInManager.PasswordSignInAsync(user, password!, true, true);
        if (!result.Succeeded)
            return "Kullanıcı adı veya şifre yanlış.";

        return null;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<string?> ForgotPassword(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName!);
        if (user == null)
            return null;

        try
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"http://localhost:5016/Dashboard/Auth/ResetPassword?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            await _mailService.SendPasswordResetMailAsync(resetLink, user.Email!);
            return "Şifre sıfırlama bağlantısı mail adresinize gönderildi";
        }
        catch (Exception ex)
        {
            return $"Mail gönderilirken bir hata oluştu. Hata Mesaji: {ex.Message}";
        }
    }

    public async Task<string?> ResetPasswordAsync(string userId, string token, string newPassword, string confirmPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return null;

        if (newPassword != confirmPassword)
            return "Şifreler eşleşmiyor.";

        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

        if (result.Succeeded)
            return "Şifre başarıyla sıfırlandı.";
        else
            return string.Join(", ", result.Errors.Select(e => e.Description));
    }

}