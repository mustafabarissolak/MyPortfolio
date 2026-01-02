using MyPortfolio.Application.DTOs;

namespace MyPortfolio.Application.Features.Queries.ContactQueries.GetAllContact;

public class GetAllContactQueryResponse
{
    public List<ContactDto>? ContactDtoList { get; set; }
}
