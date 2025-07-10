using BuberDinner.Application.Common.InterFaces.Authentication;
using BuberDinner.Application.Common.InterFaces.Presistence;
using ErrorOr;
using MediatR;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.User;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler(IJwtTokenGenerator _jwtTokenGenerator, IUserRepository _userRepository) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // Simulate async operation if needed
            // Check if the user exists
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
                // Alternatively, you could throw an exception or return a specific error.
                // throw new ArgumentException($"User with email {email} does not exist.");
            }
            // Validate the password is correct
            if (user.Password != request.Password)
            {
                return Errors.Authentication.InvalidCredentials;
                // throw new ArgumentException("Invalid password.");
            }
            // Here you would typically generate a JWT token or similar for authentication.
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );


        }
    }
}