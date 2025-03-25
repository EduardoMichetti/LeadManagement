namespace LeadManagement.Exceptions.ExceptionsBase;
public class NotFoundException : LeadManagementException
{
    public NotFoundException(string message) : base(message)
    {
    }
}

