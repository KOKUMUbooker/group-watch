using System.ComponentModel.DataAnnotations;

namespace MovieManager.DTOs;

public class RegisterUserDto
{
    [Required]
    public required string FullName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email provided")]
    public required string Email { get; set; }

    [Required]
    public required string Password {get;set;}
}