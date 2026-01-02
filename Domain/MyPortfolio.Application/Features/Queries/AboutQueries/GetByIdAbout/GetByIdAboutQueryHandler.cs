using MediatR;
using MyPortfolio.Application.Repositories.AboutRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.AboutQueries.GetByIdAbout;

public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQueryRequest, GetByIdAboutQueryResponse>
{
    readonly IAboutReadRepository _aboutReadRepository;

    public GetByIdAboutQueryHandler(IAboutReadRepository aboutReadRepository)
    {
        _aboutReadRepository = aboutReadRepository;
    }

    public async Task<GetByIdAboutQueryResponse> Handle(GetByIdAboutQueryRequest request, CancellationToken cancellationToken)
    {
        About about = await _aboutReadRepository.GetByIdAsync(request.Id!);

        return new()
        {
            AboutDto = new()
            {
                Name = about.Name,
                Field = about.Field,
                Title = about.Title,
                Description = about.Description,
                ImagePath = about.Image?.ImagePath
            }
        };
    }
}

