using MediatR;
using MyPortfolio.Application.Repositories.ContactInfoRepositories;

namespace MyPortfolio.Application.Features.Commands.ContactInfoCommands.DeleteContactInfo;

public class DeleteContactInfoCommandHandler : IRequestHandler<DeleteContactInfoCommandRequest, DeleteContactInfoCommandResponse>
{
    readonly IContactInfoWriteRepository _contactInfoWriteRepository;

    public DeleteContactInfoCommandHandler(IContactInfoWriteRepository contactInfoWriteRepository)
    {
        _contactInfoWriteRepository = contactInfoWriteRepository;
    }

    public async Task<DeleteContactInfoCommandResponse> Handle(DeleteContactInfoCommandRequest request, CancellationToken cancellationToken)
    {
        await _contactInfoWriteRepository.RemoveByIdAsync(request.Id!);
        await _contactInfoWriteRepository.SaveAsync();
        return new();
    }
}
