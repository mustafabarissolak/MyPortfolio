using MediatR;
using MyPortfolio.Application.Repositories.SocialMediaAccountRepositories;

namespace MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.UpdateSocialMediaAccount;

public class UpdateSocialMediaAccountCommandHandler : IRequestHandler<UpdateSocialMediaAccountCommandRequest, UpdateSocialMediaAccountCommandResponse>
{
    readonly ISocialMediaAccountWriteRepository _socialMediaAccountWriteRepository;
    readonly ISocialMediaAccountReadRepository _socialMediaAccountReadRepository;

    public UpdateSocialMediaAccountCommandHandler(ISocialMediaAccountWriteRepository socialMediaAccountWriteRepository, ISocialMediaAccountReadRepository socialMediaAccountReadRepository)
    {
        _socialMediaAccountWriteRepository = socialMediaAccountWriteRepository;
        _socialMediaAccountReadRepository = socialMediaAccountReadRepository;
    }

    public async Task<UpdateSocialMediaAccountCommandResponse> Handle(UpdateSocialMediaAccountCommandRequest request, CancellationToken cancellationToken)
    {
        var socialMediaAccount = await _socialMediaAccountReadRepository.GetByIdAsync(request.Id!); 

        socialMediaAccount.Name = request.Name;
        socialMediaAccount.Url = request.Url;
        socialMediaAccount.IconCode = request.IconCode;
        socialMediaAccount.UpdatedDate = DateTime.Now;

        _socialMediaAccountWriteRepository.Update(socialMediaAccount);
        await _socialMediaAccountWriteRepository.SaveAsync();
        return new();
    }
}
