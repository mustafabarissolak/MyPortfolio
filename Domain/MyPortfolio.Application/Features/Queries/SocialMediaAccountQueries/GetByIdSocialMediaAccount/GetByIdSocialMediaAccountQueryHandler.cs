using MediatR;
using MyPortfolio.Application.Repositories.SocialMediaAccountRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.SocialMediaAccountQueries.GetByIdSocialMediaAccount;

public class GetByIdSocialMediaAccountQueryHandler : IRequestHandler<GetByIdSocialMediaAccountQueryRequest, GetByIdSocialMediaAccountQueryResponse>
{
    readonly ISocialMediaAccountReadRepository _socialMediaAccountReadRepository;

    public GetByIdSocialMediaAccountQueryHandler(ISocialMediaAccountReadRepository socialMediaAccountReadRepository)
    {
        _socialMediaAccountReadRepository = socialMediaAccountReadRepository;
    }

    public async Task<GetByIdSocialMediaAccountQueryResponse> Handle(GetByIdSocialMediaAccountQueryRequest request, CancellationToken cancellationToken)
    {
        SocialMediaAccount socialMediaAccount = await _socialMediaAccountReadRepository.GetByIdAsync(request.Id!);
        if (socialMediaAccount == null)
            return new() { SocialMediaAccountDto = null };

        return new()
        {
            SocialMediaAccountDto = new()
            {
                Id = socialMediaAccount.Id,
                Name = socialMediaAccount.Name,
                IconCode = socialMediaAccount.IconCode,
                Url = socialMediaAccount.Url,
                CreateDate = socialMediaAccount.CreatedDate,
                UpdateDate = socialMediaAccount.UpdatedDate
            }
        };
    }
}
