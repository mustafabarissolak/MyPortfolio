using MediatR;
using MyPortfolio.Application.Repositories.ExperienceRepositories;

namespace MyPortfolio.Application.Features.Commands.ExperienceCommands.DeleteExperience;

public class DeleteExperienceCommandRequest : IRequest<DeleteExperienceCommandResponse>
{
    public string? Id { get; set; }
}
public class DeleteExperienceCommandResponse
{
}
public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommandRequest, DeleteExperienceCommandResponse>
{
    readonly IExperienceWriteRepository _experienceWriteRepository;

    public DeleteExperienceCommandHandler(IExperienceWriteRepository experienceWriteRepository)
    {
        _experienceWriteRepository = experienceWriteRepository;
    }

    public async Task<DeleteExperienceCommandResponse> Handle(DeleteExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        await _experienceWriteRepository.RemoveByIdAsync(request.Id!);
        await _experienceWriteRepository.SaveAsync();
        return new();
    }
}
