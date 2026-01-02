using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.CreateSocialMediaAccount;
using MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.DeleteSocialMediaAccount;
using MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.UpdateSocialMediaAccount;
using MyPortfolio.Application.Features.Queries.SocialMediaAccountQueries.GetAllSocialMediaAccount;
using MyPortfolio.Application.Features.Queries.SocialMediaAccountQueries.GetByIdSocialMediaAccount;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class SocialMediaAccountController : Controller
{
    readonly IMediator _mediator;

    public SocialMediaAccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index() => View(await _mediator.Send(new GetAllSocialMediaAccountQueryRequest()));

    [HttpGet]
    public async Task<IActionResult> Details() => View(await _mediator.Send(new GetByIdSocialMediaAccountQueryRequest()));

    [HttpGet]
    public IActionResult Create() => View(new CreateSocialMediaAccountCommandRequest());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateSocialMediaAccountCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(GetByIdSocialMediaAccountQueryRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.SocialMediaAccountDto == null)
            return NotFound();

        var model = new UpdateSocialMediaAccountCommandRequest
        {
            Id = response.SocialMediaAccountDto.Id,
            Name = response.SocialMediaAccountDto.Name,
            IconCode = response.SocialMediaAccountDto.IconCode,
            Url = response.SocialMediaAccountDto.Url
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateSocialMediaAccountCommandRequest request)
    {
        var response = await _mediator.Send(request);

        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteSocialMediaAccountCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }
}
