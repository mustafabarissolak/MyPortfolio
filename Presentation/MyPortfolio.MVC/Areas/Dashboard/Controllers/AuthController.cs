using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Services;
using MyPortfolio.MVC.Models;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;


[Area("Dashboard")]
public class AuthController : Controller
{
    readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
        {
            ModelState.AddModelError("", "Kullanıcı adı veya şifre boş olamaz.");
            return View(model);
        }

        var result = await _authService.Login(model.UserName, model.Password);

        if (result is not null)
        {
            ModelState.AddModelError("", result);
            return View(model);
        }

        return RedirectToAction("Index", "Home", new { area = "Dashboard" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Logout()
    {
        await _authService.Logout();
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult ForgotPassword() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(UserForgotPasswordVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _authService.ForgotPassword(model.Username!);

        TempData["Message"] = result ?? "Şifre sıfırlama bağlantısı mail adresinize gönderildi";
        return RedirectToAction("Login", "Auth");
    }

    [HttpGet]
    public async Task<IActionResult> ResetPassword(string userId, string token)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            return BadRequest("Geçersiz istek.");

        var model = new UserResetPasswordVM
        {
            UserId = userId,
            Token = token
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(UserResetPasswordVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _authService.ResetPasswordAsync(model.UserId, model.Token, model.NewPassword, model.ConfirmPassword);

        if (result is null)
            return NotFound();

        if (result != "Şifre başarıyla sıfırlandı.")
        {
            ModelState.AddModelError(string.Empty, result);
            return View(model);
        }

        TempData["Message"] = result;
        return RedirectToAction("Login", "Auth");
    }
}
