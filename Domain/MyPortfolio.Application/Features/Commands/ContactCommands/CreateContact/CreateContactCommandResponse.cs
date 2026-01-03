using MyPortfolio.Application.DTOs;

namespace MyPortfolio.Application.Features.Commands.ContactCommands.CreateContact;

public class CreateContactCommandResponse
{
    public ContactDto? ContactMessage { get; set; }
}
