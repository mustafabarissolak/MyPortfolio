using MediatR;

namespace MyPortfolio.Application.Features.Queries.ContactInfoQueries.GetByIdContactInfo;

public class GetByIdContactInfoQueryRequest : IRequest<GetByIdContactInfoQueryResponse>
{
    public string? Id { get; set; }
}
