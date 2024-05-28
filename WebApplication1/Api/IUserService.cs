using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Api;

public interface IUserService {
    User createUser(CreateUserRequestForm form);

    User changeNameOrGenderOrBirthday(String originalLogin, String name, Genders gender, DateTime birthDate);

    User changePassword(string originalLogin, string password);
}