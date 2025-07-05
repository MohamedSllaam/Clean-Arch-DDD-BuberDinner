using BuberDinner.Api.Filters;
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
//[ErrorHandlingExceptionFilter]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService authenticationService;


    public AuthenticationController(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;

    }

    [HttpPost("register")]
    public IActionResult Register(
         RegisterRequest request)
    {
        OneOf<AuthenticationResult, DuplicateEmailError> authenticationResult = authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

    return authenticationResult.Match(
               result => Ok(MapAuthResult(result)),
           _ => Problem(statusCode:StatusCodes.Status409Conflict ,
                title: "User with this email already exists.")
        );
       
    }


    [HttpPost("login")]
    public IActionResult Login(
      LoginRequest request)
    {
        var authenticationResult = authenticationService.Login(
            request.Email, request.Password);
        var response = new AuthenticationResponse(
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token
        );
        // Login logic goes here
        return Ok(response);
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
