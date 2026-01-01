using MediatR;
using MyPortfolio.Application.Repositories.AboutRepositories;
using MyPortfolio.Application.Storages;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Commands.AboutCommands.UpdateAbout;

public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommandRequest, UpdateAboutCommandResponse>
{
    readonly IAboutReadRepository _aboutReadRepository;
    readonly IAboutWriteRepository _aboutWriteRepository;
    readonly IStorageService _storageService;

    public UpdateAboutCommandHandler(IAboutReadRepository aboutReadRepository, IAboutWriteRepository aboutWriteRepository, IStorageService storageService)
    {
        _aboutReadRepository = aboutReadRepository;
        _aboutWriteRepository = aboutWriteRepository;
        _storageService = storageService;
    }

    public async Task<UpdateAboutCommandResponse> Handle(UpdateAboutCommandRequest request, CancellationToken cancellationToken)
    {
        About about = await _aboutReadRepository.GetByIdAsync(request.Id!);

        about.Name = request.Name;
        about.Field = request.Field;
        about.Title = request.Title;
        about.Description = request.Description;
        about.PhoneNumber = request.PhoneNumber;
        about.Email = request.Email;
        about.WebSite = request.WebSite;
        about.UpdatedDate = DateTime.Now;

        if (request.File != null && request.File.Length > 0)
        {
            var newImagePath = await _storageService.UploadAsync("about-image", request.File);

            if (about.Image != null && !string.IsNullOrEmpty(about.Image.ImagePath))
                await _storageService.DeleteAsync(about.Image.ImagePath);

            about.Image ??= new Image();
            about.Image.ImagePath = newImagePath;
        }

        _aboutWriteRepository.Update(about);
        await _aboutWriteRepository.SaveAsync();
        return new();
    }
}
