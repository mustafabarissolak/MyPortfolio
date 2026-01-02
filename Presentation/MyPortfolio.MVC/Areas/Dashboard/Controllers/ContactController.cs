using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.ContactCommands.DeleteContact;
using MyPortfolio.Application.Features.Queries.ContactQueries.GetAllContact;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class ContactController : Controller
{
    readonly IMediator _mediator;

    public ContactController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Index() => View(await _mediator.Send(new GetAllContactQueryRequest()));

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteContactCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }
}
