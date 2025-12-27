using MediatR;
using MyPortfolio.Application.Repositories.SkillRepositores;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Commands.SkillCommand.UpdateSkill;

public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommandRequest, UpdateSkillCommandResponse>
{
    readonly ISkillWriteRepository _writeRepository;
    readonly ISkillReadRepository _readRepository;

    public UpdateSkillCommandHandler(ISkillWriteRepository writeRepository, ISkillReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<UpdateSkillCommandResponse> Handle(UpdateSkillCommandRequest request, CancellationToken cancellationToken)
    {
        Skill skill = await _readRepository.GetByIdAsync(request.Id!);

        skill.Name = request.Name;
        skill.Value = request.Value;
        skill.UpdatedDate = DateTime.Now;

        _writeRepository.Update(skill);
        await _writeRepository.SaveAsync();

        return new();
    }
}
