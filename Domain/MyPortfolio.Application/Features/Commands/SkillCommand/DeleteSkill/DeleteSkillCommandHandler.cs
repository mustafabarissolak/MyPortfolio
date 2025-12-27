using MediatR;
using MyPortfolio.Application.Repositories.SkillRepositores;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.Features.Commands.SkillCommand.DeleteSkill;

public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommandRequest, DeleteSkillCommandResponse>
{
    readonly ISkillWriteRepository _writeRepository;
    readonly ISkillReadRepository _readRepository;

    public DeleteSkillCommandHandler(ISkillWriteRepository writeRepository, ISkillReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<DeleteSkillCommandResponse> Handle(DeleteSkillCommandRequest request, CancellationToken cancellationToken)
    {
        Skill skill = await _readRepository.GetByIdAsync(request.Id!);
        _writeRepository.Remove(skill);
        await _writeRepository.SaveAsync();
        return new();
    }
}


