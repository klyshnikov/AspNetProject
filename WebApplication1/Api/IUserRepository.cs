using WebApplication1.Models;

namespace WebApplication1.Api;

public interface IUserRepository {
    void addUser(User user);

    User findByLogin(String login);

    List<User> getAllUsers();

    void deleteUser(string login);
}