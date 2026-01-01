using MediatR;
using MyPortfolio.Application.Repositories.AboutRepositories;
using MyPortfolio.Application.Storages;

namespace MyPortfolio.Application.Features.Commands.AboutCommands.CreateAbout;

public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommandRequest, CreateAboutCommandResponse>
{
    readonly IAboutWriteRepository _repository;
    readonly IStorageService _storageService;

    public CreateAboutCommandHandler(IAboutWriteRepository repository, IStorageService storageService)
    {
        _repository = repository;
        _storageService = storageService;
    }

    public async Task<CreateAboutCommandResponse> Handle(CreateAboutCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.File != null && request.File.Length > 0)
            request.ImagePath = await _storageService.UploadAsync("about-image", request.File);

        await _repository.AddAsync(new()
        {
            Name = request.Name,
            Field = request.Field,
            Title = request.Title,
            Description = request.Description,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            WebSite = request.WebSite,
            Image = new() { ImagePath = request.ImagePath }
        });

        await _repository.SaveAsync();
        return new();
    }
}
