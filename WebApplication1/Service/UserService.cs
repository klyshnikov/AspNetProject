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

    public List<User> getAllUsers() {
        return _userRepository.getAllUsers();
    }
}