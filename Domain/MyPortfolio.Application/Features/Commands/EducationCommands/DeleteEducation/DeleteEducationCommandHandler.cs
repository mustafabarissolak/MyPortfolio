using MediatR;
using MyPortfolio.Application.Repositories.EducationRepositories;

namespace MyPortfolio.Application.Features.Commands.EducationCommands.DeleteEducation;

public class DeleteEducationCommandHandler : IRequestHandler<DeleteEducationCommandRequest, DeleteEducationCommandResponse>
{
    readonly IEducationWriteRepository _educationWriteRepository;

    public DeleteEducationCommandHandler(IEducationWriteRepository educationWriteRepository)
    {
        _educationWriteRepository = educationWriteRepository;
    }

    public async Task<DeleteEducationCommandResponse> Handle(DeleteEducationCommandRequest request, CancellationToken cancellationToken)
    {
        await _educationWriteRepository.RemoveByIdAsync(request.Id!);
        await _educationWriteRepository.SaveAsync();
        return new();
    }
}
