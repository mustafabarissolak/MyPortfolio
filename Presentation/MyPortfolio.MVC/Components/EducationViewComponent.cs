using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Queries.EducationQueries.GetAllEducation;

namespace MyPortfolio.MVC.Components;

public class EducationViewComponent : ViewComponent
{
    readonly IMediator _mediator;

    public EducationViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _mediator.Send(new GetAllEducationQueryRequest());
        return View(model);
    }
}
