using MediatR;
using MyPortfolio.Application.Repositories.SkillRepositores;

namespace MyPortfolio.Application.Features.Commands.SkillCommand.CreateSkill;

public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommandRequest, CreateSkillCommandResponse>
{
    readonly ISkillWriteRepository _repository;

    public CreateSkillCommandHandler(ISkillWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateSkillCommandResponse> Handle(CreateSkillCommandRequest request, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(new()
        {
            Name = request.Name,
            Value = request.Value,
        });
        await _repository.SaveAsync();
        return new();
    }
}

