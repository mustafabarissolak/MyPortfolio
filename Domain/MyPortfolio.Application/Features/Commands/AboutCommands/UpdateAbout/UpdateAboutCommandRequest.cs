using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Application.Features.Commands.AboutCommands.UpdateAbout;

public class UpdateAboutCommandRequest : IRequest<UpdateAboutCommandResponse>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Field { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? File { get; set; }
}
