using BuberDinner.Application.Common.InterFaces.Authentication;
using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.User;
namespace BuberDinner.Application.Authentication.Commands.Register
{
     
 public class RegisterCommandHandler(IJwtTokenGenerator _jwtTokenGenerator , IUserRepository _userRepository) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
             await Task.CompletedTask; // Simulate async operation if needed

            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                //  return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.Authentication.DuplicateEmail);
                return Errors.User.DuplicateEmail;
            }

            var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);

            _userRepository.AddUser(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

             return new AuthenticationResult(
                user,
                token
            );     
        }
    }
}