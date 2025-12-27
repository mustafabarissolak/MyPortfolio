using MediatR;

namespace MyPortfolio.Application.Features.Commands.SkillCommand.DeleteSkill;

public class DeleteSkillCommandRequest : IRequest<DeleteSkillCommandResponse>
{
    public string? Id { get; set; }
}
