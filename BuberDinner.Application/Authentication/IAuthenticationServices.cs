namespace BuberDinner.Application.Authentication
{
    public interface IAuthenticationService
    {
       AuthenticationResult Register(
            string firstName,
            string lastName,
            string email,
            string password);

        AuthenticationResult Login(
            string email,
            string password);

        // Task<AuthenticationResult> RefreshTokenAsync(
        //     string token);
    }
}