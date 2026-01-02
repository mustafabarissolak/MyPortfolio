using MediatR;
using MyPortfolio.Application.Repositories.ContactInfoRepositories;

namespace MyPortfolio.Application.Features.Commands.ContactInfoCommands.CreateContactInfo;

public class CreateContactInfoCommandHandler : IRequestHandler<CreateContactInfoCommandRequest, CreateContactInfoCommandResponse>
{
    readonly IContactInfoWriteRepository _contactInfoWriteRepository;

    public CreateContactInfoCommandHandler(IContactInfoWriteRepository contactInfoWriteRepository)
    {
        _contactInfoWriteRepository = contactInfoWriteRepository;
    }

    public async Task<CreateContactInfoCommandResponse> Handle(CreateContactInfoCommandRequest request, CancellationToken cancellationToken)
    {
        await _contactInfoWriteRepository.AddAsync(new()
        {
            FullName = request.FullName,
            Job = request.Job,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Location = request.Location,
            WebSite = request.WebSite,
        });

        await _contactInfoWriteRepository.SaveAsync();
        return new();
    }
}
