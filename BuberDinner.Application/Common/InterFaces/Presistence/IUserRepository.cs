using BuberDinner.Domain.Entites;

namespace BuberDinner.Application.Common.InterFaces.Presistence
{
    public interface IUserRepository
    {
         User?  GetUserByEmail(string email);
         void AddUser(User user);
    }
}