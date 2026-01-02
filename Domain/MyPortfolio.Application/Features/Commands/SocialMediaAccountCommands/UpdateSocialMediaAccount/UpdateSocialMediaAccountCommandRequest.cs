using MediatR;

namespace MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.UpdateSocialMediaAccount;

public class UpdateSocialMediaAccountCommandRequest : IRequest<UpdateSocialMediaAccountCommandResponse>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? IconCode { get; set; }
}
