using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.SkillCommand.CreateSkill;
using MyPortfolio.Application.Features.Commands.SkillCommand.DeleteSkill;
using MyPortfolio.Application.Features.Commands.SkillCommand.UpdateSkill;
using MyPortfolio.Application.Features.Queries.SkillQueries.GetAllSkills;
using MyPortfolio.Application.Features.Queries.SkillQueries.GetByIdSkills;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class SkillController : Controller
{
    private readonly IMediator _mediator;

    public SkillController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index(GetAllSkillsQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return View(response);
    }

    [HttpGet]
    public IActionResult Create() => View(new CreateSkillCommandRequest());

    [HttpPost]
    public async Task<IActionResult> Create(CreateSkillCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(GetByIdQueryRequest request)
    {
        var response = await _mediator.Send(request);

        if (response.SkillDto == null)
            return NotFound();

        var model = new UpdateSkillCommandRequest
        {
            Name = response.SkillDto.Name!,
            Value = response.SkillDto.Value
        };

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(UpdateSkillCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DeleteSkillCommandRequest request)
    {
        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }
}
