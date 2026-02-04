using Microsoft.AspNetCore.Mvc;

namespace MovieManager.Controllers;

[ApiController]
[Route("/api/auth/[controller]")]
public class AuthController:ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login()
    {
        return Ok("login");
    }

    [HttpPost("sign-up")]
    public IActionResult SignUp()
    {
        return Ok("signup");
    }
}