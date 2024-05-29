using WebApplication1.Models;

namespace WebApplication1.Api;

public interface IUserRepository {
    void AddUser(User user);

    User FindByLogin(String login);

    List<User> GetAllUsers();

    void DeleteUser(string login);
}