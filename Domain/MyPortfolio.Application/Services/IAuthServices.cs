namespace MyPortfolio.Application.Services;

public interface IAuthService
{
    Task<string?> Login(string userName, string password);
    Task Logout();
    Task<string?> ForgotPassword(string userName);
    Task<string?> ResetPasswordAsync(string UserId, string Token, string NewPassword, string ConfirmPassword);
}
