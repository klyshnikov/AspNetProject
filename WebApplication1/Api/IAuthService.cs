namespace WebApplication1.Api;

public interface IAuthService {
    string registrateUser(string name, string password, string roleName);
    
    string findTocken(string name, string password);
}