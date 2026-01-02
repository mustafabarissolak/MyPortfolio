using MediatR;
using MyPortfolio.Application.Repositories.SocialMediaAccountRepositories;

namespace MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.CreateSocialMediaAccount;

public class CreateSocialMediaAccountCommandHandler : IRequestHandler<CreateSocialMediaAccountCommandRequest, CreateSocialMediaAccountCommandResponse>
{
    readonly ISocialMediaAccountWriteRepository _socialMediaAccountWriteRepository;

    public CreateSocialMediaAccountCommandHandler(ISocialMediaAccountWriteRepository socialMediaAccountWriteRepository)
    {
        _socialMediaAccountWriteRepository = socialMediaAccountWriteRepository;
    }

    public async Task<CreateSocialMediaAccountCommandResponse> Handle(CreateSocialMediaAccountCommandRequest request, CancellationToken cancellationToken)
    {
        await _socialMediaAccountWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Url = request.Url,
            IconCode = request.IconCode
        });
        await _socialMediaAccountWriteRepository.SaveAsync();
        return new();
    }
}