using MediatR;

namespace MyPortfolio.Application.Features.Commands.ContactInfoCommands.DeleteContactInfo;

public class DeleteContactInfoCommandRequest : IRequest<DeleteContactInfoCommandResponse>
{
    public string? Id { get; set; }
}


