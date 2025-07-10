

using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.InterFaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}