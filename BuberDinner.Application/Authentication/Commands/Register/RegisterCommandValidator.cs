using FluentValidation;
namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator
    : AbstractValidator<RegisterCommand>
    {

        public RegisterCommandValidator()
        {
            RuleFor(command => command.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(command => command.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(command => command.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(command => command.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(100);
        }
    }
}