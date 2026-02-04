using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models;

public class Review : EntityBase 
{
    [Required]
    public Guid UserId { get; private set; }

    [Required]
    public Guid MovieId { get; private set; }
    
    [Required]
    public required string Text { get; set; }
    
    // Navigation properties
    public User User { get; set; } = null!;
    public Movie Movie { get; set; } = null!;
}