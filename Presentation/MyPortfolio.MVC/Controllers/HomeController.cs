using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.ContactCommands.CreateContact;
using MyPortfolio.Infrastructure.SmtpServices;
using MyPortfolio.MVC.Models;
using System.Diagnostics;

namespace MyPortfolio.MVC.Controllers;

public class HomeController : Controller
{
    readonly IMediator _mediator;
    readonly IMailTemplateService _mailService;
    public HomeController(IMediator mediator, IMailTemplateService mailService)
    {
        _mediator = mediator;
        _mailService = mailService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateContactCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        var response = await _mediator.Send(request);
        await _mailService.SendContactMessageNotificationAsync(response.ContactMessage!);
        return RedirectToAction(nameof(Index));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
