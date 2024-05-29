using System.Numerics;
using WebApplication1.Api;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Service;

public class UserService : IUserService {
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public User CreateUser(CreateUserRequestForm form) {
        DateTime birthDayFormat = new DateTime(form.birthDay.Year, form.birthDay.Month, form.birthDay.Day);
        User user = new User(form.login, form.password, form.name, (Genders) form.gender, birthDayFormat, form.role);
        _userRepository.AddUser(user);
        return user;
    }

    public User ChangeNameOrGenderOrBirthday(string originalLogin, string name, Genders gender, DateTime birthDate) {
        User originalUser = _userRepository.FindByLogin(originalLogin);
        originalUser.Name = name;
        originalUser.Gender = gender;
        originalUser.Bithday = birthDate;
        _userRepository.AddUser(originalUser);
        return originalUser;
    }

    public User ChangePassword(string originalLogin, string password) {
        User originalUser = _userRepository.FindByLogin(originalLogin);
        originalUser.Password = password;
        _userRepository.AddUser(originalUser);
        return originalUser;
    }

    public User ChangeLogin(string userLogin, string login) {
        User originalUser = _userRepository.FindByLogin(userLogin);
        originalUser.Login = login;
        _userRepository.AddUser(originalUser);
        return originalUser;
    }

    public User GetUserByLogin(string login) {
        return _userRepository.FindByLogin(login);
    }

    public List<User> GetAllUsers() {
        return _userRepository.GetAllUsers();
    }

    public List<User> GetAllActiveUsers() {
        List<User> currentActiveUsers = GetAllUsers().Where(user => user.RevokedOn == null).ToList();
        currentActiveUsers.Sort(delegate(User u1, User u2)
            { return u1.CreatedOn.CompareTo(u2.CreatedOn); });
        return currentActiveUsers;
    }

    public List<User> GetAllUsersGreatherThen(int age) {
        return GetAllUsers().Where(user =>
            (((DateTime.Now - user.Bithday)).Days / 365) >= age).ToList();
    }

    public void DeleteUser(string login) {
        _userRepository.DeleteUser(login);
    }

    public void DeleteUserSoft(string login, string revokedBy) {
        User user = GetUserByLogin(login);
        user.RevokedOn = DateTime.Now;
        user.RevokedBy = revokedBy;
        _userRepository.AddUser(user);
    }

    public void RestoreUser(string login) {
        User user = GetUserByLogin(login);
        user.RevokedOn = null;
        _userRepository.AddUser(user);
    }

    public void CheckUserForRevokeOn(string login) {
        if (GetUserByLogin(login).RevokedOn != null) {
            throw new Exception();
        }
    }
}