using WebApplication1.Api;
using WebApplication1.Models;

namespace WebApplication1.Repository;

public class UserRepository : IUserRepository {
    private List<User> users;

    public UserRepository() {
        users = new List<User>();
    }

    public void AddUser(User user) {
        users = users.Where(u => u.Login != user.Login).ToList();
        users.Add(user);
    }

    public User FindByLogin(string login) {
        return users.Find(u => u.Login == login);
    }

    public List<User> GetAllUsers() {
        return users;
    }

    public void DeleteUser(string login) {
        users = users.Where(user => user.Login != login).ToList();
    }
}