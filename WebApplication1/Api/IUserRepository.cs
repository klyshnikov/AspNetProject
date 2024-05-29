using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Api;

public interface IUserRepository {
    void AddUser(User user);

    User FindByLogin(string login);

    List<User> GetAllUsers();

    void DeleteUser(string login);
}