namespace MyPortfolio.Application.DTOs;

public class ContactInfoDto : BaseDto
{
    public string? Id { get; set; }
    public string? FullName { get; set; }
    public string? Job { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Location { get; set; }
    public string? WebSite { get; set; }
}
