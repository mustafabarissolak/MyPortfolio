using MediatR;
using MyPortfolio.Application.Repositories.EducationRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Commands.EducationCommands.UpdateEducation;

public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommandRequest, UpdateEducationCommandResponse>
{
    readonly IEducationWriteRepository _educationWriteRepository;
    readonly IEducationReadRepository _educationReadRepository;

    public UpdateEducationCommandHandler(IEducationReadRepository educationReadRepository, IEducationWriteRepository educationWriteRepository)
    {
        _educationReadRepository = educationReadRepository;
        _educationWriteRepository = educationWriteRepository;
    }

    public async Task<UpdateEducationCommandResponse> Handle(UpdateEducationCommandRequest request, CancellationToken cancellationToken)
    {
        Education education = await _educationReadRepository.GetByIdAsync(request.Id!);

        education.StartDate = request.StartDate;
        education.EndDate = request.EndDate;
        education.University = request.University;
        education.Department = request.Department;
        education.Location = request.Location;
        education.Description = request.Description;
        education.UpdatedDate = DateTime.Now;

        _educationWriteRepository.Update(education);
        await _educationWriteRepository.SaveAsync();
        return new();
    }
}
