using BuberDinner.Domain.Entites;

namespace BuberDinner.Application.Common.InterFaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}