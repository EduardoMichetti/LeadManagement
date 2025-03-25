﻿namespace LeadManagement.Exceptions.ExceptionsBase;
public class ErrorOnValidationException : LeadManagementException
{
    public IList<string> ErrorMessages { get; set; }

    public ErrorOnValidationException(IList<string> errorMessages) : base(string.Empty)
    {
        ErrorMessages = errorMessages;
    }
}
