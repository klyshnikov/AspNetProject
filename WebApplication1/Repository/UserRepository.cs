using System.Collections.Generic;
using System.Linq;
using WebApplication1.Api;
using WebApplication1.Exceptions;
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
        var user = users.Find(u => u.Login == login);
        if (user == null) {
            throw new UserNotFoundException("User not found");
        }
        return user;
    }

    public List<User> GetAllUsers() {
        return users;
    }

    public void DeleteUser(string login) {
        users = users.Where(user => user.Login != login).ToList();
    }
}