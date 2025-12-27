using MyPortfolio.Core.Common;

namespace MyPortfolio.Core.Entities;

public sealed class WelcomeArea : BaseEntity
{
    public string? TopHeading { get; set; }
    public string? SubHeading { get; set; }
    public string? ImageUrl { get; set; }
    public string? CvUrl { get; set; }
}
