using AuraFlixWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;

namespace AuraFlixWebApi.Data;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieCast> MovieCast { get; set; }
    public DbSet<Actor> Actors { get; set; }


    public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .ToTable("movies");  // This ensures the Movie class is mapped to the 'movies' table

        modelBuilder.Entity<MovieCast>()
            .ToTable("movie_cast");  
        
        // Configure composite key
        modelBuilder.Entity<MovieCast>()
            .HasKey(mc => new { mc.MovieId, mc.ActorId });

        // configure table relationships w movie
        modelBuilder.Entity<MovieCast>()
            .HasOne((mc) => mc.Movie)
            .WithMany((mc) => mc.Cast)
            .HasForeignKey((mc) => mc.MovieId);

        // configure tabel relationship w/ actor
        modelBuilder.Entity<MovieCast>()
            .HasOne((mc) => mc.Actor)
            .WithMany((a) => a.Movies)
            .HasForeignKey((mc) => mc.ActorId);
                
        modelBuilder.Entity<Actor>()
            .ToTable("actors");
    }
}