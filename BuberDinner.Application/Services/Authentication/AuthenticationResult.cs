using BuberDinner.Domain.Entites;

namespace BuberDinner.Application.Authentication
{
    public record AuthenticationResult( 
        User User,
        string Token
    );
}