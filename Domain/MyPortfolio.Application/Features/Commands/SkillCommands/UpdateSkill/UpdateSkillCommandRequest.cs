using MediatR;

namespace MyPortfolio.Application.Features.Commands.SkillCommand.UpdateSkill;

public class UpdateSkillCommandRequest : IRequest<UpdateSkillCommandResponse>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public int? Value { get; set; }
}
