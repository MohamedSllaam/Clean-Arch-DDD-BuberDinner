using BuberDinner.Api.Filters;
using BuberDinner.Application.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
//[ErrorHandlingExceptionFilter]
    public class AuthenticationController : ControllerBase
{
 private readonly IAuthenticationService authenticationService;


 public AuthenticationController(IAuthenticationService authenticationService )
 {
  this.authenticationService = authenticationService;

 }

 [HttpPost("register")]
    public IActionResult Register( 
      RegisterRequest request)
    {
        var authenticationResult = authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        var response = new AuthenticationResponse(
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token
        );
        // Registration logic goes here
        return Ok(response);
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
}
