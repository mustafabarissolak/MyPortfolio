using MediatR;
using MyPortfolio.Application.Repositories;

namespace MyPortfolio.Application.Features.Commands.EducationCommands.UpdateEducation;

public class UpdateEducationCommandRequest : IRequest<UpdateEducationCommandResponse>
{
    public string? Id { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? University { get; set; }
    public string? Department { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
}
