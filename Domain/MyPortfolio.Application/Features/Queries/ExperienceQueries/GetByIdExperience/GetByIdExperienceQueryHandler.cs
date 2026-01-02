using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.ExperienceRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.ExperienceQueries.GetByIdExperience;

public class GetByIdExperienceQueryHandler : IRequestHandler<GetByIdExperienceQueryRequest, GetByIdExperienceQueryResponse>
{
    readonly IExperienceReadRepository _experienceReadRepository;

    public GetByIdExperienceQueryHandler(IExperienceReadRepository experienceReadRepository)
    {
        _experienceReadRepository = experienceReadRepository;
    }

    public async Task<GetByIdExperienceQueryResponse> Handle(GetByIdExperienceQueryRequest request, CancellationToken cancellationToken)
    {
        Experience experience = await _experienceReadRepository.GetByIdAsync(request.Id!);

        if (experience == null)
            return new() { ExperienceDto = null };

        ExperienceDto dto = new()
        {
            Id = experience.Id,
            CompanyName = experience.CompanyName,
            Description = experience.Description,
            Location = experience.Location,
            StartDate = experience.StartDate,
            EndDate = experience.EndDate,
            CreateDate = experience.CreatedDate,
            UpdateDate = experience.UpdatedDate
        };

        return new() { ExperienceDto = dto };
    }
}
