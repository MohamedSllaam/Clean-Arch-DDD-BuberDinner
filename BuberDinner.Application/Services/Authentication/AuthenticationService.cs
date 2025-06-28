using BuberDinner.Application.Common.InterFaces.Authentication;

namespace BuberDinner.Application.Authentication
{
 public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
 {
    

  public AuthenticationResult Login(string email, string password)
        {
            // Here you would typically validate the user's credentials against a database
            // and generate a JWT token or similar for authentication.
            // For now, we will return a dummy AuthenticationResult.

            return new AuthenticationResult(
                Id: Guid.NewGuid(),
                FirstName: "John",
                LastName: "Doe",
                Email: email,
                Token: "dummy-jwt-token"
            );
        }

  public AuthenticationResult Register(string firstName, string lastName, string email, string password)
  {
            // Here you would typically create a new user in the database
            // and generate a JWT token or similar for authentication.
            // For now, we will return a dummy AuthenticationResult.
   var userId = Guid.NewGuid();
var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);   
   return new AuthenticationResult(
       Id: userId,
       FirstName: firstName,
       LastName: lastName,
       Email: email,
       Token: token
   );
  }
 }
}