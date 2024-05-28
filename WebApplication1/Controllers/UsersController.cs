using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
    
    // Create
    [HttpPost("/create-user")]
    [Authorize(Roles = "admin")]
    public User createUser([FromBody] CreateUserRequestForm form) {
        Console.WriteLine("Here 1!!!");
        return _userService.createUser(form);
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
    [HttpPut("/change-user-password/{originalLogin}/{password}")]
    public User changePassword([FromRoute] string originalLogin, [FromRoute] string password) {
        return _userService.changePassword(originalLogin, password);
    }
}