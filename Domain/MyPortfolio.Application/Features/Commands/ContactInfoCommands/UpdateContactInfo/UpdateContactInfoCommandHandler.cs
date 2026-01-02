using MediatR;
using MyPortfolio.Application.Repositories.ContactInfoRepositories;

namespace MyPortfolio.Application.Features.Commands.ContactInfoCommands.UpdateContactInfo;

public class UpdateContactInfoCommandHandler : IRequestHandler<UpdateContactInfoCommandRequest, UpdateContactInfoCommandResponse>
{
    readonly IContactInfoWriteRepository _contactInfoWriteRepository;
    readonly IContactInfoReadRepository _contactInfoReadRepository;

    public UpdateContactInfoCommandHandler(IContactInfoWriteRepository contactInfoWriteRepository, IContactInfoReadRepository contactInfoReadRepository)
    {
        _contactInfoWriteRepository = contactInfoWriteRepository;
        _contactInfoReadRepository = contactInfoReadRepository;
    }

    public async Task<UpdateContactInfoCommandResponse> Handle(UpdateContactInfoCommandRequest request, CancellationToken cancellationToken)
    {
        var contactInfo = await _contactInfoReadRepository.GetByIdAsync(request.Id!);

        contactInfo.FullName = request.FullName;
        contactInfo.Job = request.Job;
        contactInfo.Email = request.Email;
        contactInfo.PhoneNumber = request.PhoneNumber;
        contactInfo.WebSite = request.WebSite;
        contactInfo.Location = request.Location;

        contactInfo.UpdatedDate = DateTime.Now;

        _contactInfoWriteRepository.Update(contactInfo);
        await _contactInfoWriteRepository.SaveAsync();
        return new();
    }
}
