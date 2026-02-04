namespace MovieManager.Models;

public sealed class Movie : EntityBase
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public DateTimeOffset ReleaseDate { get; set; }
    public double Rating { get; set; }
    public required string Description {get; set;}
    public required string AgeRating {get; set;}
    public required string ImageUrl {get; set;}
    public required string AddedBy {get; set;}
    public DateTimeOffset CreatedAt { get; set; }
    public bool Verified { get; set; }
}