namespace MovieManager.Models;

public class MovieCast : EntityBase
{
    public Guid MovieId { get; set; }
    public Guid CastId { get; set; }

    // The role that the Cast member played in a movie eg "Wolverine" for the Cast "Hugh Jackman"
    public string CharacterName { get; set; } = string.Empty;
    public int Order { get; set; }  // For ordering cast members
    
    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public Cast Cast { get; set; } = null!;
}