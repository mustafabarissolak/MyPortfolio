using MediatR;
using MyPortfolio.Application.Repositories.ExperienceRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Commands.ExperienceCommands.UpdateExperience;

public class UpdateExperienceCommandRequest : IRequest<UpdateExperienceCommandResponse>
{
    public string? Id { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? CompanyName { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
}
public class UpdateExperienceCommandResponse { }
public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommandRequest, UpdateExperienceCommandResponse>
{
    readonly IExperienceReadRepository _experienceReadRepository;
    readonly IExperienceWriteRepository _experienceWriteRepository;

    public UpdateExperienceCommandHandler(IExperienceWriteRepository experienceWriteRepository, IExperienceReadRepository experienceReadRepository)
    {
        _experienceWriteRepository = experienceWriteRepository;
        _experienceReadRepository = experienceReadRepository;
    }

    public async Task<UpdateExperienceCommandResponse> Handle(UpdateExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        Experience experience = await _experienceReadRepository.GetByIdAsync(request.Id!);

        experience.StartDate = request.StartDate;
        experience.EndDate = request.EndDate;
        experience.CompanyName = request.CompanyName;
        experience.Location = request.Location;
        experience.Description = request.Description;

        _experienceWriteRepository.Update(experience);
        await _experienceWriteRepository.SaveAsync();
        return new();
    }
}


