using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Application.Features.Commands.AboutCommands.CreateAbout;

public class CreateAboutCommandRequest : IRequest<CreateAboutCommandResponse>
{
    public string? Name { get; set; }
    public string? Field { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? WebSite { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? File { get; set; }
}
