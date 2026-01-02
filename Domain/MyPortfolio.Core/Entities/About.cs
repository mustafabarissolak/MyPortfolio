using MyPortfolio.Core.Common;

namespace MyPortfolio.Core.Entities;

public sealed class About : BaseEntity
{
    public string? Name { get; set; }
    public string? Field { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public Image? Image { get; set; }
}
