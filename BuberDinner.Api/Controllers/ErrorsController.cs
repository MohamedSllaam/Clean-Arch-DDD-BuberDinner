using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        // var (statusCode, title) = exception switch
        // {
        //     DuplicateEmailException => ((int)StatusCodes.Status409Conflict, "Email already exists"),
        //     _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
        // };
          var (statusCode, title) = exception switch
        {
            IServiceException serviceException  => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
        };
       // return Problem(title: exception?.Message, statusCode: 400);
        return Problem(title: title, statusCode: statusCode);
        
       // return Problem();
    }
}
