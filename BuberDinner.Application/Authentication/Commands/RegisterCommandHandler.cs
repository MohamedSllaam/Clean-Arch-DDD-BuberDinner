using BuberDinner.Application.Common.InterFaces.Authentication;
using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entites;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Authentication.Common;
namespace BuberDinner.Application.Authentication.Commands
{
     
 public class RegisterCommandHandler(IJwtTokenGenerator _jwtTokenGenerator , IUserRepository _userRepository) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
        

            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                //  return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.Authentication.DuplicateEmail);
                return Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password // In a real application, you should hash the password
            };

            _userRepository.AddUser(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

             return new AuthenticationResult(
                user,
                token
            );     
        }
    }
}