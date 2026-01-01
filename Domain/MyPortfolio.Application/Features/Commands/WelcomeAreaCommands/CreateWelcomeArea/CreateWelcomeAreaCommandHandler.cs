using MediatR;
using MyPortfolio.Application.Repositories.WelcomeAreaRepositories;
using MyPortfolio.Application.Storages;

namespace MyPortfolio.Application.Features.Commands.WelcomeAreaCommands.CreateWelcomeArea;

public class CreateWelcomeAreaCommandHandler : IRequestHandler<CreateWelcomeAreaCommandRequest, CreateWelcomeAreaCommandResponse>
{
    readonly IWelcomeAreaWriteRepository _welcomeAreaWriteRepository;
    readonly IStorageService _storageService;

    public CreateWelcomeAreaCommandHandler(IWelcomeAreaWriteRepository welcomeAreaWriteRepository, IStorageService storageService)
    {
        _welcomeAreaWriteRepository = welcomeAreaWriteRepository;
        _storageService = storageService;
    }

    public async Task<CreateWelcomeAreaCommandResponse> Handle(CreateWelcomeAreaCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.File != null && request.File.Length > 0)
            request.ImagePath = await _storageService.UploadAsync("uploads/welcome-area", request.File);

        if (request.Cv != null && request.Cv.Length > 0)
            request.CvUrl = await _storageService.UploadAsync("uploads/welcome-area", request.Cv);

        await _welcomeAreaWriteRepository.AddAsync(new()
        {
            TopHeading = request.TopHeading,
            SubHeading = request.SubHeading,
            CvUrl = request.CvUrl,
            Image = new() { ImagePath = request.ImagePath }
        });

        await _welcomeAreaWriteRepository.SaveAsync();
        return new();
    }
}
