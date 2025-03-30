namespace AuraFlixWebApi.DTOs;

public class MovieDetailsDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime? ReleaseDate { get; set; }
    public string? Tagline { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int TotalRatings { get; set; }
    public List<MovieActorDTO> Cast { get; set; } = new();
}