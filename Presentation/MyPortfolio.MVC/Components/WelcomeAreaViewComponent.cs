using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Queries.WelcomeAreaQueries.GetSingleWelcomeArea;
using System.Threading.Tasks;

namespace MyPortfolio.MVC.Components;

public class WelcomeAreaViewComponent : ViewComponent
{
    readonly IMediator _mediator;

    public WelcomeAreaViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _mediator.Send(new GetSingleWelcomeAreaQueryRequest());
        return View(model);
    }
}
