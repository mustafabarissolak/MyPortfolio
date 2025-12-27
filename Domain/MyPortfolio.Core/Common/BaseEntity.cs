namespace MyPortfolio.Core.Common;

public abstract class BaseEntity : IBaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
        CreatedDate = DateTime.Now;
    }
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
