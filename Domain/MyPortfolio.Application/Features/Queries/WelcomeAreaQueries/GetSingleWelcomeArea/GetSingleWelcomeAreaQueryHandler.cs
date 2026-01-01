using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.WelcomeAreaQueries.GetSingleWelcomeArea;

public class GetSingleWelcomeAreaQueryHandler : IRequestHandler<GetSingleWelcomeAreaQueryRequest, GetSingleWelcomeAreaQueryResponse>
{
    readonly IWelcomeAreaReadRepository _welcomeAreaReadRepository;

    public GetSingleWelcomeAreaQueryHandler(IWelcomeAreaReadRepository welcomeAreaReadRepository)
    {
        _welcomeAreaReadRepository = welcomeAreaReadRepository;
    }

    public async Task<GetSingleWelcomeAreaQueryResponse> Handle(GetSingleWelcomeAreaQueryRequest request, CancellationToken cancellationToken)
    {
        WelcomeArea welcomeArea = await _welcomeAreaReadRepository.GetSingleAsync();
        if (welcomeArea is null)
            return new();

        return new()
        {
            WelcomeAreaDto = new WelcomeAreaDto()
            {
                Id = welcomeArea.Id,
                TopHeading = welcomeArea.TopHeading,
                SubHeading = welcomeArea.SubHeading,
                CvUrl = welcomeArea.CvUrl,
                ImagePath = welcomeArea.Image?.ImagePath,
                CreateDate = welcomeArea.CreatedDate,
                UpdateDate = welcomeArea.UpdatedDate
            }
        };
    }
}
