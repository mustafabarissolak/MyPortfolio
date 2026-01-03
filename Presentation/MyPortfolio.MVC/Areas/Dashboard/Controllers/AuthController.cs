using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Entities;
using MyPortfolio.MVC.Models;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;


[Area("Dashboard")]
public class AuthController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

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

        var user = await _userManager.FindByNameAsync(model.UserName!);
        if (user == null)
        {
            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(user, model.Password!, true, true);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
            return View(model);
        }

        return RedirectToAction("Index", "Home", new { area = "Dashboard" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    //[HttpPost]
    //public IActionResult ForgotPassword()
    //{
    //    return View();
    //}

    [HttpGet]
    public IActionResult ResetPassword()
    {
        return View();
    }

    //[HttpPost]
    //public IActionResult ResetPassword()
    //{
    //    return View();
    //}
}
