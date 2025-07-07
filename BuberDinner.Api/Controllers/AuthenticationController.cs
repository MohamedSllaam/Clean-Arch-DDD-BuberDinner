using System.Threading.Tasks;
using BuberDinner.Api.Filters;
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.Api.Controllers;

[Route("auth")]
//[ErrorHandlingExceptionFilter]
public class AuthenticationController : ApiController
{
 private readonly ISender mediator;

 public AuthenticationController(ISender mediator)
    {
   this.mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
         RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        ErrorOr<AuthenticationResult>  authenticationResult = await mediator.Send(command);

return authenticationResult.MatchFirst(
            result => Ok(MapAuthResult(result)),
             firtError => Problem(statusCode: StatusCodes.Status409Conflict, 
                     title: firtError.Description)
        );
        // if (authenticationResult.IsSuccess)
        // {
        //     var response = MapAuthResult(authenticationResult.Value);
        //     return Ok(response);
        // }
        // var error = authenticationResult.Errors.FirstOrDefault();
        // if (error is DuplicateEmailError)
        // {
        //     return Problem(
        //         statusCode: StatusCodes.Status409Conflict,
        //         title: "Email already exists");
        // }
        // return Problem();
    // return authenticationResult.Match(
        //     result => Ok(MapAuthResult(result)),
        //     error => Problem(statusCode: (int)error.StatusCode, 
        //              title: error.ErrorMessage)
        //     );

    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(
      LoginRequest request)
    {
        var query = new LoginQuery(
           request.Email,
           request.Password);
var authenticationResult =  await mediator.Send(query);
        // var authenticationResult = authenticationService.Login(
        //     request.Email, request.Password);
            
if(authenticationResult.IsError && authenticationResult.FirstError== Domain.Common.Errors.Errors.Authentication.InvalidCredentials)  
        {
            
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authenticationResult.FirstError.Description);  
        }

        return authenticationResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
        // Login logic goes here
        
    }
    

 private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token
        );
    }
}
