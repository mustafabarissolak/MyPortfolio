using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Queries.SkillQueries.GetAllSkills;

namespace MyPortfolio.MVC.Components;

public class SkillsViewComponent : ViewComponent
{
    readonly IMediator _mediator;

    public SkillsViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var response = await _mediator.Send(new GetAllSkillsQueryRequest());
        return View(response);
    }
}
