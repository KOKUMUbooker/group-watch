using Microsoft.Extensions.DependencyInjection;
using MovieManager.Models;

namespace MovieManager.Utils;

public static class SeedExtensions
{
    public static async Task SeedDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MovieAppDbContext>();
        await DbInitializer.SeedAsync(dbContext);
    }
}
