using MediatR;
using MyPortfolio.Application.Repositories.ContactInfoRepositories;

namespace MyPortfolio.Application.Features.Queries.ContactInfoQueries.GetSingleContactInfo;

public class GetSingleContactInfoQueryHandler : IRequestHandler<GetSingleContactInfoQueryRequest, GetSingleContactInfoQueryResponse>
{
    readonly IContactInfoReadRepository _contactInfoReadRepository;


    public GetSingleContactInfoQueryHandler(IContactInfoReadRepository contactInfoReadRepository)
    {
        _contactInfoReadRepository = contactInfoReadRepository;
    }

    public async Task<GetSingleContactInfoQueryResponse> Handle(GetSingleContactInfoQueryRequest request, CancellationToken cancellationToken)
    {
        var contactInfo = await _contactInfoReadRepository.GetSingleAsync();

        if (contactInfo is null)
            return new();

        return new()
        {
            ContactInfoDto = new()
            {
                Id = contactInfo.Id,
                FullName = contactInfo.FullName,
                Job = contactInfo.Job,
                Email = contactInfo.Email,
                PhoneNumber = contactInfo.PhoneNumber,
                Location = contactInfo.Location,
                WebSite = contactInfo.WebSite,
            }
        };
    }
}
