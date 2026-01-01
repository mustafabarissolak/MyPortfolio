namespace MyPortfolio.Application.DTOs;

public class WelcomeAreaDto : BaseDto
{
    public string? Id { get; set; }
    public string? TopHeading { get; set; }
    public string? SubHeading { get; set; }
    public string? CvUrl { get; set; }
    public string? ImagePath { get; set; }
}
