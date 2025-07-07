using BuberDinner.Domain.Common.Errors;
using BuberDinner.Application.Common.InterFaces.Authentication;
using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Domain.Entites;
using ErrorOr;
using FluentResults;
using BuberDinner.Application.Authentication.Common;

namespace BuberDinner.Application.Authentication
{
 public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository _userRepository) : IAuthenticationService
 {
    

  public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // Check if the user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
                // Alternatively, you could throw an exception or return a specific error.;
             //   throw new ArgumentException($"User with email {email} does not exist.");
            }
            // Validate the password is correct
            if (user.Password != password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
              //  throw new ArgumentException("Invalid password.");
            }
            // Here you would typically generate a JWT token or similar for authentication.
            var token = jwtTokenGenerator.GenerateToken(user);    
            
             return new AuthenticationResult(
             user,
        token
          );
        }

  public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
  {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                // throw new DuplicateEmailException();
                // throw new ArgumentException($"User with email {email} already exists.");        
                //    return new DuplicateEmailError();

                //   return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });  
              return  Errors.User.DuplicateEmail;
            }
            var user = new  User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password // In a real application, you should hash the password
            };

            _userRepository.AddUser(user);  

            // Here you would typically create a new user in the database
            // and generate a JWT token or similar for authentication.
            // For now, we will return a dummy AuthenticationResult.
            
var token = jwtTokenGenerator.GenerateToken(user);   
   return new AuthenticationResult(
    user,
        token
   );
  }
 }
}