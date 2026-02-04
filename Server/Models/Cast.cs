namespace MovieManager.Models;

class Cast : EntityBase {
    public int MovieId {get; set;}
    public required string Name {get; set;}
    public required string ImageUrl{get; set;}
}