using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.EducationRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.EducationQueries.GetAllEducation;

public class GetAllEducationQueryHandler : IRequestHandler<GetAllEducationQueryRequest, GetAllEducationQueryResponse>
{
    readonly IEducationReadRepository _educationReadRepository;

    public GetAllEducationQueryHandler(IEducationReadRepository educationReadRepository)
    {
        _educationReadRepository = educationReadRepository;
    }

    public async Task<GetAllEducationQueryResponse> Handle(GetAllEducationQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Education> educations = _educationReadRepository.GetAll();

        List<EducationDto> dtoList = educations.Select(education => new EducationDto()
        {
            Id = education.Id,
            Department = education.Department,
            Location = education.Location,
            Description = education.Description,
            University = education.University,
            CreateDate = education.CreatedDate,
            UpdateDate = education.UpdatedDate,
            EndDate = education.EndDate,
            StartDate = education.StartDate
        }).ToList();

        return new() { EducationDtoList = dtoList };
    }
}
