using MyPortfolio.Application.DTOs;

namespace MyPortfolio.Application.Features.Queries.SkillQueries.GetAllSkills;

public class GetAllSkillsQueryResponse
{
    public List<SkillDto>? SkillDtos { get; set; }
}
