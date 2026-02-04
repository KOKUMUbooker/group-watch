using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models;

class Review : EntityBase {
    [Required]
    public int UserId {get; private set;}

    [Required]
    public int MovieId {get; private set;}
    
    [Required]
    public required string Text {get; set;}
}