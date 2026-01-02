using MediatR;

namespace MyPortfolio.Application.Features.Commands.ContactInfoCommands.CreateContactInfo;

public class CreateContactInfoCommandRequest : IRequest<CreateContactInfoCommandResponse>
{
    public string? FullName { get; set; }
    public string? Job { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Location { get; set; }
    public string? WebSite { get; set; }
}


