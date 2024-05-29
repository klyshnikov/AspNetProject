using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebApplication1.Api;
using WebApplication1.Dto;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase {
    private IUserService _userService;

    public UsersController(IUserService userService) {
        _userService = userService;
    }
    
    // Show all users
    // TODO delete this
    [HttpGet("/get-all")]
    [Authorize]
    public List<User> GetAllUsers() {
        return _userService.GetAllUsers();
    }
    
    // To help - show my info
    [HttpGet("/get-my-account")]
    [Authorize]
    public User GetMyAccount() {
        return _userService.GetUserByLogin(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
    }


    // Update
    [Authorize]
    [HttpPut("/change-user-info")]
    public User ChangeNameOrGenderOrBirthday([FromBody] ChangeRequestForm form) {
        _userService.CheckUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        return _userService.ChangeNameOrGenderOrBirthday(
            HttpContext.User.FindFirst(ClaimTypes.Name).Value,
            form.Name, 
            (Genders)form.Gender,
            new DateTime(form.BirthDate.Year, form.BirthDate.Month, form.BirthDate.Day));
    }

    [Authorize]
    [HttpPut("/change-user-password/{password}")]
    public User ChangePassword([FromRoute] string password) {
        _userService.CheckUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        _userService.CheckUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        var userLogin = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        return _userService.ChangePassword(userLogin, password);
    }

    [Authorize]
    [HttpPut("/change-user-login/{login}")]
    public User ChangeLogin([FromRoute] string login) {
        _userService.CheckUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        _userService.CheckUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        var userLogin = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        return _userService.ChangeLogin(userLogin, login);
    }
    
    // Read
    [Authorize]
    [HttpGet("/get-user-by-loing-and-password/{login}/{password}")]
    public User GetUserByLoginAndPassword([FromRoute] string login, [FromRoute] string password) {
        _userService.CheckUserForRevokeOn(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
        User user = _userService.GetUserByLogin(login);
        if (user.Password == password) {
            return user;
        }
        else {
            throw new IncorrectLoginOrPasswordException("Incorrect login or password");
        }
    }


}