using MediatR;

namespace MyPortfolio.Application.Features.Queries.ExperienceQueries.GetByIdExperience;

public class GetByIdExperienceQueryRequest : IRequest<GetByIdExperienceQueryResponse>
{
    public string? Id { get; set; }
}
