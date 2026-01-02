using MediatR;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.CreateSocialMediaAccount;

public class CreateSocialMediaAccountCommandRequest : IRequest<CreateSocialMediaAccountCommandResponse>
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? IconCode { get; set; }
}
