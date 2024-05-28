//using Microsoft.AspNetCore.Authorization;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebApplication1.Api;
using WebApplication1.Dto;

namespace WebApplication1;

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase, UsersApi {

    private IAuthService _authService;

    public AuthController(IAuthService authService) {
        _authService = authService;
    }

    [Authorize]
    [HttpGet("/hello")]
    public string GetMethodExample() {
        return "Hello!";
    }

    [HttpPost("/registration")]
    public string registration(RegistrationRequestForm registrationRequestForm) {
        string login = registrationRequestForm.Login;
        string password = registrationRequestForm.Password;
        string role = registrationRequestForm.Role;

        return _authService.registrateUser(login, password, role);
    
    }

    [HttpPost("/login")]
    public string login(string name, string password) {

        return _authService.findTocken(name, password);
    }
    
}