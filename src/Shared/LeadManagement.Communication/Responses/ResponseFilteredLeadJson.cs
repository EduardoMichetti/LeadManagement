namespace LeadManagement.Communication.Responses;
public class ResponseFilteredLeadJson
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public required string ContactFirstName { get; set; }
    public string? ContactFullName { get; set; }
    public string? ContactPhoneNumber { get; set; }
    public required string ContactEmail { get; set; }
    public string? Suburb { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal PriceAccepted { get; set; }
}
