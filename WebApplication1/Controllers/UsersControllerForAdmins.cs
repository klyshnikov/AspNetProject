using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Api;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1;

[ApiController]
[Route("admin")]
public class UsersControllerForAdmins : ControllerBase {
    private IUserService _userService;

    public UsersControllerForAdmins(IUserService userService) {
        _userService = userService;
    }

    // Create
    [HttpPost("/create-user")]
    [Authorize(Roles = "admin")]
    public User createUser([FromBody] CreateUserRequestForm form) {
        Console.WriteLine("Here 1!!!");
        return _userService.createUser(form);
    }
}