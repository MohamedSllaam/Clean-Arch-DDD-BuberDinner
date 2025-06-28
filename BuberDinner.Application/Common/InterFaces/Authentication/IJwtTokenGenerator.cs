namespace BuberDinner.Application.Common.InterFaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId,  string firstName, string lastName);
    }
}