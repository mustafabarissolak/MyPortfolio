using MyPortfolio.Core.Common;

namespace MyPortfolio.Core.Entities;

public sealed class Skill : BaseEntity
{
    public string? Name { get; set; }
    public int? Value { get; set; }
}
