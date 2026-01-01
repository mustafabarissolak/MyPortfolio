using MediatR;
using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Application.Storages;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Commands.WelcomeAreaCommands.UpdateWelcomeArea;

public class UpdateWelcomeAreaCommandHandler : IRequestHandler<UpdateWelcomeAreaCommandRequest, UpdateWelcomeAreaCommandResponse>
{
    readonly IWelcomeAreaWriteRepository _welcomeAreaWriteRepository;
    readonly IWelcomeAreaReadRepository _welcomeAreaReadRepository;
    readonly IStorageService _storageService;

    public UpdateWelcomeAreaCommandHandler(IWelcomeAreaWriteRepository welcomeAreaWriteRepository, IStorageService storageService, IWelcomeAreaReadRepository welcomeAreaReadRepository)
    {
        _welcomeAreaWriteRepository = welcomeAreaWriteRepository;
        _storageService = storageService;
        _welcomeAreaReadRepository = welcomeAreaReadRepository;
    }

    public async Task<UpdateWelcomeAreaCommandResponse> Handle(UpdateWelcomeAreaCommandRequest request, CancellationToken cancellationToken)
    {
        WelcomeArea welcomeArea = await _welcomeAreaReadRepository.GetByIdAsync(request.Id!);

        welcomeArea.TopHeading = request.TopHeading;
        welcomeArea.SubHeading = request.SubHeading;
        welcomeArea.UpdatedDate = DateTime.Now;

        if (request.File != null && request.File.Length > 0)
        {
            var newImagePath = await _storageService.UploadAsync("uploads/welcome-area", request.File);

            if (welcomeArea.Image != null && !string.IsNullOrEmpty(welcomeArea.Image.ImagePath))
                await _storageService.DeleteAsync(welcomeArea.Image.ImagePath);

            welcomeArea.Image ??= new Image();
            welcomeArea.Image.ImagePath = newImagePath;
        }

        if (request.Cv != null && request.Cv.Length > 0)
        {
            var newCvUrl = await _storageService.UploadAsync("uploads/welcome-area", request.Cv);

            if (!string.IsNullOrEmpty(welcomeArea.CvUrl))
                await _storageService.DeleteAsync(welcomeArea.CvUrl);

            welcomeArea.CvUrl = newCvUrl;
        }

        _welcomeAreaWriteRepository.Update(welcomeArea);
        await _welcomeAreaWriteRepository.SaveAsync();
        return new();
    }
}
