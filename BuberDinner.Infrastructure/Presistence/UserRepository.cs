using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Domain.User;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Infrastructure.Presistence
{
 public class UserRepository : IUserRepository
 {
    private readonly List<User> _users = new();

        // This is a mock implementation. In a real application, you would interact with a database.
  public void AddUser(User user)
        {
             
            _users.Add(user);   
        }

  public User? GetUserByEmail(string email)
  {
            // This is a mock implementation. In a real application, you would query a database.
       return _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));   
  }
 }
}