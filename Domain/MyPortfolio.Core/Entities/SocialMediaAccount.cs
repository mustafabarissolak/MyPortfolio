using MyPortfolio.Core.Common;

namespace MyPortfolio.Core.Entities;

public sealed class SocialMediaAccount : BaseEntity
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? IconCode { get; set; }
}
