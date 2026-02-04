using Microsoft.EntityFrameworkCore;
using MovieManager.Models;
using MovieManager.Utils;

namespace MovieManager;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register services
        builder.Services.AddControllers();

        builder.Services.AddDbContext<MovieDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // var dbURL = builder.Configuration["Movies:ConnectionStrings"];
            options.UseNpgsql(connectionString);
        });

        var app = builder.Build();

        if (app.Environment.IsProduction())
        {
            app.UseHttpsRedirection();
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // SEED DATABASE
        await app.SeedDatabaseAsync();
        app.MapControllers();

        app.Run();
    }
}
