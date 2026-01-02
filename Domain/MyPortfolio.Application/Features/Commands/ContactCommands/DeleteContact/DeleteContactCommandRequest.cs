using MediatR;

namespace MyPortfolio.Application.Features.Commands.ContactCommands.DeleteContact;

public class DeleteContactCommandRequest : IRequest<DeleteContactCommandResponse>
{
    public string? Id { get; set; }
}
