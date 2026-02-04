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

         // 1. MOVIE - REVIEWS (One-to-Many)
        // One Movie has many Reviews, One Review belongs to one Movie
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId)
            .OnDelete(DeleteBehavior.Cascade); // Delete reviews when movie is deleted
        
        // 2. USER - REVIEWS (One-to-Many)
        // One User has many Reviews, One Review belongs to one User
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Delete reviews when user is deleted

        // 3. ROLE - USER (One-to-Many)
        // One Role has many Users, One User belongs to one Role
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deleting role if users exist

        // 4. Many to many configuration for 
        modelBuilder.Entity<MovieCast>()
            .HasKey(mc => new { mc.MovieId, mc.CastId });
            
        modelBuilder.Entity<MovieCast>()
            .HasOne(mc => mc.Movie)
            .WithMany(m => m.MovieCasts)
            .HasForeignKey(mc => mc.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<MovieCast>()
            .HasOne(mc => mc.Cast)
            .WithMany(c => c.MovieCasts)
            .HasForeignKey(mc => mc.CastId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);

        // Configure required properties and constraints
        ConfigureEntityConstraints(modelBuilder);
        
        // Configure indexes for performance
        ConfigureIndexes(modelBuilder);
    }

      private static void ConfigureEntityConstraints(ModelBuilder modelBuilder)
    {
        // MOVIE constraints
        modelBuilder.Entity<Movie>()
            .Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(200);
            
        modelBuilder.Entity<Movie>()
            .Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(2000);
            
        modelBuilder.Entity<Movie>()
            .Property(m => m.AgeRating)
            .IsRequired()
            .HasMaxLength(10);
            
        modelBuilder.Entity<Movie>()
            .Property(m => m.Rating)
            .HasPrecision(3, 1); // e.g., 8.5
            
        // USER constraints
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
            
        modelBuilder.Entity<User>()
            .Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(100);
            
        // REVIEW constraints
        modelBuilder.Entity<Review>()
            .Property(r => r.Text)
            .IsRequired()
            .HasMaxLength(5000);
            
        // CAST constraints
        modelBuilder.Entity<Cast>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
            
        modelBuilder.Entity<Cast>()
            .Property(c => c.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);
    }
    
    private static void ConfigureIndexes(ModelBuilder modelBuilder)
    {
        // Movie indexes
        modelBuilder.Entity<Movie>()
            .HasIndex(m => m.Title);
            
        modelBuilder.Entity<Movie>()
            .HasIndex(m => m.ReleaseDate);
            
        modelBuilder.Entity<Movie>()
            .HasIndex(m => m.Rating);
            
        modelBuilder.Entity<Movie>()
            .HasIndex(m => m.Verified);
            
        // User indexes
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
        modelBuilder.Entity<User>()
            .HasIndex(u => u.RoleId);
            
        // Review indexes
        modelBuilder.Entity<Review>()
            .HasIndex(r => r.MovieId);
            
        modelBuilder.Entity<Review>()
            .HasIndex(r => r.UserId);
            
        modelBuilder.Entity<Review>()
            .HasIndex(r => new { r.MovieId, r.UserId })
            .IsUnique(); // One review per user per movie
            
        // Cast indexes
        modelBuilder.Entity<Cast>()
            .HasIndex(c => c.MovieId);
            
        modelBuilder.Entity<Cast>()
            .HasIndex(c => c.Name);
    }
}