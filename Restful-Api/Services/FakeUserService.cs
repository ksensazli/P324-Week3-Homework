using Restful_Api.Models;

namespace Restful_Api.Services;

public class FakeUserService : IUserService
{
    // List of fake users
    private List<User> users = new List<User>
    {
        new User { Username = "kagan", Password = "papara" },
        new User { Username = "test", Password = "patika" }
    };

    // Authenticate a user by username and password
    public bool Authenticate(string username, string password)
    {
        return users.Any(u => u.Username == username && u.Password == password);
    }
}