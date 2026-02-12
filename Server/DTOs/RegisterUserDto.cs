using System.ComponentModel.DataAnnotations;

namespace FlickPickApp.DTOs;

public class RegisterUserDto
{
    [Required]
    public string FullName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email provided")]
    public string Email { get; set; }

    [Required]
    public string Password {get;set;}
}