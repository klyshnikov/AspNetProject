namespace WebApplication1.Api;

public interface IAuthService {
    string RegistrateUser(string name, string password, string roleName);
    
    string FindTocken(string name, string password);
}