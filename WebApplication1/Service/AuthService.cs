using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Api;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Service;

public class AuthService : IAuthService {
    private IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public string RegistrateUser(string login, string password, string roleName) {
        
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, login),
                                    new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)
        };
        var token = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string tokenString = handler.WriteToken(token);
        
        //paramet.httpContext.Response.Cookies.Append("token", tokenString);
        _userRepository.AddUser(new User(login, password, roleName));

        return tokenString;
        
    }

    public string FindTocken(string name, string password) {
        User user = _userRepository.FindByLogin(name);
        if (user.Password != password) {
            throw new IncorrectLoginOrPasswordException(
                "Incorrect login or password");
        }
        else {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            
            var token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string tokenString = handler.WriteToken(token);

            return tokenString;
        }
    }
}