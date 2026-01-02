using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.EducationCommands.CreateEducation;
using MyPortfolio.Application.Features.Commands.EducationCommands.DeleteEducation;
using MyPortfolio.Application.Features.Commands.EducationCommands.UpdateEducation;
using MyPortfolio.Application.Features.Queries.EducationQueries.GetAllEducation;
using MyPortfolio.Application.Features.Queries.EducationQueries.GetByIdEducation;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class EducationController : Controller
{
    readonly IMediator _mediator;

    public EducationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index() => View(await _mediator.Send(new GetAllEducationQueryRequest()));

    [HttpGet]
    public async Task<IActionResult> Details() => View(await _mediator.Send(new GetByIdEducationQueryRequest()));

    [HttpGet]
    public IActionResult Create() => View(new CreateEducationCommandRequest());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateEducationCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(GetByIdEducationQueryRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.EducationDto == null)
            return NotFound();

        var model = new UpdateEducationCommandRequest
        {
            Id = response.EducationDto.Id,
            Department = response.EducationDto.Department,
            Description = response.EducationDto.Description,
            Location = response.EducationDto.Location,
            University = response.EducationDto.University,
            EndDate = response.EducationDto.EndDate,
            StartDate = response.EducationDto.StartDate
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateEducationCommandRequest request)
    {
        var response = await _mediator.Send(request);

        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteEducationCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }
}
