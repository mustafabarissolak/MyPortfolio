using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Commands.ContactInfoCommands.CreateContactInfo;
using MyPortfolio.Application.Features.Commands.ContactInfoCommands.DeleteContactInfo;
using MyPortfolio.Application.Features.Commands.ContactInfoCommands.UpdateContactInfo;
using MyPortfolio.Application.Features.Queries.ContactInfoQueries.GetByIdContactInfo;
using MyPortfolio.Application.Features.Queries.ContactInfoQueries.GetSingleContactInfo;

namespace MyPortfolio.MVC.Areas.Dashboard.Controllers;

[Area("Dashboard")]
[Authorize(Roles = "Admin")]
public class ContactInfoController : Controller
{
    readonly IMediator _mediator;

    public ContactInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index() => View(await _mediator.Send(new GetSingleContactInfoQueryRequest()));

    public IActionResult Create() => View(new CreateContactInfoCommandRequest());


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateContactInfoCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(GetByIdContactInfoQueryRequest request)
    {
        var response = await _mediator.Send(request);

        if (response.ContactInfoDto == null)
            return NotFound();

        var model = new UpdateContactInfoCommandRequest
        {
            Id = response.ContactInfoDto.Id,
            FullName = response.ContactInfoDto.FullName,
            Job = response.ContactInfoDto.Job,
            Email = response.ContactInfoDto.Email,
            Location = response.ContactInfoDto.Location,
            WebSite = response.ContactInfoDto.WebSite,
            PhoneNumber = response.ContactInfoDto.PhoneNumber
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateContactInfoCommandRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteContactInfoCommandRequest request)
    {
        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }
}
