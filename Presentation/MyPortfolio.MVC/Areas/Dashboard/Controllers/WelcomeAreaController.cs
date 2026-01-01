using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.WelcomeAreaCommands.CreateWelcomeArea;
using MyPortfolio.Application.Features.Commands.WelcomeAreaCommands.DeleteWelcomeArea;
using MyPortfolio.Application.Features.Commands.WelcomeAreaCommands.UpdateWelcomeArea;
using MyPortfolio.Application.Features.Queries.WelcomeAreaQueries;
using MyPortfolio.Application.Features.Queries.WelcomeAreaQueries.GetByIdWelcomeArea;
using MyPortfolio.Application.Features.Queries.WelcomeAreaQueries.GetSingleWelcomeArea;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class WelcomeAreaController : Controller
{
    readonly IMediator _mediator;

    public WelcomeAreaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index() => View(await _mediator.Send(new GetSingleWelcomeAreaQueryRequest()));

    public async Task<IActionResult> Create() => View(new CreateWelcomeAreaCommandRequest());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateWelcomeAreaCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(GetByIdWelcomeAreaQueryRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.WelcomeAreaDto == null)
            return NotFound();

        var model = new UpdateWelcomeAreaCommandRequest
        {
            Id = response.WelcomeAreaDto.Id,
            TopHeading = response.WelcomeAreaDto.TopHeading,
            SubHeading = response.WelcomeAreaDto.SubHeading,
            ImagePath = response.WelcomeAreaDto.ImagePath,
            CvUrl = response.WelcomeAreaDto.CvUrl
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateWelcomeAreaCommandRequest request)
    {
        var response = await _mediator.Send(request);

        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteWelcomeAreaCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }
}
