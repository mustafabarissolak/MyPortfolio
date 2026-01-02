namespace MyPortfolio.Application.DTOs;

public class ExperienceDto : BaseDto
{
    public string? Id { get; set; }
    public DateOnly? StartDate { get; set; } 
    public DateOnly? EndDate { get; set; }
    public string? CompanyName { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
}
