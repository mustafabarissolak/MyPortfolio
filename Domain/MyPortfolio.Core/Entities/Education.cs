using MyPortfolio.Core.Common;

namespace MyPortfolio.Core.Entities;

public sealed class Education : BaseEntity
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? University { get; set; }
    public string? Department { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
}
