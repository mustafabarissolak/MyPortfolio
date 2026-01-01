using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Features.Queries.AboutQueries.GetSingleAbout;
using MyPortfolio.MVC.Models;

namespace MyPortfolio.MVC.Components;

public class AboutViewComponent : ViewComponent
{
    readonly IMediator _mediator;

    public AboutViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var responseAbout = await _mediator.Send(new GetSingleAboutQueryRequest());
        //var responseSocialMediaAccount = await _mediator.Send(new GetSocialMediaAccountQueryRequest());

        if (responseAbout?.AboutDto is null)
            return View(new AboutViewModel());

        var model = new AboutViewModel
        {
            AboutVM = new AboutModel
            {
                Name = responseAbout.AboutDto.Name,
                Field = responseAbout.AboutDto.Field,
                Title = responseAbout.AboutDto.Title,
                Description = responseAbout.AboutDto.Description,
                PhoneNumber = responseAbout.AboutDto.PhoneNumber,
                Email = responseAbout.AboutDto.Email,
                WebSite = responseAbout.AboutDto.WebSite,
                ImagePath = responseAbout.AboutDto.ImagePath
            },
            SocialMediaAccountsVM = new()
            //SocialMediaAccountsVM = new SocialMediaAccountModel
            //{
            //    Name = responseSocialMediaAccount.responseSocialMediaAccountDto.Name,
            //    Url = responseSocialMediaAccount.responseSocialMediaAccountDto.Url,
            //    IconCode = responseSocialMediaAccount.responseSocialMediaAccountDto.IconCode
            //}.ToList()
        };

        return View(model);
    }
}
