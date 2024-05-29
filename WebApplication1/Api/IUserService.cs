using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Api;

public interface IUserService {
    User CreateUser(CreateUserRequestForm form);

    User ChangeNameOrGenderOrBirthday(String originalLogin, String name, Genders gender, DateTime birthDate);

    User ChangePassword(string originalLogin, string password);

    User ChangeLogin(string userLogin, string login);

    User GetUserByLogin(string login);

    List<User> GetAllUsers();

    List<User> GetAllActiveUsers();

    List<User> GetAllUsersGreatherThen(int age);

    void DeleteUser(string login);

    void DeleteUserSoft(string login, string revokedBy);

    void RestoreUser(string login);

    void CheckUserForRevokeOn(string login);
}