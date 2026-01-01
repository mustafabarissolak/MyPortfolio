using MyPortfolio.Core.Common;

namespace MyPortfolio.Core.Entities;

public class Image : BaseEntity
{
    public string? ImagePath { get; set; }

    public string? AboutId { get; set; } 
    public About? About { get; set; }

    public string? WelcomeAreaId { get; set; }
    public WelcomeArea? WelcomeArea { get; set; }
}
