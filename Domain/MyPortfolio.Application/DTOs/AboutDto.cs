namespace MyPortfolio.Application.DTOs;

public class AboutDto : BaseDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Field { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
}
