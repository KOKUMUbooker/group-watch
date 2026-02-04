using MovieManager.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieManager.Utils;

public static class DbInitializer
{
    public static async Task SeedAsync(MovieAppDbContext context)
    {
        // Ensure database exists and migrations are applied
        // await context.Database.MigrateAsync();

        // Check if the sample movie exists
        // if (!await context.Movies.AnyAsync(m => m.Title == "Sonic the Hedgehog 3"))
        // {
        //     var movie = Movie.Create(
        //         "Sonic the Hedgehog 3",
        //         "Fantasy",
        //         new DateTimeOffset(new DateTime(2025, 1, 3), TimeSpan.Zero),
        //         7
        //     );

        //     await context.Movies.AddAsync(movie);
        //     await context.SaveChangesAsync();
        // }
    }
}
