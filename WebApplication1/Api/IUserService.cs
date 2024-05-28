using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Api;

public interface IUserService {
    User createUser(CreateUserRequestForm form);

    User changeNameOrGenderOrBirthday(String originalLogin, String name, Genders gender, DateTime birthDate);

    User changePassword(string originalLogin, string password);

    User changeLogin(string userLogin, string login);

    User getUserByLogin(string login);

    List<User> getAllUsers();

    List<User> getAllActiveUsers();

    List<User> getAllUsersGreatherThen(int age);

    void deleteUser(string login);

    void deleteUserSoft(string login, string revokedBy);

    void restoreUser(string login);
}