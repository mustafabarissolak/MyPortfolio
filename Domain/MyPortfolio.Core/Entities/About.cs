using MyPortfolio.Core.Common;

namespace MyPortfolio.Core.Entities;

public sealed class About : BaseEntity
{
    public string? Name { get; set; }
    public string? Field { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? WebSite { get; set; }
    public string? ImageUrl { get; set; }
    public List<SocialMediaAccount>? SocialMediaAccount { get; set; }
}
