using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.InterFaces.Authentication;
using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Domain.Entites;
using FluentResults;


namespace BuberDinner.Application.Authentication
{
 public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository _userRepository) : IAuthenticationService
 {
    

  public AuthenticationResult Login(string email, string password)
        {
            // Check if the user exists
           if( _userRepository.GetUserByEmail(email) is  not  User user)
            {
                throw new ArgumentException($"User with email {email} does not exist.");
            }
            // Validate the password is correct
            if(user.Password != password)
            {
                throw new ArgumentException("Invalid password.");
            }
            // Here you would typically generate a JWT token or similar for authentication.
            var token = jwtTokenGenerator.GenerateToken(user);    
            
             return new AuthenticationResult(
             user,
        token
          );
        }

  public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
  {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                // throw new DuplicateEmailException();
                // throw new ArgumentException($"User with email {email} already exists.");        
                //    return new DuplicateEmailError();
  
                return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });  
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