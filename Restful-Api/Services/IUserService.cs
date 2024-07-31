namespace Restful_Api.Services;

public interface IUserService
{
    // Authenticate a user by username and password
    bool Authenticate(string username, string password);
}