using MediatR;
using MyPortfolio.Application.Repositories.ContactRepositories;

namespace MyPortfolio.Application.Features.Commands.ContactCommands.CreateContact;

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, CreateContactCommandResponse>
{
    readonly IContactWriteRepository _contactWriteRepository;

    public CreateContactCommandHandler(IContactWriteRepository contactWriteRepository)
    {
        _contactWriteRepository = contactWriteRepository;
    }

    public async Task<CreateContactCommandResponse> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
    {
        await _contactWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Email = request.Email,
            Subject = request.Subject,
            Message = request.Message
        });

        await _contactWriteRepository.SaveAsync();
        return new()
        {
            ContactMessage = new()
            {
                Name = request.Name,
                Email = request.Email,
                Subject = request.Subject,
                Message = request.Message,
                SendDate = DateTime.Now
            }
        };
    }
}
