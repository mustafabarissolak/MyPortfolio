using MediatR;
using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Application.Storages;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Commands.WelcomeAreaCommands.DeleteWelcomeArea;

public class DeleteWelcomeAreaCommandHandler : IRequestHandler<DeleteWelcomeAreaCommandRequest, DeleteWelcomeAreaCommandResponse>
{
    readonly IWelcomeAreaWriteRepository _welcomeAreaWriteRepository;
    readonly IWelcomeAreaReadRepository _welcomeAreaReadRepository;
    readonly IStorageService _storageService;

    public DeleteWelcomeAreaCommandHandler(IWelcomeAreaWriteRepository welcomeAreaWriteRepository, IWelcomeAreaReadRepository welcomeAreaReadRepository, IStorageService storageService)
    {
        _welcomeAreaWriteRepository = welcomeAreaWriteRepository;
        _welcomeAreaReadRepository = welcomeAreaReadRepository;
        _storageService = storageService;
    }

    public async Task<DeleteWelcomeAreaCommandResponse> Handle(DeleteWelcomeAreaCommandRequest request, CancellationToken cancellationToken)
    {
        WelcomeArea welcomeArea = await _welcomeAreaReadRepository.GetByIdAsync(request.Id!);

        if (welcomeArea.Image != null && welcomeArea.Image.ImagePath != null)
            await _storageService.DeleteAsync(welcomeArea.Image.ImagePath);

        if (welcomeArea.CvUrl != null)
            await _storageService.DeleteAsync(welcomeArea.CvUrl);

        await _welcomeAreaWriteRepository.RemoveByIdAsync(request.Id!);
        await _welcomeAreaWriteRepository.SaveAsync();

        return new();
    }
}
