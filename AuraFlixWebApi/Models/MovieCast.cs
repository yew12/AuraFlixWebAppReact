using System.ComponentModel.DataAnnotations.Schema;

namespace AuraFlixWebApi.Models;

public class MovieCast
{
    [Column("movie_id")]
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    [Column("actor_id")]
    public int ActorId { get; set; }
    public Actor Actor { get; set; } = null!;
    
    [Column("role")]
    public string Role { get; set; } = string.Empty;
} 