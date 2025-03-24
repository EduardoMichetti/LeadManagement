namespace LeadManagement.Domain.Entities;
public class EntityBase
{
    public long Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
