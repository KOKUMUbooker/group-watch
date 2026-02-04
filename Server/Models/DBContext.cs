using  Microsoft.EntityFrameworkCore;

namespace MovieManager.Models;

public class MovieAppDbContext : DbContext
{
    public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options) {
    }

    public DbSet<Movie> Movies {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Review> Reviews {get; set;}
    public DbSet<Role> Roles {get; set;}
    public DbSet<Cast> Cast {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("app");
        base.OnModelCreating(modelBuilder);
    }
}