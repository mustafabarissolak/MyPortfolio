using MediatR;

namespace MyPortfolio.Application.Features.Commands.EducationCommands.CreateEducation;

public class CreateEducationCommandRequest : IRequest<CreateEducationCommandResponse>
{
    public DateOnly? StartDate { get; set; } = new();
    public DateOnly? EndDate { get; set; } = null;
    public string? University { get; set; }
    public string? Department { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
}
