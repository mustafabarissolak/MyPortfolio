using MediatR;

namespace MyPortfolio.Application.Features.Queries.WelcomeAreaQueries.GetByIdWelcomeArea;

public class GetByIdWelcomeAreaQueryRequest : IRequest<GetByIdWelcomeAreaQueryResponse>
{
    public string? Id { get; set; }
}
