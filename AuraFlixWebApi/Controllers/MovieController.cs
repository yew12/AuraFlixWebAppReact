using AuraFlixWebApi.Data;
using AuraFlixWebApi.DTOs;
using AuraFlixWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuraFlixWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{

    private readonly MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }

    // A simple in-memory list of movies (replace this with actual data source, e.g., database)
    private static List<Movie> _movies = new List<Movie>
    {
        new Movie { MovieId = 1, Title = "Inception", Rating = 2.4 },
        new Movie { MovieId = 2, Title = "The Dark Knight", Rating = 3.5},
        new Movie { MovieId = 3, Title = "Interstellar", Rating = 5 }
    };

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }

    [HttpGet("{movieId}")]
    public async Task<ActionResult<MovieDetailsDTO>> GetMovie(int movieId)
    {
        var movie = await _context.Movies
                    .Where(m => m.MovieId == movieId) // grab the movie by the movieId param
                    .Include(m => m.Cast) // include the movie's FK Cast item
                        .ThenInclude(mc => mc.Actor) // then go deeper and grab the actors related to the Cast Table
                    .Select(m => new MovieDetailsDTO // Now, select, from that list specific data only we want to display
                    {
                        Id = m.MovieId,
                        Title = m.Title!,
                        Description = m.Description!,
                        Tagline = m.Tagline!,
                        Rating = m.Rating,
                        TotalRatings = m.TotalRatings,
                        ReleaseDate = m.ReleaseDate,
                        Cast = m.Cast.Select(c => new MovieActorDTO
                        {
                            ActorId = c.Actor.Id,
                            ActorName = c.Actor.Name,
                            Role = c.Role
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

        if (movie == null)
        {
            return NotFound();
        }
        
        return Ok(movie);
    }


}