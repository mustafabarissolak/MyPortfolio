using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.ExperienceCommands.CreateExperience;
using MyPortfolio.Application.Features.Commands.ExperienceCommands.DeleteExperience;
using MyPortfolio.Application.Features.Commands.ExperienceCommands.UpdateExperience;
using MyPortfolio.Application.Features.Queries.ExperienceQueries.GetAllExperience;
using MyPortfolio.Application.Features.Queries.ExperienceQueries.GetByIdExperience;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class ExperienceController : Controller
{
    readonly IMediator _mediator;

    public ExperienceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index() => View(await _mediator.Send(new GetAllExperienceQueryRequest()));

    [HttpGet]
    public async Task<IActionResult> Details() => View(await _mediator.Send(new GetByIdExperienceQueryRequest()));

    [HttpGet]
    public IActionResult Create() => View(new CreateExperienceCommandRequest());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateExperienceCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(GetByIdExperienceQueryRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.ExperienceDto == null)
            return NotFound();

        var model = new UpdateExperienceCommandRequest
        {
            Id = response.ExperienceDto.Id,
            CompanyName = response.ExperienceDto.CompanyName,
            Description = response.ExperienceDto.Description,
            Location = response.ExperienceDto.Location,
            EndDate = response.ExperienceDto.EndDate,
            StartDate = response.ExperienceDto.StartDate
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateExperienceCommandRequest request)
    {
        var response = await _mediator.Send(request);

        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteExperienceCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }
}
