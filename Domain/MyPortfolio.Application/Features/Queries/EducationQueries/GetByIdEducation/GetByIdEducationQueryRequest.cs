using MediatR;

namespace MyPortfolio.Application.Features.Queries.EducationQueries.GetByIdEducation;

public class GetByIdEducationQueryRequest : IRequest<GetByIdEducationQueryResponse>
{
    public string? Id { get; set; }
}
