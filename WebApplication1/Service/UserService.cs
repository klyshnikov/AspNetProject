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

    public User createUser(CreateUserRequestForm form) {
        Console.WriteLine("Here 2!!!");
        DateTime birthDayFormat = new DateTime(form.birthDay.Year, form.birthDay.Month, form.birthDay.Day);
        User user = new User(form.login, form.password, form.name, (Genders) form.gender, birthDayFormat, form.role);
        _userRepository.addUser(user);
        Console.WriteLine(_userRepository.getAllUsers().Count);
        return user;
    }

    public User changeNameOrGenderOrBirthday(string originalLogin, string name, Genders gender, DateTime birthDate) {
        User originalUser = _userRepository.findByLogin(originalLogin);
        originalUser.Name = name;
        originalUser.Gender = gender;
        originalUser.Bithday = birthDate;
        _userRepository.addUser(originalUser);
        return originalUser;
    }

    public User changePassword(string originalLogin, string password) {
        User originalUser = _userRepository.findByLogin(originalLogin);
        originalUser.Password = password;
        _userRepository.addUser(originalUser);
        return originalUser;
    }

    public User changeLogin(string userLogin, string login) {
        User originalUser = _userRepository.findByLogin(userLogin);
        originalUser.Login = login;
        _userRepository.addUser(originalUser);
        return originalUser;
    }

    public User getUserByLogin(string login) {
        return _userRepository.findByLogin(login);
    }

    public List<User> getAllUsers() {
        return _userRepository.getAllUsers();
    }

    public List<User> getAllActiveUsers() {
        List<User> currentActiveUsers = getAllUsers().Where(user => user.RevokedOn == null).ToList();
        currentActiveUsers.Sort(delegate(User u1, User u2)
            { return u1.CreatedOn.CompareTo(u2.CreatedOn); });
        return currentActiveUsers;
    }

    public List<User> getAllUsersGreatherThen(int age) {
        return getAllUsers().Where(user =>
            (((DateTime.Now - user.Bithday)).Days / 365) >= age).ToList();
    }

    public void deleteUser(string login) {
        _userRepository.deleteUser(login);
    }

    public void deleteUserSoft(string login, string revokedBy) {
        User user = getUserByLogin(login);
        user.RevokedOn = DateTime.Now;
        user.RevokedBy = revokedBy;
        _userRepository.addUser(user);
    }

    public void restoreUser(string login) {
        User user = getUserByLogin(login);
        user.RevokedOn = null;
        _userRepository.addUser(user);
    }
}