namespace MovieManager.Models;

public class Cast : EntityBase {
    public required string Name {get; set;}
    public required string ImageUrl{get; set;}

    // Navigational properties
    public List<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
}