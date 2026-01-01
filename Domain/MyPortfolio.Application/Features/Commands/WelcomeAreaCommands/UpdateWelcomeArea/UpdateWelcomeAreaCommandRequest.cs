using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Application.Features.Commands.WelcomeAreaCommands.UpdateWelcomeArea;

public class UpdateWelcomeAreaCommandRequest : IRequest<UpdateWelcomeAreaCommandResponse>
{
    public string? Id { get; set; }
    public string? TopHeading { get; set; }
    public string? SubHeading { get; set; }
    public string? CvUrl { get; set; }
    public IFormFile? Cv { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? File { get; set; }
}
