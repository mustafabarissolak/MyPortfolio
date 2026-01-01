using MediatR;
using MyPortfolio.Application.DTOs;
using MyPortfolio.Application.Repositories.SkillRepositores;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Queries.SkillQueries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQueryRequest, GetAllSkillsQueryResponse>
{
    readonly ISkillReadRepository _repository;

    public GetAllSkillsQueryHandler(ISkillReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAllSkillsQueryResponse> Handle(GetAllSkillsQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Skill> skills = _repository.GetAll();
        var dtoList = skills.Select(skill => new SkillDto
        {
            Id = skill.Id,
            Name = skill.Name,
            Value = skill.Value,
            CreateDate = skill.CreatedDate,
            UpdateDate = skill.UpdatedDate
        }).ToList();

        return new()
        {
            SkillDtos = dtoList
        };
    }
}
