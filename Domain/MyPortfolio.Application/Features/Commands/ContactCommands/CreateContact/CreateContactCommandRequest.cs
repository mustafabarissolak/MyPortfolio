using MediatR;

namespace MyPortfolio.Application.Features.Commands.ContactCommands.CreateContact;

public class CreateContactCommandRequest : IRequest<CreateContactCommandResponse>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
}
