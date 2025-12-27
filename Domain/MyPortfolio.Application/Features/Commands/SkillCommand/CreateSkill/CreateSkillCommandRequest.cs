using MediatR;

namespace MyPortfolio.Application.Features.Commands.SkillCommand.CreateSkill;

public class CreateSkillCommandRequest : IRequest<CreateSkillCommandResponse>
{
    public string? Name { get; set; }
    public int? Value { get; set; }
}

