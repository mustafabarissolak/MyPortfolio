using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.ContactRepositories;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.ContactQueries.GetAllContact;

public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQueryRequest, GetAllContactQueryResponse>
{
    readonly IContactReadRepository _contactReadRepository;

    public GetAllContactQueryHandler(IContactReadRepository contactReadRepository)
    {
        _contactReadRepository = contactReadRepository;
    }

    public async Task<GetAllContactQueryResponse> Handle(GetAllContactQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Contact> contactMessages = _contactReadRepository.GetAll();
        List<ContactDto> dtoList = contactMessages.Select(message => new ContactDto()
        {
            Id = message.Id,
            Name = message.Name,
            Message = message.Message,
            Email = message.Email,
            Subject = message.Subject,
            SendDate = message.CreatedDate
        }).ToList();

        return new() { ContactDtoList = dtoList };
    }
}
