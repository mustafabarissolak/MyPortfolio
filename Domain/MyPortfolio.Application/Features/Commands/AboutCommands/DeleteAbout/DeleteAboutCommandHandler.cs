using MediatR;
using MyPortfolio.Application.Repositories.AboutRepositories;
using MyPortfolio.Application.Storages;

namespace MyPortfolio.Application.Features.Commands.AboutCommands.DeleteAbout;

public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommandRequest, DeleteAboutCommandResponse>
{
    readonly IAboutWriteRepository _aboutWriteRepository;
    readonly IAboutReadRepository _aboutReadRepository;
    readonly IStorageService _storageService;
    public DeleteAboutCommandHandler(IAboutWriteRepository aboutWriteRepository, IStorageService storageService, IAboutReadRepository aboutReadRepository)
    {
        _aboutWriteRepository = aboutWriteRepository;
        _storageService = storageService;
        _aboutReadRepository = aboutReadRepository;
    }

    public async Task<DeleteAboutCommandResponse> Handle(DeleteAboutCommandRequest request, CancellationToken cancellationToken)
    {
        var about = await _aboutReadRepository.GetByIdAsync(request.Id!);

        if (about.Image != null && about.Image.ImagePath != null)
            await _storageService.DeleteAsync(about.Image.ImagePath);

        await _aboutWriteRepository.RemoveByIdAsync(request.Id!);
        await _aboutWriteRepository.SaveAsync();

        return new();
    }
}
