using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models;

class User : EntityBase
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public required string Email {get; set;}

    public required string Password {get; set;}

    [MinLength(3,ErrorMessage = "Full name must be at least 3 characters long")]
    public required string FullName {get; set;}

    [Required]
    public int RoleId {get; set;}

    [Required]
    public required byte[] PasswordHash { get; set; }
    
    [Required]
    public required byte[] PasswordSalt { get; set; }
}
