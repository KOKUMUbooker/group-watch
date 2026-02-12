using System.ComponentModel.DataAnnotations;

namespace FlickPickApp.DTOs;

public class UserLoginDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email provided")]
    public string Email { get; set; }

    [Required]
    public string Password {get;set;}

    [Required(ErrorMessage = "ClientId is required.")]
    public string ClientId { get; set; } = null!;
}

public class ResendVerificationDto
{
    public string Token { get; set; } = string.Empty;
}