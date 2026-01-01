using MediatR;

namespace MyPortfolio.Application.Features.Queries.AboutQueries.GetByIdAbout;

public class GetByIdAboutQueryRequest : IRequest<GetByIdAboutQueryResponse>
{
    public string? Id { get; set; }
}

