namespace LeadManagement.Domain.Entities;
public enum LeadStatus
{
    Pending = 0,
    Approved = 1,
    Rejected = 2,
    Done = 3
}
public class Lead : EntityBase
{
    //NOTE - Os dados do contato poderiam estar em uma entidade separada, mas para simplificar, vamos manter tudo em uma entidade só
    public string ContactFirstName { get; set; } = string.Empty;
    public string ContactFullName { get; set; } = string.Empty;
    public string ContactPhoneNumber { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public string Suburb { get; set; } = string.Empty;
    //NOTE - Categoria poderia estar em uma entidade separada, mas para simplificar, vamos manter tudo em uma entidade só
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public LeadStatus Status { get; set; } = LeadStatus.Pending;
}
