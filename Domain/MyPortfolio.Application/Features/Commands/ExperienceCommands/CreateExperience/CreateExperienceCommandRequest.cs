using MediatR;
using MyPortfolio.Application.Repositories.ExperienceRepositories;

namespace MyPortfolio.Application.Features.Commands.ExperienceCommands.CreateExperience;

public class CreateExperienceCommandRequest : IRequest<CreateExperienceCommandResponse>
{
    public DateOnly? StartDate { get; set; } = new();
    public DateOnly? EndDate { get; set; } = null;
    public string? CompanyName { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
}
public class CreateExperienceCommandResponse{}
public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommandRequest, CreateExperienceCommandResponse>
{
    readonly IExperienceWriteRepository _experienceWriteRepository;

    public CreateExperienceCommandHandler(IExperienceWriteRepository experienceWriteRepository)
    {
        _experienceWriteRepository = experienceWriteRepository;
    }

    public async Task<CreateExperienceCommandResponse> Handle(CreateExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        await _experienceWriteRepository.AddAsync(new()
        {
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CompanyName = request.CompanyName,
            Location = request.Location,
            Description = request.Description,
        });
        await _experienceWriteRepository.SaveAsync();
        return new();
    }
}
