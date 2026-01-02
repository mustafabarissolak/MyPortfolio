using MyPortfolio.Core.Common;

namespace MyPortfolio.Core.Entities;

public sealed class ContactInfo : BaseEntity
{
    public string? FullName { get; set; }
    public string? Job { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Location { get; set; }
    public string? WebSite { get; set; }
}