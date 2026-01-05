using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Services;
using MyPortfolio.MVC.Models;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
[Authorize(Roles = "Admin")]
public class AccountController : Controller
{
    readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userInfoDto = await _userService.GetUserInfo(User);

        if (userInfoDto == null)
            return NotFound();

        UserVM model = new()
        {
            UserInfoModel = new()
            {
                UserName = userInfoDto.UserName,
                Email = userInfoDto.Email,
                FirstName = userInfoDto.FirstName,
                LastName = userInfoDto.LastName,
                PhoneNumber = userInfoDto.PhoneNumber
            },
            UserPasswordModel = new()
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(UserVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var userInfoDto = await _userService.GetUserInfo(User);

        userInfoDto.FirstName = model.UserInfoModel.FirstName;
        userInfoDto.LastName = model.UserInfoModel.LastName;
        userInfoDto.UserName = model.UserInfoModel.UserName;
        userInfoDto.Email = model.UserInfoModel.Email;
        userInfoDto.PhoneNumber = model.UserInfoModel.PhoneNumber;

        var resultInfo = await _userService.UpdateUserInfoAsync(userInfoDto);        

        if (!string.IsNullOrEmpty(model.UserPasswordModel.CurrentPassword) &&
            !string.IsNullOrEmpty(model.UserPasswordModel.NewPassword) &&
            !string.IsNullOrEmpty(model.UserPasswordModel.NewPasswordConfirm))
        {
            var resultPassword = await _userService.UpdateUserPasswordAsync(userInfoDto.Id, model.UserPasswordModel.CurrentPassword, model.UserPasswordModel.NewPassword, model.UserPasswordModel.NewPasswordConfirm);

            if (resultPassword == null)
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu !!!");
                return View(model);
            }
            if (resultPassword != string.Empty)
            {
                ModelState.AddModelError("", resultPassword);
                return View(model);
            }

        }

        if (resultInfo == null)
        {
            ModelState.AddModelError("", "Bilinmeyen bir hata olustu !!!");
            return View(model);
        }
        if (resultInfo != string.Empty)
        {
            ModelState.AddModelError("", resultInfo);
            return View(model);
        }

        TempData["Message"] = "Bilgileriniz basariyla guncellendi. ";
        return RedirectToAction(nameof(Index));
    }
}
