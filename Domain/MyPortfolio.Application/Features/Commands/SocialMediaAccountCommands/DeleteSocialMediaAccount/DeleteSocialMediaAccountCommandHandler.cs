using MediatR;
using MyPortfolio.Application.Repositories.SocialMediaAccountRepositories;

namespace MyPortfolio.Application.Features.Commands.SocialMediaAccountCommands.DeleteSocialMediaAccount;

public class DeleteSocialMediaAccountCommandHandler : IRequestHandler<DeleteSocialMediaAccountCommandRequest, DeleteSocialMediaAccountCommandResponse>
{
    readonly ISocialMediaAccountWriteRepository _socialMediaAccountWriteRepository;

    public DeleteSocialMediaAccountCommandHandler(ISocialMediaAccountWriteRepository socialMediaAccountWriteRepository)
    {
        _socialMediaAccountWriteRepository = socialMediaAccountWriteRepository;
    }

    public async Task<DeleteSocialMediaAccountCommandResponse> Handle(DeleteSocialMediaAccountCommandRequest request, CancellationToken cancellationToken)
    {
        await _socialMediaAccountWriteRepository.RemoveByIdAsync(request.Id!);
        await _socialMediaAccountWriteRepository.SaveAsync();
        return new();
    }
}