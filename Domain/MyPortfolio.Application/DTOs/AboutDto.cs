using MyPortfolio.Core.Entities;

namespace MyPortfolio.Application.DTOs;

public class AboutDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Field { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? WebSite { get; set; }
    public string? ImagePath { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public List<SocialMediaAccount>? SocialMediaAccounts { get; set; }
}
