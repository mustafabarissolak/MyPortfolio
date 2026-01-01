using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.SkillRepositores;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.SkillQueries.GetByIdSkills;

public class GetByIdSkillQueryHandler : IRequestHandler<GetByIdSkillQueryRequest, GetByIdSkillQueryResponse>
{
    readonly ISkillReadRepository _repository;

    public GetByIdSkillQueryHandler(ISkillReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetByIdSkillQueryResponse> Handle(GetByIdSkillQueryRequest request, CancellationToken cancellationToken)
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
