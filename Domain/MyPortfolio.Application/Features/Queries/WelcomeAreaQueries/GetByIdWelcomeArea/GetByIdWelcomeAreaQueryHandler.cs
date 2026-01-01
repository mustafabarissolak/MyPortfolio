using MediatR;
using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.WelcomeAreaQueries.GetByIdWelcomeArea;

public class GetByIdWelcomeAreaQueryHandler : IRequestHandler<GetByIdWelcomeAreaQueryRequest, GetByIdWelcomeAreaQueryResponse>
{
    readonly IWelcomeAreaReadRepository _welcomeAreaReadRepository;

    public GetByIdWelcomeAreaQueryHandler(IWelcomeAreaReadRepository welcomeAreaReadRepository)
    {
        _welcomeAreaReadRepository = welcomeAreaReadRepository;
    }

    public async Task<GetByIdWelcomeAreaQueryResponse> Handle(GetByIdWelcomeAreaQueryRequest request, CancellationToken cancellationToken)
    {
        WelcomeArea welcomeArea = await _welcomeAreaReadRepository.GetByIdAsync(request.Id!);

        if (welcomeArea is null)
            return new();

        return new()
        {
            WelcomeAreaDto = new()
            {
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
