using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.SocialMediaAccountRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.SocialMediaAccountQueries.GetAllSocialMediaAccount;

public class GetAllSocialMediaAccountQueryHandler : IRequestHandler<GetAllSocialMediaAccountQueryRequest, GetAllSocialMediaAccountQueryResponse>
{
    readonly ISocialMediaAccountReadRepository _socialMediaAccountReadRepository;

    public GetAllSocialMediaAccountQueryHandler(ISocialMediaAccountReadRepository socialMediaAccountReadRepository)
    {
        _socialMediaAccountReadRepository = socialMediaAccountReadRepository;
    }

    public async Task<GetAllSocialMediaAccountQueryResponse> Handle(GetAllSocialMediaAccountQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<SocialMediaAccount> socialMediaAccounts = _socialMediaAccountReadRepository.GetAll();

        List<SocialMediaAccountDto> dtoList = socialMediaAccounts.Select(socialMediaAccount => new SocialMediaAccountDto()
        {
            Id = socialMediaAccount.Id,
            Name = socialMediaAccount.Name,
            IconCode = socialMediaAccount.IconCode,
            Url = socialMediaAccount.Url,
            CreateDate = socialMediaAccount.CreatedDate,
            UpdateDate = socialMediaAccount.UpdatedDate
        }).ToList();

        return new() { SocialMediaAccountDto = dtoList };
    }
}
