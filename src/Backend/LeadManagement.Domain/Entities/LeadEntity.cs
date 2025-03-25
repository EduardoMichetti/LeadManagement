using System.ComponentModel.DataAnnotations.Schema;
using LeadManagement.Domain.Enums;

namespace LeadManagement.Domain.Entities;

//TODO - Implementar a criação da entidade de Lead com EF
[Table("TB_LEAD")]
public class LeadEntity : EntityBase
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

    public double PriceAccepted { get; set; }
    public LeadStatus Status { get; set; } = LeadStatus.Pending;
}
