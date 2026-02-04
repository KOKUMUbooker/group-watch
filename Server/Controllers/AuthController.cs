using Microsoft.AspNetCore.Mvc;
using MovieManager.Models;
using MovieManager.DTOs;
using Microsoft.EntityFrameworkCore;
using MovieManager.Utils;

namespace MovieManager.Controllers;

[ApiController]
[Route("/api/auth/")]
public class AuthController : ControllerBase
{
    private readonly MovieAppDbContext _context;

    public AuthController(MovieAppDbContext context)
    {
        _context = context;
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] RegisterUserDto userDetails)
    {
          // Check if the email already exists
        var userExists = await _context.Users.AnyAsync(u => u.Email == userDetails.Email);
        if (userExists) return BadRequest("Email is already in use.");

        // Create password hash and salt
        PasswordHasher.CreatePasswordHash(userDetails.Password, out byte[] passwordHash, out byte[] passwordSalt);

        // Create user entity
        var user = new User
        {
            FullName = userDetails.FullName,
            Email = userDetails.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        };

        // Add user to the database
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // For security reasons, do not return password hash and salt
        return Ok(new { Message = "User registered successfully." });
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto userDetails)
    {
        // Retrieve the user by email
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDetails.Email);
        if (user == null) return Unauthorized("Invalid email or password.");

        // Verify the password
        if (!PasswordHasher.VerifyPasswordHash(userDetails.Password, user.PasswordHash, user.PasswordSalt))
            return Unauthorized("Invalid email or password.");
       
        // TODO: Generate JWT or other token as needed
        return Ok(new { Message = "User logged in successfully." });
    }
}