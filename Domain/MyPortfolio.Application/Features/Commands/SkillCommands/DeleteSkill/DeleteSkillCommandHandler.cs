using MediatR;
using MyPortfolio.Application.Repositories.SkillRepositores;

namespace MyPortfolio.Application.Features.Commands.SkillCommand.DeleteSkill;

public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommandRequest, DeleteSkillCommandResponse>
{
    readonly ISkillWriteRepository _writeRepository;

    public DeleteSkillCommandHandler(ISkillWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<DeleteSkillCommandResponse> Handle(DeleteSkillCommandRequest request, CancellationToken cancellationToken)
    {
        await _writeRepository.RemoveByIdAsync(request.Id!);
        await _writeRepository.SaveAsync();
        return new();
    }
}


