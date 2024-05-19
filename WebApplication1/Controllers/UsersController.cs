using Microsoft.AspNetCore.Mvc;
using WebApplication1.Api;

namespace WebApplication1;

[Route("api")]
[ApiController]
public class UsersController : ControllerBase, UsersApi {
    
    [HttpGet]
    public string GetMethodExample() {
        return "Hello!";
    }
}