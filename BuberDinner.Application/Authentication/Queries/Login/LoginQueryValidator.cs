using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        
        public LoginQueryValidator()
        {
            RuleFor(query => query.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(query => query.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(100);
        }
    }
}