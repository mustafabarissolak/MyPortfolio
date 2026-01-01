using MediatR;

namespace MyPortfolio.Application.Features.Queries.SkillQueries.GetByIdSkills;

public class GetByIdSkillQueryRequest : IRequest<GetByIdSkillQueryResponse>
{
    public string? Id { get; set; }
}
