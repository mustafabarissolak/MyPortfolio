using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.AboutCommands.CreateAbout;
using MyPortfolio.Application.Features.Commands.AboutCommands.DeleteAbout;
using MyPortfolio.Application.Features.Commands.AboutCommands.UpdateAbout;
using MyPortfolio.Application.Features.Queries.AboutQueries.GetByIdAbout;
using MyPortfolio.Application.Features.Queries.AboutQueries.GetSingleAbout;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;


[Area("Dashboard")]
public class AboutController : Controller
{
    readonly IMediator _mediator;

    public AboutController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(GetSingleAboutQueryRequest request) => View(await _mediator.Send(request));

    public IActionResult Create() => View(new CreateAboutCommandRequest());


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateAboutCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(GetByIdAboutQueryRequest request)
    {
        var response = await _mediator.Send(request);

        if (response.AboutDto == null)
            return NotFound();

        var model = new UpdateAboutCommandRequest
        {
            Id = response.AboutDto.Id,
            Name = response.AboutDto.Name,
            Field = response.AboutDto.Field,
            Title = response.AboutDto.Title,
            Description = response.AboutDto.Description,
            PhoneNumber = response.AboutDto.PhoneNumber,
            Email = response.AboutDto.Email,
            WebSite = response.AboutDto.WebSite,
            ImagePath = response.AboutDto.ImagePath
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateAboutCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteAboutCommandRequest request)
    {
        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }
}
