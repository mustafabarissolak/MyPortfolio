using MediatR;

namespace MyPortfolio.Application.Features.Queries.ContactQueries.GetByIdContact;

public class GetByIdContactQueryRequest : IRequest<GetByIdContactQueryResponse>
{
    public string? Id { get; set; }
}
