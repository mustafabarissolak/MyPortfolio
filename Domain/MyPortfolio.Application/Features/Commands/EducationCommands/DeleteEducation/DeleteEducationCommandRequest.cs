using MediatR;
using MyPortfolio.Application.Repositories.ContactRepositories;

namespace MyPortfolio.Application.Features.Commands.EducationCommands.DeleteEducation;

public class DeleteEducationCommandRequest : IRequest<DeleteEducationCommandResponse>
{
    public string? Id { get; set; }
}
