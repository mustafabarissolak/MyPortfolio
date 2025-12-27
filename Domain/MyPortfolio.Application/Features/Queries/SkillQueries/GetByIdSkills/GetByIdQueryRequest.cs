using MediatR;

namespace MyPortfolio.Application.Features.Queries.SkillQueries.GetByIdSkills;

public class GetByIdQueryRequest : IRequest<GetByIdQueryResponse>
{
    public string? Id { get; set; }
}
