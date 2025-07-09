using System.Threading.Tasks;
using BuberDinner.Api.Filters;
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.Api.Controllers;

[Route("auth")]
//[ErrorHandlingExceptionFilter]
public class AuthenticationController : ApiController
{
 private readonly ISender mediator;
 private readonly IMapper _mapper;


 public AuthenticationController(ISender mediator , IMapper mapper )
    {
   this.mediator = mediator;
    _mapper = mapper;
 }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
         RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authenticationResult = await mediator.Send(command);

        // return authenticationResult.MatchFirst(
        //             result => Ok(_mapper.Map<AuthenticationResponse>(result)),
        //              firtError => Problem(statusCode: StatusCodes.Status409Conflict, 
        //                      title: firtError.Description)
        //         );
      return authenticationResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors)
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
        var query = _mapper.Map<LoginQuery>(request);
        // var query = new LoginQuery(
        //     request.Email, request.Password);
        
        // var authenticationService = new AuthenticationService();
        // var authenticationResult = await authenticationService.LoginAsync(
        //     request.Email, request.Password);
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
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors)
        );
        // Login logic goes here
        
    }
    

//  private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
//     {
//         return new AuthenticationResponse(
//             result.User.Id,
//             result.User.FirstName,
//             result.User.LastName,
//             result.User.Email,
//             result.Token
//         );
//     }
}
