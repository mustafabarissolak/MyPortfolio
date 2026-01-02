using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.AboutRepositories;

namespace MyPortfolio.Application.Features.Queries.AboutQueries.GetSingleAbout;

public class GetSingleAboutQueryHandler : IRequestHandler<GetSingleAboutQueryRequest, GetSingleAboutQueryResponse>
{
    readonly IAboutReadRepository _aboutReadRepository;

    public GetSingleAboutQueryHandler(IAboutReadRepository aboutReadRepository)
    {
        _aboutReadRepository = aboutReadRepository;
    }

    public async Task<GetSingleAboutQueryResponse> Handle(GetSingleAboutQueryRequest request, CancellationToken cancellationToken)
    {
        var about = await _aboutReadRepository.GetSingleAsync();

        if (about is null)
            return new();

        return new()
        {
            AboutDto = new()
            {
                Id = about.Id,
                Name = about.Name,
                Field = about.Field,
                Title = about.Title,
                Description = about.Description,
                CreateDate = about.CreatedDate,
                UpdateDate = about.UpdatedDate,
                ImagePath = about.Image?.ImagePath,
            }
        };
    }
}

