using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Features.Queries.AboutQueries.GetSingleAbout;
using MyPortfolio.Application.Features.Queries.ContactInfoQueries.GetSingleContactInfo;
using MyPortfolio.Application.Features.Queries.SocialMediaAccountQueries.GetAllSocialMediaAccount;
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
        var responseContactInfo = await _mediator.Send(new GetSingleContactInfoQueryRequest());
        var responseSocialMediaAccount = await _mediator.Send(new GetAllSocialMediaAccountQueryRequest());

        var model = new AboutViewModel
        {
            AboutModel = new()
            {
                Name = responseAbout.AboutDto!.Name,
                Field = responseAbout.AboutDto.Field,
                Title = responseAbout.AboutDto.Title,
                Description = responseAbout.AboutDto.Description,
                ImagePath = responseAbout.AboutDto.ImagePath
            },
            ContactInfoDtoModel = new()
            {
                FullName = responseContactInfo.ContactInfoDto!.FullName,
                Job = responseContactInfo.ContactInfoDto.Job,
                Email = responseContactInfo.ContactInfoDto.Email,
                Location = responseContactInfo.ContactInfoDto.Location,
                WebSite = responseContactInfo.ContactInfoDto.WebSite,
                PhoneNumber = responseContactInfo.ContactInfoDto.PhoneNumber
            }
            ,
            SocialMediaAccountModels = responseSocialMediaAccount.SocialMediaAccountDto?.Select(socialMediaAccount => new SocialMediaAccountDto()
            {
                Name = socialMediaAccount.Name,
                IconCode = socialMediaAccount.IconCode,
                Url = socialMediaAccount.Url,
            }).ToList()
        };

        return View(model);
    }
}
