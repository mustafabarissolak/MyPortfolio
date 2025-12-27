using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.SkillRepositores;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.SkillQueries.GetByIdSkills;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQueryRequest, GetByIdQueryResponse>
{
    readonly ISkillReadRepository _repository;

    public GetByIdQueryHandler(ISkillReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetByIdQueryResponse> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
    {
        Skill skill = await _repository.GetByIdAsync(request.Id!);

        if (skill == null)
            return new() { SkillDto = null };

        SkillDto dto = new()
        {
            Name = skill.Name,
            Value = skill.Value,
            CreateDate = skill.CreatedDate,
            UpdateDate = skill.UpdatedDate
        };

        return new()
        {
            SkillDto = dto
        };
    }

}
