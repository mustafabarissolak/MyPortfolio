using MediatR;

namespace MyPortfolio.Application.Features.Commands.WelcomeAreaCommands.DeleteWelcomeArea;

public class DeleteWelcomeAreaCommandRequest : IRequest<DeleteWelcomeAreaCommandResponse>
{
    public string? Id { get; set; }
}
