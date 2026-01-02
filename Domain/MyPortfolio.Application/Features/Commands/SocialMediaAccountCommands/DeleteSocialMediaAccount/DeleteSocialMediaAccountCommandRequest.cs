using MediatR;

namespace MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.DeleteSocialMediaAccount;

public class DeleteSocialMediaAccountCommandRequest : IRequest<DeleteSocialMediaAccountCommandResponse>
{
    public string? Id { get; set; }
}
