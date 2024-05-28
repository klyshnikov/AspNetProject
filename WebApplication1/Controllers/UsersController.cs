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
    [HttpGet("/get-all")]
    [Authorize]
    public List<User> getAllUsers() {
        return _userService.getAllUsers();
    }
    
    
    // Update
    [Authorize]
    [HttpPut("/change-user-info")]
    public User changeNameOrGenderOrBirthday([FromBody] ChangeRequestForm form) {
        return _userService.changeNameOrGenderOrBirthday(
            form.OriginalLogin,
            form.Name, 
            (Genders)form.Gender,
            new DateTime(form.BirthDate.Year, form.BirthDate.Month, form.BirthDate.Day));
    }

    [Authorize]
    [HttpPut("/change-user-password/{password}")]
    public User changePassword([FromRoute] string password) {
        var userLogin = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        return _userService.changePassword(userLogin, password);
    }

    [Authorize]
    [HttpPut("/change-user-login/{login}")]
    public User changeLogin([FromRoute] string login) {
        var userLogin = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        return _userService.changeLogin(userLogin, login);
    }
    
    // Read
    [Authorize]
    [HttpGet("/get-user-by-loing-and-password/{login}/{password}")]
    public User getUserByLoginAndPassword([FromRoute] string login, [FromRoute] string password) {
        User user = _userService.getUserByLogin(login);
        if (user.Password == password) {
            return user;
        }
        else {
            throw new Exception();
        }
    }


}