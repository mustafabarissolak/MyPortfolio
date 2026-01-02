using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.ContactRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.ContactQueries.GetByIdContact;

public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQueryRequest, GetByIdContactQueryResponse>
{
    readonly IContactReadRepository _contactReadRepository;

    public GetByIdContactQueryHandler(IContactReadRepository contactReadRepository)
    {
        _contactReadRepository = contactReadRepository;
    }

    public async Task<GetByIdContactQueryResponse> Handle(GetByIdContactQueryRequest request, CancellationToken cancellationToken)
    {
        Contact contact = await _contactReadRepository.GetByIdAsync(request.Id!);

        if (contact == null)
            return new() { ContactDto = null };

        ContactDto dto = new()
        {
            Id = request.Id,
            Name = contact.Name,
            Message = contact.Message,
            Subject = contact.Subject,
            Email = contact.Email,
            SendDate = contact.CreatedDate
        };

        return new() { ContactDto = dto };
    }
}
