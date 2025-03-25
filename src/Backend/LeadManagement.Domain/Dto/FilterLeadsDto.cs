using LeadManagement.Domain.Enums;

namespace LeadManagement.Domain.Dto;
public record FilterLeadsDto
{
    public LeadStatus Status { get; init; }
}
