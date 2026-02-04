namespace MovieManager.Models;

public class Role : EntityBase 
{
    public int RoleValue { get; private set; }
    
    // Navigation property
    public List<User> Users { get; set; } = new List<User>();
}