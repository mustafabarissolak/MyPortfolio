using MyPortfolio.Application.DTOs;

namespace MyPortfolio.Application.Features.Queries.EducationQueries.GetAllEducation;

public class GetAllEducationQueryResponse
{
    public List<EducationDto>? EducationDtoList { get; set; }
}
