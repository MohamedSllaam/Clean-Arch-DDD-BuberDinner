using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters
{
    public class ErrorHandlingExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.Result = new ObjectResult(new
            {
                error = "An error occurred while processing your request.",
                message = exception.Message,
                stackTrace = exception.StackTrace
            })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ContentTypes = { "application/json" }
            };
            context.ExceptionHandled = true;
        }
    }
}