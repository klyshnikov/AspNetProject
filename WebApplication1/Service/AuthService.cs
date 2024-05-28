using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Api;

namespace WebApplication1.Service;

public class AuthService : IAuthService {
    public string registrateUser(string name, string password, string roleName) {
        
        var claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                                    new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName) };
        var token = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        string tokenString = handler.WriteToken(token);
        
        //paramet.httpContext.Response.Cookies.Append("token", tokenString);

        return tokenString;
        
    }

    public string findTocken(string name, string password) {
        return "NO";
    }
}