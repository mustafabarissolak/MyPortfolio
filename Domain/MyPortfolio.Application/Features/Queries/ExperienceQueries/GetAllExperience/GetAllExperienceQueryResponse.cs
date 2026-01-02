using MyPortfolio.Application.DTOs;

namespace MyPortfolio.Application.Features.Queries.ExperienceQueries.GetAllExperience;

public class GetAllExperienceQueryResponse
{
    public List<ExperienceDto>? ExperienceDtoList { get; set; }
}
