using MediatR;

namespace MyPortfolio.Application.Features.Queries.SocialMediaAccountQueries.GetByIdSocialMediaAccount;

public class GetByIdSocialMediaAccountQueryRequest : IRequest<GetByIdSocialMediaAccountQueryResponse>
{
    public string? Id { get; set; }
}
