using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.ExperienceRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.ExperienceQueries.GetAllExperience;

public class GetAllExperienceQueryHandler : IRequestHandler<GetAllExperienceQueryRequest, GetAllExperienceQueryResponse>
{
    readonly IExperienceReadRepository _experienceReadRepository;

    public GetAllExperienceQueryHandler(IExperienceReadRepository experienceReadRepository)
    {
        _experienceReadRepository = experienceReadRepository;
    }

    public async Task<GetAllExperienceQueryResponse> Handle(GetAllExperienceQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Experience> experiences = _experienceReadRepository.GetAll();
        List<ExperienceDto> dtoList = experiences.Select(experience => new ExperienceDto()
        {
            Id = experience.Id,
            CompanyName = experience.CompanyName,
            Description = experience.Description,
            EndDate = experience.EndDate,
            Location = experience.Location,
            StartDate = experience.StartDate,
            CreateDate = experience.CreatedDate,
            UpdateDate = experience.UpdatedDate,            
        }).ToList();

        return new() {ExperienceDtoList = dtoList };
    }
}