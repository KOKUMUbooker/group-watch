namespace MovieManager.Models;

public class MovieCast : EntityBase
{
    public Guid MovieId { get; set; }
    public Guid CastId { get; set; }
    
    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public Cast Cast { get; set; } = null!;
}