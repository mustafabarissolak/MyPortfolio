using MediatR;
using MyPortfolio.Application.Repositories.EducationRepositories;

namespace MyPortfolio.Application.Features.Commands.EducationCommands.CreateEducation;

public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommandRequest, CreateEducationCommandResponse>
{
    readonly IEducationWriteRepository _educationWriteRepository;

    public CreateEducationCommandHandler(IEducationWriteRepository educationWriteRepository)
    {
        _educationWriteRepository = educationWriteRepository;
    }

    public async Task<CreateEducationCommandResponse> Handle(CreateEducationCommandRequest request, CancellationToken cancellationToken)
    {
        await _educationWriteRepository.AddAsync(new()
        {
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            University = request.University,
            Department = request.Department,
            Location = request.Location,
            Description = request.Description,
        });
        await _educationWriteRepository.SaveAsync();
        return new();
    }
}
