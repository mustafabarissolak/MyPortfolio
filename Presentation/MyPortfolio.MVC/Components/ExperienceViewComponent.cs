using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Queries.ExperienceQueries.GetAllExperience;

namespace MyPortfolio.MVC.Components;

public class ExperienceViewComponent : ViewComponent
{
    readonly IMediator _mediator;

    public ExperienceViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _mediator.Send(new GetAllExperienceQueryRequest());
        return View(model);
    }
}
