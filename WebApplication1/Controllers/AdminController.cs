using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Api;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1;

[ApiController]
[Route("admin")]
public class AdminController : ControllerBase {
    private IUserService _userService;

    public AdminController(IUserService userService) {
        _userService = userService;
    }
    
    
    //Update
    [Authorize(Roles = "admin")]
    [HttpPut("/change-user-info-for-admin")]
    public User ChangeNameOrGenderOrBirthday([FromBody] ChangeForAdminRequestForm form) {
        //_userService.checkUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        return _userService.ChangeNameOrGenderOrBirthday(
            form.UserLogin,
            form.Name, 
            (Genders)form.Gender,
            new DateTime(form.BirthDate.Year, form.BirthDate.Month, form.BirthDate.Day));
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("/change-user-password/{userLogin}/{password}")]
    public User ChangePassword([FromRoute] string userLogin, [FromRoute] string password) {
        _userService.CheckUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        return _userService.ChangePassword(userLogin, password);
    }

    [Authorize(Roles = "admin")]
    [HttpPut("/change-user-login/{userLogin}/{newLogin}")]
    public User ChangeLogin([FromRoute] string userLogin, [FromRoute] string newLogin) {
        _userService.CheckUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        return _userService.ChangeLogin(userLogin, newLogin);
    }
    
    // Create
    [HttpPost("/create-user")]
    [Authorize(Roles = "admin")]
    public User CreateUser([FromBody] CreateUserRequestForm form) {
        return _userService.CreateUser(form);
    }
    
    // Uppdate
    [HttpPost("restore-user/{login}")]
    [Authorize(Roles = "admin")]
    public void RestoreUser([FromRoute] string login) {
        _userService.RestoreUser(login);
    }

    // Read
    [HttpGet("/get-all-active-users")]
    [Authorize(Roles = "admin")]
    public List<User> GetAllActiveUsers() {
        return _userService.GetAllActiveUsers();
    }

    [HttpGet("/get-user/{login}")]
    [Authorize(Roles = "admin")]
    public User GetUser([FromRoute] string login) {
        return _userService.GetUserByLogin(login);
    }

    [HttpGet("/get-user-greather-than/{age}")]
    [Authorize(Roles = "admin")]
    public List<User> GetUsersGreatherThan([FromRoute] int age) {
        return _userService.GetAllUsersGreatherThen(age);
    }

    [HttpDelete("/delete-user/{login}")]
    [Authorize(Roles = "admin")]
    public void DeleteUser([FromRoute] string login) {
        _userService.DeleteUser(login);
    }

    [HttpDelete("/delete-user-soft/{login}")]
    [Authorize(Roles = "admin")]    
    public void DeleteUserSoft([FromRoute] string login) {
        string currentLogin = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        _userService.DeleteUserSoft(login, currentLogin);
    }
}