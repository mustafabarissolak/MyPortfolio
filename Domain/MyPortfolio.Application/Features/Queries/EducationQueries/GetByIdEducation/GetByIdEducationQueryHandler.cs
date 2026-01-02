using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.EducationRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.EducationQueries.GetByIdEducation;

public class GetByIdEducationQueryHandler : IRequestHandler<GetByIdEducationQueryRequest, GetByIdEducationQueryResponse>
{
    readonly IEducationReadRepository _educationReadRepository;

    public GetByIdEducationQueryHandler(IEducationReadRepository educationReadRepository)
    {
        _educationReadRepository = educationReadRepository;
    }
    public async Task<GetByIdEducationQueryResponse> Handle(GetByIdEducationQueryRequest request, CancellationToken cancellationToken)
    {
        Education education = await _educationReadRepository.GetByIdAsync(request.Id!);

        if (education == null)
            return new() { EducationDto = null };

        EducationDto dto = new()
        {
            Id = education.Id,
            CreateDate = education.CreatedDate,
            StartDate = education.StartDate,
            Department = education.Department,
            Description = education.Description,
            EndDate = education.EndDate,
            Location = education.Location,
            University = education.University,
            UpdateDate = education.UpdatedDate,
        };

        return new() { EducationDto = dto };
    }
}
