using MediatR;

namespace MyPortfolio.Application.Features.Commands.AboutCommands.DeleteAbout;

public class DeleteAboutCommandRequest : IRequest<DeleteAboutCommandResponse>
{
    public string? Id { get; set; }
}
