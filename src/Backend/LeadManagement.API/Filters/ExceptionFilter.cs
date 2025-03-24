using System.Net;
using LeadManagement.Communication.Responses;
using LeadManagement.Exceptions;
using LeadManagement.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LeadManagement.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is LeadManagementException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowException(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException)
        {
            var exception = context.Exception as ErrorOnValidationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
        }
    }
    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//erro 500
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOWN_ERROR));
    }
}