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
    
    // Create
    [HttpPost("/create-user")]
    [Authorize(Roles = "admin")]
    public User createUser([FromBody] CreateUserRequestForm form) {
        Console.WriteLine("Here 1!!!");
        return _userService.createUser(form);
    }
    
    // Uppdate
    [HttpPost("restore-user/{login}")]
    [Authorize(Roles = "admin")]
    public void restoreUser([FromRoute] string login) {
        _userService.restoreUser(login);
    }

    // Read
    [HttpGet("/get-all-active-users")]
    [Authorize(Roles = "admin")]
    public List<User> GetAllActiveUsers() {
        return _userService.getAllActiveUsers();
    }

    [HttpGet("/get-user/{login}")]
    [Authorize(Roles = "admin")]
    public User getUser([FromRoute] string login) {
        return _userService.getUserByLogin(login);
    }

    [HttpGet("/get-user-greather-than/{age}")]
    [Authorize(Roles = "admin")]
    public List<User> getUsersGreatherThan([FromRoute] int age) {
        return _userService.getAllUsersGreatherThen(age);
    }

    [HttpDelete("/delete-user/{login}")]
    [Authorize(Roles = "admin")]
    public void deleteUser([FromRoute] string login) {
        _userService.deleteUser(login);
    }

    [HttpDelete("/delete-user-soft/{login}")]
    [Authorize(Roles = "admin")]    
    public void deleteUserSoft([FromRoute] string login) {
        string currentLogin = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        _userService.deleteUserSoft(login, currentLogin);
    }
}