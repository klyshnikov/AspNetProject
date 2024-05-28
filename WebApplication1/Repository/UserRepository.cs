using WebApplication1.Api;
using WebApplication1.Models;

namespace WebApplication1.Repository;

public class UserRepository : IUserRepository {
    private List<User> users = new List<User>();
    
    
    public void addUser(User user) {
        users = users.Where(u => u.Login != user.Login).ToList();
        users.Append(user);
    }

    public User findByLogin(string login) {
        return users.Find(u => u.Login == login);
    }
}