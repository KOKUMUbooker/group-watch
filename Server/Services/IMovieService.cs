using System;
using System.Collections.Generic;
using System.Linq;                    // For LINQ Select
using System.Threading.Tasks;         // For Task, async/await
using MovieManager.DTOs;              // For MovieDto, CreateMovieDto, UpdateMovieDto

namespace MovieManager.Services;

public interface IMovieService
{
    Task<MovieDto> CreateMovieAsync(CreateMovieDto command);
    Task<MovieDto?> GetMovieByIdAsync(Guid id);
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    Task UpdateMovieAsync(Guid id, UpdateMovieDto command);
    Task DeleteMovieAsync(Guid id);
}