namespace LeadManagement.Communication.Requests
{
    public class RequestRegisterLeadJson
    {
        public string ContactFirstName { get; set; } = string.Empty;
        public string ContactFullName { get; set; } = string.Empty;
        public string ContactPhoneNumber { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string Suburb { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
