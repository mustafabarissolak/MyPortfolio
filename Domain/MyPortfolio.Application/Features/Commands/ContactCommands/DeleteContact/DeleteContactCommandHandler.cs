using MediatR;
using MyPortfolio.Application.Repositories.ContactRepositories;

namespace MyPortfolio.Application.Features.Commands.ContactCommands.DeleteContact;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommandRequest, DeleteContactCommandResponse>
{
    readonly IContactWriteRepository _contactWriteRepository;

    public DeleteContactCommandHandler(IContactWriteRepository contactWriteRepository)
    {
        _contactWriteRepository = contactWriteRepository;
    }

    public async Task<DeleteContactCommandResponse> Handle(DeleteContactCommandRequest request, CancellationToken cancellationToken)
    {
        await _contactWriteRepository.RemoveByIdAsync(request.Id!);
        await _contactWriteRepository.SaveAsync();
        return new();
    }
}
